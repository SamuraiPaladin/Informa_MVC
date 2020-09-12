namespace Web.Model.Entity
{
    public class ConsultaPagamento
    {
        public System.DateTime DataInicial { get; set; }
        public System.DateTime DataFinal { get; set; }
        public string Dias { get; set; }
        public decimal Credito { get; set; }
        public decimal Debito { get; set; }
        public decimal Dinheiro { get; set; }
    }
}
