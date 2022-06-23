using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoFitz.Models
{
    public class XmlModel
    {
        public List<int> Codigo = new List<int>();
        public List<string> Nome = new List<string>();
        public List<string> TipoItem = new List<string>();
        public List<double> QuantidadeCX = new List<double>();
        public List<double> ValorUnitatiro = new List<double>();
        public List<double> ValorTotalCx = new List<double>();
        public double PrecoFinal { get; set; }
        public List<int> Porcetagem = new List<int>();
        public List<int> QuantidadeUN = new List<int>();
        public List<double> QuantidadeKG = new List<double>();
    }
}
