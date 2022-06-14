namespace SocialMedia.Infrastructure
{
    internal abstract class AppSettings
    {
        public static string ConnectionStringPostgreSql => "Server=localhost;Port=5432;Database=socialmediadb;User Id=dev;Password=12345678;";

        public static string ConnectionStringSqlServer => "Server=localhost;Database=SocialMediaDB;Trusted_Connection=True;";

        public static string SecurityKey => "UzI1IshbGciOiJIInR5ceyJzdWIiOiIxMjDkwIiwI6kpviaWF0E2MjM5MDIwRSMeKKFPOk6yJw5c";

        public static string Issuer => "SocialMediaIssuer";

        public static string Audience => "SocialMediaAudience";

        public static string SmtpServer => "send.one.com";

        public static int SmtpPort => 465;

        public static string Email => SecretSettings.Email;

        public static string Password => SecretSettings.Password;
    }
}
