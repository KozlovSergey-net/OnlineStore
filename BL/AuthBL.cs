using OnlineStore.DAL;
using OnlineStore.DAL.Models;

namespace OnlineStore.BL
{
    public class AuthBL : IAuthBL
    {
        private readonly IAuthDal authDal;
        public AuthBL(IAuthDal authDal)
        {
            this.authDal = authDal;
        }
        public async Task<int> CreateUser(UserModel user)
        {
            int id = await authDal.CreateUser(user);
            return id;
        }
    }
}
