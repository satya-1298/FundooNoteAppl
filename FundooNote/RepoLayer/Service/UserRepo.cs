﻿using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepoLayer.Service
{
    public class UserRepo:IUserRepo
    {
        private readonly FundooContext _fundooContext;
        private readonly IConfiguration configuration;
        public UserRepo(FundooContext fundooContext,IConfiguration configuration)
        {
            this._fundooContext = fundooContext;
            this.configuration = configuration;
        }
        public UserEntity UserRegister(UserRegisterModel model)
        {
            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.FirstName = model.FirstName;
                userEntity.LastName = model.LastName;
                userEntity.Email = model.Email;
                userEntity.Password = model.Password;
                _fundooContext.User.Add(userEntity);
                _fundooContext.SaveChanges();
                if(userEntity!=null)
                {
                    return userEntity;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }

        // JWT TOKEN GENERATE:-
        public string GenerateToken(string Email, long UserId)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = Encoding.ASCII.GetBytes(configuration["JwtConfig:key"]);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("UserId", UserId.ToString()),
                    new Claim(ClaimTypes.Email, Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(TokenDescriptor);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
