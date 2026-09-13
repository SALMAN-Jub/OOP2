-- SeedBangladeshData.sql
-- Add realistic Bangladesh hotel data
USE HotelManagementDB;
GO

-- Add Bangladeshi Guests if not exist
IF NOT EXISTS(SELECT 1 FROM Guests WHERE Phone='01700123456')
BEGIN
  SET XACT_ABORT ON;

  INSERT INTO Guests(FullName,Phone,Email,Address,CreatedAt)
  VALUES
	('Abul Hossain','01700123456','abul.hosen@email.com','Dhaka, Bangladesh',GETDATE()),
	('Fatima Begum','01711234567','fatima.begum@email.com','Chittagong, Bangladesh',GETDATE()),
	('Karim Saheb','01755789012','karim.saheb@email.com','Sylhet, Bangladesh',GETDATE()),
	('Rahima Akhtar','01812345678','rahima.akhtar@email.com','Rajshahi, Bangladesh',GETDATE()),
	('Nasir Uddin','01923456789','nasir.uddin@email.com','Khulna, Bangladesh',GETDATE()),
	('Ayesha Khatun','01634567890','ayesha.khatun@email.com','Dhaka, Bangladesh',GETDATE()),
	('Salim Ahmed','01745678901','salim.ahmed@email.com','Narayanganj, Bangladesh',GETDATE()),
	('Nurjahan Bibi','01856789012','nurjahan.bibi@email.com','Gazipur, Bangladesh',GETDATE());

  PRINT CONCAT('Guests rows inserted: ', @@ROWCOUNT);
END
GO

-- Add Bangladeshi Staff
IF NOT EXISTS(SELECT 1 FROM Staff WHERE Email='rajib.khan@hotel.bd')
BEGIN
  INSERT INTO Staff(FullName,Phone,Email,Position,Salary,HireDate,IsActive)
  VALUES
	('Rajib Khan','01700001111','rajib.khan@hotel.bd','Manager',35000.00,'2023-01-15',1),
	('Sumaiya Akhtar','01700002222','sumaiya.akhtar@hotel.bd','Receptionist',15000.00,'2023-02-20',1),
	('Hasan Ali','01700003333','hasan.ali@hotel.bd','Housekeeping',12000.00,'2023-03-10',1),
	('Lina Yasmin','01700004444','lina.yasmin@hotel.bd','Chef',20000.00,'2023-01-05',1),
	('Biplob Ghosh','01700005555','biplab.ghosh@hotel.bd','IT Support',18000.00,'2023-04-01',1);
END
GO
GO

-- Add Bangladeshi RoomTypes (if not already exist)
IF NOT EXISTS(SELECT 1 FROM RoomTypes WHERE TypeName='Single')
BEGIN
  INSERT INTO RoomTypes(TypeName,Description,PricePerNight,Capacity,IsActive)
  VALUES
	('Single','Single room',3500.00,1,1),
	('Double','Double room',5500.00,2,1),
	('Deluxe','Deluxe room - with air conditioning',8000.00,2,1),
	('Suite','Suite room - premium amenities',12000.00,4,1);
END
GO
GO

-- Add Bangladeshi Services
IF NOT EXISTS(SELECT 1 FROM Services WHERE ServiceName='Room Cleaning')
BEGIN
  INSERT INTO Services(ServiceName,Description,Price,IsActive)
  VALUES
	('Room Cleaning','Daily room cleaning service',500.00,1),
	('Laundry','Laundry service',300.00,1),
	('Breakfast','Buffet breakfast',400.00,1),
	('Room Service','In-room food service',200.00,1),
	('Wi-Fi','High-speed internet',250.00,1);
END
GO
GO

-- Add Sample Rooms (if not exist)
IF NOT EXISTS(SELECT 1 FROM Rooms WHERE RoomNumber='101')
BEGIN
  DECLARE @SingleTypeId INT, @DoubleTypeId INT, @DeluxeTypeId INT;
  SELECT @SingleTypeId = RoomTypeId FROM RoomTypes WHERE TypeName='Single';
  SELECT @DoubleTypeId = RoomTypeId FROM RoomTypes WHERE TypeName='Double';
  SELECT @DeluxeTypeId = RoomTypeId FROM RoomTypes WHERE TypeName='Deluxe';

  SET XACT_ABORT ON;
  INSERT INTO Rooms(RoomNumber,RoomTypeId,FloorNumber,Status,Description)
  VALUES
	('101',@SingleTypeId,1,'Available',''),
	('102',@SingleTypeId,1,'Available',''),
	('103',@DoubleTypeId,1,'Available',''),
	('104',@DoubleTypeId,1,'Available',''),
	('201',@DeluxeTypeId,2,'Available',''),
	('202',@DeluxeTypeId,2,'Available',''),
	('203',@DoubleTypeId,2,'Available',''),
	('204',@SingleTypeId,2,'Available',''),
	('301',@SingleTypeId,3,'Available',''),
	('302',@DoubleTypeId,3,'Available','');
  PRINT CONCAT('Rooms rows inserted: ', @@ROWCOUNT);
END
GO

-- Add Sample Reservations (today and future dates)
IF NOT EXISTS(SELECT 1 FROM Reservations)
BEGIN
  DECLARE @GuestId1 INT, @GuestId2 INT, @GuestId3 INT, @RoomId1 INT, @RoomId2 INT, @RoomId3 INT;

  SELECT TOP 1 @GuestId1 = GuestId FROM Guests ORDER BY GuestId;
  SELECT TOP 1 @GuestId2 = GuestId FROM Guests WHERE GuestId != @GuestId1 ORDER BY GuestId;
  SELECT TOP 1 @GuestId3 = GuestId FROM Guests WHERE GuestId NOT IN (@GuestId1, @GuestId2) ORDER BY GuestId;

  SELECT TOP 1 @RoomId1 = RoomId FROM Rooms ORDER BY RoomId;
  SELECT TOP 1 @RoomId2 = RoomId FROM Rooms WHERE RoomId != @RoomId1 ORDER BY RoomId;
  SELECT TOP 1 @RoomId3 = RoomId FROM Rooms WHERE RoomId NOT IN (@RoomId1, @RoomId2) ORDER BY RoomId;

  INSERT INTO Reservations(GuestId,RoomId,BookingDate,CheckInDate,ExpectedCheckOutDate,NumberOfGuests,Status,SpecialRequest,CreatedBy)
  VALUES
	(@GuestId1, @RoomId1, GETDATE(), CAST(GETDATE() AS DATE), CAST(DATEADD(DAY,3,GETDATE()) AS DATE), 1, 'Confirmed', '', NULL),
	(@GuestId2, @RoomId2, GETDATE(), CAST(DATEADD(DAY,5,GETDATE()) AS DATE), CAST(DATEADD(DAY,7,GETDATE()) AS DATE), 1, 'Confirmed', '', NULL),
	(@GuestId3, @RoomId3, GETDATE(), CAST(DATEADD(DAY,10,GETDATE()) AS DATE), CAST(DATEADD(DAY,12,GETDATE()) AS DATE), 1, 'Pending', '', NULL);
	PRINT CONCAT('Reservations rows inserted: ', @@ROWCOUNT);
END
GO

PRINT 'Bangladesh hotel data seeded successfully!';
