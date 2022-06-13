namespace SocialMedia.Infrastructure
{
    internal abstract class AppSettings
    {
        // PostgreSql Connection => "Server=localhost;Port=5432;Database=socialmediadb;User Id=dev;Password=12345678;"
        // SqlServer Connection => "Server=localhost;Database=master;Trusted_Connection=True;"

        public static string ConnectionString => "Server=localhost;Database=SocialMediaDB;Trusted_Connection=True;";

        public static string SecurityKey => "UzI1IshbGciOiJIInR5ceyJzdWIiOiIxMjDkwIiwI6kpviaWF0E2MjM5MDIwRSMeKKFPOk6yJw5c";

        public static string Issuer => "SocialMediaIssuer";

        public static string Audience => "SocialMediaAudience";
    }
}
