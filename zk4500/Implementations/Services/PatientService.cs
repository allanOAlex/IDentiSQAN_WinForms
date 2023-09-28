using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using zk4500.Abstractions.Interfaces;
using zk4500.Abstractions.IServices;
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
                                       PhoneNumber = patient.Phone

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
                    p.Phone.Equals(fetchPatientRequest.PhoneNumber)
                
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
                            PhoneNumber = item.Phone


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
                            FirstName = item.FirstName,
                            MiddleName = item.MiddleName,
                            LastName = item.LastName,
                            IPOPNumber = item.IPOPNumber,
                            IDNumber = item.IDNumber,
                            PhoneNumber = item.Phone,



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
                var patients = await unitOfWork.PatientRepository.SQLFindAll();

                var patientsToFind = patients;

                if (!string.IsNullOrEmpty(fetchPatientRequest.FirstName))
                    patientsToFind = patients.Where(p => p.FirstName.Equals(fetchPatientRequest.FirstName));

                if (!string.IsNullOrEmpty(fetchPatientRequest.MiddleName))
                    patientsToFind = patients.Where(p => p.MiddleName.Equals(fetchPatientRequest.MiddleName));

                if (!string.IsNullOrEmpty(fetchPatientRequest.LastName))
                    patientsToFind = patients.Where(p => p.LastName.Equals(fetchPatientRequest.LastName));

                if (!string.IsNullOrEmpty(fetchPatientRequest.IPOPNumber))
                    patientsToFind = patients.Where(p => p.IPOPNumber.Equals(fetchPatientRequest.IPOPNumber));

                if (!string.IsNullOrEmpty(fetchPatientRequest.IDNumber))
                    patientsToFind = patients.Where(p => p.IDNumber.Equals(fetchPatientRequest.IDNumber));

                if (!string.IsNullOrEmpty(fetchPatientRequest.PhoneNumber))
                    patientsToFind = patients.Where(p => p.Phone.Equals(fetchPatientRequest.PhoneNumber));

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
                            PhoneNumber = item.Phone


                        };

                        patienstList.Add(listItem);
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



    }
}
