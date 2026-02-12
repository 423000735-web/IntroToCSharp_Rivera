using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        // Set Philippine Peso currency
        CultureInfo php = new CultureInfo("en-PH");

        // STRING is used for text (driver name)
        Console.Write("Enter Driver's Full Name: ");
        string driverName = Console.ReadLine();

        // DECIMAL is used for money to avoid rounding errors
        Console.Write("Enter Weekly Fuel Budget: ");
        decimal weeklyBudget = decimal.Parse(Console.ReadLine());

        // DOUBLE is used for distance because it allows decimal values
        double totalDistance = 0;

        // WHILE LOOP validates input until correct value is entered
        while (true)
        {
            Console.Write("Enter Total Distance Traveled (1.0 - 5000.0 km): ");
            totalDistance = double.Parse(Console.ReadLine());

            if (totalDistance >= 1.0 && totalDistance <= 5000.0)
                break;

            Console.WriteLine("Invalid distance! Please enter a value between 1.0 and 5000.0.");
        }

        // ARRAY stores 5 days of fuel expenses
        decimal[] fuelExpenses = new decimal[5];
        decimal totalFuelSpent = 0;

        // FOR LOOP collects daily fuel expenses
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Enter fuel expense for Day {i + 1}: ");
            fuelExpenses[i] = decimal.Parse(Console.ReadLine());

            // Accumulate total fuel cost
            totalFuelSpent += fuelExpenses[i];
        }

        // Calculate average daily expense
        decimal averageExpense = totalFuelSpent / 5;

        // Calculate fuel efficiency
        double efficiency = totalDistance / (double)totalFuelSpent;
        string efficiencyRating;

        // IF/ELSE determines efficiency rating
        if (efficiency > 15)
            efficiencyRating = "High Efficiency";
        else if (efficiency >= 10)
            efficiencyRating = "Standard Efficiency";
        else
            efficiencyRating = "Low Efficiency / Maintenance Required";

        // BOOL checks if driver stayed under budget
        bool underBudget = totalFuelSpent <= weeklyBudget;

        // ===== AUDIT REPORT =====
        Console.WriteLine("\n===== CODAC LOGISTICS AUDIT REPORT =====");
        Console.WriteLine($"Driver Name: {driverName}");

        Console.WriteLine("\n5-Day Fuel Expenses:");
        for (int i = 0; i < 5; i++)
        {
            // Display in Philippine Pesos
            Console.WriteLine($"Day {i + 1}: {fuelExpenses[i].ToString("C", php)}");
        }

        Console.WriteLine($"\nTotal Fuel Spent: {totalFuelSpent.ToString("C", php)}");
        Console.WriteLine($"Average Daily Expense: {averageExpense.ToString("C", php)}");
        Console.WriteLine($"Efficiency Rating: {efficiencyRating}");
        Console.WriteLine($"Stayed Under Budget: {underBudget}");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
