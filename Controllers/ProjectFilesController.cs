using lablinAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lablinAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectFilesController : Controller
    {
        [HttpGet("ByProjectID/{projectID}")]
        public async Task<List<tbl_project_files>?> GetByProjectID(int projectID)
        {
            using var db = new lablinContext();
            List<tbl_project_files>? project_files = await db.tbl_project_files.Where(x => x.projectID == projectID).ToListAsync<tbl_project_files>();

            return project_files;
        }

        [HttpPost("new")]
        public async Task<ActionResult<tbl_project_files?>> PostProject(tbl_project_files new_project_file)
        {
            if (new_project_file.ID != 0)
            {
                // update the project
                using var db = new lablinContext();
                db.Attach(new_project_file);
                db.Entry(new_project_file).State = EntityState.Modified;
                await db.SaveChangesAsync();
            } else
            {
                // create new
                using var db = new lablinContext();
                db.tbl_project_files.Add(new_project_file);
                await db.SaveChangesAsync();
            }
            

            return new_project_file;
        }



    }
}
