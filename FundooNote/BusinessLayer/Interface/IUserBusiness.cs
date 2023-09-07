using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBusiness
    {
        public UserEntity UserRegister(UserRegisterModel model);
        public string UserLogin(UserLoginModel model);
        public string ForgotPassword(ForgotPasswordModel forgotPassword);
        public bool ResetPassword(string email, ResetPasswordModel resetPassword);
    }
}
