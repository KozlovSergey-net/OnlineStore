using OnlineStore.DAL;
using OnlineStore.DAL.Models;

namespace OnlineStore.BL
{
    public class AuthBL : IAuthBL
    {
        private readonly IAuthDal authDal;
        private readonly ICryptoKey cryptoKey;
        public AuthBL(IAuthDal authDal, ICryptoKey cryptoKey)
        {
            this.authDal = authDal;
            this.cryptoKey = cryptoKey;
        }
        public async Task<int> CreateUser(UserModel user)
        {
            user.Salt = Guid.NewGuid().ToString();
            user.Password = cryptoKey.HashPassword(user.Password, user.Salt);
            int id = await authDal.CreateUser(user);
            return id;
        }

        public async Task<UserModel> GetUser(UserModel user)
        {
          
            return await authDal.GetUser(user.Email); ;
        }
    }
}
