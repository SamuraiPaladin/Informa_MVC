namespace Model.Entity
{
    public class Matricula
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public System.DateTime DataNascimento { get; set; }
        public string RG { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public System.Collections.Generic.IList<MatriculaTurma> ListaMatriculaTurma { get; set; }
        public System.Collections.Generic.List<Matricula> ListaMatricula { get; set; }
        public string[] Array { get; set; }
        public MatriculaTurma DadosMatriculaTurma { get; set; }
        public string DescTelefone { get; set; }
        public string Telefone2 { get; set; }
        public string DescTelefone2 { get; set; }
        public string Telefone3 { get; set; }
        public string DescTelefone3 { get; set; }
        public int GerarNota { get; set; }
        public string NomeReponsavel { get; set; }
        public string Parentesco { get; set; }
        public System.DateTime DataNascimentoResponsavel { get; set; }
        public int MenorIdade { get; set; }
        public bool Ativo { get; set; }
    }
}
