using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SagiCore.Cadastros.Domain.Entities;

namespace SagiCore.Cadastros.Infrastructure.Persistence.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("cag_pro");
            builder.HasKey(p => new { p.codpro, p.subcod });

            builder.Property(p => p.codpro).HasColumnName("codpro").HasMaxLength(15).IsRequired();
            builder.Property(p => p.subcod).HasColumnName("subcod").HasMaxLength(4).IsRequired();

            builder.Property(p => p.produto).HasColumnName("produto").HasMaxLength(60).IsRequired();
            builder.Property(p => p.produto_complemento).HasColumnName("produto_complemento").HasMaxLength(60);
            builder.Property(p => p.subprod).HasColumnName("subprod").HasMaxLength(60);
            builder.Property(p => p.un).HasColumnName("un").HasMaxLength(3);
            builder.Property(p => p.codcat).HasColumnName("codcat");
            builder.Property(p => p.nomeest).HasColumnName("nomeest").HasMaxLength(80);
            builder.Property(p => p.comrec).HasColumnName("comrec").HasMaxLength(100);
            builder.Property(p => p.codref1).HasColumnName("codref1").HasMaxLength(30);
            builder.Property(p => p.codref2).HasColumnName("codref2").HasMaxLength(30);
            builder.Property(p => p.codref3).HasColumnName("codref3").HasMaxLength(30);
            builder.Property(p => p.codref4).HasColumnName("codref4").HasMaxLength(30);
            builder.Property(p => p.codref5).HasColumnName("codref5").HasMaxLength(30);
            builder.Property(p => p.ncm).HasColumnName("ncm").HasMaxLength(10);
            builder.Property(p => p.empresa).HasColumnName("empresa").HasMaxLength(20);

            builder.Property(p => p.peso_pro).HasColumnName("peso_pro").HasPrecision(19, 5);
            builder.Property(p => p.peso_teorico).HasColumnName("peso_teorico").HasPrecision(19, 5);
            builder.Property(p => p.tp_prod).HasColumnName("tp_prod").HasMaxLength(2);
            builder.Property(p => p.md_precom).HasColumnName("md_precom").HasPrecision(19, 5);
            builder.Property(p => p.md_preven).HasColumnName("md_preven").HasPrecision(19, 5);
            builder.Property(p => p.bonus_prc).HasColumnName("bonus_prc").HasPrecision(19, 5);
            builder.Property(p => p.lotpad).HasColumnName("lotpad").HasPrecision(19, 5);
            builder.Property(p => p.taxa_conv).HasColumnName("taxa_conv").HasPrecision(19, 5);
            builder.Property(p => p.altura).HasColumnName("altura").HasPrecision(19, 5);
            builder.Property(p => p.comprimento).HasColumnName("comprimento").HasPrecision(19, 5);
            builder.Property(p => p.largura).HasColumnName("largura").HasPrecision(19, 5);
            builder.Property(p => p.preco_min1).HasColumnName("preco_min1").HasPrecision(19, 5);
            builder.Property(p => p.preco_max1).HasColumnName("preco_max1").HasPrecision(19, 5);
            builder.Property(p => p.preco_min2).HasColumnName("preco_min2").HasPrecision(19, 5);
            builder.Property(p => p.preco_max2).HasColumnName("preco_max2").HasPrecision(19, 5);
            builder.Property(p => p.preco_min3).HasColumnName("preco_min3").HasPrecision(19, 5);
            builder.Property(p => p.preco_max3).HasColumnName("preco_max3").HasPrecision(19, 5);
            builder.Property(p => p.preco_min4).HasColumnName("preco_min4").HasPrecision(19, 5);
            builder.Property(p => p.preco_max4).HasColumnName("preco_max4").HasPrecision(19, 5);

            builder.Property(p => p.peso_acima).HasColumnName("peso_acima").HasPrecision(19, 5);
            builder.Property(p => p.prc_acima).HasColumnName("prc_acima").HasPrecision(19, 5);
            builder.Property(p => p.peso_ac2).HasColumnName("peso_ac2").HasPrecision(19, 5);
            builder.Property(p => p.prc_ac2).HasColumnName("prc_ac2").HasPrecision(19, 5);
            builder.Property(p => p.peso_baixo).HasColumnName("peso_baixo").HasPrecision(19, 5);
            builder.Property(p => p.prc_baixo).HasColumnName("prc_baixo").HasPrecision(19, 5);

            builder.Property(p => p.aprovaped).HasColumnName("aprovaped");
            builder.Property(p => p.usefis).HasColumnName("usefis");
            builder.Property(p => p.codfis).HasColumnName("codfis").HasMaxLength(20);
            builder.Property(p => p.subfis).HasColumnName("subfis").HasMaxLength(20);
            builder.Property(p => p.ult_data).HasColumnName("ult_data");
            builder.Property(p => p.obs).HasColumnName("obs").HasMaxLength(255);
            builder.Property(p => p.diverso).HasColumnName("diverso");
            builder.Property(p => p.rendimento).HasColumnName("rendimento").HasPrecision(19, 5);
            builder.Property(p => p.cod_barras).HasColumnName("cod_barras").HasMaxLength(50);
            builder.Property(p => p.tipo_barras).HasColumnName("tipo_barras").HasMaxLength(10);
            builder.Property(p => p.id_onu).HasColumnName("id_onu");
            builder.Property(p => p.status).HasColumnName("status").HasMaxLength(1);
            builder.Property(p => p.codcdc).HasColumnName("codcdc").HasMaxLength(20);
            builder.Property(p => p.bloq_inventario).HasColumnName("bloq_inventario");
            builder.Property(p => p.mix_venda).HasColumnName("mix_venda").HasMaxLength(2);
            builder.Property(p => p.nao_obriga_mtr).HasColumnName("nao_obriga_mtr");
            builder.Property(p => p.ativo_saida_ins).HasColumnName("ativo_saida_ins");
            builder.Property(p => p.cor_producao).HasColumnName("cor_producao");
            builder.Property(p => p.usacompetencia).HasColumnName("usacompetencia");
            builder.Property(p => p.editavalorcusto).HasColumnName("editavalorcusto");
            builder.Property(p => p.usoprecocusto).HasColumnName("usoprecocusto");
            builder.Property(p => p.tabela_servicos_codigo).HasColumnName("tabela_servicos_codigo").HasMaxLength(10);
            builder.Property(p => p.nao_movimentar).HasColumnName("nao_movimentar");
            builder.Property(p => p.dias_uso).HasColumnName("dias_uso");
            builder.Property(p => p.cad_usuario).HasColumnName("cad_usuario").HasMaxLength(25);
            builder.Property(p => p.cad_data).HasColumnName("cad_data");
            builder.Property(p => p.pes_avulsa_serv).HasColumnName("pes_avulsa_serv");
            builder.Property(p => p.obriga_os_saida_ins).HasColumnName("obriga_os_saida_ins");
            builder.Property(p => p.tipo_pesquisa).HasColumnName("tipo_pesquisa").HasMaxLength(10);
            builder.Property(p => p.id_subcategoria).HasColumnName("id_subcategoria");
            builder.Property(p => p.epi_com_ca).HasColumnName("epi_com_ca");
            builder.Property(p => p.epi_tamanho).HasColumnName("epi_tamanho").HasMaxLength(10);
            builder.Property(p => p.liga).HasColumnName("liga");
            builder.Property(p => p.tipo_liga).HasColumnName("tipo_liga").HasMaxLength(4);
            builder.Property(p => p.solicitar_metragem_class).HasColumnName("solicitar_metragem_class");
            builder.Property(p => p.codigo_epi).HasColumnName("codigo_epi");
            builder.Property(p => p.validade_epi).HasColumnName("validade_epi");
            builder.Property(p => p.descricao_alternativa_exp).HasColumnName("descricao_alternativa_exp").HasMaxLength(120);
            builder.Property(p => p.fator_conv_ex).HasColumnName("fator_conv_ex").HasPrecision(19, 5);
            builder.Property(p => p.un_trib_ex).HasColumnName("un_trib_ex").HasMaxLength(3);
            builder.Property(p => p.cat8309).HasColumnName("cat8309");
            builder.Property(p => p.tecnologia).HasColumnName("tecnologia").HasMaxLength(120);
            builder.Property(p => p.usar_mtr).HasColumnName("usar_mtr");
            // Auditoria/base:
            builder.Property(p => p.CriadoEm).HasColumnName("created_at");
            builder.Property(p => p.AtualizadoEm).HasColumnName("updated_at");
            builder.Property(p => p.CriadoPor).HasColumnName("created_by").HasMaxLength(50);
            builder.Property(p => p.AtualizadoPor).HasColumnName("updated_by").HasMaxLength(50);
        }
    }
}