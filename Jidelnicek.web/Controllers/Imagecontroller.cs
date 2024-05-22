using Microsoft.AspNetCore.Mvc;

namespace Jidelnicek.web.Controllers
{
    public class ImagesController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public ImagesController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Please upload a file.");
            }

            var uploads = Path.Combine(_env.WebRootPath, "images");
            var filePath = Path.Combine(uploads, file.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // Save image metadata to the database or an in-memory collection

            return RedirectToAction("Index"); // Or wherever you want to redirect
        }

        public IActionResult DisplayImage(string fileName)
        {
            var absolutePath = Path.Combine(_env.WebRootPath, "images");
            var filePath = Path.Combine(absolutePath, fileName);
            return PhysicalFile(filePath, "image/jpeg");
        }
    }

}
