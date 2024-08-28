using lablinAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lablinAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExtractionkitController : Controller
    {
        [HttpGet("list")]
        public List<tbl_extraction_kit> Get()
        {
            using var db = new lablinContext();
            List<tbl_extraction_kit> extractionkit_list = db.tbl_extraction_kit.ToList<tbl_extraction_kit>();
            return extractionkit_list;
            
        }

        [HttpGet("ByID/{id}")]
        public async Task<tbl_extraction_kit?> GetSingle(int id)
        {
            using var db = new lablinContext();
            tbl_extraction_kit? single_extractionkit = await db.tbl_extraction_kit.SingleOrDefaultAsync(x => x.id == id);

            return single_extractionkit;
        }

        [HttpPost("new")]
        public async Task<tbl_extraction_kit?> PostExtractionkit(tbl_extraction_kit new_extractionkit)
        {
            if (new_extractionkit.id != 0)
            {
                // update the project
                using var db = new lablinContext();
                db.Attach(new_extractionkit);
                db.Entry(new_extractionkit).State = EntityState.Modified;
                await db.SaveChangesAsync();
            } else
            {
                // create new
                using var db = new lablinContext();
                db.tbl_extraction_kit.Add(new_extractionkit);
                await db.SaveChangesAsync();
            }
            
            return new_extractionkit;
            
        }
    }
}
