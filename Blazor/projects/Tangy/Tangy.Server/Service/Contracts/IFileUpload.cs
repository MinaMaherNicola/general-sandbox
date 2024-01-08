using Microsoft.AspNetCore.Components.Forms;

namespace Tangy.Server.Service.Contracts
{
    public interface IFileUpload
    {
        Task<string> UploadFile(IBrowserFile file);
        bool DeleteFile(string filePath);
    }
}
