using Microsoft.AspNetCore.Http;

namespace Demo.BLL.Services;

public interface IDocumentService
{
    //Upload
    // (file , folderName) => string
    Task<string?> UploadAsync(IFormFile file, string folderName);
    //delete
    //(fileName , folderName) => bool

    bool Delete(string fileName, string folderName);
}
