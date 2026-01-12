using Microsoft.AspNetCore.Identity.Data;
using OnlineStore.DAL.Models;

namespace OnlineStore.BL
{
    public interface IAuthBL 
    {
        Task<int> CreateUser(DAL.Models.UserModel user);
        Task<UserModel> GetUser(UserModel user);
        
    }
}
