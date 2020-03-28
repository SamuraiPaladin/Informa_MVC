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
    public class MensalidadeDAO : IDAO<Mensalidade>
    {
        private readonly string stringConexao = ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
        public bool Adicionar(Mensalidade entity)
        {

            string query = @"INSERT INTO Mensalidades(
	AlunoId, 
	ModalidadeId, 
	TurmaId, 
	DataDeVencimento, 
    StatusDaMensalidade,
	FormaDePagamento)
	Values(
        @AlunoId, 
	    @ModalidadeId, 
	    @TurmaId, 
	    @DataDeVencimento, 
        @StatusDaMensalidade,
	    @FormaDePagamento);
            SELECT @@IDENTITY";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@AlunoId", entity.AlunoId);

                cmd.Parameters.AddWithValue("@ModalidadeId", entity.ModalidadeId);

                cmd.Parameters.AddWithValue("@TurmaId", entity.TurmaId);

                cmd.Parameters.AddWithValue("@DataDeVencimento", entity.DataDeVencimento);

                cmd.Parameters.AddWithValue("@StatusDaMensalidade", entity.StatusDaMensalidade);

                cmd.Parameters.AddWithValue("@FormaDePagamento", entity.FormaDePagamento);

                cmd.ExecuteNonQuery();
                return true;
            }

        }

        public bool Atualizar(Mensalidade entityAntigo, Mensalidade entityNovo)
        {

            string query = @"UPDATE Mensalidades 
        SET
            AlunoId = @AlunoIdNovo, 
	        ModalidadeId = @ModalidadeIdNovo, 
	        TurmaId = @TurmaIdNovo, 
	        DataDeVencimento = @DataDeVencimentoNovo, 
            StatusDaMensalidade = @StatusDaMensalidadeNovo,
	        FormaDePagamento = @FormaDePagamentoNovo
        WHERE   
            AlunoId = @AlunoIdAntigo AND
	        ModalidadeId = @ModalidadeIdAntigo AND
	        TurmaId = @TurmaIdAntigo AND
	        DataDeVencimento = @DataDeVencimentoAntigo AND
            StatusDaMensalidade = @StatusDaMensalidadeAntigo AND
	        FormaDePagamento = @FormaDePagamentoAntigo";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@AlunoIdNovo", entityNovo.AlunoId);
                cmd.Parameters.AddWithValue("@ModalidadeIdNovo", entityNovo.ModalidadeId);
                cmd.Parameters.AddWithValue("@TurmaIdNovo", entityNovo.TurmaId);
                cmd.Parameters.AddWithValue("@DataDeVencimentoNovo", entityNovo.DataDeVencimento);
                cmd.Parameters.AddWithValue("@StatusDaMensalidadeNovo", entityNovo.StatusDaMensalidade);
                cmd.Parameters.AddWithValue("@FormaDePagamentoNovo", entityNovo.FormaDePagamento);

                cmd.Parameters.AddWithValue("@AlunoIdAntigo", entityAntigo.AlunoId);
                cmd.Parameters.AddWithValue("@ModalidadeIdAntigo", entityAntigo.ModalidadeId);
                cmd.Parameters.AddWithValue("@TurmaIdAntigo", entityAntigo.TurmaId);
                cmd.Parameters.AddWithValue("@DataDeVencimentoAntigo", entityAntigo.DataDeVencimento);
                cmd.Parameters.AddWithValue("@StatusDaMensalidadeAntigo", entityAntigo.StatusDaMensalidade);
                cmd.Parameters.AddWithValue("@FormaDePagamentoAntigo", entityAntigo.FormaDePagamento);

                cmd.ExecuteNonQuery();
                return true;
            }
        }
        public bool Deletar(Mensalidade entity)
        {

            string query = @"DELETE FROM Mensalidades
                            WHERE 
                            AlunoId = @AlunoId and 
	                        ModalidadeId =   @ModalidadeId and 
	                        TurmaId = @TurmaId and 
	                        DataDeVencimento =  @DataDeVencimento and
                            StatusDaMensalidade = @StatusDaMensalidade and    
	                        FormaDePagamento = @FormaDePagamento";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@AlunoId", entity.AlunoId);

                cmd.Parameters.AddWithValue("@ModalidadeId", entity.ModalidadeId);

                cmd.Parameters.AddWithValue("@TurmaId", entity.TurmaId);

                cmd.Parameters.AddWithValue("@DataDeVencimento", entity.DataDeVencimento);

                cmd.Parameters.AddWithValue("@StatusDaMensalidade", entity.StatusDaMensalidade);

                cmd.Parameters.AddWithValue("@FormaDePagamento", entity.FormaDePagamento);

                cmd.ExecuteNonQuery();

                return true;
            }
        }

        public IList<Mensalidade> Lista()
        {
            throw new NotImplementedException();
        }
        public List<Mensalidade> ListaMensalidade()
        {
            string query = @"SELECT t.*, a.Nome, m.TipoModalidade, m.Descricao DescricaoModalidade, a.Nome, u.Descricao  DescricaoTurma
                            from Mensalidades t 
                            inner join Turmas u on t.TurmaId = u.Id
                            inner join Modalidades m on t.ModalidadeId = m.Id 
                            inner join Alunos a on t.Alunoid = a.Id";

            List<Mensalidade> Mensalidades = new List<Mensalidade>();
            using (var con = new SqlConnection(stringConexao))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        var model = new Mensalidade
                        {
                            Id = (int)sdr["Id"],
                            AlunoId = (int)sdr["AlunoId"],
                            Aluno = new Aluno { Id = (int)sdr["AlunoId"], Nome = sdr["Nome"].ToString() },
                            ModalidadeId = (int)sdr["ModalidadeId"],
                            Modalidade = new Modalidade { Id = (int)sdr["ModalidadeId"], TipoModalidade = sdr["TipoModalidade"].ToString(), Descricao = sdr["DescricaoModalidade"].ToString() },
                            TurmaId = (int)sdr["TurmaId"],
                            Turma = new Turma { Id = (int)sdr["TurmaId"], Descricao = sdr["Descricao"].ToString() },
                            DataDeVencimento = (DateTime)sdr["DataDeVencimento"],
                            StatusDaMensalidade = sdr["StatusDaMensalidade"].ToString(),
                            FormaDePagamento = sdr["FormaDePagamento"].ToString()
                        };
                        Mensalidades.Add(model);
                    }
                }
                con.Close();
                return Mensalidades;
            }
        }

        public List<Aluno> ReturnMensalidadeAlunoLista()
        {
            string query = @"SELECT * FROM Alunos ORDER BY Nome";
            List<Aluno> lista = new List<Aluno>();
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        var model = new Aluno
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
                            Telefone = sdr["Telefone"].ToString()
                        };
                        lista.Add(model);
                    }
                }
                con.Close();
                return lista;
            }

        }

        public List<Modalidade> ReturnMensalidadeModalidadesLista()
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

        public List<Turma> ReturnMensalidadeTurmasLista()
        {
            string query = @"SELECT t.*, u.Descricao DescricaoUnidade, m.TipoModalidade, m.Descricao DescricaoModalidade 
                            from Turmas t 
                            inner join Unidades u on t.UnidadeId = u.Id
                            inner join Modalidades m on t.ModalidadeId = m.Id";

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

        public bool VerificarSeJaExiste(Mensalidade entity)
        {

            string query = @"SELECT 
                                	count(1) as qtd
                                FROM 
                                	Mensalidades  
                            AlunoId = @AlunoId and 
	                        ModalidadeId =   @ModalidadeId and 
	                        TurmaId = @TurmaId and 
	                        DataDeVencimento =  @DataDeVencimento and
                            StatusDaMensalidade = @StatusDaMensalidade and    
	                        FormaDePagamento = @FormaDePagamento";
            return GravarERetornarVerdadeiroOuFalse(entity, query);
        }



        private bool GravarERetornarVerdadeiroOuFalse(Mensalidade entity, string query)
        {
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@AlunoId", entity.AlunoId);

                cmd.Parameters.AddWithValue("@ModalidadeId", entity.ModalidadeId);

                cmd.Parameters.AddWithValue("@TurmaId", entity.TurmaId);

                cmd.Parameters.AddWithValue("@DataDeVencimento", entity.DataDeVencimento);

                cmd.Parameters.AddWithValue("@StatusDaMensalidade", entity.StatusDaMensalidade);

                cmd.Parameters.AddWithValue("@FormaDePagamento", entity.FormaDePagamento);

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0 ? true : false;
            }
        }

    }
}