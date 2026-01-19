namespace SagiCore.Communication.Requests.Operacional.PedidoVenda
{
    public class RequestRegisterPedidoVendaJson
    {
        // Cabeçalho do Pedido (pedido_ven)
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

        // Itens do Pedido
        public List<RequestPedidoVendaItemJson> itens { get; set; } = [];
    }

    public class RequestPedidoVendaItemJson
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
    }
}
