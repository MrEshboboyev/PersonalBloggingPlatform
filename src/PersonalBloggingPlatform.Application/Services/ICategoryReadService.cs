using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Services;

public interface ICategoryReadService
{
    Task<bool> ExistsByNameAsync(string name);
}