using Microsoft.AspNetCore.Http;

namespace BookStorage.Interfaces
{
    public interface IFileService
    {
        void SaveUploadedFile(IFormFile uploadedFile, string path);
        void DeleteFile(string path);
    }
}