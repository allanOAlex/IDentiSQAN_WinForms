using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork UnitOfWork)
        {
            unitOfWork = UnitOfWork;   
        }

        public async Task<List<FetchUserResponse>> SQLFindAll()
        {
            try
            {
                var userList = new List<FetchUserResponse>();
                var response = await unitOfWork.UserRepository.SQLFindAll();
                if (response.Any())
                {
                    foreach (var item in response)
                    {
                        var listItem = new FetchUserResponse
                        {
                            Id = item.Id,
                            Title = item.Title,
                            Username = item.Username, 
                            Password = item.Password,
                            FirstName = item.FirstName,
                            MiddleName = item.MiddleName,
                            LastName = item.OtherNames,
                            DepartmentId = item.DepartmentId,
                            IsActive = item.IsActive,

                        };

                        userList.Add(listItem);
                    }

                    return userList;
                }

                return userList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ApiResponse<FetchUserResponse>> SQLFindByCondition(FetchUserRequest fetchUserRequest)
        {
            try
            {
                var userList = new List<FetchUserResponse>();
                var user = new FetchUserResponse();
                StringBuilder stringBuilder = new StringBuilder();
                var users = await unitOfWork.UserRepository.SQLFindAll();
                var usersToFind = users.DefaultIfEmpty();

                if (!string.IsNullOrEmpty(fetchUserRequest.Username))
                    usersToFind = users.Where(p => p.Username.IndexOf(fetchUserRequest.Username, StringComparison.OrdinalIgnoreCase) >= 0).DefaultIfEmpty();

                if (!string.IsNullOrEmpty(fetchUserRequest.FullName))
                    usersToFind = users.Where(p => p.FullName.IndexOf(fetchUserRequest.FullName, StringComparison.OrdinalIgnoreCase) >= 0).DefaultIfEmpty();

                if (!string.IsNullOrEmpty(fetchUserRequest.PhoneNumber))
                    usersToFind = users.Where(p => p.PhoneNumber.IndexOf(fetchUserRequest.PhoneNumber, StringComparison.OrdinalIgnoreCase) >= 0).DefaultIfEmpty();

                if (usersToFind.Any())
                {
                    if (usersToFind.Count() > 1)
                    {
                        foreach (var item in usersToFind)
                        {
                            user = new FetchUserResponse
                            {
                                Id = item.Id, 
                                Title = item.Title,
                                Username = item.Username,
                                Password = item.Password,
                                FirstName = item.FirstName,
                                MiddleName = item.MiddleName,
                                LastName = item.OtherNames,
                                DepartmentId = item.DepartmentId,
                                IsActive = item.IsActive
                            };

                            userList.Add(user);
                        }
                    }
                    else
                    {
                        user = new FetchUserResponse
                        {
                            Id = usersToFind.FirstOrDefault().Id,
                            Title = usersToFind.FirstOrDefault().Title,
                            Username = usersToFind.FirstOrDefault().Username,
                            Password = usersToFind.FirstOrDefault().Password,
                            FirstName = usersToFind.FirstOrDefault().FirstName,
                            MiddleName = usersToFind.FirstOrDefault().MiddleName,
                            LastName = usersToFind.FirstOrDefault().OtherNames,
                            DepartmentId = usersToFind.FirstOrDefault().DepartmentId,
                            IsActive = usersToFind.FirstOrDefault().IsActive
                        };

                        userList.Add(user);
                    }

                    return new ApiResponse<FetchUserResponse> { Successful = true, Message = "", Datas = userList };
                }

                return new ApiResponse<FetchUserResponse> { Successful = false, Message = "No records found", Data = new FetchUserResponse() };

            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message.ToString());
                throw;
            }
        }

        public async Task<ApiResponse<FetchUserResponse>> SQLFindByLoginCredentials(FetchUserRequest fetchUserRequest)
        {
            try
            {
                var userList = new List<FetchUserResponse>();
                var user = new FetchUserResponse();
                StringBuilder stringBuilder = new StringBuilder();
                var users = await unitOfWork.UserRepository.SQLFindByLoginCredentials();
                var usersToFind = users.DefaultIfEmpty();

                if (!string.IsNullOrEmpty(fetchUserRequest.Username) && !string.IsNullOrEmpty(fetchUserRequest.FullName) && !string.IsNullOrEmpty(fetchUserRequest.PhoneNumber) && !string.IsNullOrEmpty(fetchUserRequest.Password))
                    usersToFind = users.Where(p => 
                    p.Username.IndexOf(fetchUserRequest.Username, StringComparison.OrdinalIgnoreCase) >= 0 &&
                    p.FullName.IndexOf(fetchUserRequest.FullName, StringComparison.OrdinalIgnoreCase) >= 0 &&
                    p.PhoneNumber.IndexOf(fetchUserRequest.PhoneNumber, StringComparison.OrdinalIgnoreCase) >= 0 &&
                    p.Password.IndexOf(fetchUserRequest.Password, StringComparison.OrdinalIgnoreCase) >= 0
                    
                    ).DefaultIfEmpty();

                usersToFind = users.Where(p =>
                    p.Username.IndexOf(fetchUserRequest.Username, StringComparison.OrdinalIgnoreCase) >= 0 &&
                    p.Password.IndexOf(fetchUserRequest.Password, StringComparison.OrdinalIgnoreCase) >= 0

                    ).DefaultIfEmpty();

                if (usersToFind.Any())
                {
                    if (usersToFind.Count() > 1)
                    {
                        foreach (var item in usersToFind)
                        {
                            user = new FetchUserResponse
                            {
                                Id = item.Id,
                                Title = item.Title,
                                Username = item.Username,
                                Password = item.Password,
                                FirstName = item.FirstName,
                                MiddleName = item.MiddleName,
                                LastName = item.OtherNames,
                                DepartmentId = item.DepartmentId,
                                IsActive = item.IsActive,
                                ImageTemplate = AppExtensions.UserImageTemplates.ContainsKey(item.Id) ? AppExtensions.UserImageTemplates[item.Id] : string.Empty

                            };

                            userList.Add(user);
                        }
                    }
                    else
                    {
                        user = new FetchUserResponse
                        {
                            Id = usersToFind.FirstOrDefault().Id,
                            Title = usersToFind.FirstOrDefault().Title,
                            Username = usersToFind.FirstOrDefault().Username,
                            Password = usersToFind.FirstOrDefault().Password,
                            FirstName = usersToFind.FirstOrDefault().FirstName,
                            MiddleName = usersToFind.FirstOrDefault().MiddleName,
                            LastName = usersToFind.FirstOrDefault().OtherNames,
                            DepartmentId = usersToFind.FirstOrDefault().DepartmentId,
                            IsActive = usersToFind.FirstOrDefault().IsActive,
                            ImageTemplate = AppExtensions.UserImageTemplates.ContainsKey(usersToFind.FirstOrDefault().Id) ? AppExtensions.UserImageTemplates[usersToFind.FirstOrDefault().Id] : string.Empty
                        };

                        userList.Add(user);
                    }

                    return new ApiResponse<FetchUserResponse> { Successful = true, Message = "", Datas = userList };
                }

                return new ApiResponse<FetchUserResponse> { Successful = false, Message = "User not found", Data = new FetchUserResponse() };
            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public async Task<UpdateVerifiedResponse> SQLUpdateVerified(UpdateVerifiedRequest updateVerifiedRequest)
        {
            try
            {
                AppExtensions.BitValue = updateVerifiedRequest.IsFingerVerified;
                AppExtensions.CheckInTimeStamp = DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss zzz");
                User patient = new User
                {
                    Id = updateVerifiedRequest.CheckInPatientId,
                };

                var response = await unitOfWork.UserRepository.SQLUpdateVerified(patient);
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
    }
}
