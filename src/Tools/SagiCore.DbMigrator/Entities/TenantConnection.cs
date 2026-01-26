namespace SagiCore.DbMigrator.Entities
{
    public class TenantConnection
    {
        public int Id { get; set; }
        public string Database { get; set; } = string.Empty;
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public string User { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string GetConnectionString()
        {
            return $"Host={Host};Port={Port};Database={Database};Username={User};Password={Password}";
        }
    }
}
