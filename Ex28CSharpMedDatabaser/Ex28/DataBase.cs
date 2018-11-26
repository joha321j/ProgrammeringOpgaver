using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Ex28
{
    enum InsertPetVariables
    {
        PetName,
        PetType,
        PetBreed,
        PetDateOfBirth,
        PetWeight,
        OwnerId
    }

    enum InsertOwnerVariables
    {
        OwnerLastName,
        OwnerFirstName,
        OwnerPhone,
        OwnerEmail
    }
    public class Database
    {
        private string connectionString = "Server = EALSQL1.eal.local;" +
                                          " Database = B_DB14_2018;" +
                                          " User Id = B_STUDENT14;" +
                                          " Password = B_OPENDB14";

        public void AddPet(string petName, string petType, string petBreed, DateTime petDateOfBirth, double petWeight, int ownerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand insertPet = new SqlCommand("InsertPet", connection)
                        { CommandType = CommandType.StoredProcedure})
                    {
                        insertPet.Parameters.Add(new SqlParameter("@PetInsertName", petName));
                        insertPet.Parameters.Add(new SqlParameter("@PetInsertType", petType));
                        insertPet.Parameters.Add(new SqlParameter("@PetInsertBreed", petBreed));
                        insertPet.Parameters.Add(new SqlParameter("@PetInsertDOB", petDateOfBirth));
                        insertPet.Parameters.Add(new SqlParameter("@PetInsertWeight", petWeight));
                        insertPet.Parameters.Add(new SqlParameter("@OwnerInsertPk", ownerId));
                        insertPet.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Shit is fucked! " + e.Message);
                }
            }
        }

        public void ShowAllPets()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand showAllPets = new SqlCommand("SELECT * FROM PET", connection))
                    using (SqlDataReader reader = showAllPets.ExecuteReader())
                    {
                        string date;
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(4))
                            {
                                date = reader.GetDateTime(4).ToString();
                            }
                            else
                            {
                                date = "NULL";
                            }
                            Console.WriteLine("PetID: {0} PetName: {1} PetType: {2} PetBreed: {3} PetDOB: {4} PetWeight: {5} OwnerID: {6}",
                                              reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), date, reader.GetDecimal(5), reader.GetInt32(6));
                        }

                        Console.ReadKey();
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Shit is uber fucked! " + e.Message);
                }
            }
        }

        public void AddOwner(string ownerFirstName, string ownerLastName, string ownerPhone, string ownerEmail = "NULL")
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand insertOwner = new SqlCommand("InsertPetOwner", connection)
                        { CommandType =  CommandType.StoredProcedure})
                    {
                        insertOwner.Parameters.Add(new SqlParameter("@OwnerLastName", ownerLastName));
                        insertOwner.Parameters.Add(new SqlParameter("@OwnerFirstName", ownerFirstName));
                        insertOwner.Parameters.Add(new SqlParameter("@OwnerPhone", ownerPhone));
                        insertOwner.Parameters.Add(new SqlParameter("@OwnerEmail", ownerEmail));
                        insertOwner.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Shit is so fucked." + e.Message);
                }
            }
        }

        public void FindOwnerByEmail(string firstName, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand findOwnerByEmailCommand = new SqlCommand("GetOwnersByEmail", connection)
                        { CommandType = CommandType.StoredProcedure})
                    {
                        findOwnerByEmailCommand.Parameters.Add(new SqlParameter("@InputEmail", email));
                        findOwnerByEmailCommand.Parameters.Add(new SqlParameter("@InputFirstName", firstName));
                        using (SqlDataReader reader = findOwnerByEmailCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("OwnerID: {0} OwnerLastName: {1} OwnerFirstName: {2} OwnerPhone: {3} OwnerEmail: {4}"
                                    , reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                            }

                            Console.ReadKey();
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Shit is quite fucked" + e.Message);
                }
            }
        }

        public void FindOwnerByLastName(string lastName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand findOwnerByLastNameCommand = new SqlCommand("GetOwnersByLastName", connection)
                    { CommandType = CommandType.StoredProcedure})
                {
                    findOwnerByLastNameCommand.Parameters.Add(new SqlParameter("@OwnersLastName", lastName));
                    using (SqlDataReader reader = findOwnerByLastNameCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("OwnerID: {0} OwnerLastName: {1} OwnerFirstName: {2} OwnerPhone: {3} OwnerEmail: {4}"
                                , reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                        }

                        Console.ReadKey();
                    }
                }
            }
        }
    }
}