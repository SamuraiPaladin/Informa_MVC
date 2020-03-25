using Model.Entity;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.BD.Interface;

namespace Web.BD.Repository
{
    public class TurmaDAO : IDAO<Turma>
    {
        private readonly string stringConexao = ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
        public bool Adicionar(Turma entity)
        {

            string query = @"INSERT INTO Turmas
           (UnidadeId
      ,ModalidadeId
      ,Descricao
      ,ColaboradorId
      ,Tipo
      ,DiaDaSemana
      ,HorarioInicial
      ,HorarioFinal)
			Values(@UnidadeId
      ,@ModalidadeId
      ,@Descricao
      ,@ColaboradorId
      ,@Tipo
      ,@DiaDaSemana
      ,@HorarioInicial
      ,@HorarioFinal);
            SELECT @@IDENTITY";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@UnidadeId", entity.UnidadeId);

                cmd.Parameters.AddWithValue("@ModalidadeId", entity.ModalidadeId);

                cmd.Parameters.AddWithValue("@Descricao", entity.Descricao);

                cmd.Parameters.AddWithValue("@ColaboradorId", entity.ColaboradorId);

                cmd.Parameters.AddWithValue("@Tipo", entity.Tipo);

                cmd.Parameters.AddWithValue("@DiaDaSemana", entity.DiaDaSemana);

                cmd.Parameters.AddWithValue("@HorarioInicial", entity.HorarioInicial);

                cmd.Parameters.AddWithValue("@HorarioFinal", entity.HorarioFinal);

