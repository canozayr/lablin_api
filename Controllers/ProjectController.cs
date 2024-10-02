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
        [HttpGet("FavouriteProjects")]
        public async Task<List<tbl_project>> GetFavouriteProjects([FromQuery] int[] projectIDs)
        {

            using (lablinContext db = new lablinContext())
            {
                string betterQuery = string.Join(",", projectIDs);
                FormattableString q = $"SELECT * FROM tbl_project WHERE id in ({betterQuery})";
                List<tbl_project> projectList = await (from p in db.tbl_project where projectIDs.Contains(p.id) select p).ToListAsync<tbl_project>();

                return projectList;
            };
        }

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

        [HttpGet("LinkSample2Project/{projectID}/{sampleID}")]
        public async Task LinkSample2Project(int projectID, int sampleID)
        {
            using (lablinContext db = new lablinContext())
            {
                tec_project_samples? project_sample = await db.tec_project_samples.Where(x=>x.projectID == projectID && x.sampleID == sampleID).FirstOrDefaultAsync();

                if (project_sample == null)
                {
                    project_sample = new tec_project_samples();
                    project_sample.projectID = projectID;
                    project_sample.sampleID = sampleID;

                    db.tec_project_samples.Add(project_sample);
                    await db.SaveChangesAsync();
                }

                return;
            };
        }



        [HttpGet("ProjectUsers/{projectID}")]
        public async Task<List<tbl_users>> GetProjectUsers(int projectID)
        {
            using (lablinContext db = new lablinContext())
            {
                FormattableString q = $"CALL sp_project_users ({projectID})";
                List<tbl_users> userList = await db.tbl_users.FromSql(q).ToListAsync<tbl_users>();

                return userList;
            }
        }

        [HttpGet("LinkUser2Project/{projectID}/{userID}")]
        public async Task LinkUser2Project(int projectID, int userID)
        {
            using (lablinContext db = new lablinContext())
            {
                tbl_project_users? project_user = await db.tbl_project_users.Where(x => x.projectID == projectID && x.userID == userID).FirstOrDefaultAsync();

                if (project_user == null)
                {
                    project_user = new tbl_project_users();
                    project_user.projectID = projectID;
                    project_user.userID = userID;

                    db.tbl_project_users.Add(project_user);
                    await db.SaveChangesAsync();
                }

                return;
            };
        }
        #endregion
    }
}
