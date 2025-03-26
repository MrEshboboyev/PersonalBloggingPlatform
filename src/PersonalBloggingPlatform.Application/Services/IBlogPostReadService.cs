using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Services;

public interface IBlogPostReadService
{
    Task<bool> ExistsByTitleAsync(string title);
}
