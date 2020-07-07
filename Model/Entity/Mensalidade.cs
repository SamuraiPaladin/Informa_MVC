using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Entity
{
    public class Mensalidade
    {
        public int Id { get; set; }
        public List<Matricula> ListaMatricula{ get; set; }
        public Matricula Matricula { get; set; }
        public int MatriculaId { get; set; }
        public DateTime DataDeVencimento { get; set; }
        public Array StatusDasMensalidades { get; set; }
        public string StatusDaMensalidade { get; set; }
        public Array FormasDePagamentos { get; set; }
        public string FormaDePagamento { get; set; }
        public List<Mensalidade> ListaMensalidade { get; set; }
        public int Dia { get; set; }
        public int QuantidadeDeMeses { get; set; }
        public decimal Valor { get; set; }
        public bool EditarTodasMensalidades { get; set; }
        public bool GerarRecibo { get; set; }
        public decimal Juros { get; set; }
        public int DiasVencidos { get; set; }
        public string CPF { get; set; }
        public List<EntradasPorPagamento> EntradasPorPagamento { get; set; }
    }
}
