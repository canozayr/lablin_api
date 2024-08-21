using lablinAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lablinAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SequencingFacilityController : Controller
    {
        
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<tbl_sequencing_facility>>> GetList()
        {
            using var db = new lablinContext();
            List<tbl_sequencing_facility> seq_fac_list = await db.tbl_sequencing_facility.ToListAsync();

            return seq_fac_list;
        }
    }
}
