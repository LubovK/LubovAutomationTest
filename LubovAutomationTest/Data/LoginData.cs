using Twitter.Constants;

namespace Twitter.Data
{
    /// <summary>
    /// Incapsulate login credentials to data
    /// </summary>
    public class LoginData
    {
        public string Username { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Get Valid Credentials data
        /// </summary>
        /// <returns></returns>
        public static LoginData GetValidCredentials()
        {
            return new LoginData
            {
                Username = LoginCredentials.UserName,
                Password = LoginCredentials.Password
            };           
        }

        /// <summary>
        /// Get Invalid Credentials
        /// </summary>
        /// <returns></returns>
        public static LoginData GetInvalidCredentials()
        {
            return new LoginData
            {
                Username = LoginCredentials.UserName,
                Password = LoginCredentials.IncorrectPassword
            };
        }
    }
}
