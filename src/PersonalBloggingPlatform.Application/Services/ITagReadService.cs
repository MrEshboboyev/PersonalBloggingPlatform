using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Services;

public interface ITagReadService
{
    Task<bool> ExistsByNameAsync(string name);
}