namespace OnlineStore.BL
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public bool IsLoggedIn()
        {
            int? id = httpContextAccessor.HttpContext?.Session.GetInt32(AuthConst.AUTH_SESSION_PARAM_NAME);
            return id != null;
        }
    }
}
