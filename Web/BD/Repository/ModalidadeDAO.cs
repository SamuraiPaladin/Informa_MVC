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
    public class ModalidadeDAO : IDAO<Modalidade>
    {
        private readonly string stringConexao = ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
        public bool Adicionar(Modalidade entity)
        {
            string query = @"INSERT INTO Modalidades(Descricao, TipoModalidade) VALUES(@Descricao, @TipoModalidade);
                            SELECT @@IDENTITY";
            return GravarERetornarVerdadeiroOuFalse(entity, query);
        }
        public bool Atualizar(Modalidade entityAntigo, Modalidade entityNovo)
        {
            string query = @"UPDATE Modalidades SET Descricao = @DescricaoNovo, TipoModalidade = @TipoModalidadeNovo
                                WHERE Descricao = @DescricaoAntigo AND TipoModalidade = @TipoModalidadeAntigo";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DescricaoNovo", entityNovo.Descricao);
                cmd.Parameters.AddWithValue("@TipoModalidadeNovo", entityNovo.TipoModalidade);

                cmd.Parameters.AddWithValue("@DescricaoAntigo", entityAntigo.Descricao);
                cmd.Parameters.AddWithValue("@TipoModalidadeAntigo", entityAntigo.TipoModalidade);
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
        }

        public bool Deletar(Modalidade entity)
        {
            string query = "DELETE FROM Modalidades WHERE Descricao = @Descricao AND TipoModalidade = @TipoModalidade";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Descricao", entity.Descricao);
                cmd.Parameters.AddWithValue("@TipoModalidade", entity.TipoModalidade);
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
        }

        public IList<Modalidade> Lista()
        {
            string query = "SELECT * FROM Modalidades Order by Descricao";
            IList<Modalidade> lista = new List<Modalidade>();
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        var model = new Modalidade
                        {
                            Ativo = Convert.ToBoolean(sdr["Ativo"]),
                            Descricao = sdr["Descricao"].ToString(),
                            TipoModalidade = sdr["TipoModalidade"].ToString()
                        };
                        lista.Add(model);
                    }
                }
                return lista;
            }
        }
        public bool VerificarSeJaExiste(Modalidade entity)
        {
            string query = @"SELECT 
                                	count(1) as qtd
                                FROM 
                                	Modalidades
                                WHERE 
                                	TipoModalidade = @TipoModalidade AND Descricao = @Descricao";
            return GravarERetornarVerdadeiroOuFalse(entity, query);
        }
        private bool GravarERetornarVerdadeiroOuFalse(Modalidade entity, string query)
        {
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Descricao", entity.Descricao);
                cmd.Parameters.AddWithValue("@TipoModalidade", entity.TipoModalidade);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0 ? true : false;
            }
        }
    }
}