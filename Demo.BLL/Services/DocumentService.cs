using Microsoft.AspNetCore.Http;

namespace Demo.BLL.Services;

public class DocumentService : IDocumentService
{
    private List<string> _allowedExtensions = [".png", ".jpeg", ".jpg"];
    private const int MAXSIZE = 2_097_152;
    public async Task<string?> UploadAsync(IFormFile file, string folderName)
    {
        var extension = Path.GetExtension(file.FileName);
        if (!_allowedExtensions.Contains(extension))
            return null;

        if (file.Length > MAXSIZE)
            return null;

        var fileName = $"{Guid.NewGuid()}{extension}";

        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", folderName);

        var filePath = Path.Combine(folderPath, fileName);

        using Stream fileStream = new FileStream(filePath, FileMode.Create);

        await file.CopyToAsync(fileStream);

        return fileName;
    }
    public bool Delete(string fileName, string folderName)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", folderName, fileName);
        if (!File.Exists(filePath))
            return false;
        File.Delete(filePath);
        return true;
    }


}
