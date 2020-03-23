using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Entity
{
    public class Turma
    {
        public int Id { get; set; }
        public List<Unidade> ListaUnidade { get; set; }
        public Unidade Unidade { get; set; }
        public int UnidadeId { get; set; }
        public List<Modalidade> ListaModalidade { get; set; }
        public Modalidade Modalidade { get; set; }
        public int ModalidadeId { get; set; }
        //[Required(ErrorMessage = "Preenchimento obrigatório campo Descrição")]
        public string Descricao { get; set; }
        public int ColaboradorId { get; set; }
        public List<Colaborador> ListaColaborador { get; set; }
        public Colaborador Colaborador { get; set; }
        public string Tipo { get; set; }
        public string DiaDaSemana { get; set; }
        public string HorarioInicial { get; set; }
        public string HorarioFinal { get; set; }
        public List<Turma> ListaTurma { get; set; } 
    }
}
