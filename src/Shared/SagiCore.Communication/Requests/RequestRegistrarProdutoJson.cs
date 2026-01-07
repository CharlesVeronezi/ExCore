using System;
using System.Collections.Generic;
using System.Text;

namespace SagiCore.Communication.Requests
{
    public class RequestRegistrarProdutoJson
    {
        public string codpro { get; set; } = string.Empty;
        public string subcod { get; set; } = string.Empty;
        public string produto { get; set; } = string.Empty;
        public string un { get; set; }  = string.Empty;
        public string tp_prod { get; set; } = string.Empty;
        public string ncm { get; set; } = string.Empty;
        public bool diverso { get; set; } = false;
        public int codcat { get; set; } = 0;
        public string tipo_pesquisa { get; set; } = string.Empty;
        public string codref1 { get; set; } = string.Empty;
    }
}
