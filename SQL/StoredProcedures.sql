-- StoredProcedures.sql
USE HotelManagementDB;
GO

-- Stored procedure example: check room availability for date range
IF OBJECT_ID('dbo.CheckRoomAvailability') IS NOT NULL
	DROP PROCEDURE dbo.CheckRoomAvailability;
GO
CREATE PROCEDURE dbo.CheckRoomAvailability
	@RoomTypeId INT,
	@CheckIn DATE,
	@CheckOut DATE
AS
BEGIN
	SET NOCOUNT ON;
	SELECT r.RoomId, r.RoomNumber
	FROM Rooms r
	WHERE r.RoomTypeId = @RoomTypeId
	  AND r.Status NOT IN ('Maintenance')
	  AND r.RoomId NOT IN (
		SELECT RoomId FROM Reservations
		WHERE NOT (ExpectedCheckOutDate <= @CheckIn OR CheckInDate >= @CheckOut)
		AND Status IN ('Pending','Confirmed','CheckedIn')
	  );
END
GO
