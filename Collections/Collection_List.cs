using System;
using System.Collections.Generic;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter numbers (type 'done' when finished):");

        string input;
        while ((input = Console.ReadLine().ToLower()) != "done")
        {
            if (int.TryParse(input, out int number))
            {
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        // Assuming you have a database table named Numbers with a column named Value
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=Collections;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate = true";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            foreach (int number in numbers)
            {
                string insertQuery = $"INSERT INTO Numbers (Value) VALUES ({number})";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        Console.WriteLine("Entered numbers stored in the database.");
    }
}
