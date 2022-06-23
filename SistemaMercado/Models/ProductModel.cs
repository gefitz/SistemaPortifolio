namespace MercadoFitz.Models
{
    public class ProductModel
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double QuantidadeCX { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorTotalCx { get; set; }
        public double PrecoFinal { get; set; }
        public string Porcetagem { get; set; }
        public int QuantidadeUN { get; set; }
        public double QuantidadeKG { get; set; }
    }
}
