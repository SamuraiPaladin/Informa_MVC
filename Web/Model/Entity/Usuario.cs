namespace Web.Model.Entity
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string PerfilUsuario { get; set; }
        public int IdColaborador { get; set; }
        public string NomeColaborador { get; set; }
        public System.Collections.Generic.IList<Colaborador> ListaDeColaboradores { get; set; }
        public System.Collections.Generic.IList<Usuario> ListaDeUsuarios { get; set; }
    }
}
