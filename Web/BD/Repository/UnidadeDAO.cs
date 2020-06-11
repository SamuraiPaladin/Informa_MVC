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
    public class UnidadeDAO : IUnidadeDAO<Unidade>
    {
        private readonly string stringConexao = ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
        public bool Adicionar(Unidade entity)
        {
            string query = @"INSERT INTO Unidades(Descricao, Endereco, Numero, Cep, Telefone, Bairro, Cidade, Estado)
			                    Values(@Descricao, @Endereco, @Numero, @Cep, @Telefone, @Bairro, @Cidade, @Estado);
                             SELECT @@IDENTITY";
            return GravarERetornarVerdadeiroOuFalse(entity, query, 1);
        }
        public bool Atualizar(Unidade entityAntigo, Unidade entityNovo)
        {
            string query = @"UPDATE Unidades 
                                SET Endereco = @Endereco, Numero = @Numero, CEP = @CEP, Estado = @Estado,
                                	Telefone = @Telefone, Bairro = @Bairro, Cidade = @Cidade
                                WHERE Endereco = @AntigoEndereco AND Numero = @AntigoNumero AND CEP = @AntigoCEP AND Estado = @AntigoEstado
                                	AND Telefone = @AntigoTelefone AND Bairro = @AntigoBairro AND Cidade = @AntigoCidade";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Endereco", entityNovo.Endereco);
                cmd.Parameters.AddWithValue("@Numero", entityNovo.Numero);
                cmd.Parameters.AddWithValue("@CEP", entityNovo.CEP);
                cmd.Parameters.AddWithValue("@Estado", entityNovo.Estado);
                cmd.Parameters.AddWithValue("@Telefone", entityNovo.Telefone);
                cmd.Parameters.AddWithValue("@Bairro", entityNovo.Bairro);
                cmd.Parameters.AddWithValue("@Cidade", entityNovo.Cidade);
                cmd.Parameters.AddWithValue("@Descricao", entityNovo.Descricao);

                cmd.Parameters.AddWithValue("@AntigoEndereco", entityAntigo.Endereco);
                cmd.Parameters.AddWithValue("@AntigoNumero", entityAntigo.Numero);
                cmd.Parameters.AddWithValue("@AntigoCEP", entityAntigo.CEP);
                cmd.Parameters.AddWithValue("@AntigoEstado", entityAntigo.Estado);
                cmd.Parameters.AddWithValue("@AntigoTelefone", entityAntigo.Telefone);
                cmd.Parameters.AddWithValue("@AntigoBairro", entityAntigo.Bairro);
                cmd.Parameters.AddWithValue("@AntigoCidade", entityAntigo.Cidade);
                cmd.Parameters.AddWithValue("@AntigoDescricao", entityAntigo.Descricao);
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
        }
        public bool Deletar(Unidade entity)
        {
            string query = @"DELETE FROM Unidades
                            WHERE Endereco = @Endereco AND Numero = @Numero AND CEP = @CEP AND Estado = @Estado
                                	AND Telefone = @Telefone AND Bairro = @Bairro AND Cidade = @Cidade";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Endereco", entity.Endereco);
                cmd.Parameters.AddWithValue("@Numero", entity.Numero);
                cmd.Parameters.AddWithValue("@CEP", entity.CEP);
                cmd.Parameters.AddWithValue("@Estado", entity.Estado);
                cmd.Parameters.AddWithValue("@Telefone", entity.Telefone);
                cmd.Parameters.AddWithValue("@Bairro", entity.Bairro);
                cmd.Parameters.AddWithValue("@Cidade", entity.Cidade);
                cmd.Parameters.AddWithValue("@Descricao", entity.Descricao);
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
        }

        public IList<Unidade> Lista()
        {
            string query = "SELECT * FROM Unidades Order by Descricao";
            IList<Unidade> lista = new List<Unidade>();
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        var model = new Unidade
                        {
                            Bairro = sdr["bairro"].ToString(),
                            CEP = sdr["cep"].ToString(),
                            Cidade = sdr["cidade"].ToString(),
                            Descricao = sdr["descricao"].ToString(),
                            Endereco = sdr["endereco"].ToString(),
                            Estado = sdr["estado"].ToString(),
                            Numero = sdr["numero"].ToString(),
                            Telefone = sdr["telefone"].ToString()
                        };
                        lista.Add(model);
                    }
                }
                return lista;
            }
        }
        public bool VerificarSeJaExiste(Unidade entity, int acao)
        {
            string query = acao == 1 ? @"SELECT 
                                	count(1) as qtd
                                FROM 
                                	Unidades 
                                WHERE 
                                    Descricao = @Descricao AND
                                    Endereco = @Endereco AND
                                    Numero   = @Numero AND
                                    CEP      = @CEP AND
                                    Estado   = @Estado AND
                                    Telefone = @Telefone AND
                                    Bairro  =  @Bairro AND
                                    Cidade =   @Cidade 
                                "
                                   : 
                                
                                @"SELECT 
                                	count(1) as qtd
                                FROM 
                                	Unidades 
                                WHERE 
                                    Descricao = @Descricao";
            return GravarERetornarVerdadeiroOuFalse(entity, query, acao);
        }


        private bool GravarERetornarVerdadeiroOuFalse(Unidade entity, string query, int acao)
        {
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Descricao", entity.Descricao);
                if (acao == 1) {
                    cmd.Parameters.AddWithValue("@Endereco", entity.Endereco);
                    cmd.Parameters.AddWithValue("@Numero", entity.Numero);
                    cmd.Parameters.AddWithValue("@CEP", entity.CEP);
                    cmd.Parameters.AddWithValue("@Estado", entity.Estado);
                    cmd.Parameters.AddWithValue("@Telefone", entity.Telefone);
                    cmd.Parameters.AddWithValue("@Bairro", entity.Bairro);
                    cmd.Parameters.AddWithValue("@Cidade", entity.Cidade);
                }
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0 ? true : false;
            }
        }
    }
}