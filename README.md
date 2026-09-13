# Hotel Management System

A desktop application built in C# (Windows Forms) for managing hotel operations, including room bookings, guest information, and billing.

## Features

- Add, update, and view guest details
- Room booking and availability management
- Check-in / check-out processing
- Billing and invoice generation
- View booking history and revenue reports

## Technologies Used

- **Language:** C#
- **Framework:** .NET (Windows Forms)
- **Database:** Microsoft SQL Server
- **IDE:** Visual Studio

## Project Structure

HotelManagementSystem/
├── Forms/ # UI forms (Login, Dashboard, Booking, etc.)
├── Models/ # Data models (Guest, Room, Booking)
├── DataAccess/ # Database connection and queries
├── HotelManagementSystem.sln
└── README.md


## Getting Started

### Prerequisites

- Visual Studio 2019 or later
- .NET Framework installed
- SQL Server (Express or full version)

### Setup

1. Clone this repository:

git clone https://github.com/SALMAN-Jub/OOP2.git

2. Open `HotelManagementSystem.sln` in Visual Studio.
3. Update the database connection string in the code to match your local SQL Server instance.
4. Run the SQL scripts (if provided) to set up the database schema.
5. Build and run the project.

## Database

The system uses a relational database with tables such as:

- `Guests` – stores guest information
- `Rooms` – stores room types and availability
- `Bookings` – stores booking and payment records

## Contributors

- [SALMAN-Jub](https://github.com/SALMAN-Jub)

## License

This project is for educational purposes as part of an OOP coursework assignment.
