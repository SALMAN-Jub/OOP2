-- AddRoomsAndReservations.sql
USE HotelManagementDB;
GO

SET XACT_ABORT ON;

-- Add Sample Rooms
INSERT INTO Rooms(RoomNumber,RoomTypeId,FloorNumber,Status,Description)
VALUES
  ('101',1,1,'Available',''),
  ('102',1,1,'Available',''),
  ('103',2,1,'Available',''),
  ('104',2,1,'Available',''),
  ('201',3,2,'Available',''),
  ('202',3,2,'Available',''),
  ('203',2,2,'Available',''),
  ('204',1,2,'Available',''),
  ('301',1,3,'Available',''),
  ('302',2,3,'Available',''),
  ('401',4,4,'Available','');
GO

-- Add Sample Reservations
INSERT INTO Reservations(GuestId,RoomId,BookingDate,CheckInDate,ExpectedCheckOutDate,NumberOfGuests,Status,SpecialRequest,CreatedBy)
VALUES
  (1, 1, GETDATE(), CAST(GETDATE() AS DATE), CAST(DATEADD(DAY,3,GETDATE()) AS DATE), 1, 'Confirmed', '', NULL),
  (2, 3, GETDATE(), CAST(DATEADD(DAY,5,GETDATE()) AS DATE), CAST(DATEADD(DAY,7,GETDATE()) AS DATE), 1, 'Confirmed', '', NULL),
  (3, 5, GETDATE(), CAST(DATEADD(DAY,10,GETDATE()) AS DATE), CAST(DATEADD(DAY,12,GETDATE()) AS DATE), 1, 'Pending', '', NULL);
GO

PRINT CONCAT('Rooms and Reservations rows inserted: ', @@ROWCOUNT);
