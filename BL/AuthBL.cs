using System;
using OnlineStore.DAL;
using OnlineStore.DAL.Models;

namespace OnlineStore.BL
{
    public class AuthBL : IAuthBL
    {
        private readonly IAuthDal authDal;
        private readonly ICryptoKey cryptoKey;
        private readonly IHttpContextAccessor httpContexAccessor;
        public AuthBL(IAuthDal authDal, ICryptoKey cryptoKey, IHttpContextAccessor httpContexAccessor)
        {
            this.authDal = authDal;
            this.cryptoKey = cryptoKey;
            this.httpContexAccessor = httpContexAccessor;
        }
        public async Task<int> CreateUser(UserModel user)
        {
            user.Salt = Guid.NewGuid().ToString();
            user.Password = cryptoKey.HashPassword(user.Password, user.Salt);
            int id = await authDal.CreateUser(user);
            await Login(id);
            return id;
        }

        public async Task<UserModel> GetUser(UserModel user)
        {
          
            return await authDal.GetUser(user.Email); ;
        }

        public async Task Login(int id)
        {
            httpContexAccessor.HttpContext?.Session.SetInt32(AuthConst.AUTH_SESSION_PARAM_NAME, id);
        }
    }
}
