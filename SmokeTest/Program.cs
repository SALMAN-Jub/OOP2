using System;
using Hotel_Management_System.Database;
using Hotel_Management_System.Services;

class Program
{
    static void Main()
    {
        Console.WriteLine("Running smoke tests...");
        if (!DatabaseInitializer.TestConnection(out var msg))
        {
            Console.WriteLine($"DB connection failed: {msg}");
            Environment.Exit(2);
        }
        Console.WriteLine("DB connection OK");

        try
        {
            DatabaseInitializer.EnsureSeedData();
            Console.WriteLine("Seed check completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Seed failed: {ex.Message}");
            Environment.Exit(3);
        }

        var rs = new ReservationService();
        var list = rs.GetAll();
        Console.WriteLine($"Reservations found: {System.Linq.Enumerable.Count(list)}");

        // Test DatabaseConnection new helpers
        Console.WriteLine($"Current Server & DB: {DatabaseConnection.GetCurrentServerAndDatabase()}");
        if (!DatabaseConnection.TestConnection(DatabaseConnection.ConnectionString, out var errTest, out var tableCount))
        {
            Console.WriteLine($"TestConnection failed: {errTest}");
            Environment.Exit(4);
        }
        Console.WriteLine($"TestConnection OK! Tables found: {tableCount}");

        // Test invalid connection string handling
        bool invalidResult = DatabaseConnection.TestConnection("Data Source=INVALID_SERVER_XYZ;Initial Catalog=NoDb;Connect Timeout=1", out var invalidErr, out _);
        if (invalidResult)
        {
            Console.WriteLine("Expected invalid connection to fail, but it succeeded!");
            Environment.Exit(5);
        }
        Console.WriteLine($"Negative TestConnection test passed (gracefully caught: {invalidErr.Substring(0, Math.Min(40, invalidErr.Length))}...)");

        Console.WriteLine("Smoke tests completed successfully.");
    }
}
