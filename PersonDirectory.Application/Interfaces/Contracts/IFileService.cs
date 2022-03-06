using Microsoft.AspNetCore.Http;

namespace PersonDirectory.Application.Interfaces.Contracts
{
    public interface IFileService
    {
        Task<string> SavePicture(IFormFile file, string fileName);
    }
}
