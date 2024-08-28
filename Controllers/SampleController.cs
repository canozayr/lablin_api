using lablinAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lablinAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : Controller
    {
        [HttpGet("list")]
        public List<tbl_sample> Get()
        {
            using var db = new lablinContext();
            List<tbl_sample> userList = db.tbl_sample.ToList<tbl_sample>();
            return userList;
            
        }

        [HttpGet("ByID/{id}")]
        public async Task<ActionResult<tbl_sample?>> GetSingle(int id)
        {
            using var db = new lablinContext();
            tbl_sample? single_User = await db.tbl_sample.SingleOrDefaultAsync(x => x.id == id);

            return single_User;
        }

        [HttpPost("new")]
        public async Task<ActionResult<tbl_sample?>> PostProject(tbl_sample new_sample)
        {
            if (new_sample.id != 0)
            {
                // update the project
                using var db = new lablinContext();
                db.Attach(new_sample);
                db.Entry(new_sample).State = EntityState.Modified;
                await db.SaveChangesAsync();
            } else
            {
                // create new
                using var db = new lablinContext();
                db.tbl_sample.Add(new_sample);
                await db.SaveChangesAsync();
            }
            
            return new_sample;
            
        }
    }
}
