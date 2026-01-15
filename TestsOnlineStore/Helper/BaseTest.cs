using Microsoft.AspNetCore.Http;
using OnlineStore.BL;
using OnlineStore.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestsOnlineStore.Helper
{
    public class BaseTest
    {
        protected IAuthDal authDal = new AuthDal();
        protected ICryptoKey cryptoKey = new CryptoKey();
        protected IHttpContextAccessor httpContexAccessor = new HttpContextAccessor();
        protected IAuthBL authBL;
        public BaseTest()
        {
            authBL = new AuthBL(authDal, cryptoKey, httpContexAccessor);
        }
    }
}
