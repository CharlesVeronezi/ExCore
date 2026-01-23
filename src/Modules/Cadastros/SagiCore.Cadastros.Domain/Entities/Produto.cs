using SagiCore.Shared.Domain.Entities;

namespace SagiCore.Cadastros.Domain.Entities
{
    public class Produto : EntityBase
    {
        public string codpro { get; set; } = string.Empty;
        public string produto { get; set; } = string.Empty;
        public string produto_complemento { get; set; } = string.Empty;
        public string subcod { get; set; } = string.Empty;
        public string subprod { get; set; } = string.Empty;
        public string un { get; set; } = string.Empty;
        public int codcat { get; set; }
        public string nomeest { get; set; } = string.Empty;
        public string comrec { get; set; } = string.Empty;
        public string codref1 { get; set; } = string.Empty;
        public string codref2 { get; set; } = string.Empty;
        public string codref3 { get; set; } = string.Empty;
        public string codref4 { get; set; } = string.Empty;
        public string codref5 { get; set; } = string.Empty;
        public string ncm { get; set; } = string.Empty;
        public string empresa { get; set; } = string.Empty;
        public decimal peso_pro { get; set; }
        public decimal peso_teorico { get; set; }
        public string tp_prod { get; set; } = string.Empty;
        public decimal md_precom { get; set; }
        public decimal md_preven { get; set; }
        public decimal bonus_prc { get; set; }
        public decimal lotpad { get; set; }
        public decimal taxa_conv { get; set; }
        public decimal altura { get; set; }
        public decimal comprimento { get; set; }
        public decimal largura { get; set; }
        public decimal preco_min1 { get; set; }
        public decimal preco_max1 { get; set; }
        public decimal preco_min2 { get; set; }
        public decimal preco_max2 { get; set; }
        public decimal preco_min3 { get; set; }
        public decimal preco_max3 { get; set; }
        public decimal preco_min4 { get; set; }
        public decimal preco_max4 { get; set; }
        public decimal peso_acima { get; set; }
        public decimal prc_acima { get; set; }
        public decimal peso_ac2 { get; set; }
        public decimal prc_ac2 { get; set; }
        public decimal peso_baixo { get; set; }
        public decimal prc_baixo { get; set; }
        public bool aprovaped { get; set; }
        public bool usefis { get; set; }
        public string codfis { get; set; } = string.Empty;
        public string subfis { get; set; } = string.Empty;
        public DateTime? ult_data { get; set; }
        public string obs { get; set; } = string.Empty;
        public bool diverso { get; set; }
        public decimal rendimento { get; set; }
        public string cod_barras { get; set; } = string.Empty;
        public string tipo_barras { get; set; } = string.Empty;
        public int id_onu { get; set; }
        public string status { get; set; } = string.Empty;
        public string codcdc { get; set; } = string.Empty;
        public bool bloq_inventario { get; set; }
        public string mix_venda { get; set; } = string.Empty;
        public bool nao_obriga_mtr { get; set; }
        public bool ativo_saida_ins { get; set; }
        public int cor_producao { get; set; }
        public bool usacompetencia { get; set; }
        public bool editavalorcusto { get; set; }
        public int usoprecocusto { get; set; }
        public string tabela_servicos_codigo { get; set; } = string.Empty;
        public bool nao_movimentar { get; set; }
        public int? dias_uso { get; set; }
        public string? cad_usuario { get; set; }
        public DateTime? cad_data { get; set; }
        public bool pes_avulsa_serv { get; set; }
        public bool obriga_os_saida_ins { get; set; }
        public string? tipo_pesquisa { get; set; }
        public int id_subcategoria { get; set; }
        public bool epi_com_ca { get; set; }
        public string? epi_tamanho { get; set; }
        public bool liga { get; set; }
        public string tipo_liga { get; set; } = string.Empty;
        public bool solicitar_metragem_class { get; set; }
        public long codigo_epi { get; set; }
        public DateTime? validade_epi { get; set; }
        public string descricao_alternativa_exp { get; set; } = string.Empty;
        public decimal fator_conv_ex { get; set; }
        public string un_trib_ex { get; set; } = string.Empty;
        public bool cat8309 { get; set; }
        public string tecnologia { get; set; } = string.Empty;
        public bool usar_mtr { get; set; }
    }
}
