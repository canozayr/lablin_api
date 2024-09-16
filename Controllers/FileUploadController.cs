using lablinAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lablinAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileUploadController : Controller
    {

        [HttpPost("upload")]
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        public IActionResult Upload(IFormFile file)
        {
            try
            {
                if (!Request.Form.Files.Any())
                    return Ok();

                string pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(pathToSave))
                    Directory.CreateDirectory(pathToSave);

                string fullPath = Path.Combine(pathToSave, file.FileName);

               
                using (var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: false))
                {
                    file.CopyTo(fileStream);
                    fileStream.Close();

                }

            }catch (Exception err)
            {
                return StatusCode(500);
            }

            return Ok();
        }

    }
}