                cmd.ExecuteNonQuery();
                return true;
            }

        }

        public bool Atualizar(Turma entityAntigo, Turma entityNovo)
        {

            string query = @"UPDATE Turmas 
        SET
            UnidadeId = @UnidadeIdNovo,
            ModalidadeId = @ModalidadeIdNovo,
            Descricao = @DescricaoNovo,
            ColaboradorId = @ColaboradorIdNovo,
            Tipo = @TipoNovo,
            DiaDaSemana = @DiaDaSemanaNovo,
            HorarioInicial = @HorarioInicialNovo,
            HorarioFinal = @HorarioFinalNovo
        WHERE   
            UnidadeId = @UnidadeIdAntigo AND
            ModalidadeId = @ModalidadeIdAntigo AND
            Descricao = @DescricaoAntigo AND
            ColaboradorId = @ColaboradorIdAntigo AND
            Tipo = @TipoAntigo AND
            DiaDaSemana = @DiaDaSemanaAntigo AND
            HorarioInicial = @HorarioInicialAntigo AND
            HorarioFinal = @HorarioFinalAntigo";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@UnidadeIdNovo", entityNovo.UnidadeId);
                cmd.Parameters.AddWithValue("@ModalidadeIdNovo", entityNovo.ModalidadeId);
                cmd.Parameters.AddWithValue("@DescricaoNovo", entityNovo.Descricao);
                cmd.Parameters.AddWithValue("@ColaboradorIdNovo", entityNovo.ColaboradorId);
                cmd.Parameters.AddWithValue("@TipoNovo", entityNovo.Tipo);
                cmd.Parameters.AddWithValue("@DiaDaSemanaNovo", entityNovo.DiaDaSemana[0]);
                cmd.Parameters.AddWithValue("@HorarioInicialNovo", entityNovo.HorarioInicial);
                cmd.Parameters.AddWithValue("@HorarioFinalNovo", entityNovo.HorarioFinal);

                cmd.Parameters.AddWithValue("@UnidadeIdAntigo", entityAntigo.UnidadeId);
                cmd.Parameters.AddWithValue("@ModalidadeIdAntigo", entityAntigo.ModalidadeId);
                cmd.Parameters.AddWithValue("@DescricaoAntigo", entityAntigo.Descricao);
                cmd.Parameters.AddWithValue("@ColaboradorIdAntigo", entityAntigo.ColaboradorId);
                cmd.Parameters.AddWithValue("@TipoAntigo", entityAntigo.Tipo);
                cmd.Parameters.AddWithValue("@DiaDaSemanaAntigo", entityAntigo.DiaDaSemana[0]);
                cmd.Parameters.AddWithValue("@HorarioInicialAntigo", entityAntigo.HorarioInicial);
                cmd.Parameters.AddWithValue("@HorarioFinalAntigo", entityAntigo.HorarioFinal);
                cmd.ExecuteNonQuery();
                return true;
            }
        }
        public bool Deletar(Turma entity)
        {

            string query = @"DELETE FROM Turmas
                            WHERE 
                            UnidadeId = @UnidadeId AND
                            ModalidadeId = @ModalidadeId AND
                            Descricao = @Descricao AND
                            ColaboradorId = @ColaboradorId AND
                            Tipo = @Tipo AND
                            DiaDaSemana = @DiaDaSemana AND
                            HorarioInicial = @HorarioInicial AND
                            HorarioFinal = @HorarioFinal";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UnidadeId", entity.UnidadeId);

                cmd.Parameters.AddWithValue("@ModalidadeId", entity.ModalidadeId);

                cmd.Parameters.AddWithValue("@Descricao", entity.Descricao);

                cmd.Parameters.AddWithValue("@ColaboradorId", entity.ColaboradorId);

                cmd.Parameters.AddWithValue("@Tipo", entity.Tipo);

                cmd.Parameters.AddWithValue("@DiaDaSemana", entity.DiaDaSemana);

                cmd.Parameters.AddWithValue("@HorarioInicial", entity.HorarioInicial);

                cmd.Parameters.AddWithValue("@HorarioFinal", entity.HorarioFinal);

                cmd.ExecuteNonQuery();
                return true;
            }
        }

        public IList<Turma> Lista()
        {
            throw new NotImplementedException();
        }

        public List<Colaborador> ReturnTurmaColaboradorLista()
        {
            string query = @"SELECT * FROM Colaboradores c inner join Funcoes f on c.FuncaoId = f.Id 
                               WHERE f.TipoFuncao like '%prof%' ORDER BY c.Nome";
            List<Colaborador> lista = new List<Colaborador>();
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        var model = new Colaborador
                        {
                            Id = (int)sdr["Id"],
                            Nome = sdr["Nome"].ToString(),
                            //DataNascimento = sdr["DataNascimento"].ToString(),
                            //CPF = sdr["CPF"].ToString(),
                            //RG = sdr["RG"].ToString(),
                            //Endereco = sdr["Endereco"].ToString(),
                            //CEP = sdr["CEP"].ToString(),
                            //Numero = sdr["Numero"].ToString(),
                            //Bairro = sdr["Bairro"].ToString(),
                            //Cidade = sdr["Cidade"].ToString(),
                            //Estado = sdr["Estado"].ToString(),
                            //Telefone = sdr["Telefone"].ToString(),
                            FuncaoId = (int)sdr["FuncaoId"],
                            //Funcao = new Funcao() { Id = (int)sdr["FuncaoId"], Descricao = sdr["Descricao"].ToString(), TipoFuncao = sdr["TipoFuncao"].ToString(), Ativo = (bool)sdr["Ativo"] }
                        };
                        lista.Add(model);
                    }
                }
                con.Close();
                return lista;
            }

        }

        public List<Modalidade> ReturnTurmaModalidadesLista()
        {
            string query = @"SELECT * FROM Modalidades Order by Descricao";
            List<Modalidade> lista = new List<Modalidade>();
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
                            Id = (int)sdr["Id"],
                            Descricao = sdr["Descricao"].ToString(),
                            TipoModalidade = sdr["TipoModalidade"].ToString(),
                            Ativo = (bool)sdr["Ativo"]
                        };
                        lista.Add(model);
                    }
                }
                con.Close();
                return lista;
            }
        }

        public List<Unidade> ReturnTurmaUnidadesLista()
        {
            string query = @"SELECT * FROM Unidades Order by Descricao";
            List<Unidade> lista = new List<Unidade>();
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
                            Id = (int)sdr["Id"],
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
                con.Close();
                return lista;
            }
        }


        public List<Turma> ReturnTurmaLista()
        {
            string query = @"SELECT t.*, u.Descricao DescricaoUnidade, m.TipoModalidade, m.Descricao DescricaoModalidade, c.Nome 
                            from Turmas t 
                            inner join Unidades u on t.UnidadeId = u.Id
                            inner join Modalidades m on t.ModalidadeId = m.Id 
                            inner join Colaboradores c on t.ColaboradorId = c.Id";

            List<Turma> turmas = new List<Turma>();
            using (var con = new SqlConnection(stringConexao))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        var model = new Turma
                        {
                            Id = (int)sdr["Id"],
                            UnidadeId = (int)sdr["UnidadeId"],
                            Unidade = new Unidade() { Id = (int)sdr["UnidadeId"], Descricao = sdr["DescricaoUnidade"].ToString() },
                            ModalidadeId = (int)sdr["ModalidadeId"],
                            Modalidade = new Modalidade { Id = (int)sdr["ModalidadeId"], TipoModalidade = sdr["TipoModalidade"].ToString(), Descricao = sdr["DescricaoModalidade"].ToString() },
                            Descricao = sdr["Descricao"].ToString(),
                            ColaboradorId = (int)sdr["ColaboradorId"],
                            Colaborador = new Colaborador() { Id = (int)sdr["ColaboradorId"], Nome = sdr["Nome"].ToString() },
                            Tipo = sdr["Tipo"].ToString(),
                            DiaDaSemana = sdr["DiaDaSemana"].ToString(),
                            HorarioInicial = sdr["HorarioInicial"].ToString(),
                            HorarioFinal = sdr["HorarioFinal"].ToString()
                        };
                        turmas.Add(model);
                    }
                }
                con.Close();
                return turmas;
            }
        }



        public bool VerificarSeJaExiste(Turma entity)
        {


            string query = @"SELECT 
                                	count(1) as qtd
                                FROM 
                                	Turmas  
                                	                   WHERE 
            UnidadeId = @UnidadeId AND
            ModalidadeId = @ModalidadeId AND
            Descricao = @Descricao AND
            ColaboradorId = @ColaboradorId AND
            Tipo = @Tipo AND
            DiaDaSemana = @DiaDaSemana AND
            HorarioInicial = @HorarioInicial AND
            HorarioFinal = @HorarioFinal";
            return GravarERetornarVerdadeiroOuFalse(entity, query);
        }



        private bool GravarERetornarVerdadeiroOuFalse(Turma entity, string query)
        {
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UnidadeId", entity.UnidadeId);

                cmd.Parameters.AddWithValue("@ModalidadeId", entity.ModalidadeId);

                cmd.Parameters.AddWithValue("@Descricao", entity.Descricao);

                cmd.Parameters.AddWithValue("@ColaboradorId", entity.ColaboradorId);

                cmd.Parameters.AddWithValue("@Tipo", entity.Tipo);

                cmd.Parameters.AddWithValue("@DiaDaSemana", entity.DiaDaSemana);

                cmd.Parameters.AddWithValue("@HorarioInicial", entity.HorarioInicial);

                cmd.Parameters.AddWithValue("@HorarioFinal", entity.HorarioFinal);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0 ? true : false;
            }
        }

    }
}