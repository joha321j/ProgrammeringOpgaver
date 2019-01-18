using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Ex28.Domain
{
    internal class Connection
    {
        private string connectionString = "Server = EALSQL1.eal.local;" +
                                          " Connection = B_DB14_2018;" +
                                          " User Id = B_STUDENT14;" +
                                          " Password = B_OPENDB14";

        public void AddPet(Pet pet)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand insertPet = new SqlCommand("InsertPet", connection)
                        { CommandType = CommandType.StoredProcedure})
                    {
                        insertPet.Parameters.Add(new SqlParameter("@PetInsertName", pet.Name));
                        insertPet.Parameters.Add(new SqlParameter("@PetInsertType", pet.Type));
                        insertPet.Parameters.Add(new SqlParameter("@PetInsertBreed", pet.Breed));
                        insertPet.Parameters.Add(new SqlParameter("@PetInsertDOB", pet.DateOfBirth));
                        insertPet.Parameters.Add(new SqlParameter("@PetInsertWeight", pet.Weight));
                        insertPet.Parameters.Add(new SqlParameter("@OwnerInsertPk", pet.OwnerId));
                        insertPet.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {

                    throw new DatabaseException(e.Message);
                }
            }
        }

        public List<Pet> GetAllPets()
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand showAllPets = new SqlCommand("SELECT * FROM PET", connection))
                    using (SqlDataReader reader = showAllPets.ExecuteReader())
                    {
                        List<Pet> petList = new List<Pet>();
                        while (reader.Read())
                        {
                            string date = !reader.IsDBNull(4) ? reader.GetDateTime(4).ToString() : "NULL";

                            Pet petToAdd = new Pet(reader.GetString(1), reader.GetString(2), reader.GetString(3),
                                date, reader.GetDouble(5), reader.GetInt32(6), reader.GetInt32(0));
                            petList.Add(petToAdd);
                        }

                        return petList;
                    }
                }
                catch (SqlException e)
                {

                    throw new DatabaseException(e.Message);
                }
            }
        }

        public void AddOwner(Owner owner)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand insertOwner = new SqlCommand("InsertPetOwner", connection)
                        { CommandType =  CommandType.StoredProcedure})
                    {
                        insertOwner.Parameters.Add(new SqlParameter("@OwnerLastName", owner.LastName));
                        insertOwner.Parameters.Add(new SqlParameter("@OwnerFirstName", owner.FirstName));
                        insertOwner.Parameters.Add(new SqlParameter("@OwnerPhone", owner.Phone));
                        insertOwner.Parameters.Add(new SqlParameter("@OwnerEmail", owner.Email));
                        insertOwner.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    throw new DatabaseException(e.Message);
                }
            }
        }

        public List<Owner> FindOwnerByEmail(string firstName, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand findOwnerByEmailCommand = new SqlCommand("GetOwnersByEmail", connection)
                        { CommandType = CommandType.StoredProcedure})
                    {
                        List<Owner> ownerList = new List<Owner>();

                        findOwnerByEmailCommand.Parameters.Add(new SqlParameter("@InputEmail", email));
                        findOwnerByEmailCommand.Parameters.Add(new SqlParameter("@InputFirstName", firstName));

                        using (SqlDataReader reader = findOwnerByEmailCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Owner owner = new Owner(reader.GetString(2), reader.GetString(1), reader.GetString(3), reader.GetString(4), reader.GetInt32(0));
                                ownerList.Add(owner);
                            }

                            return ownerList;
                        }
                    }
                }
                catch (SqlException e)
                {
                    throw new DatabaseException(e.Message);
                }
            }
        }

        public List<Owner> FindOwnerByLastName(string lastName)
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
                        List<Owner> ownerList = new List<Owner>();
                        while (reader.Read())
                        {
                            Owner owner = new Owner(reader.GetString(2), reader.GetString(1), reader.GetString(3), reader.GetString(4), reader.GetInt32(0));
                            ownerList.Add(owner);
                        }

                        return ownerList;
                    }
                }
            }
        }
    }
}