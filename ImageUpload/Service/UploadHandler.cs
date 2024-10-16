using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;

namespace ImageUpload.Service
{
    public class UploadHandler
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UploadHandler(IWebHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
        {
            _environment = environment;
            _httpContextAccessor = httpContextAccessor;
        }

        

        public string Upload(IFormFile file)
        {
            // Valid extensions
            List<string> validExtensions = new List<string>() { ".jpg", ".png", ".jpeg" };
            string extension = Path.GetExtension(file.FileName);
            if (!validExtensions.Contains(extension))
            {
                return $"Extensions Not Valid {string.Join(',', validExtensions)}";
            }

            // Size check
            long size = file.Length;
            if (size > (5 * 1024 * 1024))
            {
                return "Maximum size can be 5Mb";
            }

            // Change file name
            string filename = Guid.NewGuid().ToString() + extension;
            string uploadPath = Path.Combine(_environment.ContentRootPath, "wwwroot/Images");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            using (FileStream stream = new FileStream(Path.Combine(uploadPath, filename), FileMode.Create))
            {
                file.CopyTo(stream);
            }

            // Get the host and scheme from HttpContext
            var request = _httpContextAccessor.HttpContext.Request;
            string scheme = request.Scheme;  // e.g. http or https
            string host = request.Host.Value; // e.g. localhost:5000 or example.com

            // Generate the full URL
            string fileUrl = $"{scheme}://{host}/wwwroot/Images/{filename}";

            return fileUrl;
        }
    }
}
