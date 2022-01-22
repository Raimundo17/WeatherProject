using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WeatherProject.Helpers
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile imageFile, string folder);  // caminho guardado na base de dados
    }
}
