namespace OnlineStore.BL
{
    public interface IAuthBL 
    {
        Task<int> CreateUser(DAL.Models.UserModel user);
    }
}
