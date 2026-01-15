using System;
using System.ComponentModel.DataAnnotations;
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

        public async Task<int> GetUser(string Email, string Password)
        {
          
            var user =  await authDal.GetUser(Email);
            if (user.Password == cryptoKey.HashPassword(Password, user.Salt)){
                Login(user.UserId ?? 0);
                return user.UserId ?? 0;
            }
            return 0;
        }

        public async Task Login(int id)
        {
            httpContexAccessor.HttpContext?.Session.SetInt32(AuthConst.AUTH_SESSION_PARAM_NAME, id);
        }

        public async Task<ValidationResult> ValidEmail(string Email)
        {
            var user = await authDal.GetUser(Email);
            if(user.UserId != null)
            {
                return new ValidationResult("Email уже существует");
            }
            return null;

        }
    }
}
