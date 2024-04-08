using Microsoft.AspNetCore.Identity;

namespace BlogMVC.Web.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}

