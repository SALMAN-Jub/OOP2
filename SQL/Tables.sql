-- Tables.sql
USE HotelManagementDB;
GO

-- Users
IF OBJECT_ID('Users') IS NULL
BEGIN
CREATE TABLE Users(
	UserId INT IDENTITY(1,1) PRIMARY KEY,
	Username NVARCHAR(50) UNIQUE NOT NULL,
	PasswordHash NVARCHAR(255) NOT NULL,
	FullName NVARCHAR(100),
	Role NVARCHAR(30),
	IsActive BIT DEFAULT 1,
	CreatedAt DATETIME DEFAULT GETDATE()
);
END
GO

-- Guests
IF OBJECT_ID('Guests') IS NULL
BEGIN
CREATE TABLE Guests(
	GuestId INT IDENTITY(1,1) PRIMARY KEY,
	FullName NVARCHAR(100) NOT NULL,
	Phone NVARCHAR(20) NOT NULL,
	Email NVARCHAR(100),
	Address NVARCHAR(250),
	NationalId NVARCHAR(50),
	Gender NVARCHAR(20),
	DateOfBirth DATE,
	CreatedAt DATETIME DEFAULT GETDATE()
);
END
GO

-- RoomTypes
IF OBJECT_ID('RoomTypes') IS NULL
BEGIN
CREATE TABLE RoomTypes(
	RoomTypeId INT IDENTITY(1,1) PRIMARY KEY,
	TypeName NVARCHAR(50) NOT NULL,
	Description NVARCHAR(250),
	PricePerNight DECIMAL(10,2) NOT NULL,
	Capacity INT NOT NULL,
	IsActive BIT DEFAULT 1
);
END
GO

-- Rooms
IF OBJECT_ID('Rooms') IS NULL
BEGIN
CREATE TABLE Rooms(
	RoomId INT IDENTITY(1,1) PRIMARY KEY,
	RoomNumber NVARCHAR(20) UNIQUE NOT NULL,
	RoomTypeId INT NOT NULL,
	FloorNumber INT,
	Status NVARCHAR(30) NOT NULL,
	Description NVARCHAR(250),
	CONSTRAINT FK_Room_RoomType FOREIGN KEY (RoomTypeId) REFERENCES RoomTypes(RoomTypeId)
);
END
GO

-- Reservations
IF OBJECT_ID('Reservations') IS NULL
BEGIN
CREATE TABLE Reservations(
	ReservationId INT IDENTITY(1,1) PRIMARY KEY,
	GuestId INT NOT NULL,
	RoomId INT NOT NULL,
	BookingDate DATETIME DEFAULT GETDATE(),
	CheckInDate DATE NOT NULL,
	ExpectedCheckOutDate DATE NOT NULL,
	NumberOfGuests INT NOT NULL,
	Status NVARCHAR(30) NOT NULL,
	SpecialRequest NVARCHAR(500),
	CreatedBy INT,
	CONSTRAINT FK_Res_Guest FOREIGN KEY (GuestId) REFERENCES Guests(GuestId),
	CONSTRAINT FK_Res_Room FOREIGN KEY (RoomId) REFERENCES Rooms(RoomId),
	CONSTRAINT FK_Res_User FOREIGN KEY (CreatedBy) REFERENCES Users(UserId)
);
END
GO

-- CheckIns
IF OBJECT_ID('CheckIns') IS NULL
BEGIN
CREATE TABLE CheckIns(
	CheckInId INT IDENTITY(1,1) PRIMARY KEY,
	ReservationId INT NOT NULL,
	ActualCheckIn DATETIME DEFAULT GETDATE(),
	NumberOfGuests INT,
	Notes NVARCHAR(500),
	CreatedBy INT,
	CONSTRAINT FK_CheckIn_Res FOREIGN KEY (ReservationId) REFERENCES Reservations(ReservationId)
);
END
GO

-- CheckOuts
IF OBJECT_ID('CheckOuts') IS NULL
BEGIN
CREATE TABLE CheckOuts(
	CheckOutId INT IDENTITY(1,1) PRIMARY KEY,
	ReservationId INT NOT NULL,
	ActualCheckOut DATETIME DEFAULT GETDATE(),
	TotalRoomCharge DECIMAL(10,2),
	TotalServiceCharge DECIMAL(10,2),
	Discount DECIMAL(10,2) DEFAULT 0,
	Tax DECIMAL(10,2) DEFAULT 0,
	GrandTotal DECIMAL(10,2),
	Notes NVARCHAR(500),
	CreatedBy INT,
	CONSTRAINT FK_CheckOut_Res FOREIGN KEY (ReservationId) REFERENCES Reservations(ReservationId)
);
END
GO

-- Payments
IF OBJECT_ID('Payments') IS NULL
BEGIN
CREATE TABLE Payments(
	PaymentId INT IDENTITY(1,1) PRIMARY KEY,
	ReservationId INT NOT NULL,
	Amount DECIMAL(10,2) NOT NULL,
	PaymentDate DATETIME DEFAULT GETDATE(),
	PaymentMethod NVARCHAR(30) NOT NULL,
	TransactionReference NVARCHAR(100),
	Status NVARCHAR(30) DEFAULT 'Completed',
	ReceivedBy INT,
	CONSTRAINT FK_Pay_Res FOREIGN KEY (ReservationId) REFERENCES Reservations(ReservationId)
);
END
GO

-- Staff
IF OBJECT_ID('Staff') IS NULL
BEGIN
CREATE TABLE Staff(
	StaffId INT IDENTITY(1,1) PRIMARY KEY,
	FullName NVARCHAR(100) NOT NULL,
	Phone NVARCHAR(20),
	Email NVARCHAR(100),
	Position NVARCHAR(50),
	Salary DECIMAL(10,2),
	HireDate DATE,
	IsActive BIT DEFAULT 1
);
END
GO

-- Services
IF OBJECT_ID('Services') IS NULL
BEGIN
CREATE TABLE Services(
	ServiceId INT IDENTITY(1,1) PRIMARY KEY,
	ServiceName NVARCHAR(100) NOT NULL,
	Description NVARCHAR(250),
	Price DECIMAL(10,2) NOT NULL,
	IsActive BIT DEFAULT 1
);
END
GO

-- ServiceOrders
IF OBJECT_ID('ServiceOrders') IS NULL
BEGIN
CREATE TABLE ServiceOrders(
	ServiceOrderId INT IDENTITY(1,1) PRIMARY KEY,
	ReservationId INT NOT NULL,
	ServiceId INT NOT NULL,
	Quantity INT NOT NULL,
	UnitPrice DECIMAL(10,2) NOT NULL,
	TotalPrice DECIMAL(10,2) NOT NULL,
	OrderDate DATETIME DEFAULT GETDATE(),
	Status NVARCHAR(30) DEFAULT 'Pending',
	CONSTRAINT FK_ServiceOrder_Res FOREIGN KEY (ReservationId) REFERENCES Reservations(ReservationId),
	CONSTRAINT FK_ServiceOrder_Service FOREIGN KEY (ServiceId) REFERENCES Services(ServiceId)
);
END
GO
