namespace Web.Model.Entity
{
    public class Turma
    {
        public int Id { get; set; }
        public System.Collections.Generic.List<Unidade> ListaUnidade { get; set; }
        public Unidade Unidade { get; set; }
        public int UnidadeId { get; set; }
        public System.Collections.Generic.List<Modalidade> ListaModalidade { get; set; }
        public Modalidade Modalidade { get; set; }
        public int ModalidadeId { get; set; }
        public string Descricao { get; set; }
        public int ColaboradorId { get; set; }
        public System.Collections.Generic.List<Colaborador> ListaColaborador { get; set; }
        public Colaborador Colaborador { get; set; }
        public string Tipo { get; set; }
        public System.Array TipoClientes { get; set; }
        public string DiaDaSemana { get; set; }
        public System.Array DiasDaSemana { get; set; }
        public string HorarioInicial { get; set; }
        public string HorarioFinal { get; set; }
        public System.Collections.Generic.List<Turma> ListaTurma { get; set; } 
    }
}
