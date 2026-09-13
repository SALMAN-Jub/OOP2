-- SeedData.sql
USE HotelManagementDB;
GO

-- Sample RoomTypes
IF NOT EXISTS(SELECT 1 FROM RoomTypes WHERE TypeName='Single')
INSERT INTO RoomTypes(TypeName,Description,PricePerNight,Capacity,IsActive)
VALUES('Single','Single bed room',50.00,1,1),
	  ('Double','Double bed room',80.00,2,1),
	  ('Deluxe','Deluxe room',150.00,2,1),
	  ('Suite','Suite room',250.00,4,1);
GO

-- Sample Services
IF NOT EXISTS(SELECT 1 FROM Services)
INSERT INTO Services(ServiceName,Description,Price,IsActive)
VALUES('Room Cleaning','Daily room cleaning',10.00,1),
	  ('Laundry','Clothes washing',5.00,1),
	  ('Breakfast','Buffet breakfast',8.00,1);
GO

-- Sample Staff
IF NOT EXISTS(SELECT 1 FROM Staff)
INSERT INTO Staff(FullName,Phone,Email,Position,Salary,HireDate,IsActive)
VALUES('John Doe','1234567890','jdoe@example.com','Manager',2000.00,GETDATE(),1);
GO

-- Note: Admin user will be seeded by the application initializer to ensure password hashing.
