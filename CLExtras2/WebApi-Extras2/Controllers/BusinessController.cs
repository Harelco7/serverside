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
    public class BusinessController : ControllerBase
    {
        Extras2Context db = new Extras2Context();

        [HttpGet]
        [Route("ShowBusiness/{businessId}")]
        public dynamic ShowBusiness(int businessId)
        {
            try
            {
                var boxes = db.Boxes
            .Where(box => box.BusinessId == businessId)
            .Select(box => new
            {
                BoxName = box.BoxName,
                Description = box.Description,
                Price = box.Price,
                QuantityAvailable = box.QuantityAvailable,
                BoxImage = box.BoxImage,
                AlergicType = box.AlergicType,
                boxID= box.BoxId,
                businessID = box.BusinessId,
            }).ToList();

                return boxes;

            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
