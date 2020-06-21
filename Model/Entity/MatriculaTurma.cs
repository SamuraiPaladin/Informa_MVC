using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entity
{
    public class MatriculaTurma
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public string DataNascimento { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Telefone { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Colaborador { get; set; }
        public int Quantidade { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public string DiaDaSemana { get; set; }
        public string HorarioInicial { get; set; }
        public string HorarioFinal { get; set; }
        public string Nome { get; set; }

    }
}
