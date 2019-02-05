using System;
using System.Data.SqlClient;
using System.Linq;

namespace _08.IncreaseMinionAge
{
    class IncreaseMinionAge
    {
        static void Main(string[] args)
        {
            int[] minionIds = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Server=COMP14415\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";

            sqlConnection.Open();

            using (sqlConnection)
            {
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;

                for (int i = 0; i < minionIds.Length; i++)
                {
                    int minionId = minionIds[i];

                    GetNameAndAge(command, minionId, out string minionFullName, out int minionAge);

                    if (minionFullName == null)
                    {
                        continue;
                    }

                    ChangeNameAndAge(ref minionFullName, ref minionAge);
                    UpdateNameAndAge(command, minionId, minionFullName, minionAge);
                }

                PrintNameAndAge(command);
            }

            sqlConnection.Close();
        }

        private static void PrintNameAndAge(SqlCommand command)
        {
            command.CommandText = "SELECT m.Name, m.Age FROM Minions AS m";

            SqlDataReader sqlDataReader2 = command.ExecuteReader();

            while (sqlDataReader2.Read())
            {
                Console.WriteLine(String.Concat(sqlDataReader2["Name"], " ", sqlDataReader2["Age"]));
            }
            sqlDataReader2.Close();
        }

        private static void UpdateNameAndAge(SqlCommand command, int minionId, string minionFullName, int minionAge)
        {
            command.CommandText = "UPDATE Minions SET Name = @minionName , Age = @minionAge WHERE Id = @minionId";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@minionName", minionFullName);
            command.Parameters.AddWithValue("@minionAge", minionAge);
            command.Parameters.AddWithValue("@minionId", minionId);

            command.ExecuteNonQuery();
        }

        private static void ChangeNameAndAge(ref string minionFullName, ref int minionAge)
        {
            minionAge += 1;

            string[] minionNames = minionFullName.Split(" ");
            for (int j = 0; j < minionNames.Length; j++)
            {
                minionNames[j] = minionNames[j].Substring(0, 1).ToUpper() + minionNames[j].Substring(1).ToLower();
            }
            minionFullName = String.Join(" ", minionNames);
        }

        private static void GetNameAndAge(SqlCommand command, int minionId, out string minionFullName, out int minionAge)
        {
            command.CommandText = "SELECT m.Name, m.Age FROM Minions AS m WHERE m.Id = @minionId";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@minionId", minionId);

            SqlDataReader sqlDataReader = command.ExecuteReader();

            minionFullName = null;
            minionAge = 0;
            while (sqlDataReader.Read())
            {
                minionFullName = (string)sqlDataReader["Name"];
                minionAge = (int)sqlDataReader["Age"];
            }
            sqlDataReader.Close();
        }
    }
}
