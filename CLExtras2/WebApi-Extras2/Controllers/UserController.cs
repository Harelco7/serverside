using CLExtras2.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Extras2.DTO_s;
namespace WebApi_Extras2.Controllers

{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class UserController : ControllerBase
    {
        Extras2Context db = new Extras2Context();


        [HttpPut]
        [Route("updateBusiness")]
        public IActionResult UpdatePassword([FromBody] UpdateBusinessDTO newBusiness)
        {
            // Find the object in the database by username
            var business = db.Users.FirstOrDefault(u => u.Username == newBusiness.Username);

            if (business == null)
            {
                return NotFound(); // Handle the case where the object is not found

            }

            // Update the password


            // Save changes to the database
            db.SaveChanges();

            return Ok();
        }
    }
}
