using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using zk4500.Abstractions.Interfaces;
using zk4500.Abstractions.IServices;
using zk4500.Entities;
using zk4500.Extensions;
using zk4500.Shared.Dtos;
using zk4500.Shared.Requests;
using zk4500.Shared.Responses;

namespace zk4500.Implementations.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork unitOfWork;

        public PatientService(IUnitOfWork UnitOfWork)
        {
            unitOfWork = UnitOfWork;
        }

        public async Task<List<FetchPatientResponse>> FindAll()
        {
            try
            {
                try
                {
                    var patientList = new List<FetchPatientResponse>();
                    var patients = await unitOfWork.PatientRepository.FindAll();
                    if (patients.Any())
                    {
                        foreach (var item in patients)
                        {
                            var listItem = new FetchPatientResponse
                            {
                                Id = item.Id,
                                

                            };

                            patientList.Add(listItem);
                        }

                        return patientList;
                    }

                    return patientList;
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

        public async Task<FetchPatientResponse> GetById(int Id)
        {
            try
            {
                var patientToFind = await unitOfWork.PatientRepository.FindByCondition(e => e.Id == Id);
                if (patientToFind.Any())
                {
                    var response = from patient in patientToFind
                                   select new FetchPatientResponse
                                   {
                                       Id = patient.Id,
                                       FirstName = patient.FirstName,
                                       MiddleName = patient.MiddleName,
                                       LastName = patient.LastName,
                                       IPOPNumber = patient.IPOPNumber,
                                       IDNumber = patient.IDNumber,
                                       PhoneNumber = patient.PhoneNumber

                                   };

                    return response.FirstOrDefault();
                }

                return new FetchPatientResponse() { };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ApiResponse<FetchPatientResponse>> FindByCondition(FetchPatientRequest fetchPatientRequest)
        {
            try
            {
                var patienstList = new List<FetchPatientResponse>();
                var response = new FetchPatientResponse();

                var patientsToFind = await unitOfWork.PatientRepository.FindByCondition(p => 
                    p.Id == fetchPatientRequest.Id || 
                    p.FirstName.Equals(fetchPatientRequest.FirstName) || 
                    p.MiddleName.Equals(fetchPatientRequest.MiddleName) || 
                    p.LastName.Equals(fetchPatientRequest.LastName) ||
                    p.IPOPNumber.Equals(fetchPatientRequest.IPOPNumber) ||
                    p.IDNumber.Equals(fetchPatientRequest.IDNumber) ||
                    p.PhoneNumber.Equals(fetchPatientRequest.PhoneNumber)
                
                );

                if (patientsToFind.Any())
                {
                    foreach (var item in patientsToFind)
                    {
                        var listItem = new FetchPatientResponse
                        {
                            Id = item.Id,
                            FirstName = item.FirstName,
                            MiddleName = item.MiddleName,
                            LastName = item.LastName,
                            IPOPNumber = item.IPOPNumber,
                            IDNumber = item.IDNumber,
                            PhoneNumber = item.PhoneNumber


                        };

                        patienstList.Add(response);
                    }

                    if (patienstList.Count > 1)
                        return new ApiResponse<FetchPatientResponse> { Successful = true, Message = "", Datas = patienstList };
                     
                    return new ApiResponse<FetchPatientResponse> { Successful = true, Message = "", Datas = patienstList };
                }

                return new ApiResponse<FetchPatientResponse> { Successful = false, Message = "No records found", Data = new FetchPatientResponse() };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                throw;
            }
        }

        public Task<UpdatePatientResponse> Update(UpdatePatientRequest updatePatientRquest)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FetchPatientResponse>> SQLFindAll()
        {
            try
            {
                var patientList = new List<FetchPatientResponse>();
                var response = await unitOfWork.PatientRepository.SQLFindAll();
                if (response.Any())
                {
                    foreach (var item in response)
                    {
                        var listItem = new FetchPatientResponse
                        {
                            Id = item.Id,
                            Title = item.Title,
                            FirstName = item.FirstName,
                            MiddleName = item.MiddleName,
                            LastName = item.LastName,
                            IPOPNumber = item.IPOPNumber,
                            IDNumber = item.IDNumber,
                            PhoneNumber = item.PhoneNumber,

                        };

                        patientList.Add(listItem);
                    }

                    return patientList;
                }

                return patientList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ApiResponse<FetchPatientResponse>> SQLFindByCondition(FetchPatientRequest fetchPatientRequest)
        {
            try
            {
                var patienstList = new List<FetchPatientResponse>();
                var patient = new FetchPatientResponse();
                var patients = await unitOfWork.PatientRepository.SQLFindAll();

                var patientsToFind = patients;

                if (!string.IsNullOrEmpty(fetchPatientRequest.FirstName))
                    //patientsToFind = patients.Where(p => p.FirstName.Equals(fetchPatientRequest.FirstName, StringComparison.OrdinalIgnoreCase));
                    patientsToFind = patients.Where(p =>p.FirstName.IndexOf(fetchPatientRequest.FirstName, StringComparison.OrdinalIgnoreCase) >= 0).DefaultIfEmpty();

                if (!string.IsNullOrEmpty(fetchPatientRequest.MiddleName))
                    patientsToFind = patients.Where(p => p.MiddleName.IndexOf(fetchPatientRequest.MiddleName, StringComparison.OrdinalIgnoreCase) >= 0).DefaultIfEmpty();

                if (!string.IsNullOrEmpty(fetchPatientRequest.LastName))
                    patientsToFind = patients.Where(p => p.LastName.IndexOf(fetchPatientRequest.LastName, StringComparison.OrdinalIgnoreCase) >= 0).DefaultIfEmpty();

                if (!string.IsNullOrEmpty(fetchPatientRequest.IPOPNumber))
                    patientsToFind = patients.Where(p => p.IPOPNumber.IndexOf(fetchPatientRequest.IPOPNumber, StringComparison.OrdinalIgnoreCase) >= 0).DefaultIfEmpty();

                if (!string.IsNullOrEmpty(fetchPatientRequest.IDNumber))
                    patientsToFind = patients.Where(p => p.IDNumber.IndexOf(fetchPatientRequest.IDNumber, StringComparison.OrdinalIgnoreCase) >= 0).DefaultIfEmpty();

                if (!string.IsNullOrEmpty(fetchPatientRequest.PhoneNumber))
                    patientsToFind = patients.Where(p => p.PhoneNumber.IndexOf(fetchPatientRequest.PhoneNumber, StringComparison.OrdinalIgnoreCase) >= 0).DefaultIfEmpty();

                try
                {
                    if (patientsToFind.Any())
                    {
                        if (patientsToFind.Count() > 1)
                        {
                            foreach (var item in patientsToFind)
                            {
                                patient = new FetchPatientResponse
                                {
                                    Title = item.Title,
                                    Id = item.Id,
                                    FirstName = item.FirstName,
                                    MiddleName = item.MiddleName,
                                    LastName = item.LastName,
                                    IPOPNumber = item.IPOPNumber,
                                    IDNumber = item.IDNumber,
                                    PhoneNumber = item.PhoneNumber,
                                    ImageTemplate = item.FingerData
                                };

                                patienstList.Add(patient);
                            }
                        }
                        else
                        {
                            patient = new FetchPatientResponse
                            {
                                Title = patientsToFind.FirstOrDefault().Title,
                                Id = patientsToFind.FirstOrDefault().Id,
                                FirstName = patientsToFind.FirstOrDefault().FirstName,
                                MiddleName = patientsToFind.FirstOrDefault().MiddleName,
                                LastName = patientsToFind.FirstOrDefault().LastName,
                                IPOPNumber = patientsToFind.FirstOrDefault().IPOPNumber,
                                IDNumber = patientsToFind.FirstOrDefault().IDNumber,
                                PhoneNumber = patientsToFind.FirstOrDefault().PhoneNumber,
                                ImageTemplate = patientsToFind.FirstOrDefault().FingerData
                            };

                            patienstList.Add(patient);
                        }

                        

                        

                        if (patienstList.Count > 1)
                            return new ApiResponse<FetchPatientResponse> { Successful = true, Message = "", Datas = patienstList };

                        return new ApiResponse<FetchPatientResponse> { Successful = true, Message = "", Datas = patienstList };
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
                

                return new ApiResponse<FetchPatientResponse> { Successful = false, Message = "No records found", Data = new FetchPatientResponse() };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                throw;
            }

        }

        public async Task<UpdateVerifiedResponse> SQLUpdateVerified(UpdateVerifiedRequest updateVerifiedRequest)
        {
            try
            {
                AppExtensions.BitValue = updateVerifiedRequest.IsFingerVerified;
                AppExtensions.CheckInTimeStamp = DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss zzz");
                Patient patient = new Patient
                {
                    Id = updateVerifiedRequest.CheckInPatientId,
                };

                var response = await unitOfWork.PatientRepository.SQLUpdateVerified(patient);
                if (AppExtensions.UpdateQueryResult <= 0)
                {
                    return new UpdateVerifiedResponse
                    {
                        Id = AppExtensions.RowId,
                        CheckInPatientId = response.Id,
                        IsFingerVerified = false

                    };
                }

                return new UpdateVerifiedResponse
                {
                    Id = AppExtensions.RowId,
                    CheckInPatientId = response.Id,
                    IsFingerVerified = true

                };
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<List<FetchPatientForVerificationResponse>> SQLFetchPatientsForVerification()
        {
            try
            {
                var patientList = new List<FetchPatientForVerificationResponse>();
                var response = await unitOfWork.PatientRepository.SQLFetchPatientsForVerification();
                if (response.Any())
                {
                    foreach (var item in response)
                    {
                        var listItem = new FetchPatientForVerificationResponse
                        {
                            Id = item.Id,
                            CheckInID = item.PatientId,
                            Title = item.Title,
                            FirstName = item.FirstName,
                            MiddleName = item.MiddleName,
                            LastName = item.LastName,
                            IPOPNumber = item.IPOPNumber,
                            PhoneNumber = item.PhoneNumber,
                            ServicePointId = item.ServicePointId,
                            ImageTemplate = item.ImageTemplate,
                            IsFingerVerified = item.IsFingerVerified

                        };

                        patientList.Add(listItem);
                    }

                    return patientList;
                }

                return patientList;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
