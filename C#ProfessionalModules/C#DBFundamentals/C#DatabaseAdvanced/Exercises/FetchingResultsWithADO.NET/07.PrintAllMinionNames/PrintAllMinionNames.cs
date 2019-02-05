using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _07.PrintAllMinionNames
{
    class PrintAllMinionNames
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Server=COMP14415\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";

            sqlConnection.Open();

            using (sqlConnection)
            {
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;

                List<string> townNames = GetTownNames(command);

                Print(townNames);
            }

            sqlConnection.Close();
        }

        private static void Print(List<string> townNames)
        {
            int rows = townNames.Count;
            for (int i = 0; i < rows / 2; i++)
            {
                Console.WriteLine(townNames[i]);
                Console.WriteLine(townNames[rows - i - 1]);
            }
            if (rows % 2 == 1)
            {
                Console.WriteLine(townNames[rows / 2]);
            }
        }

        private static List<string> GetTownNames(SqlCommand command)
        {
            command.CommandText = "SELECT m.Name FROM Minions AS m";
            SqlDataReader dataReader = command.ExecuteReader();

            List<string> townNames = new List<string>();
            while (dataReader.Read())
            {
                townNames.Add((string)dataReader["Name"]);
            }
            dataReader.Close();
            return townNames;
        }
    }
}
