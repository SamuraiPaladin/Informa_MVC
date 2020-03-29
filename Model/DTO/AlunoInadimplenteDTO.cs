using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.DTO
{
    public class AlunoInadimpente
    {
        //entity modalidade
        public AlunoInadimpente()
        {
        }
        public int IdAluno { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public int IdMensalidade { get; set; }
        public DateTime DataDeVencimento { get; set; }
        public string StatusDaMensalidade { get; set; }
        public List<AlunoInadimpente> AlunosInadimplentes { get; set; }
    }
}
