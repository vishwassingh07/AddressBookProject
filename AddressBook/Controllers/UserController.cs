using BusinessLayer.Interface;
using CommonLayer.Model.UserModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;   
        }
        [HttpPost("Register")]
        public ActionResult Registration(UserRegistrationModel registrationModel)
        {
            try
            {
                var result = userBL.UserRegistration(registrationModel);
                if(result != null)
                {
                    return Ok(new { success = true, message = "User Registration Successfull", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "User Registration Not Successfull" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
