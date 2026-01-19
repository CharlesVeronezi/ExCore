namespace SagiCore.Domain.Entities.Operacional
{
    public class PedidoVenda
    {
        public int pednum { get; set; }
        public DateTime dataped { get; set; }
        public DateTime dataval { get; set; }
        public int codcli { get; set; }
        public string cliente { get; set; } = string.Empty;
        public int codvnd { get; set; }
        public string vendedor { get; set; } = string.Empty;
        public bool impnumped { get; set; }
        public bool imppedcli { get; set; }
        public string obsfiscal1 { get; set; } = string.Empty;
        public DateTime prazo_ent { get; set; }
        public string obs { get; set; } = string.Empty;
        public string ende_entre { get; set; } = string.Empty;
        public string num_entre { get; set; } = string.Empty;
        public string bai_entre { get; set; } = string.Empty;
        public string cid_entre { get; set; } = string.Empty;
        public int ibge_entre { get; set; }
        public string uf_entre { get; set; } = string.Empty;
        public string cep_entre { get; set; } = string.Empty;
        public int cod_pais_entre { get; set; }
        public bool aprovado { get; set; }
        public string usuario { get; set; } = string.Empty;
        public DateTime data { get; set; }
        public string hora { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string empresa { get; set; } = string.Empty;
        public decimal vlrfrete { get; set; }
        public string pedcli { get; set; } = string.Empty;
        public string itemped { get; set; } = string.Empty;
        public bool naogernf { get; set; }
        public string use_aprova { get; set; } = string.Empty;
        public DateTime data_aprova { get; set; }
        public bool embarque { get; set; }
        public bool revisar { get; set; }
        public decimal seguro { get; set; }
        public decimal vlrservicos { get; set; }
        public int volumes { get; set; }
        public string tipovol { get; set; } = string.Empty;
        public int moeda { get; set; }
        public string motivo_alt { get; set; } = string.Empty;
        public string user_alt { get; set; } = string.Empty;
        public int unidade { get; set; }
        public string compl_entre { get; set; } = string.Empty;
        public bool beneficiamento { get; set; }
        public bool encerra_aomov { get; set; }
        public int codcli_destino { get; set; }
        public int codtransp_destino { get; set; }
        public string hora_aprova { get; set; } = string.Empty;
        public string ped_tip_terc { get; set; } = string.Empty;
        public int ped_cod_terc { get; set; }
        public bool ped_assume_cfop { get; set; }
        public short nr_tentativa_rec { get; set; }
        public long numorc { get; set; }
        public string ped_scrap { get; set; } = string.Empty;
        public bool visto_tabela_comissao { get; set; }
        public string usuario_tabela_comissao { get; set; } = string.Empty;
        public bool pedido_global { get; set; }
        public bool consignado { get; set; }
        public string tipo_boleto { get; set; } = string.Empty;

        // Navegação para os itens
        public List<PedidoVendaItem> Itens { get; set; } = [];
    }
}