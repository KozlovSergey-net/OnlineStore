using OnlineStore.DAL.Models;

namespace OnlineStore.DAL
{
    public interface IAuthDal
    {
        Task<UserModel> GetUser(string Email);
        Task<UserModel> GetUser(int Id);
        Task<int> CreateUser(UserModel user);

    }
}
