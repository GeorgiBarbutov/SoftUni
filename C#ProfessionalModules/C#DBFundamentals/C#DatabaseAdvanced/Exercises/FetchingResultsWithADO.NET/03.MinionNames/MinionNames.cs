using System;
using System.Data.SqlClient;

namespace _03.MinionNames
{
    class MinionNames
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=COMP14415\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            using (sqlConnection)
            {
                int villainId = int.Parse(Console.ReadLine());
                string villainName = GetVillainName(sqlConnection, villainId);

                if (villainName != null)
                {
                    SqlDataReader sqlDataReader = GetResultSet(sqlConnection, villainId);

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine(String.Concat(sqlDataReader["RowNumber"], ". ", sqlDataReader["Name"], " ", sqlDataReader["Age"]));
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Villain: {villainName}");
                        Console.WriteLine("(no minions)");
                    }
                }
                else
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                }
            }

            sqlConnection.Close();
        }

        private static SqlDataReader GetResultSet(SqlConnection sqlConnection, int villainId)
        {
            string sqlCommandText2 = "SELECT ROW_NUMBER() OVER(ORDER BY m.Name) AS [RowNumber], m.Name, m.Age " +
                                                           "FROM Villains AS v " +
                                                      "LEFT JOIN MinionsVillains AS mv " +
                                                             "ON v.Id = mv.VillainId " +
                                                      "LEFT JOIN Minions AS m " +
                                                             "ON m.Id = mv.MinionId " +
                                                          "WHERE v.Id = @Id";

            SqlCommand sqlCommand2 = new SqlCommand(sqlCommandText2, sqlConnection);
            sqlCommand2.Parameters.AddWithValue("@Id", villainId);

            SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
            return sqlDataReader;
        }

        private static string GetVillainName(SqlConnection sqlConnection, int villainId)
        {
            string sqlCommandText1 = "SELECT v.Name " +
                                       "FROM Villains AS v " +
                                      "WHERE v.Id = @Id";

            SqlCommand sqlCommand1 = new SqlCommand(sqlCommandText1, sqlConnection);
            sqlCommand1.Parameters.AddWithValue("@Id", villainId);

            string villainName = (string)sqlCommand1.ExecuteScalar();
            return villainName;
        }
    }
}
