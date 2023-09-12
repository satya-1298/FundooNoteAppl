
using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteBusiness business;
        public NoteController(INoteBusiness business)
        {
            this.business = business;
        }
        [Authorize]
        [HttpPost]
        [Route("AddNote")]
        public IActionResult NoteCreate(NoteCreateModel noteCreateModel)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
                var result = business.CreateNote(noteCreateModel, userId);
                if (result != null)
                {
                    return Ok(new { message = "Successfull", data = result });
                }
                else
                {
                    return BadRequest(new { message = "Unsuccessfull", data = result });
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
