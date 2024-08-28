using lablinAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lablinAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacilityController : Controller
    {
        [HttpGet("list")]
        public List<tbl_facility> Get()
        {
            using var db = new lablinContext();
            List<tbl_facility> facility_list = db.tbl_facility.ToList<tbl_facility>();
            return facility_list;
        }

        [HttpGet("ByID/{id}")]
        public async Task<tbl_facility?> GetSingle(int id)
        {
            using var db = new lablinContext();
            tbl_facility? single_facility = await db.tbl_facility.SingleOrDefaultAsync(x => x.id == id);

            return single_facility;
        }

        [HttpPost("new")]
        public async Task<tbl_facility?> PostExtractionkit(tbl_facility new_facility)
        {
            if (new_facility.id != 0)
            {
                // update the project
                using var db = new lablinContext();
                db.Attach(new_facility);
                db.Entry(new_facility).State = EntityState.Modified;
                await db.SaveChangesAsync();
            } else
            {
                // create new
                using var db = new lablinContext();
                db.tbl_facility.Add(new_facility);
                await db.SaveChangesAsync();
            }
            
            return new_facility;
            
        }
    }
}
