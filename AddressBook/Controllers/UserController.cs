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
        [HttpGet("Retrieve")]
        public ActionResult RetrieveAddress()
        {
            try
            {
                var result = userBL.GetAllAddress();
                if(result != null)
                {
                    return this.Ok(new { success = true, message = "Addres Details Fetched Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Address Details Could Not Be Fetched" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
