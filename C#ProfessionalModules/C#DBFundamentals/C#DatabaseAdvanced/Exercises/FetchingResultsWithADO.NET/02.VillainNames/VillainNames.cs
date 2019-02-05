using System;
using System.Data.SqlClient;

namespace _02.VillainNames
{
    class VillainNames
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=COMP14415\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            using (sqlConnection)
            {
                SqlCommand sqlCommand = new SqlCommand("  SELECT v.Name, COUNT(m.Id) AS MinionCount " +
                    "                                       FROM Villains AS v " +
                    "                                       JOIN MinionsVillains AS mv " +
                    "                                         ON mv.VillainId = v.Id " +
                    "                                       JOIN Minions AS m " +
                    "                                         ON m.Id = mv.MinionId " +
                    "                                   GROUP BY v.Id, v.Name " +
                    "                                     HAVING COUNT(m.Id) > 3 " +
                    "                                   ORDER BY COUNT(m.Id) DESC", sqlConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                using (sqlDataReader)
                {
                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine(sqlDataReader["Name"] + " - " + sqlDataReader["MinionCount"]);
                    }
                }
            }

            sqlConnection.Close();
        }
    }
}
