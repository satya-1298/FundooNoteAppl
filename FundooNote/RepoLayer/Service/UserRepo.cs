using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
        public string UserLogin(UserLoginModel model)
        {
            var result=_fundooContext.User.FirstOrDefault(x=>x.Email== model.Email && x.Password==model.Password);
            if(result!=null)
            {
                var token=GenerateToken(result.Email, result.UserId);
                return token;
            }
            else
            {
                return null;
            }
        }
        public string ForgotPassword(ForgotPasswordModel model)
        {
            try
            {
                var result = _fundooContext.User.FirstOrDefault(x => x.Email == model.Email);
                if (result != null)
                {
                    var token = GenerateToken(result.Email, result.UserId);
                    MSMQ mSMQ = new MSMQ();
                    mSMQ.SendData2Queue(token);
                    return token;
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
        public bool ResetPassword(string email, ResetPasswordModel resetPassword)
        {
            try
            {
                if (resetPassword.newPassword.Equals(resetPassword.conformPassword))
                {
                    var user = _fundooContext.User.Where(x => x.Email == email).FirstOrDefault();
                    user.Password = resetPassword.conformPassword;

                    _fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
