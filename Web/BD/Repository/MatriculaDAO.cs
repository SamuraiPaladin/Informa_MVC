using Model.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
               (Nome, CPF, DataNascimento, RG, CEP, Endereco, Numero, Bairro, Cidade, Estado, Telefone, Email, DataCadastro, DescTelefone, Telefone2, DescTelefone2, Telefone3, DescTelefone3, GerarNota, DataNascimentoResponsavel, MenorIdade, NomeResponsavel, GrauParentesco)
			    Values(@Nome, @CPF, @DataNascimento, @RG, @CEP, @Endereco, @Numero, @Bairro, @Cidade, @Estado, @Telefone, @Email, getdate(), @DescTelefone,  @Telefone2, @DescTelefone2, @Telefone3, @DescTelefone3, @GerarNota, @DataNascimentoResponsavel, @MenorIdade, @NomeResponsavel, @GrauParentesco);
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
                cmd.Parameters.AddWithValue("@DescTelefone", string.IsNullOrEmpty(entity.DescTelefone) ? SqlString.Null : entity.DescTelefone);
                cmd.Parameters.AddWithValue("@Telefone2", string.IsNullOrEmpty(entity.Telefone2) ? SqlString.Null : entity.Telefone2);
                cmd.Parameters.AddWithValue("@DescTelefone2", string.IsNullOrEmpty(entity.DescTelefone2) ? SqlString.Null : entity.DescTelefone2);
                cmd.Parameters.AddWithValue("@Telefone3", string.IsNullOrEmpty(entity.Telefone3) ? SqlString.Null : entity.Telefone3);
                cmd.Parameters.AddWithValue("@DescTelefone3", string.IsNullOrEmpty(entity.DescTelefone3) ? SqlString.Null : entity.DescTelefone3);
                cmd.Parameters.AddWithValue("@GerarNota", entity.GerarNota);
                cmd.Parameters.AddWithValue("@DataNascimentoResponsavel", entity.DataNascimentoResponsavel == new DateTime() ? SqlDateTime.Null : entity.DataNascimentoResponsavel);
                cmd.Parameters.AddWithValue("@MenorIdade", entity.MenorIdade);
                cmd.Parameters.AddWithValue("@NomeResponsavel", string.IsNullOrEmpty(entity.NomeReponsavel) ? SqlString.Null : entity.NomeReponsavel);
                cmd.Parameters.AddWithValue("@GrauParentesco", string.IsNullOrEmpty(entity.Parentesco) ? SqlString.Null : entity.Parentesco);


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
                  Email = @Email, 
                  DescTelefone = @DescTelefone,
                  Telefone2 = @Telefone2,
                  DescTelefone2 = @DescTelefone2,
                  Telefone3 = @Telefone3,
                  DescTelefone3 = @DescTelefone3,
                  GerarNota = @GerarNota,
                  DataNascimentoResponsavel = @DataNascimentoResponsavel,
                  MenorIdade = @MenorIdade
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

                cmd.Parameters.AddWithValue("@DescTelefone", string.IsNullOrEmpty(entityNovo.DescTelefone) ? SqlString.Null : entityNovo.DescTelefone);
                cmd.Parameters.AddWithValue("@Telefone2", string.IsNullOrEmpty(entityNovo.Telefone2) ? SqlString.Null : entityNovo.Telefone2);
                cmd.Parameters.AddWithValue("@DescTelefone2", string.IsNullOrEmpty(entityNovo.DescTelefone2) ? SqlString.Null : entityNovo.DescTelefone2);
                cmd.Parameters.AddWithValue("@Telefone3", string.IsNullOrEmpty(entityNovo.Telefone3) ? SqlString.Null : entityNovo.Telefone3);
                cmd.Parameters.AddWithValue("@DescTelefone3", string.IsNullOrEmpty(entityNovo.DescTelefone3) ? SqlString.Null : entityNovo.DescTelefone3);
                cmd.Parameters.AddWithValue("@GerarNota", entityNovo.GerarNota);
                cmd.Parameters.AddWithValue("@DataNascimentoResponsavel", entityNovo.DataNascimentoResponsavel == new DateTime() ? SqlDateTime.Null : entityNovo.DataNascimentoResponsavel);
                cmd.Parameters.AddWithValue("@MenorIdade", entityNovo.MenorIdade);
                cmd.Parameters.AddWithValue("@NomeResponsavel", string.IsNullOrEmpty(entityNovo.NomeReponsavel) ? SqlString.Null : entityNovo.NomeReponsavel);
                cmd.Parameters.AddWithValue("@GrauParentesco", string.IsNullOrEmpty(entityNovo.Parentesco) ? SqlString.Null : entityNovo.Parentesco);

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
            string query = "SELECT * FROM Matriculas ORDER BY Nome";
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
                            Email = sdr["Email"].ToString(),
                            Ativo = (bool)sdr["Ativo"]
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
            string query = @"select t.Id, count(1) Quantidade, t.Descricao, t.Tipo, t.DiaDaSemana, t.HorarioInicial, t.HorarioFinal, c.Nome from turmas t
