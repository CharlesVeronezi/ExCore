namespace SagiCore.Communication.Responses.Operacional.PedidoVenda
{
    public class ResponseRegisteredPedidoVendaJson
    {
        public int pednum { get; set; }
        public DateTime dataped { get; set; }
        public int codcli { get; set; }
        public string cliente { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public List<ResponsePedidoVendaItemJson> itens { get; set; } = [];
    }

    public class ResponsePedidoVendaItemJson
    {
        public string codpro { get; set; } = string.Empty;
        public string produto { get; set; } = string.Empty;
        public decimal peso { get; set; }
        public decimal preco { get; set; }
        public decimal total { get; set; }
    }
}
