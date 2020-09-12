namespace Web.Model.Entity
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nome {get; set;} 
        public System.DateTime DataNascimento {get; set;} 
        public string CPF {get; set;} 
        public string RG { get; set;} 
        public string Endereco { get; set;}
        public string CEP { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set;} 
        public Funcao Funcao { get; set;} 
        public int FuncaoId { get; set;}
        public System.Collections.Generic.List<Funcao> ListaFuncao { get; set; }
        public System.Collections.Generic.List<Colaborador> ListaColaborador { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public string DataCadastro { get; set; }

    }
}
