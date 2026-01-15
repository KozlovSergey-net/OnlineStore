using System.Threading.Tasks;
using System.Transactions;
using TestsOnlineStore.Helper;

namespace TestsOnlineStore
{
    public class UnitTest1: BaseTest
    {
        [Fact]
        public async Task Registration()
        {
            using(TransactionScope scope = Helper.Helper.CreateTransactionScope())
            {
               // проверка сгенерированного email, его не должно быть в базе
                string email = Guid.NewGuid().ToString()+ "@test.ru";
                var emailValidResult = await authBL.ValidEmail(email);
                Assert.Null(emailValidResult);

                // создаем нового пользователя
                int userId = await authBL.CreateUser(
                    new OnlineStore.DAL.Models.UserModel()
                    {
                        Email = email,
                        Password = "qwer12345"
                    });
                Assert.True(userId > 0);

                //проверяем создается ли в БД
                emailValidResult = await authBL.ValidEmail(email);
                Assert.NotNull(emailValidResult);

            }
        }
    }
}
