using Microsoft.Data.SqlClient;
using Web.Model.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Caching;
using Web.BD.Interface;

namespace Web.BD.Repository
{
    public class UsuarioDAO : IUsuarioDAO<Usuario>
    {
        private readonly string stringConexao = ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
        public bool Adicionar(Usuario entity)
        {
            string query = @"INSERT Usuarios(Nome, Perfil, Senha, IdColaborador) 
                                VALUES(@Nome, @Perfil, PWDENCRYPT(@Senha), @IdColab )";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@Perfil", entity.PerfilUsuario);
                cmd.Parameters.AddWithValue("@Senha", entity.Senha);
                cmd.Parameters.AddWithValue("@IdColab", entity.IdColaborador);
                return Convert.ToInt32(cmd.ExecuteNonQuery()) > 0 ? true : false;
            }
        }

        public bool Atualizar(Usuario entity)
        {
            string query = @"UPDATE Usuarios SET Nome = @Nome, Perfil = @Perfil, Senha = PWDENCRYPT(@Senha) FROM Usuarios WHERE Id = @Id";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@Perfil", entity.PerfilUsuario);
                cmd.Parameters.AddWithValue("@Senha", entity.Senha);
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                //cmd.Parameters.AddWithValue("@IdColab", entity.IdColaborador);
                return Convert.ToInt32(cmd.ExecuteNonQuery()) > 0 ? true : false;
            }
        }

        public Usuario DadosDoUsuario(int id)
        {
            string query = @"SELECT u.Id, u.Nome, Perfil, IdColaborador, c.Nome NomeColaborador FROM Usuarios u
                                JOIN Colaboradores c ON c.Id = u.IdColaborador WHERE u.Id = @Id";
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                var usuario = new Usuario();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        usuario = new Usuario()
                        {
                            PerfilUsuario = sdr["Perfil"].ToString(),
                            Nome = sdr["Nome"].ToString(),
                            Id = Convert.ToInt32(sdr["Id"]),
                            IdColaborador = Convert.ToInt32(sdr["IdColaborador"]),
                            NomeColaborador = sdr["NomeColaborador"].ToString()
                        };

                    }
                }
                return usuario;
            }
        }

        public bool Deletar(Usuario entity)
        {
            string query = @"DELETE Usuarios WHERE Id = @Id";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                return Convert.ToInt32(cmd.ExecuteNonQuery()) > 0 ? true : false;
            }
        }

        public IList<Usuario> Lista()
        {
            string query = @"SELECT u.Id, u.Nome, Perfil, IdColaborador, c.Nome NomeColaborador FROM Usuarios u
                                JOIN Colaboradores c ON c.Id = u.IdColaborador";
            var listaDeUsuarios = new List<Usuario>();
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        var usuario = new Usuario()
                        {
                            Id = Convert.ToInt32(sdr["Id"]),
                            Nome = sdr["Nome"].ToString(),
                            PerfilUsuario = sdr["Perfil"].ToString(),
                            IdColaborador = Convert.ToInt32(sdr["IdColaborador"]),
                            NomeColaborador = sdr["NomeColaborador"].ToString()
                        };
                        listaDeUsuarios.Add(usuario);
                    }
                }
            }
            return listaDeUsuarios;
        }

        public Usuario Autentica(Usuario entity)
        {
            string query = "SELECT Id FROM Usuarios WHERE Nome = @Nome AND PWDCOMPARE(@Senha, Senha) = 1";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@Senha", entity.Senha);
                SqlDataReader sdr = cmd.ExecuteReader();
                Usuario usuario = new Usuario();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        usuario = DadosDoUsuario(Convert.ToInt32(sdr["Id"]));
                    }
                }

                return usuario;
            }
        }

        public bool VerificarSeJaExiste(Usuario entity)
        {
            string query = "SELECT count(1) FROM Usuarios WHERE Nome = @Nome";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0 ? true : false;
            }
        }

        public bool ValidaUsuarioNoCache()
        {
            return new Cache()["DadosDoUsuario"] != null ? true : false;
        }

        public IList<Colaborador> ListaColaboradores()
        {
            string query = "SELECT Id, Nome FROM Colaboradores";
            var listaDeColaborador = new List<Colaborador>();
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        var colaborador = new Colaborador()
                        {
                            Id = Convert.ToInt32(sdr["Id"]),
                            Nome = sdr["Nome"].ToString(),
                        };
                        listaDeColaborador.Add(colaborador);
                    }
                }
            }
            return listaDeColaborador;
        }
    }
}