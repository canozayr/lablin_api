using lablinAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lablinAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectPropiertiesController : Controller
    {
        [HttpGet("ByProjectID/{id}")]
        public async Task<tbl_project_properties?> GetSingle(int id)
        {
            using var db = new lablinContext();
            tbl_project_properties? project_properties = await db.tbl_project_properties.SingleOrDefaultAsync(x => x.projectID == id);

            return project_properties;
        }

        [HttpPost("new")]
        public async Task<ActionResult<tbl_project_properties?>> PostProject(tbl_project_properties new_project_properties)
        {
            if (new_project_properties.id != 0)
            {
                // update the project
                using var db = new lablinContext();
                db.Attach(new_project_properties);
                db.Entry(new_project_properties).State = EntityState.Modified;
                await db.SaveChangesAsync();
            } else
            {
                // create new
                using var db = new lablinContext();
                db.tbl_project_properties.Add(new_project_properties);
                await db.SaveChangesAsync();
            }
            

            return new_project_properties;
        }



    }
}
