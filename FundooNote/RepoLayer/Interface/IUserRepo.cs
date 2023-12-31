﻿using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IUserRepo
    {
        public UserEntity UserRegister(UserRegisterModel userRegister);
        public string UserLogin(UserLoginModel userLogin);
        public string ForgotPassword(ForgotPasswordModel forgotPassword);
        public bool ResetPassword(string email, ResetPasswordModel resetPassword);
    }
}
