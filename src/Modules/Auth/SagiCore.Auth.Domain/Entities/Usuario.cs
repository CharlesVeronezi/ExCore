namespace SagiCore.Auth.Domain.Entities
{
    public class Usuario
    {
        public int idempresa { get; set; }
        public int iduser { get; set; }
        public string usuario { get; set; } = string.Empty;
        public string chave { get; set; } = string.Empty;
        public string empresa { get; set; } = string.Empty;
        public string bloqueia { get; set; } = string.Empty;
        public int sr_recno { get; set; }
        public bool bloq_portal_cli { get; set; }
        public string email { get; set; } = string.Empty;
    }
}
