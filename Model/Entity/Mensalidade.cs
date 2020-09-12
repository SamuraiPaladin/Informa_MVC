namespace Model.Entity
{
    public class Mensalidade
    {
        public int Id { get; set; }
        public System.Collections.Generic.List<Matricula> ListaMatricula{ get; set; }
        public Matricula Matricula { get; set; }
        public int MatriculaId { get; set; }
        public System.DateTime DataDeVencimento { get; set; }
        public System.Array StatusDasMensalidades { get; set; }
        public string StatusDaMensalidade { get; set; }
        public System.Array FormasDePagamentos { get; set; }
        public string FormaDePagamento { get; set; }
        public System.Collections.Generic.List<Mensalidade> ListaMensalidade { get; set; }
        public int Dia { get; set; }
        public int QuantidadeDeMeses { get; set; }
        public decimal Valor { get; set; }
        public bool EditarTodasMensalidades { get; set; }
        public bool GerarRecibo { get; set; }
        public decimal Juros { get; set; }
        public int DiasVencidos { get; set; }
        public string CPF { get; set; }
        public System.Collections.Generic.List<EntradasPorPagamento> EntradasPorPagamento { get; set; }

        public System.DateTime DataInicial { get; set; }
        public System.DateTime DataFinal { get; set; }
    }
}
