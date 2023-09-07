using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBussiness:IUserBusiness
    {
        private readonly IUserRepo userRepo;
        private readonly IConfiguration configuration;
        public UserBussiness(IUserRepo userRepo,IConfiguration configuration)
        {
            this.userRepo = userRepo;
            this.configuration = configuration;
        }
        public UserEntity UserRegister(UserRegisterModel model)
        {
            try
            {
               return userRepo.UserRegister(model);
            }
            catch
            {
                throw;
            }
        }
        public string UserLogin(UserLoginModel model)
        {
            try
            {
                return userRepo.UserLogin(model);
            }
            catch
            {
                throw;
            }

        }
        public string ForgotPassword(ForgotPasswordModel forgotPassword)
        {
            try
            {
                return userRepo.ForgotPassword(forgotPassword);
            }
            catch
            {
                throw;
            }
        }
    }

}
