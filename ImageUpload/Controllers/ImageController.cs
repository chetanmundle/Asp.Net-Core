using ImageUpload.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ImageUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        // Inject IWebHostEnvironment and IHttpContextAccessor into the controller
        public ImageController(IWebHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
        {
            _environment = environment;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("[action]")]
        public IActionResult UploadFile(IFormFile file)
        {
            // Pass the dependencies to the UploadHandler
            var uploadHandler = new UploadHandler(_environment, _httpContextAccessor);
            var result = uploadHandler.Upload(file);
            return Ok(result);
        }
    }
}
