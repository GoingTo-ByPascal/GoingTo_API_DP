﻿
using GoingTo_API_DP.Domain.Model.Accounts;
using GoingTo_API_DP.Domain.Repositories;
using GoingTo_API_DP.Domain.Repositories.Accounts;
using GoingTo_API_DP.Domain.Services.Accounts;
using GoingTo_API_DP.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoingTo_API_DP.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public readonly IUnitOfWork _unitOfWork;
        
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }
        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch(Exception ex) 
            {
                return new UserResponse($"An error ocurred while saving the user: { ex.Message}");
            }
        }
        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            var existingUser = await _userRepository.FindById(id);
            if (existingUser == null)
                return new UserResponse("User not found");
            existingUser.Email = user.Email;
            try
            {
                _userRepository.Update(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch(Exception ex)
            {
                return new UserResponse($"An error ocured while updating the user {ex.Message}");
            }
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingUser = await _userRepository.FindById(id);
            if (existingUser == null)
                return new UserResponse("User not found");
            try 
            {
                _userRepository.Remove(existingUser);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(existingUser);
            }
            catch(Exception ex) 
            {
                return new UserResponse($"An error ocurred while deleting user {ex.Message}");
            }
        }
        
        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var existingUser = await _userRepository.FindById(id);
            if (existingUser == null)
                return new UserResponse("User not found");
            return new UserResponse(existingUser);
        }

    }
}
