using Microsoft.Extensions.Configuration;
namespace Forum
{
    public class ConnectionString
    {
        private static IConfiguration _configuration;
        public ConnectionString(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public static string CONNECTION_STRING = _configuration.GetConnectionString("ForumDBConnection");
    }
}
