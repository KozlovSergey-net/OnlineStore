using Dapper;
using Npgsql;
using OnlineStore.DAL.Models;
using System.Reflection;


namespace OnlineStore.DAL
{
    public class AuthDal : IAuthDal
    {
        public async Task<int> CreateUser(UserModel user)
        {
            using (var connection = new NpgsqlConnection(DbHelper.ConnectString))
            {
                await connection.OpenAsync();
                string sql = @"insert into public.appuser(email, password, salt, status)
                        values(@email, @password, @salt, @status);
                        SELECT currval(pg_get_serial_sequence('public.appuser','userid'));";
                return await connection.QuerySingleAsync<int>(sql, user);
            }

        }

        public async Task<UserModel> GetUser(string email)
        {
            using (var connection = new NpgsqlConnection(DbHelper.ConnectString))
            {
                await connection.OpenAsync();

                return await connection.QueryFirstOrDefaultAsync<UserModel>(@"select userid, email, password, salt, status 
                                                                              from appuser
                                                                              where Email = @email", new { email = email }) ?? new UserModel();
            }
                
            
        }

        public Task<UserModel> GetUser(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
