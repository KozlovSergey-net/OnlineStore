namespace OnlineStore.BL
{
    public interface ICryptoKey
    {
        string HashPassword(string password, string salt);
    }
}
