using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Model
{
    public class ProdutoModel
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double QuantidadeCX { get; set; }
        public double ValorUnitatiro { get; set; }
        public double ValorTotalCx { get; set; }
        public double PrecoFinal { get; set; }
        public string Porcetagem { get; set; }
        public int QuantidadeUN { get; set; }
        public double QuantidadeKG { get; set; }

    }

}