JOIN Colaboradores c ON t.ColaboradorId = c.Id
GROUP BY t.Id, t.Descricao, t.Tipo, t.DiaDaSemana, t.HorarioInicial, t.HorarioFinal, c.Nome";
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
                            Telefone = @Telefone AND
                            DescTelefone = @DescTelefone AND
                            Telefone2 = @Telefone2 AND
                            DescTelefone2 = @DescTelefone2 AND
                            Telefone3 = @Telefone3 AND
                            DescTelefone3 = @DescTelefone3 AND
                            GerarNota = @GerarNota AND
                            DataNascimentoResponsavel = @DataNascimentoResponsavel AND
                            MenorIdade = @MenorIdade";
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
                cmd.Parameters.AddWithValue("@DescTelefone", string.IsNullOrEmpty(entity.DescTelefone) ? SqlString.Null : entity.DescTelefone);
                cmd.Parameters.AddWithValue("@Telefone2", string.IsNullOrEmpty(entity.Telefone2) ? SqlString.Null : entity.Telefone2);
                cmd.Parameters.AddWithValue("@DescTelefone2", string.IsNullOrEmpty(entity.DescTelefone2) ? SqlString.Null : entity.DescTelefone2);
                cmd.Parameters.AddWithValue("@Telefone3", string.IsNullOrEmpty(entity.Telefone3) ? SqlString.Null : entity.Telefone3);
                cmd.Parameters.AddWithValue("@DescTelefone3", string.IsNullOrEmpty(entity.DescTelefone3) ? SqlString.Null : entity.DescTelefone3);
                cmd.Parameters.AddWithValue("@GerarNota", entity.GerarNota);
                cmd.Parameters.AddWithValue("@DataNascimentoResponsavel", entity.DataNascimentoResponsavel == new DateTime() ? SqlDateTime.Null : entity.DataNascimentoResponsavel);
                cmd.Parameters.AddWithValue("@MenorIdade", entity.MenorIdade);
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
                            Nome = sdr["Nome"].ToString()
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
                            Email = sdr["Email"].ToString(),
                            DescTelefone = sdr["DescTelefone"].ToString(),
                            DescTelefone2 = sdr["DescTelefone2"].ToString(),
                            DescTelefone3 = sdr["DescTelefone3"].ToString(),
                            Telefone2 = sdr["Telefone2"].ToString(),
                            Telefone3 = sdr["Telefone3"].ToString(),
                            MenorIdade = string.IsNullOrEmpty(sdr["MenorIdade"].ToString()) || sdr["MenorIdade"].ToString() == "0" ? 0 : 1,
                            NomeResponsavel = sdr["NomeResponsavel"].ToString(),
                            DataNascimentoResponsavel = sdr["DataNascimentoResponsavel"].ToString(),
                            Parentesco = sdr["GrauParentesco"].ToString(),
                            Ativo = sdr["Ativo"].ToString() == "0" || string.IsNullOrEmpty(sdr["Ativo"].ToString()) ? false : true
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
                            Id = @Id";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                return Convert.ToInt32(cmd.ExecuteNonQuery()) > 0 ? true : false;
            }
        }

        public List<int> ListaDeMensalidades(int id)
        {
            string query = @"SELECT Id FROM Mensalidades 
                                WHERE (StatusDaMensalidade = 'EmHaver' OR StatusDaMensalidade = 'ProximoDaDataDeVencimento') 
                                AND DataDeVencimento > GETDATE()
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