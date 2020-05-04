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
    public class MensalidadeDAO : IDAO<Mensalidade>
    {
        private readonly string stringConexao = ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
        public bool Adicionar(Mensalidade entity)
        {
            string query = @"INSERT INTO Mensalidades(
	MatriculaId, 
	--ModalidadeId, 
	--TurmaId, 
	DataDeVencimento, 
    StatusDaMensalidade,
	FormaDePagamento,
    Valor)
	Values(
        @MatriculaId, 
	    --@ModalidadeId, 
	    --@TurmaId, 
	    @DataDeVencimento, 
        @StatusDaMensalidade,
	    @FormaDePagamento,
        @Valor);
            SELECT @@IDENTITY";
            using (var con = new SqlConnection(stringConexao))
            {
                var ano = DateTime.Now.Year;
                var mes = DateTime.Now.Month;
                for (int i = 1; i <= entity.QuantidadeDeMeses; i++)
                {
                    mes++;
                    if (mes > 12)
                    {
                        ano++;
                        mes = 1;
                    }

                    var dataVencimento = new DateTime(ano, mes, entity.Dia);

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@MatriculaId", entity.MatriculaId);
                    //cmd.Parameters.AddWithValue("@ModalidadeId", entity.ModalidadeId);
                    //cmd.Parameters.AddWithValue("@TurmaId", entity.TurmaId);
                    cmd.Parameters.AddWithValue("@DataDeVencimento", dataVencimento);
                    cmd.Parameters.AddWithValue("@StatusDaMensalidade", entity.StatusDaMensalidade);
                    cmd.Parameters.AddWithValue("@FormaDePagamento", entity.FormaDePagamento);
                    cmd.Parameters.AddWithValue("@Valor", entity.Valor);
                    cmd.ExecuteNonQuery();

                    con.Close();
                }

                return true;
            }

        }

        public void AlterarMensalidadeParaVencido()
        {
            string query = @"UPDATE Mensalidades SET StatusDaMensalidade = 'Vencido'
                                WHERE DataDeVencimento BETWEEN DATEADD(DAY, -60, GETDATE()) AND DATEADD(DAY, -1, GETDATE())  
                                AND StatusDaMensalidade != 'PAGO' AND StatusDaMensalidade != 'PagoComAtraso' AND StatusDaMensalidade != 'Vencido'";
            using (var con  = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
        }

        public bool Atualizar(Mensalidade entityAntigo, Mensalidade entityNovo)
        {
            //var date = entityNovo.DataDeVencimento;

            //if (entityNovo.StatusDaMensalidade != "Pago" && entityNovo.StatusDaMensalidade != "PagoComAtraso")
            //{
            //    if (date > DateTime.Now)
            //    {
            //        if ((DateTime.Now.Date.AddDays(5)) >= date && date <= (DateTime.Now.Date.AddDays(5)))
            //        {
            //            entityNovo.StatusDaMensalidade = "ProximoDaDataDeVencimento";
            //        }
            //        else
            //        {
            //            entityNovo.StatusDaMensalidade = "EmHaver";
            //        }
            //    }

            //    if (date.Date < DateTime.Now.Date)
            //    {
            //        entityNovo.StatusDaMensalidade = "Vencido";
            //    }
            //}

            string unicaOuTodaMensalidade = entityNovo.EditarTodasMensalidades ? 
                @"DataDeVencimento IS NOT NULL AND
                  Valor IS NOT NULL AND" 
                :
                @"DataDeVencimento = @DataDeVencimentoAntigo AND
                  Valor = @ValorAntigo AND";


            string query = $@"UPDATE Mensalidades 
            SET
             MatriculaId = @MatriculaIdNovo, 
             --ModalidadeId = @ModalidadeIdNovo, 
             --TurmaId = @TurmaIdNovo, 
             DataDeVencimento = CONVERT(datetime, FORMAT(DataDeVencimento, CONCAT('yyyy-MM-', @DataDeVencimentoNovo))), 
             StatusDaMensalidade = @StatusDaMensalidadeNovo,
             FormaDePagamento = @FormaDePagamentoNovo,
             Valor = @ValorNovo       
            WHERE   
             MatriculaId = @MatriculaIdAntigo AND
             --ModalidadeId = @ModalidadeIdAntigo AND
             --TurmaId = @TurmaIdAntigo AND 
             {unicaOuTodaMensalidade}
             StatusDaMensalidade = @StatusDaMensalidadeAntigo --AND
             --FormaDePagamento = @FormaDePagamentoAntigo";

            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@MatriculaIdNovo", entityNovo.MatriculaId);
                //cmd.Parameters.AddWithValue("@ModalidadeIdNovo", entityNovo.ModalidadeId);
                //cmd.Parameters.AddWithValue("@TurmaIdNovo", entityNovo.TurmaId);
                cmd.Parameters.AddWithValue("@DataDeVencimentoNovo", entityNovo.Dia);
                cmd.Parameters.AddWithValue("@StatusDaMensalidadeNovo", entityNovo.StatusDaMensalidade);
                cmd.Parameters.AddWithValue("@FormaDePagamentoNovo", entityNovo.FormaDePagamento);
                cmd.Parameters.AddWithValue("@ValorNovo", entityNovo.Valor);

                cmd.Parameters.AddWithValue("@MatriculaIdAntigo", entityAntigo.MatriculaId);
                //cmd.Parameters.AddWithValue("@ModalidadeIdAntigo", entityAntigo.ModalidadeId);
                //cmd.Parameters.AddWithValue("@TurmaIdAntigo", entityAntigo.TurmaId);
                cmd.Parameters.AddWithValue("@DataDeVencimentoAntigo", entityAntigo.DataDeVencimento);
                cmd.Parameters.AddWithValue("@StatusDaMensalidadeAntigo", entityAntigo.StatusDaMensalidade);
                //cmd.Parameters.AddWithValue("@FormaDePagamentoAntigo", entityAntigo.FormaDePagamento);
                cmd.Parameters.AddWithValue("@ValorAntigo", entityAntigo.Valor);

                cmd.ExecuteNonQuery();
                return true;
            }
        }
        public bool Deletar(Mensalidade entity)
        {
            string unicaOuTodaMensalidade = entity.EditarTodasMensalidades ?
                @"DataDeVencimento IS NOT NULL AND
                  Valor IS NOT NULL AND"
                :
                @"DataDeVencimento = @DataDeVencimento AND
                  Valor = @Valor AND";

            string query = $@"DELETE FROM Mensalidades
                            WHERE 
                            MatriculaId = @MatriculaId and 
	                        --ModalidadeId =   @ModalidadeId and 
	                        --TurmaId = @TurmaId and 
	                        {unicaOuTodaMensalidade}
                            StatusDaMensalidade = @StatusDaMensalidade     
	                        --FormaDePagamento = @FormaDePagamento";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@MatriculaId", entity.MatriculaId);
                //cmd.Parameters.AddWithValue("@ModalidadeId", entity.ModalidadeId);
                //cmd.Parameters.AddWithValue("@TurmaId", entity.TurmaId);
                cmd.Parameters.AddWithValue("@DataDeVencimento", entity.DataDeVencimento);
                cmd.Parameters.AddWithValue("@Valor", entity.Valor);
                cmd.Parameters.AddWithValue("@StatusDaMensalidade", entity.StatusDaMensalidade);
                //cmd.Parameters.AddWithValue("@FormaDePagamento", entity.FormaDePagamento);

                cmd.ExecuteNonQuery();

                return true;
            }
        }

        public decimal Juros()
        {
            string query = "SELECT TOP 1 Valor FROM Parametros";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                return Convert.ToDecimal(cmd.ExecuteScalar() == null ? 0 : cmd.ExecuteScalar());
            }
            throw new NotImplementedException();
        }

        public IList<Mensalidade> Lista()
        {
            throw new NotImplementedException();
        }
        public List<Mensalidade> ListaMensalidade()
        {
            string query = @"SELECT t.*, a.Nome, DATEDIFF(DAY, DataDeVencimento, GETDATE()) DiasVencidos
                            from Mensalidades t 
                            inner join Matriculas a on t.Matriculaid = a.Id
                            WHERE
                            t.DataDeVencimento BETWEEN DATEADD(DAY, -60, GETDATE()) AND DATEADD(DAY, -1, GETDATE()) ";

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
                            MatriculaId = (int)sdr["MatriculaId"],
                            Matricula = new Matricula { Id = (int)sdr["MatriculaId"], Nome = sdr["Nome"].ToString() },
                            //ModalidadeId = (int)sdr["ModalidadeId"],
                            //Modalidade = new Modalidade { Id = (int)sdr["ModalidadeId"], TipoModalidade = sdr["TipoModalidade"].ToString(), Descricao = sdr["DescricaoModalidade"].ToString() },
                            //TurmaId = (int)sdr["TurmaId"],
                            //Turma = new Turma { Id = (int)sdr["TurmaId"], Descricao = sdr["DescricaoTurma"].ToString() },
                            DataDeVencimento = (DateTime)sdr["DataDeVencimento"],
                            StatusDaMensalidade = sdr["StatusDaMensalidade"].ToString(),
                            FormaDePagamento = sdr["FormaDePagamento"].ToString(),
                            Valor = (decimal)sdr["Valor"],
                            DiasVencidos = (int)sdr["DiasVencidos"]
                        };

                        //if (model.DataDeVencimento.Date > DateTime.Now.Date)
                        //{
                        //    if (model.DataDeVencimento.Date >= (DateTime.Now.Date.AddDays(5)) && model.DataDeVencimento.Date <= (DateTime.Now.Date.AddDays(5)))
                        //    {
                        //        model.StatusDaMensalidade = "ProximoDaDataDeVencimento";
                        //    }
                        //    else
                        //    {
                        //        model.StatusDaMensalidade = "EmHaver";
                        //    }
                        //}
                        //else if (model.DataDeVencimento.Date < DateTime.Now.Date)
                        //{
                        //    model.StatusDaMensalidade = "Vencido";
                        //}


                        Mensalidades.Add(model);
                    }
                }
                con.Close();
                return Mensalidades;
            }
        }


        public List<Mensalidade> ListaMensalidadePorNome(string Nome)
        {
            string query = @"SELECT t.*, a.Nome, m.TipoModalidade, m.Descricao DescricaoModalidade, a.Nome, u.Descricao  DescricaoTurma
                            from Mensalidades t 
                            inner join Turmas u on t.TurmaId = u.Id
                            inner join Modalidades m on t.ModalidadeId = m.Id 
                            inner join Matriculas a on t.Matriculaid = a.Id
                            WHERE 
                            a.Nome LIKE '%' + @Nome + '%'";

            List<Mensalidade> Mensalidades = new List<Mensalidade>();
            using (var con = new SqlConnection(stringConexao))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nome", Nome);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        var model = new Mensalidade
                        {
                            Id = (int)sdr["Id"],
                            MatriculaId = (int)sdr["MatriculaId"],
                            Matricula = new Matricula { Id = (int)sdr["MatriculaId"], Nome = sdr["Nome"].ToString() },
                            //ModalidadeId = (int)sdr["ModalidadeId"],
                            //Modalidade = new Modalidade { Id = (int)sdr["ModalidadeId"], TipoModalidade = sdr["TipoModalidade"].ToString(), Descricao = sdr["DescricaoModalidade"].ToString() },
                            //TurmaId = (int)sdr["TurmaId"],
                            //Turma = new Turma { Id = (int)sdr["TurmaId"], Descricao = sdr["DescricaoTurma"].ToString() },
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

        public List<Matricula> ReturnMensalidadeMatriculaLista()
        {
            string query = @"SELECT * FROM Matriculas ORDER BY Nome";
            List<Matricula> lista = new List<Matricula>();
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
            var dataDeVencimentoQuery = entity.EditarTodasMensalidades || string.IsNullOrEmpty(entity.FormaDePagamento) ? "DataDeVencimento = CONVERT(datetime, FORMAT(DataDeVencimento, CONCAT('yyyy-MM-', @DataDeVencimento))) and" : "DataDeVencimento = @DataDeVencimento and";

            string query = $@"SELECT 
                                	count(1) as qtd
                                FROM 
                                	Mensalidades  
                                WHERE
                            MatriculaId = @MatriculaId and 
	                        --ModalidadeId =   @ModalidadeId and 
	                        --TurmaId = @TurmaId and 
	                        {dataDeVencimentoQuery}
                            StatusDaMensalidade = @StatusDaMensalidade and    
	                        --FormaDePagamento = @FormaDePagamento and    
	                        Valor = @Valor";
            return GravarERetornarVerdadeiroOuFalse(entity, query);
        }



        private bool GravarERetornarVerdadeiroOuFalse(Mensalidade entity, string query)
        {
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();

                var dataDeVencimentoValor = entity.EditarTodasMensalidades || string.IsNullOrEmpty(entity.FormaDePagamento)  ? entity.Dia.ToString() : entity.DataDeVencimento.ToString($"yyyy-MM-{entity.Dia}");

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@MatriculaId", entity.MatriculaId);
                //cmd.Parameters.AddWithValue("@ModalidadeId", entity.ModalidadeId);
                //cmd.Parameters.AddWithValue("@TurmaId", entity.TurmaId);
                cmd.Parameters.AddWithValue("@DataDeVencimento", dataDeVencimentoValor);
                cmd.Parameters.AddWithValue("@StatusDaMensalidade", entity.StatusDaMensalidade);
                //cmd.Parameters.AddWithValue("@FormaDePagamento", entity.FormaDePagamento);
                cmd.Parameters.AddWithValue("@Valor", entity.Valor);

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0 ? true : false;
            }
        }

    }
}