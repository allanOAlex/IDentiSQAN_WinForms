using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using zk4500.Abstractions.IRepositories;
using zk4500.Abstractions.IServices;
using zk4500.DataContext;
using zk4500.Entities;
using zk4500.Shared.Requests;
using zk4500.Shared.Responses;

namespace zk4500.Implementations.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IConfigurationService configurationService;
        private readonly MyDBContext context;
        internal DbSet<Patient> dbSet;

        public PatientRepository(MyDBContext Context, IConfigurationService ConfigurationService) : base()
        {
            configurationService = ConfigurationService;
            context = Context;
            dbSet = context.Set<Patient>();
        }

        public Task<Patient> Create(Patient entity)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> Delete(Patient entity)
        {
            throw new NotImplementedException();

        }

        public async Task<IQueryable<Patient>> FindAll()
        {
            try
            {
                return await Task.FromResult(context.Patients.OrderByDescending(p => p.Id).AsNoTracking());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IQueryable<Patient>> FindByCondition(Expression<Func<Patient, bool>> expression)
        {
            return await Task.FromResult(dbSet.Where(expression).AsNoTracking());
        }

        public async Task<Patient> FindById(int Id)
        {
            Patient patient = new Patient();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(await configurationService.GetConnectionString("Promed")))
                {
                    try
                    {
                        connection.Open();

                        string sqlQuery = $"SELECT * FROM tbl_registered_patients where id = {Id}";
                        using (MySqlCommand cmd = new MySqlCommand(sqlQuery, connection))
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        patient = new Patient
                                        {
                                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                            FirstName = reader["FirstName"] as string,
                                            MiddleName = reader["MiddleName"] as string,
                                            LastName = reader["LastName"] as string,
                                            IPOPNumber = reader["IPOPNumber"] as string,
                                            IDNumber = reader["IDNumber"] as string,
                                            Phone = reader["PhoneNumber"] as string
                                        };

                                        return patient;
                                    }
                                }

                                connection.Close();
                                return patient;

                            }
                        }
                    }
                    catch (MySqlException)
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

        public Task<Patient> SQLCreate(Patient entity)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> SQLDelete(Patient entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<PatientForVerification>> SQLFetchPatientsForVerification()
        {
            try
            {
                string sqlQuery = "SELECT a.id Id , " +
                    "a.checkinPatientID PatientId, " +
                    "b.patientIPOPNumber IPOPNumber, " +
                    "b.patientTitle Title, " +
                    "b.firstName FirstName, " +
                    "b.middleName MiddleName, " +
                    "b.lastName LastName, " +
                    "b.patientPhone PhoneNumber, " +
                    "a.checkinToServicePointName ServicePoint " +
                    "FROM tbl_patient_checkin a JOIN tbl_registered_patients b ON b.id = a.checkinPatientID " +
                    "WHERE a.isFingerVerified = 0 AND a.checkinToDepartmentServicePointID = 2; ";

                List<PatientForVerification> patientList = new List<PatientForVerification>();

                using (MySqlConnection connection = new MySqlConnection(await configurationService.GetConnectionString("Promed")))
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
                                        var patient = new PatientForVerification
                                        {
                                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                            PatientId = reader.GetInt32(reader.GetOrdinal("PatientId")),
                                            Title = reader["Title"] as string,
                                            FirstName = reader["FirstName"] as string,
                                            MiddleName = reader["MiddleName"] as string,
                                            LastName = reader["LastName"] as string,
                                            IPOPNumber = reader["IPOPNumber"] as string,
                                            PhoneNumber = reader["PhoneNumber"] as string,
                                            ServicePointId = reader["ServicePoint"] as string

                                        };

                                        patientList.Add(patient);
                                    }
                                }

                                return patientList.AsQueryable();

                            }
                        }
                    }
                    catch (Exception ex)
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

        public async Task<IQueryable<PatientForVerification>> SQLFetchPatientsForVerificationByCondition()
        {
            try
            {
                string sqlQuery = "SELECT a.id Id , " +
                    "a.checkinPatientID PatientId, " +
                    "b.patientIPOPNumber IPOPNumber, " +
                    "b.patientTitle Title, " +
                    "b.firstName FirstName, " +
                    "b.middleName MiddleName, " +
                    "b.lastName LastName, " +
                    "b.patientPhone PhoneNumber, " +
                    "a.checkinToServicePointName ServicePoint " +
                    "FROM tbl_patient_checkin a JOIN tbl_registered_patients b ON b.id = a.checkinPatientID " +
                    "WHERE a.isFingerVerified = 0 AND a.checkinToDepartmentServicePointID = 2; ";

                List<PatientForVerification> patientList = new List<PatientForVerification>();

                using (MySqlConnection connection = new MySqlConnection(await configurationService.GetConnectionString("Promed")))
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
                                        var patient = new PatientForVerification
                                        {
                                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                            PatientId = reader.GetInt32(reader.GetOrdinal("PatientId")),
                                            Title = reader["Title"] as string,
                                            FirstName = reader["FirstName"] as string,
                                            MiddleName = reader["MiddleName"] as string,
                                            LastName = reader["LastName"] as string,
                                            IPOPNumber = reader["IPOPNumber"] as string,
                                            PhoneNumber = reader["PhoneNumber"] as string,
                                            ServicePointId = reader["ServicePoint"] as string

                                        };

                                        patientList.Add(patient);
                                    }
                                }

                                return patientList.AsQueryable();

                            }
                        }
                    }
                    catch (Exception ex)
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

        public async Task<IQueryable<Patient>> SQLFindAll()
        {
            try
            {
                string sqlQuery = $"SELECT " +
                            $"id as Id, " +
                            $"firstName as FirstName, " +
                            $"middleName as MiddleName, " +
                            $"lastName as LastName, " +
                            $"patientIPOPNumber as IPOPNumber, " +
                            $"patientIDNumber as IDNumber, " +
                            $"patientPhone as  PhoneNumber " +
                            $"FROM tbl_registered_patients ";

                List<Patient> patientList = new List<Patient>();

                using (MySqlConnection connection = new MySqlConnection(await configurationService.GetConnectionString("Promed")))
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
                                        var patient = new Patient
                                        {
                                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                            FirstName = reader["FirstName"] as string,
                                            MiddleName = reader["MiddleName"] as string,
                                            LastName = reader["LastName"] as string,
                                            IPOPNumber = reader["IPOPNumber"] as string,
                                            IDNumber = reader["IDNumber"] as string,
                                            Phone = reader["PhoneNumber"] as string
                                        };

                                        patientList.Add(patient);
                                    }
                                }

                                return patientList.AsQueryable();

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

        public async Task<IQueryable<Patient>> SQLFindByCondition(Expression<Func<Patient, bool>> expression)
        {
            try
            {
                try
                {
                    string sqlQuery = $"SELECT " +
                                $"id as Id, " +
                                $"firstName as FirstName, " +
                                $"middleName as MiddleName, " +
                                $"lastName as LastName, " +
                                $"patientIPOPNumber as IPOPNumber, " +
                                $"patientIDNumber as IDNumber, " +
                                $"patientPhone as  PhoneNumber " +
                                $"FROM tbl_registered_patients ";

                    List<Patient> patientList = new List<Patient>();

                    using (MySqlConnection connection = new MySqlConnection(await configurationService.GetConnectionString("Promed")))
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
                                        try
                                        {
                                            while (reader.Read())
                                            {
                                                try
                                                {
                                                    var patient = new Patient
                                                    {
                                                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                                        FirstName = reader["FirstName"] as string,
                                                        MiddleName = reader["MiddleName"] as string,
                                                        LastName = reader["LastName"] as string,
                                                        IPOPNumber = reader["IPOPNumber"] as string,
                                                        IDNumber = reader["IDNumber"] as string,
                                                        Phone = reader["PhoneNumber"] as string
                                                    };

                                                    patientList.Add(patient);
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

                                    return patientList.AsQueryable();

                                }
                            }
                        }
                        catch (Exception ex)
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
            catch (Exception)
            {

                throw;
            }
        }

        public Task<Patient> SQLFindById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> SQLUpdate(Patient entity)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> Update(Patient entity)
        {
            throw new NotImplementedException();
        }


    }
}
