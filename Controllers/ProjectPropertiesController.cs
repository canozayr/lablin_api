using lablinAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lablinAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NGSController : Controller
    {
        [HttpGet("list")]
        public async Task<List<tbl_ngs_run_info>> List()
        {
            using var db = new lablinContext();

            List<tbl_ngs_run_info> run_info_list = await db.tbl_ngs_run_info.ToListAsync();
            return run_info_list;

        }

        [HttpGet("ByID/{id}")]
        public async Task<ActionResult<tbl_ngs_run_info?>> GetSingle(int id)
        {
            using var db = new lablinContext();
            tbl_ngs_run_info? single_run_info = await db.tbl_ngs_run_info.SingleOrDefaultAsync(x => x.id == id);

            return single_run_info;
        }
    }
}
