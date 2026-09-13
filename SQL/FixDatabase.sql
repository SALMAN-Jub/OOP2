-- FixDatabase.sql
-- Repairs corrupted character encodings, fixes invalid reservation dates,
-- updates stored procedures, and creates performance indexes.

USE HotelManagementDB;
GO

-- 1. Fix corrupted Staff records (StaffId 7 - 11)
UPDATE Staff 
SET FullName = 'Rajib Khan', Position = 'Manager' 
WHERE StaffId = 7 OR Email = 'rajib.khan@hotel.bd';

UPDATE Staff 
SET FullName = 'Sumaiya Akhtar', Position = 'Receptionist' 
WHERE StaffId = 8 OR Email = 'sumaiya.akhtar@hotel.bd';

UPDATE Staff 
SET FullName = 'Hasan Ali', Position = 'Housekeeping' 
WHERE StaffId = 9 OR Email = 'hasan.ali@hotel.bd';

UPDATE Staff 
SET FullName = 'Lina Yasmin', Position = 'Chef' 
WHERE StaffId = 10 OR Email = 'lina.yasmin@hotel.bd';

UPDATE Staff 
SET FullName = 'Biplob Ghosh', Position = 'IT Support' 
WHERE StaffId = 11 OR Email = 'biplab.ghosh@hotel.bd';
GO

-- 2. Clean up corrupted Services and insert standard hotel services
-- Remove corrupted services that have no order history
DELETE FROM Services 
WHERE ServiceId >= 4 
  AND ServiceId NOT IN (SELECT DISTINCT ServiceId FROM ServiceOrders);

-- Insert standard services if they don't already exist
IF NOT EXISTS (SELECT 1 FROM Services WHERE ServiceName = 'Airport Shuttle')
BEGIN
    INSERT INTO Services (ServiceName, Description, Price, IsActive)
    VALUES ('Airport Shuttle', 'Airport pickup and drop-off service', 25.00, 1);
END

IF NOT EXISTS (SELECT 1 FROM Services WHERE ServiceName = 'In-Room Dining')
BEGIN
    INSERT INTO Services (ServiceName, Description, Price, IsActive)
    VALUES ('In-Room Dining', 'Food and beverage delivered directly to room', 15.00, 1);
END

IF NOT EXISTS (SELECT 1 FROM Services WHERE ServiceName = 'Spa & Massage')
BEGIN
    INSERT INTO Services (ServiceName, Description, Price, IsActive)
    VALUES ('Spa & Massage', 'Full relaxation spa and massage therapy', 40.00, 1);
END

IF NOT EXISTS (SELECT 1 FROM Services WHERE ServiceName = 'High-Speed Wi-Fi')
BEGIN
    INSERT INTO Services (ServiceName, Description, Price, IsActive)
    VALUES ('High-Speed Wi-Fi', 'Premium high-speed internet pass', 5.00, 1);
END

IF NOT EXISTS (SELECT 1 FROM Services WHERE ServiceName = 'Mini Bar')
BEGIN
    INSERT INTO Services (ServiceName, Description, Price, IsActive)
    VALUES ('Mini Bar', 'In-room snacks, soda, and beverages', 20.00, 1);
END
GO

-- 3. Fix 0-night reservation durations in Reservations table
UPDATE Reservations
SET ExpectedCheckOutDate = DATEADD(DAY, 2, CheckInDate)
WHERE ExpectedCheckOutDate <= CheckInDate;
GO

-- 4. Clean up and format Guests table
UPDATE Guests
SET FullName = 'Abul Hossain', Address = 'Dhaka, Bangladesh', NationalId = '19902691234567'
WHERE GuestId = 1 AND (Address IS NULL OR Address = '');

UPDATE Guests
SET FullName = 'Fatima Begum', Address = 'Chittagong, Bangladesh', NationalId = '19922697654321'
WHERE GuestId = 2 AND (Address IS NULL OR Address = '');

UPDATE Guests
SET FullName = 'Karim Saheb', Address = 'Sylhet, Bangladesh', NationalId = '19882695554321'
WHERE GuestId = 3 AND (Address IS NULL OR Address = '');
GO

-- 5. Update CheckRoomAvailability stored procedure
IF OBJECT_ID('dbo.CheckRoomAvailability') IS NOT NULL
    DROP PROCEDURE dbo.CheckRoomAvailability;
GO

CREATE PROCEDURE dbo.CheckRoomAvailability
    @RoomTypeId INT = NULL,
    @CheckIn DATE,
    @CheckOut DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT r.RoomId, r.RoomNumber, rt.TypeName, rt.PricePerNight
    FROM Rooms r
    JOIN RoomTypes rt ON r.RoomTypeId = rt.RoomTypeId
    WHERE (@RoomTypeId IS NULL OR @RoomTypeId = 0 OR r.RoomTypeId = @RoomTypeId)
      AND (r.Status IS NULL OR r.Status NOT IN ('Maintenance'))
      AND r.RoomId NOT IN (
          SELECT RoomId 
          FROM Reservations
          WHERE NOT (ExpectedCheckOutDate <= @CheckIn OR CheckInDate >= @CheckOut)
            AND Status IN ('Pending', 'Confirmed', 'CheckedIn', 'Booked')
      );
END
GO

-- 6. Add non-clustered performance indexes
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Reservations_Room_Dates' AND object_id = OBJECT_ID('Reservations'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_Reservations_Room_Dates 
    ON Reservations(RoomId, CheckInDate, ExpectedCheckOutDate, Status);
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Reservations_GuestId' AND object_id = OBJECT_ID('Reservations'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_Reservations_GuestId 
    ON Reservations(GuestId);
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Rooms_RoomTypeId_Status' AND object_id = OBJECT_ID('Rooms'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_Rooms_RoomTypeId_Status 
    ON Rooms(RoomTypeId, Status);
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_ServiceOrders_ReservationId' AND object_id = OBJECT_ID('ServiceOrders'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_ServiceOrders_ReservationId 
    ON ServiceOrders(ReservationId);
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Payments_ReservationId' AND object_id = OBJECT_ID('Payments'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_Payments_ReservationId 
    ON Payments(ReservationId);
END
GO

PRINT 'HotelManagementDB repaired and optimized successfully!';
GO
