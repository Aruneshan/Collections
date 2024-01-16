using System;
using System.Collections.Generic;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        HashSet<string> uniqueNames = new HashSet<string>();

        Console.WriteLine("Enter names (type 'done' when finished):");

        string input;
        while ((input = Console.ReadLine().ToLower()) != "done")
        {
            uniqueNames.Add(input);
        }

        // Assuming you have a database table named UniqueNames with a column named Name
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=Collections;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate = true";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            foreach (string name in uniqueNames)
            {
                string insertQuery = $"INSERT INTO UniqueNames (Name) VALUES ('{name}')";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        Console.WriteLine("Entered unique names stored in the database.");
    }
}
