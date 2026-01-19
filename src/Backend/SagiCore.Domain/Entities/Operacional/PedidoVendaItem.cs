namespace SagiCore.Domain.Entities.Operacional
{
    public class PedidoVendaItem
    {
        public int pednum { get; set; }
        public DateTime dataped { get; set; }
        public int codcli { get; set; }
        public string codpro { get; set; } = string.Empty;
        public string subcod { get; set; } = string.Empty;
        public string produto { get; set; } = string.Empty;
        public string un { get; set; } = string.Empty;
        public decimal peso { get; set; }
        public decimal preco { get; set; }
        public decimal preco_nf { get; set; }
        public decimal total { get; set; }
        public string frete { get; set; } = string.Empty;
        public int prazo { get; set; }
        public string condicao { get; set; } = string.Empty;
        public string condicao_pf { get; set; } = string.Empty;
        public decimal vlrdesconto { get; set; }
        public bool com_icms { get; set; }
        public decimal icms { get; set; }
        public decimal ipi { get; set; }
        public decimal totipi { get; set; }
        public int cfop { get; set; }
        public int cfop_id { get; set; }
        public string cst { get; set; } = string.Empty;
        public string pedcli { get; set; } = string.Empty;
        public string itemped { get; set; } = string.Empty;
        public bool bloqueia { get; set; }
        public decimal peso_carga { get; set; }
        public string usuario { get; set; } = string.Empty;
        public DateTime data { get; set; }
        public string hora { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string obs_fiscal { get; set; } = string.Empty;
        public string empresa { get; set; } = string.Empty;
        public string obs_iten { get; set; } = string.Empty;
        public string codcdc { get; set; } = string.Empty;
        public int trib_id { get; set; }
        public string descricao_process { get; set; } = string.Empty;
        public string cond_frete { get; set; } = string.Empty;
        public int centro_id { get; set; }

        // Navegação para o pedido pai
        public PedidoVenda? PedidoVenda { get; set; }
    }
}