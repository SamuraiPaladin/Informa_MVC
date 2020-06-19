using Microsoft.Data.SqlClient;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Web.BD.Interface;

namespace Web.BD.Repository
{
    public class UsuarioDAO : IUsuarioDAO<Usuario>
    {
        private readonly string stringConexao = ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
        public bool Adicionar(Usuario entity)
        {
            string query = @"INSERT Usuarios(Nome, Perfil, Senha) 
                                VALUES(@Nome, @Perfil, PWDENCRYPT(@Senha) )";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nome",entity.Nome);
                cmd.Parameters.AddWithValue("@Perfil",entity.PerfilUsuario);
                cmd.Parameters.AddWithValue("@Senha",entity.Senha);
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
                return Convert.ToInt32(cmd.ExecuteNonQuery()) > 0 ? true : false;
            }
        }

        public Usuario DadosDoUsuario(int id)
        {
            string query = @"SELECT Id, Nome, Perfil  FROM  Usuarios WHERE Id = @Id";
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
                            Id = Convert.ToInt32(sdr["Id"])
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
            string query = "SELECT Id, Nome, Perfil FROM Usuarios";
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
                            PerfilUsuario = sdr["Perfil"].ToString()
                        };
                        listaDeUsuarios.Add(usuario);
                    }
                }
            }
            return listaDeUsuarios;
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
    }
}