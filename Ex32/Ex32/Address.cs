using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex32
{
    class Address
    {
        private static string connectionString =
            "Server=EALSQL1.eal.local; SERVER = Ex31Klinik; User Id = B_STUDENT30; Password = B_OPENDB30;";

        public void InsertAddress(string street, string houseNr, string zipCode)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand checkIfCityZipCodeExistsCommand = new SqlCommand("SELECT COUNT(PostNr, Bynavn) FROM PostNrBy WHERE PostNr = @zipCode");
                checkIfCityZipCodeExistsCommand.Parameters.AddWithValue("@zipCode", zipCode);
                int cityCount = (int) checkIfCityZipCodeExistsCommand.ExecuteScalar();

                SqlCommand addresSqlCommand = new SqlCommand("IndsætAdresse", connection);
                addresSqlCommand.CommandType = CommandType.StoredProcedure;
                addresSqlCommand.Parameters.AddWithValue("@Gade", street);
                addresSqlCommand.Parameters.AddWithValue("@HusNr", houseNr);
                addresSqlCommand.Parameters.AddWithValue("@PostNr", zipCode);



                if (cityCount < 1)
                {
                    string city = getCityName();
                    SqlCommand cityZipCodeCommand = new SqlCommand("INSERT INTO PostNrBy (PostNr, Bynavn) VALUES (@ZipCode, @City)");
                    cityZipCodeCommand.Parameters.AddWithValue("@ZipCode", zipCode);
                    cityZipCodeCommand.Parameters.AddWithValue("@City", city);
                }

                 addresSqlCommand.ExecuteNonQuery();
            }
 

        }

        private string getCityName()
        {
            Console.WriteLine("I need a city name, you shit.");
            return Console.ReadLine();
        }
    }
}

