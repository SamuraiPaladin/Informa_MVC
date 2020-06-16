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
    public class MatriculaDAO : IDAOMatricula<Matricula>
    {
        private readonly string stringConexao = ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
        public bool Adicionar(Matricula entity)
        {

            string query = @"INSERT INTO Matriculas
               (Nome, CPF, DataNascimento, RG, CEP, Endereco, Numero, Bairro, Cidade, Estado, Telefone, Email, DataCadastro)
			    Values(@Nome, @CPF, @DataNascimento, @RG, @CEP, @Endereco, @Numero, @Bairro, @Cidade, @Estado, @Telefone, @Email, getdate());
                SELECT @@IDENTITY";

            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@DataNascimento", entity.DataNascimento);
                cmd.Parameters.AddWithValue("@CPF", entity.CPF);
                cmd.Parameters.AddWithValue("@RG", entity.RG);
                cmd.Parameters.AddWithValue("@Endereco", entity.Endereco);
                cmd.Parameters.AddWithValue("@CEP", entity.CEP);
                cmd.Parameters.AddWithValue("@Numero", entity.Numero);
                cmd.Parameters.AddWithValue("@Bairro", entity.Bairro);
                cmd.Parameters.AddWithValue("@Cidade", entity.Cidade);
                cmd.Parameters.AddWithValue("@Estado", entity.Estado);
                cmd.Parameters.AddWithValue("@Telefone", entity.Telefone);
                cmd.Parameters.AddWithValue("@Email", entity.Email);
                var ultimoIdInserido = cmd.ExecuteScalar();
                var retorno = Convert.ToInt32(ultimoIdInserido) > 0 ? true : false;
                return SalvarMatriculaTurma(entity, Convert.ToInt32(ultimoIdInserido)); ;
            }
        }

        private bool SalvarMatriculaTurma(Matricula entity, int ultimoIdInserido)
        {
            bool resultado = false;
            using (var con = new SqlConnection(stringConexao))
            {
                for (int i = 0; i < entity.Array.Length; i++)
                {
                    string query = @"INSERT INTO MatriculaTurma(IdMatricula, IdTurma)
                                VALUES(@IdMatricula, @IdTurma)";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@IdMatricula", ultimoIdInserido);
                    cmd.Parameters.AddWithValue("@IdTurma", entity.Array[i]);
                    var retorno = cmd.ExecuteNonQuery();
                    if (retorno > 0)
                        resultado = true;
                    con.Close();
                }
            }
            return resultado;
        }

        public bool Atualizar(Matricula entityAntigo, Matricula entityNovo)
        {
            string query = @"DELETE FROM MatriculaTurma WHERE IdMatricula = @IdMatricula";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IdMatricula", entityNovo.Id);
                cmd.ExecuteNonQuery();
                for (int i = 0; i < entityNovo.Array.ToList().Count; i++)
                {
                    con.Close();
                    query = @"INSERT INTO MatriculaTurma(IdMatricula, IdTurma) VALUES(@IdMatricula, @IdTurma)";
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@IdMatricula", entityNovo.Id);
                    cmd.Parameters.AddWithValue("@IdTurma", entityNovo.Array.ToList()[i]);
                    cmd.ExecuteScalar();
                }
            }

            return AtualizacaoDadosDoUsuario(entityAntigo, entityNovo);
        }

        private bool AtualizacaoDadosDoUsuario(Matricula entityAntigo, Matricula entityNovo)
        {
            string query = @"UPDATE Matriculas 
                SET
                  Nome = @NomeNovo,
                  CPF = @CPFNovo,
                  DataNascimento = @DataNascimentoNovo,
                  RG = @RGNovo,
                  CEP =  @CEPNovo,
                  Endereco = @EnderecoNovo,
                  Numero = @NumeroNovo,
                  Bairro = @BairroNovo,
                  Cidade = @CidadeNovo,
                  Estado = @EstadoNovo,
                  Telefone = @TelefoneNovo,
                  Email = @Email
                WHERE   
                  ID = @IDAntigo";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@NomeNovo", entityNovo.Nome);
                cmd.Parameters.AddWithValue("@DataNascimentoNovo", entityNovo.DataNascimento);
                cmd.Parameters.AddWithValue("@CPFNovo", entityNovo.CPF);
                cmd.Parameters.AddWithValue("@RGNovo", entityNovo.RG);
                cmd.Parameters.AddWithValue("@EnderecoNovo", entityNovo.Endereco);
                cmd.Parameters.AddWithValue("@CEPNovo", entityNovo.CEP);
                cmd.Parameters.AddWithValue("@NumeroNovo", entityNovo.Numero);
                cmd.Parameters.AddWithValue("@BairroNovo", entityNovo.Bairro);
                cmd.Parameters.AddWithValue("@CidadeNovo", entityNovo.Cidade);
                cmd.Parameters.AddWithValue("@EstadoNovo", entityNovo.Estado);
                cmd.Parameters.AddWithValue("@TelefoneNovo", entityNovo.Telefone);
                cmd.Parameters.AddWithValue("@Email", entityNovo.Email);

                cmd.Parameters.AddWithValue("@IDAntigo", entityAntigo.Id);
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
        }

        public bool Deletar(Matricula entity)
        {

            string query = @"UPDATE Matriculas SET Ativo = 0 WHERE Id = @ID";

            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", entity.Id);
                cmd.ExecuteNonQuery();
                return true;
            }
        }

        public IList<Matricula> Lista()
        {
            string query = "SELECT * FROM Matriculas WHERE Ativo = 1 ORDER BY Nome";
            List<Matricula> entity = new List<Matricula>();
            using (var con = new SqlConnection(stringConexao))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        var model = new Matricula
                        {
                            Id = (int)sdr["Id"],
                            Nome = sdr["Nome"].ToString(),
                            DataNascimento = DateTime.Parse(sdr["DataNascimento"].ToString()),
                            CPF = sdr["CPF"].ToString(),
                            RG = sdr["RG"].ToString(),
                            Endereco = sdr["Endereco"].ToString(),
                            CEP = sdr["CEP"].ToString(),
                            Numero = sdr["Numero"].ToString(),
                            Bairro = sdr["Bairro"].ToString(),
                            Cidade = sdr["Cidade"].ToString(),
                            Estado = sdr["Estado"].ToString(),
                            Telefone = sdr["Telefone"].ToString(),
                            Email = sdr["Email"].ToString()
                        };
                        entity.Add(model);
                    }
                }
                con.Close();
                return entity;
            }
        }

        public IList<MatriculaTurma> ListaMatriculaTurma()
        {
            string query = @"SELECT t.Id, count(1) Quantidade, t.Descricao, t.Tipo, t.DiaDaSemana, t.HorarioInicial, t.HorarioFinal, c.Nome
                                FROM Colaboradores c
                                JOIN Turmas t ON c.Id = t.ColaboradorId
                                GROUP BY t.id, t.Descricao, t.Tipo, t.DiaDaSemana, t.HorarioInicial, t.HorarioFinal, c.Nome
                                ORDER BY t.HorarioInicial";
            var lista = new List<MatriculaTurma>();
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    MatriculaTurma model;
                    while (sdr.Read())
                    {
                        model = new MatriculaTurma
                        {
                            Id = Convert.ToInt32(sdr["Id"])
                            ,
                            Quantidade = Convert.ToInt32(sdr["Quantidade"])
                            ,
                            Descricao = sdr["Descricao"].ToString()
                            ,
                            Tipo = sdr["Tipo"].ToString()
                            ,
                            DiaDaSemana = sdr["DiaDaSemana"].ToString()
                            ,
                            HorarioInicial = sdr["HorarioInicial"].ToString()
                            ,
                            HorarioFinal = sdr["HorarioFinal"].ToString()
                            ,
                            Nome = sdr["Nome"].ToString()
                        };
                        lista.Add(model);
                    }
                }
            }
            return lista;
        }

        public bool VerificarSeJaExiste(Matricula entity)
        {
            string query = @"SELECT COUNT(1) AS qtd
                            FROM Matriculas WHERE 
                            Nome = @Nome AND
                            DataNascimento = @DataNascimento AND
                            CPF = @CPF AND
                            RG = @RG AND
                            Endereco = @Endereco AND
                            CEP = @CEP AND
                            Numero = @Numero AND
                            Bairro =  @Bairro AND
                            Cidade = @Cidade AND
                            Estado = @Estado AND
                            Email = @Email AND
                            Telefone = @Telefone";
            return GravarERetornarVerdadeiroOuFalse(entity, query);
        }

        private bool GravarERetornarVerdadeiroOuFalse(Matricula entity, string query)
        {
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@DataNascimento", entity.DataNascimento);
                cmd.Parameters.AddWithValue("@CPF", entity.CPF);
                cmd.Parameters.AddWithValue("@RG", entity.RG);
                cmd.Parameters.AddWithValue("@Endereco", entity.Endereco);
                cmd.Parameters.AddWithValue("@CEP", entity.CEP);
                cmd.Parameters.AddWithValue("@Numero", entity.Numero);
                cmd.Parameters.AddWithValue("@Bairro", entity.Bairro);
                cmd.Parameters.AddWithValue("@Cidade", entity.Cidade);
                cmd.Parameters.AddWithValue("@Estado", entity.Estado);
                cmd.Parameters.AddWithValue("@Telefone", entity.Telefone);
                cmd.Parameters.AddWithValue("@Email", entity.Email);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0 ? true : false;
            }
        }

        public void DeletarMatriculaTurma(int id)
        {
            string query = "DELETE MatriculaTurma WHERE IdMatricula = @IdMatricula";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IdMatricula", id);
                cmd.ExecuteNonQuery();
            }
        }

        public IList<MatriculaTurma> ListaMatriulaTurmaPorId(int id)
        {
            string query = @"SELECT  t.Id, m.Nome, m.DataNascimento, m.CPF, m.RG, m.Telefone, m.CEP, m.Endereco, m.Numero, m.Bairro
                                , m.Cidade, m.Estado, t.Descricao, t.Tipo, c.Nome Colaborador, t.DiaDaSemana, t.HorarioInicial, 
                                t.HorarioFinal
                                FROM Matriculas m
                                JOIN MatriculaTurma mt ON m.Id = mt.IdMatricula
                                JOIN Turmas t ON t.id = mt.IdTurma
                                JOIN Colaboradores c ON c.Id = t.ColaboradorId
                                WHERE m.Id = @ID";
            List<MatriculaTurma> lista = new List<MatriculaTurma>();
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        var matricula = new MatriculaTurma
                        {
                            Id = Convert.ToInt32(sdr["Id"]),
                            DataNascimento = sdr["DataNascimento"].ToString(),
                            CPF = sdr["CPF"].ToString(),
                            RG = sdr["RG"].ToString(),
                            Telefone = sdr["Telefone"].ToString(),
                            CEP = sdr["CEP"].ToString(),
                            Endereco = sdr["Endereco"].ToString(),
                            Numero = sdr["Numero"].ToString(),
                            Bairro = sdr["Bairro"].ToString(),
                            Cidade = sdr["Cidade"].ToString(),
                            Estado = sdr["Estado"].ToString(),
                            Colaborador = sdr["Colaborador"].ToString(),
                            Descricao = sdr["Descricao"].ToString(),
                            Tipo = sdr["Tipo"].ToString(),
                            DiaDaSemana = sdr["DiaDaSemana"].ToString(),
                            HorarioInicial = sdr["HorarioInicial"].ToString(),
                            HorarioFinal = sdr["HorarioFinal"].ToString(),
                            Nome = sdr["Nome"].ToString(),
                            Ativo = true
                        };
                        lista.Add(matricula);
                    }
                }
            }
            return lista;
        }
        public MatriculaTurma DadosMatriculaPorId(int id)
        {
            string query = @"SELECT  * FROM Matriculas WHERE Id = @ID";
            List<MatriculaTurma> lista = new List<MatriculaTurma>();
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        return new MatriculaTurma
                        {
                            Id = Convert.ToInt32(sdr["Id"]),
                            Nome = sdr["Nome"].ToString(),
                            CPF = sdr["CPF"].ToString(),
                            DataNascimento = sdr["DataNascimento"].ToString(),
                            RG = sdr["RG"].ToString(),
                            CEP = sdr["CEP"].ToString(),
                            Endereco = sdr["Endereco"].ToString(),
                            Numero = sdr["Numero"].ToString(),
                            Bairro = sdr["Bairro"].ToString(),
                            Cidade = sdr["Cidade"].ToString(),
                            Estado = sdr["Estado"].ToString(),
                            Telefone = sdr["Telefone"].ToString(),
                            Email = sdr["Email"].ToString()
                        };
                    }
                }
                return new MatriculaTurma();
            }
        }
        public bool AtivarMatricula(Matricula entity)
        {
            string query = @"UPDATE Matriculas SET Ativo = 1 
                            WHERE 
                            Nome = @Nome AND
                            DataNascimento = @DataNascimento AND
                            CPF = @CPF AND
                            RG = @RG AND
                            Endereco = @Endereco AND
                            CEP = @CEP AND
                            Numero = @Numero AND
                            Bairro =  @Bairro AND
                            Cidade = @Cidade AND
                            Estado = @Estado AND
                            Telefone = @Telefone AND
                            Email = @Email";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@DataNascimento", entity.DataNascimento);
                cmd.Parameters.AddWithValue("@CPF", entity.CPF);
                cmd.Parameters.AddWithValue("@RG", entity.RG);
                cmd.Parameters.AddWithValue("@Endereco", entity.Endereco);
                cmd.Parameters.AddWithValue("@CEP", entity.CEP);
                cmd.Parameters.AddWithValue("@Numero", entity.Numero);
                cmd.Parameters.AddWithValue("@Bairro", entity.Bairro);
                cmd.Parameters.AddWithValue("@Cidade", entity.Cidade);
                cmd.Parameters.AddWithValue("@Estado", entity.Estado);
                cmd.Parameters.AddWithValue("@Telefone", entity.Telefone);
                cmd.Parameters.AddWithValue("@Email", entity.Email);
                return Convert.ToInt32(cmd.ExecuteNonQuery()) > 0 ? true : false;
            }
        }

        public List<int> ListaDeMensalidades(int id)
        {
            string query = @"SELECT Id FROM Mensalidades 
                                WHERE (StatusDaMensalidade = 'Em Haver' || 'ProximoDaDataDeVencimento') AND DataDeVencimento > GETDATE()
                                AND MatriculaId = @Id";
            List<int> lista = new List<int>();
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        lista.Add(Convert.ToInt32(sdr["Id"]));
                    }
                }
                return lista;
            }
        }

        public void DeletarListaMensalidade(List<int> listaIdMensalidade)
        {
            string query = "DELETE Mensalidades WHERE Id = @Id";
            using (var con = new SqlConnection(stringConexao))
            {
                foreach (var item in listaIdMensalidade)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Id", item);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}