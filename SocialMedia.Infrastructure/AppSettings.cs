namespace SocialMedia.Infrastructure
{
    internal abstract class AppSettings
    {
        public static string ConnectionStringPostgreSql => "Server=localhost;Port=5432;Database=socialmediadb;User Id=dev;Password=12345678;";

        public static string ConnectionStringSqlServer => "Server=localhost;Database=SocialMediaDB;Trusted_Connection=True;";

        public static string JwtSecurityKey => "UzI1IshbGciOiJIInR5ceyJzdWIiOiIxMjDkwIiwI6kpviaWF0E2MjM5MDIwRSMeKKFPOk6yJw5c";

        public static string JwtIssuer => "SocialMediaIssuer";

        public static string JwtAudience => "SocialMediaAudience";

        public static string SmtpServer => "send.one.com";

        public static int SmtpPort => 465;

        public static string Email => SecretSettings.Email;

        public static string Password => SecretSettings.Password;

        public static string AzureBlobStorageConnectionString => SecretSettings.AzureBlobStorageConnectionString;

        public static string AzureBlobStorageKey => SecretSettings.AzureBlobStorageKey;

        public static string AzureBlobStorageContainer => "data";
    }
}
