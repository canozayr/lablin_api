using lablinAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace lablinAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : Controller
    {
        [HttpGet("list")]
        public List<tbl_project> Get()
        {
            using var db = new lablinContext();
            List<tbl_project> projectList = db.tbl_project.ToList();
            return projectList;
            
        }

        [HttpGet("ByID/{id}")]
        public async Task<ActionResult<tbl_project?>> GetSingle(int id)
        {
            using var db = new lablinContext();
            tbl_project? single_project = await db.tbl_project.SingleOrDefaultAsync(x => x.id == id);

            return single_project;
        }

        [HttpPost("new")]
        public async Task<ActionResult<tbl_project?>> PostProject(tbl_project new_project)
        {
            if (new_project.id != 0)
            {
                // update the project
                using var db = new lablinContext();
                db.Attach(new_project);
                db.Entry(new_project).State = EntityState.Modified;
                await db.SaveChangesAsync();
            } else
            {
                // create new
                using var db = new lablinContext();
                db.tbl_project.Add(new_project);
                await db.SaveChangesAsync();
            }
            

            return new_project;
            
        }

        #region TECS
        [HttpGet("ProjectSamples/{projectID}")]
        public async Task<List<tbl_sample>> GetProjectSamples(int projectID)
        {
            using (lablinContext db = new lablinContext())
            {
                FormattableString q = $"CALL sp_project_samples ({projectID})";
                List<tbl_sample> samplesList = await db.tbl_sample.FromSql(q).ToListAsync<tbl_sample>();

                return samplesList;
            };
        }
        #endregion
    }
}
