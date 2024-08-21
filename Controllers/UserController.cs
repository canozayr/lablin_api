using lablinAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lablinAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpGet("list")]
        public List<tbl_users> Get()
        {
            using var db = new lablinContext();
            List<tbl_users> userList = db.tbl_users.ToList<tbl_users>();
            return userList;
            
        }

        [HttpGet("ByID/{id}")]
        public async Task<ActionResult<tbl_users?>> GetSingle(int id)
        {
            using var db = new lablinContext();
            tbl_users? single_User = await db.tbl_users.SingleOrDefaultAsync(x => x.id == id);

            return single_User;
        }

        [HttpPost("new")]
        public async Task<ActionResult<tbl_users?>> PostProject(tbl_users new_user)
        {
            if (new_user.id != 0)
            {
                // update the project
                using var db = new lablinContext();
                db.Attach(new_user);
                db.Entry(new_user).State = EntityState.Modified;
                await db.SaveChangesAsync();
            } else
            {
                // create new
                using var db = new lablinContext();
                db.tbl_users.Add(new_user);
                await db.SaveChangesAsync();
            }
            

            return new_user;
            
        }
    }
}
