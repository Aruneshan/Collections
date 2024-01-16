using System;
using System.Collections.Generic;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        Dictionary<string, int> ages = new Dictionary<string, int>();

        Console.WriteLine("Enter names and ages (type 'done' when finished):");

        string input;
        while ((input = Console.ReadLine().ToLower()) != "done")
        {
            string[] parts = input.Split(' ');
            if (parts.Length == 2 && int.TryParse(parts[1], out int age))
            {
                ages[parts[0]] = age;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid name and age.");
            }
        }

        // Assuming you have a database table named UserAges with columns Name and Age
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=Collections;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate = true";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            foreach (var kvp in ages)
            {
                string insertQuery = $"INSERT INTO UserAges (Name, Age) VALUES ('{kvp.Key}', {kvp.Value})";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        Console.WriteLine("Entered names and ages stored in the database.");
    }
}
