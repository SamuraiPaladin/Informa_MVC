using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entity
{
    public class ConsultaPagamento
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string Dias { get; set; }
        public decimal Credito { get; set; }
        public decimal Debito { get; set; }
        public decimal Dinheiro { get; set; }
    }
}
