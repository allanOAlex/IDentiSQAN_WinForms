using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using zk4500.Abstractions.IRepositories;
using zk4500.Abstractions.IServices;
using zk4500.DataContext;
using zk4500.Entities;
using zk4500.Extensions;
using zk4500.Shared.Requests;
using zk4500.Shared.Responses;

namespace zk4500.Implementations.Repositories
{
    public class FingerPrintRepository : IFingerPrintRepository
    {
        private readonly IConfigurationService configurationService;
        private readonly MyDBContext context;
        internal DbSet<FingerPrint> dbSet;

        public FingerPrintRepository(MyDBContext Context, IConfigurationService ConfigurationService) : base()
        {
            configurationService = ConfigurationService;
            context = Context;
            dbSet = context.Set<FingerPrint>();
        }

        public Task<FingerPrint> Create(FingerPrint entity)
        {
            throw new NotImplementedException();
        }

        public Task<FingerPrint> Delete(FingerPrint entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<FingerPrint>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<FingerPrint>> FindByCondition(Expression<Func<FingerPrint, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<FingerPrint> FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<FingerPrint> SQLCreate(FingerPrint entity)
        {
            try
            {
                string sqlQuery = $"insert into tbl_finger_prints(" +
                    $"patientID, " +
                    $"fingerPrintTemplate, " +
                    $"entityType ) " +
                    $"values('" +
                    $"{entity.PatientId}', " +
                    $"'{entity.ImageTemplate}', " +
                    $"{entity.EntityType}) ";

                using (MySqlConnection connection = new MySqlConnection(await configurationService.GetConnectionString(AppExtensions.GetConnection(AppExtensions.Environment))))
                {
                    try
                    {
                        connection.Open();

                        using (MySqlCommand cmd = new MySqlCommand(sqlQuery, connection))
                        {
                            int result = cmd.ExecuteNonQuery();

                            if (result > 0)
                            {
                                entity.Id = 1;
                                return entity;
                            }

                            return entity;
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

        public Task<FingerPrint> SQLDelete(FingerPrint entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<FingerPrint>> SQLFindAll()
        {
            try
            {
                string sqlQuery = "SELECT id Id , " +
                    "patientID PatientId, " +
                    "fingerPrintTemplate ImageTemplate, " +
                    "isActive IsActive " +
                    "FROM tbl_finger_prints ";

                List<FingerPrint> fingerPrintList = new List<FingerPrint>();

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
                                        var fingerPrint = new FingerPrint
                                        {
                                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                            PatientId = reader.GetInt32(reader.GetOrdinal("PatientId")),
                                            ImageTemplate = reader["ImageTemplate"] as string,
                                            IsActive = Convert.ToBoolean(reader["IsActive"]),

                                        };

                                        fingerPrintList.Add(fingerPrint);
                                    }
                                }

                                return fingerPrintList.AsQueryable();

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

        public Task<IQueryable<FingerPrint>> SQLFindByCondition(Expression<Func<FingerPrint, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<FingerPrint> SQLFindById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<FingerPrint> SQLUpdate(FingerPrint entity)
        {
            throw new NotImplementedException();
        }

        public Task<FingerPrint> Update(FingerPrint entity)
        {
            throw new NotImplementedException();
        }

        public Task<FingerPrint> Verify(FingerPrint fingerPrint)
        {
            throw new NotImplementedException();
        }
    }
}
