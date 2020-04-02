using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Entity
{
    public class Mensalidade
    {
        public int Id { get; set; }
        public List<Aluno> ListaAluno { get; set; }
        public Aluno Aluno { get; set; }
        public int AlunoId { get; set; }
        public List<Modalidade> ListaModalidade { get; set; }
        public Modalidade Modalidade { get; set; }
        public int ModalidadeId { get; set; }
        //[Required(ErrorMessage = "Preenchimento obrigatório campo Descrição")]
        public List<Turma> ListaTurma { get; set; }
        public Turma Turma { get; set; }
        public int TurmaId { get; set; }
        public DateTime DataDeVencimento { get; set; }
        public Array StatusDasMensalidades { get; set; }
        public string StatusDaMensalidade { get; set; }
        public Array FormasDePagamentos { get; set; }
        public string FormaDePagamento { get; set; }
        public List<Mensalidade> ListaMensalidade { get; set; }
    }
}
