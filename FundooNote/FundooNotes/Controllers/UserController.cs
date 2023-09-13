using BusinessLayer.Interface;
using BusinessLayer.Services;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Entity;
using System.Security.Claims;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness userBussiness;
        public UserController(IUserBusiness userBussiness)
        {
            this.userBussiness = userBussiness;
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult RegisterUser(UserRegisterModel model)
        {
            try
            {
                var result = userBussiness.UserRegister(model);
                if (result != null)
                {
                    return Ok(new { message = "Successfully Registered", data = result });
                }
                else
                {
                    return BadRequest(new {message="Unsuccessful",data=result});
                }
            }
            catch
            {
                throw;
            }
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult LoginUser(UserLoginModel model)
        {
            try
            {
                var result = userBussiness.UserLogin(model);
                if (result != null)
                {
                    return Ok(new { message = "Successfully Logged", data = result });
                }
                else
                {
                    return BadRequest(new { message = "Unsuccessful", data = result });
                }
            }
            catch
            {
                throw;
            }
        }
        [HttpPost]
        [Route("ForgotPassword")]
        public IActionResult UserForGotPass(ForgotPasswordModel passwordModel)
        {
            try
            {
                var result = userBussiness.ForgotPassword(passwordModel);
                if(result != null)
                {
                    return Ok(new { message = "mail send Successfully ", data = result });
                }
                else
                {
                    return BadRequest(new { message = "Unsuccessful", data = result });
                }
            }
            catch
            {
                throw;
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        [Route("ResetPass")]
        public IActionResult ResetPassword(ResetPasswordModel resetPassword)
        {
            var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
            var result = userBussiness.ResetPassword(email, resetPassword);
            if (result != null)
            {
                return Ok(new { success = true, message = "Password Changed Successfully"});
            }
            else
            {
                return NotFound(new { success = false, message = "Password not changed" });
            }
        }
    }
}
