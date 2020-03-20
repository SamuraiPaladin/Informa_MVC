using Model.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.BD.Interface;

namespace Web.BD.Repository
{
    public class FuncaoDAO : IDAO<Funcao>
    {
        private readonly string stringConexao = ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
        public bool Adicionar(Funcao entity)
        {
            string query = @"INSERT INTO Funcoes(Descricao, TipoFuncao) VALUES(@Descricao, @TipoFuncao);
                            SELECT @@IDENTITY";
            return GravarERetornarVerdadeiroOuFalse(entity, query);
        }
        public bool Atualizar(Funcao entityAntigo, Funcao entityNovo)
        {
            string query = @"UPDATE Funcoes SET Descricao = @DescricaoNovo, TipoFuncao = @TipoFuncaoNovo
                                WHERE Descricao = @DescricaoAntigo AND TipoFuncao = @TipoFuncaoAntigo";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DescricaoNovo", entityNovo.Descricao);
                cmd.Parameters.AddWithValue("@TipoFuncaoNovo", entityNovo.TipoFuncao);

                cmd.Parameters.AddWithValue("@DescricaoAntigo", entityAntigo.Descricao);
                cmd.Parameters.AddWithValue("@TipoFuncaoAntigo", entityAntigo.TipoFuncao);
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
        }

        public bool Deletar(Funcao entity)
        {
            string query = "DELETE FROM Funcoes WHERE Descricao = @Descricao AND TipoFuncao = @TipoFuncao";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Descricao", entity.Descricao);
                cmd.Parameters.AddWithValue("@TipoFuncao", entity.TipoFuncao);
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
        }

        public IList<Funcao> Lista()
        {
            string query = "SELECT * FROM Funcoes Order by Descricao";
            IList<Funcao> lista = new List<Funcao>();
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        var model = new Funcao
                        {
                            Ativo = Convert.ToBoolean(sdr["Ativo"]),
                            Descricao = sdr["Descricao"].ToString(),
                            TipoFuncao = sdr["TipoFuncao"].ToString()
                        };
                        lista.Add(model);
                    }
                }
                return lista;
            }
        }
        public bool VerificarSeJaExiste(Funcao entity)
        {
            string query = @"SELECT 
                                	count(1) as qtd
                                FROM 
                                	Funcoes
                                WHERE 
                                	TipoFuncao = @TipoFuncao AND Descricao = @Descricao";
            return GravarERetornarVerdadeiroOuFalse(entity, query);
        }
        private bool GravarERetornarVerdadeiroOuFalse(Funcao entity, string query)
        {
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Descricao", entity.Descricao);
                cmd.Parameters.AddWithValue("@TipoFuncao", entity.TipoFuncao);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0 ? true : false;
            }
        }
    }
}