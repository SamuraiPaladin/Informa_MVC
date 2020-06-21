using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Model.Entity
{
    public class Aula
    {
        public int MatriculaId { get; set; }
        public int TurmaId { get; set; }
        public int AulaId { get; set; }
        public string NomeColaborador { get; set; }
        public string TipoFaixaEtaria { get; set; }
        public string DiaDaSemana { get; set; }
        public string HorarioInicial { get; set; }
        public string HorarioFinal { get; set; }
        public string DescricaoTurma { get; set; }
        public bool Presenca { get; set; }
        public string NomeAluno { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string DataNascimento { get; set; }
        public DateTime Data { get; set; }
        public string TipoModalidade { get; set; }
    }
}
