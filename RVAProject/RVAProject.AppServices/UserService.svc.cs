﻿using Microsoft.IdentityModel.Tokens;
using RVAProject.Common;
using RVAProject.Common.DTOs.UserDTO;
using RVAProject.Common.Entities;
using RVAProject.Common.Repositories;
using RVAProject.Common.Repositories.Impl;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApplicationException = RVAProject.Common.ApplicationException;

namespace RVAProject.AppServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository(new LibraryDbContext());
        }

        public async Task AddUser(UserRequest userRequest)
        {

            var existingUser = await _userRepository.GetUserByUsername(userRequest.Username);

            if (existingUser != null)
            {
                throw new ApplicationException("User already exists");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = userRequest.Username,
                Password = userRequest.Password,
                FirstName = userRequest.FirstName,
                LastName = userRequest.LastName,
                isAdmin = userRequest.isAdmin
            };

            await _userRepository.AddUser(user);
        }
        public async Task UpdateUser(UpdateUserRequest updateUserRequest)
        {
            var existingUser = await _userRepository.GetUserById(updateUserRequest.Id);

            if (existingUser == null)
            {
                throw new ApplicationException("User does not exist");
            }

            existingUser.FirstName = updateUserRequest.FirstName;
            existingUser.LastName = updateUserRequest.LastName;

            await _userRepository.SaveChangesUser();
        }

        public async Task<string> LogIn(LogInRequest logInRequest)
        {
            var existingUser = await _userRepository.GetUserByUsername(logInRequest.Username);

            if (existingUser == null)
            {
                throw new ApplicationException("Invalid credentials");
            }
            else
            {
                if (existingUser.Password == logInRequest.Password)
                {
                    return GenerateToken(existingUser);
                }
            }

            return "";
        }


        /// Helper for token generating
        private string GenerateToken(User user)
        {
            //Generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("5B4C20A7F76B4EFEA3C29DEAB7B387B8"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim("user_id", user.Id.ToString()),
                user.isAdmin ? new Claim("user_role", "admin") : new Claim("user_role", "user")
                };

            var token = new JwtSecurityToken(
                claims: userClaims,
                signingCredentials: credentials,
                expires: DateTime.Now.AddDays(5)
            );

            return tokenHandler.WriteToken(token);
        }
    }
}