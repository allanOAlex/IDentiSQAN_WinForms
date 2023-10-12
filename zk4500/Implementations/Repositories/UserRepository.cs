using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using zk4500.Abstractions.IRepositories;
using zk4500.Abstractions.IServices;
using zk4500.Entities;
using zk4500.Extensions;

namespace zk4500.Implementations.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfigurationService configurationService;

        public UserRepository(IConfigurationService ConfigurationService) : base()
        {
            configurationService = ConfigurationService;
        }

        public Task<User> Create(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<User>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<User>> FindByCondition(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<User> SQLCreate(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> SQLDelete(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<User>> SQLFetchPatientsForVerification()
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<User>> SQLFindAll()
        {
            string sqlQuery = string.Empty;
            try
            {
                sqlQuery = $"SELECT " +
                    $"TU.id Id, " +
                    $"TU.user_title Title, " +
                    $"TU.uname Username, " +
                    $"TU.pass Password, " +
                    $"TU.names FullName, " +
                    $"TU.email Email, " +
                    $"TU.userDepartmentID DepartmentId, " +
                    $"TU.isActive IsActive " +
                    $"FROM Promed.tbl_users TU " +
                    $"LEFT JOIN tbl_finger_prints TFP ON TU.id = TFP.patientID " +
                    $"WHERE TFP.patientID IS NULL;"; ;
                    
                List<User> userList = new List<User>();

                using (MySqlConnection connection = new MySqlConnection(await configurationService.GetConnectionString(AppExtensions.GetConnection(AppExtensions.Environment))))
                {
                    try
                    {
                        connection.Open();

                        using (MySqlCommand cmd = new MySqlCommand(sqlQuery, connection))
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        string firstName = string.Empty;
                                        string middleName = string.Empty;
                                        string otherNames = string.Empty;

                                        var fullName = reader["FullName"] as string ?? string.Empty;
                                        if (!string.IsNullOrEmpty(fullName))
                                        {
                                            string[] nameParts = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                                            if (nameParts.Length >= 1)
                                            {
                                                firstName = nameParts[0].Trim();
                                            }

                                            if (nameParts.Length >= 2)
                                            {
                                                middleName = nameParts[1].Trim();
                                            }

                                            if (nameParts.Length > 2)
                                            {
                                                for (int i = 2; i < nameParts.Length; i++)
                                                {
                                                    otherNames += nameParts[i] + " ";
                                                }
                                                otherNames = otherNames.Trim();
                                            }

                                        }

                                        var user = new User
                                        {
                                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                            Title = reader["Title"] as string ?? string.Empty,
                                            Username = reader["Username"] as string ?? string.Empty,
                                            Password = reader["Password"] as string ?? string.Empty,
                                            FullName = fullName ?? string.Empty,
                                            FirstName = firstName ?? string.Empty,
                                            MiddleName = middleName ?? string.Empty,
                                            OtherNames = otherNames ?? string.Empty,
                                            Email = reader["Email"] as string ?? string.Empty,
                                            DepartmentId = reader.GetInt32(reader.GetOrdinal("DepartmentId")),
                                            IsActive = Convert.ToInt32(reader["IsActive"]),

                                        };
                                            
                                        userList.Add(user);
                                    }
                                }

                                return userList.AsQueryable();

                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<IQueryable<User>> SQLFindByCondition(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<User> SQLFindById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<User>> SQLFindByLoginCredentials()
        {
            string sqlQuery = string.Empty;
            try
            {
                sqlQuery = $"SELECT " +
                    $"TU.id Id, " +
                    $"TU.user_title Title, " +
                    $"TU.uname Username, " +
                    $"TU.pass Password, " +
                    $"TU.names FullName, " +
                    $"TU.email Email, " +
                    $"TU.userDepartmentID DepartmentId, " +
                    $"TU.isActive IsActive, " +
                    $"TFP.fingerPrintTemplate ImageTemplate " +
                    $"FROM Promed.tbl_users TU " +
                    $"LEFT JOIN tbl_finger_prints TFP ON TU.id = TFP.patientID " +
                    $"WHERE TFP.patientID IS NOT NULL AND TFP.entityType = 2";

                List<User> userList = new List<User>();
                Dictionary<int, string> userImageTemplates = new Dictionary<int, string>();

                using (MySqlConnection connection = new MySqlConnection(await configurationService.GetConnectionString(AppExtensions.GetConnection(AppExtensions.Environment))))
                {
                    try
                    {
                        connection.Open();

                        using (MySqlCommand cmd = new MySqlCommand(sqlQuery, connection))
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        string firstName = string.Empty;
                                        string middleName = string.Empty;
                                        string otherNames = string.Empty;

                                        var fullName = reader["FullName"] as string ?? string.Empty;
                                        if (!string.IsNullOrEmpty(fullName))
                                        {
                                            string[] nameParts = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                                            if (nameParts.Length >= 1)
                                            {
                                                firstName = nameParts[0].Trim();
                                            }

                                            if (nameParts.Length >= 2)
                                            {
                                                middleName = nameParts[1].Trim();
                                            }

                                            if (nameParts.Length > 2)
                                            {
                                                for (int i = 2; i < nameParts.Length; i++)
                                                {
                                                    otherNames += nameParts[i] + " ";
                                                }
                                                otherNames = otherNames.Trim();
                                            }

                                        }

                                        var user = new User
                                        {
                                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                            Title = reader["Title"] as string ?? string.Empty,
                                            Username = reader["Username"] as string ?? string.Empty,
                                            Password = reader["Password"] as string ?? string.Empty,
                                            FullName = fullName ?? string.Empty,
                                            FirstName = firstName ?? string.Empty,
                                            MiddleName = middleName ?? string.Empty,
                                            OtherNames = otherNames ?? string.Empty,
                                            Email = reader["Email"] as string ?? string.Empty,
                                            DepartmentId = reader.GetInt32(reader.GetOrdinal("DepartmentId")),
                                            IsActive = Convert.ToInt32(reader["IsActive"]),

                                        };

                                        userList.Add(user);

                                        int userId = user.Id;
                                        string imageTemplate = reader["ImageTemplate"] as string ?? string.Empty;
                                        userImageTemplates[userId] = imageTemplate;
                                    }
                                }

                                AppExtensions.UserImageTemplates = userImageTemplates;
                                return userList.AsQueryable();

                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<User> SQLUpdate(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<User> SQLUpdateVerified(User entity)
        {
            try
            {
                string sqlQuery = $"UPDATE tbl_patient_checkin SET isFingerVerified = @isVerified " +
                    $"WHERE checkinPatientID = @patientID " +
                    $"AND checkinToDepartmentServicePointID = @departmentID ";

                int result = 0;
                using (MySqlConnection connection = new MySqlConnection(await configurationService.GetConnectionString(AppExtensions.GetConnection(AppExtensions.Environment))))
                {
                    try
                    {
                        await connection.OpenAsync();

                        using (MySqlCommand cmd = new MySqlCommand(sqlQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@isVerified", AppExtensions.BitValue);
                            cmd.Parameters.AddWithValue("@patientID", entity.Id);
                            cmd.Parameters.AddWithValue("@departmentID", AppExtensions.DepartmentId);

                            result = await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }

                AppExtensions.UpdateQueryResult = result;
                return entity;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
