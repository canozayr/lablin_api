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
        public async Task<ActionResult<IEnumerable<tbl_project_properties>>> GetSingle(int id)
        {
            using var db = new lablinContext();
            List<tbl_project_properties> propertyList = await db.tbl_project_properties.Where(x => x.projectID == id).ToListAsync<tbl_project_properties>();

            return propertyList;
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
