using System;
using System.Collections.Generic;
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
    public class Connection
    {
        private string connectionString = "Server = EALSQL1.eal.local;" +
                                          " Connection = B_DB14_2018;" +
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

                    throw new DatabaseException("a");
                }
            }
        }

        public List<string> GetAllPets()
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand showAllPets = new SqlCommand("SELECT * FROM PET", connection))
                    using (SqlDataReader reader = showAllPets.ExecuteReader())
                    {
                        List<string> petList = new List<string>();
                        while (reader.Read())
                        {
                            string date;
                            date = !reader.IsDBNull(4) ? reader.GetDateTime(4).ToString() : "NULL";

                            petList.Add("PetID: " + reader.GetInt32(0) +
                                        " PetName: " + reader.GetString(1) +
                                        " PetType: " + reader.GetString(2) +
                                        " PetBreed: " + reader.GetString(3) +
                                        " PetDOB: " + date +
                                        " PetWeight: " + reader.GetDecimal(5) +
                                        " OwnerID: " + reader.GetInt32(6));
                        }

                        return petList;
                    }
                }
                catch (SqlException e)
                {

                    throw new DatabaseException("a");
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

        public List<string> FindOwnerByEmail(string firstName, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand findOwnerByEmailCommand = new SqlCommand("GetOwnersByEmail", connection)
                        { CommandType = CommandType.StoredProcedure})
                    {
                        List<string> ownerList = new List<string>();

                        findOwnerByEmailCommand.Parameters.Add(new SqlParameter("@InputEmail", email));
                        findOwnerByEmailCommand.Parameters.Add(new SqlParameter("@InputFirstName", firstName));

                        using (SqlDataReader reader = findOwnerByEmailCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ownerList.Add("OwnerID: " + reader.GetInt32(0) +
                                              " OwnerLastName: " + reader.GetString(1) +
                                              " OwnerFirstName: " + reader.GetString(2) +
                                              " OwnerPhone: " + reader.GetString(3) +
                                              " OwnerEmail: " + reader.GetString(4));
                            }

                            return ownerList;
                        }
                    }
                }
                catch (SqlException e)
                {
                    throw new DatabaseException("a");
                }
            }
        }

        public List<string> FindOwnerByLastName(string lastName)
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
                        List<string> ownerList = new List<string>();
                        while (reader.Read())
                        {
                            ownerList.Add("OwnerID: " + reader.GetInt32(0) +
                                          " OwnerLastName: " + reader.GetString(1) +
                                          " OwnerFirstName: " + reader.GetString(2) +
                                          " OwnerPhone: " + reader.GetString(3) +
                                          " OwnerEmail: " + reader.GetString(4));
                        }

                        return ownerList;
                    }
                }
            }
        }
    }
}