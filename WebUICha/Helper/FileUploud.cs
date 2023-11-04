using System.IO;
using WebUICha.Data;

namespace WebUICha.Helper
{
    public static class FileUploud
    {
        public static async Task<string> SeveFileAsync(this IFormFile file, string WebRootPath)
        {
            var path = "/uploads/" + Guid.NewGuid() + file.FileName;
            using FileStream fileStream = new(WebRootPath + path, FileMode.Create);
            await file.CopyToAsync(fileStream);

            return path;
        }
    }
}
