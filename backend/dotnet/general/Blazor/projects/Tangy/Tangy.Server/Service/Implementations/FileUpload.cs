using Microsoft.AspNetCore.Components.Forms;
using Tangy.Server.Service.Contracts;

namespace Tangy.Server.Service.Implementations
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public FileUpload(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public bool DeleteFile(string filePath)
        {
            if (File.Exists(webHostEnvironment.WebRootPath + filePath))
            {
                File.Delete(webHostEnvironment.WebRootPath + filePath);
                return true;
            }
            return true;
        }

        public async Task<string> UploadFile(IBrowserFile file)
        {
            FileInfo fileInfo = new(file.Name);
            string fileName = Guid.NewGuid().ToString() + fileInfo.Extension;
            string directory = $"{webHostEnvironment.WebRootPath}\\images\\product";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            string filePath = Path.Combine(directory, fileName);

            await using FileStream fs = new FileStream(filePath, FileMode.Create);
            await file.OpenReadStream().CopyToAsync(fs);

            return $"/images/product/{fileName}";
        }
    }
}
