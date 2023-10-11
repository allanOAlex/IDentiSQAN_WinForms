using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zk4500.Abstractions.Interfaces;
using zk4500.Abstractions.IServices;
using zk4500.Entities;
using zk4500.Exceptions;
using zk4500.Shared.Requests;
using zk4500.Shared.Responses;

namespace zk4500.Implementations.Services
{
    public class FingerPrintService : IFingerPrintService
    {
        private readonly IUnitOfWork unitOfWork;

        public FingerPrintService(IUnitOfWork UnitOfWork)
        {
            unitOfWork = UnitOfWork;
        }

        public async Task<RegisterFingerPrintResponse> Create(RegisterFingerPrintRequest registerFingerPrintRequest)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateFingerPrintResponse> Delete(UpdateFingerPrintRequest updateFingerPrintRequest)
        {
            throw new NotImplementedException();
        }

        public Task<List<FetchFingerPrintResponse>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<FetchFingerPrintResponse> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<RegisterFingerPrintResponse> SQLCreate(RegisterFingerPrintRequest registerFingerPrintRequest)
        {
            try
            {
                IEnumerable<FingerPrint> fingerPrints = await unitOfWork.FingerPrintRepository.SQLFindAll();
                var existingFingerPrint = fingerPrints.Where(f => f.PatientId == registerFingerPrintRequest.Id);
                if (existingFingerPrint.Any())
                    throw new CreatingDuplicateException($"Duplicate Data : {registerFingerPrintRequest.Id}");

                FingerPrint fingerPrint = new FingerPrint
                {
                    PatientId = registerFingerPrintRequest.Id,
                    ImageTemplate = registerFingerPrintRequest.Image,
                    EntityType = registerFingerPrintRequest.EntityType,
                };


                var response = await unitOfWork.FingerPrintRepository.SQLCreate(fingerPrint);
                if (response.Id > 0)
                {
                    return new RegisterFingerPrintResponse { Id = response.Id, PatientId = response.PatientId, Image = response.ImageTemplate, IsActive = response.IsActive };
                }

                return new RegisterFingerPrintResponse { Id = response.Id, PatientId = response.PatientId, Image = response.ImageTemplate, IsActive = response.IsActive };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<FetchFingerPrintResponse>> SQLFindAll()
        {
            try
            {
                try
                {
                    var fingerPrintList = new List<FetchFingerPrintResponse>();
                    var response = await unitOfWork.FingerPrintRepository.SQLFindAll();
                    if (response.Any())
                    {
                        foreach (var item in response)
                        {
                            var listItem = new FetchFingerPrintResponse
                            {
                                Id = item.Id,
                                PatientId = item.PatientId,
                                ImageTemplate = item.ImageTemplate,
                                IsActive = item.IsActive

                            };

                            fingerPrintList.Add(listItem);
                        }

                        return fingerPrintList;
                    }

                    return fingerPrintList;
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

        public Task<UpdateFingerPrintResponse> Update(UpdateFingerPrintRequest updateFingerPrintRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<VerifyFingerPrintResponse> Verify(VerifyFingerPrintRequest verifyFingerPrintRequest)
        {
            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }

            throw new NotImplementedException();
        }


    }
}
