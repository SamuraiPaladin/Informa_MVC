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
    public class AulaTurmaDAO : IAulaTurmaDAO
    {
        private readonly string stringConexao = ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;

        public IList<Aula> AlunosPorTurma(int turmaId)
        {
            string query = @"SELECT a.Id, a.MatriculaId, a.TurmaId, m.Nome, m.Email, m.CPF, m.DataNascimento, a.Presenca, t.Descricao, 
                                t.HorarioInicial, t.HorarioFinal, t.DiaDaSemana, c.Nome as NomeColaborador,
								ms.TipoModalidade, t.Tipo, m.Telefone
							  FROM Matriculas m
                              JOIN Aulas a ON m.Id = a.MatriculaId
                              JOIN Turmas t ON t.Id = a.TurmaId
							  JOIN Colaboradores c ON c.Id = t.ColaboradorId
							  JOIN Modalidades ms ON ms.Id = t.ModalidadeId
                             WHERE  t.Id =  @TurmaId  AND a.Data = CONVERT(date, GETDATE()); ";
            List<Aula> listaAulas = new List<Aula>();
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TurmaId", turmaId);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        var aula = new Aula()
                        {
                            AulaId = Convert.ToInt32(sdr["Id"]),
                            MatriculaId = Convert.ToInt32(sdr["MatriculaId"]),
                            TurmaId = Convert.ToInt32(sdr["TurmaId"]),
                            NomeAluno = sdr["Nome"].ToString(),
                            Email = sdr["Email"].ToString(),
                            CPF = sdr["CPF"].ToString(),
                            DataNascimento = sdr["DataNascimento"].ToString(),
                            Presenca = Convert.ToBoolean(sdr["Presenca"]),
                            DescricaoTurma = sdr["Descricao"].ToString(),
                            HorarioInicial = sdr["HorarioInicial"].ToString(),
                            HorarioFinal = sdr["HorarioFinal"].ToString(),
                            DiaDaSemana = sdr["DiaDaSemana"].ToString(),
                            NomeColaborador= sdr["NomeColaborador"].ToString(),
                            TipoModalidade = sdr["TipoModalidade"].ToString(),
                            TipoFaixaEtaria = sdr["Tipo"].ToString(),
                            Telefone = sdr["Telefone"].ToString()
                        };

                        listaAulas.Add(aula);
                    }
                }
            }
            return listaAulas;
        }


        public void Atualizar(Aula[] entity)
        {
            using (var con = new SqlConnection(stringConexao))
            {
                foreach (var item in entity)
                {
                    con.Open();
                    string query = @"UPDATE Aulas set Presenca = @Presenca WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Id", item.AulaId);
                    cmd.Parameters.AddWithValue("@Presenca", item.Presenca);
                    cmd.ExecuteScalar();
                    con.Close();
                }
            }
        }

        public IList<Aula> AulasNaDataDeHoje()
        {
            string query = @"SET LANGUAGE 'Brazilian';
                                SELECT TurmaId, MatriculaId, Presenca, Data FROM Aulas WHERE Data = CONVERT(date, GETDATE());";
            IList<Aula> listaAulas = new List<Aula>();
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        Aula aula = new Aula();
                        aula.TurmaId = Convert.ToInt32(sdr["TurmaId"]);
                        aula.MatriculaId = Convert.ToInt32(sdr["MatriculaId"]);
                        aula.Presenca = Convert.ToBoolean(sdr["Presenca"]);
                        aula.Data = Convert.ToDateTime(sdr["Data"]);
                        listaAulas.Add(aula);
                    }
                }
            }
            return listaAulas;
        }

        public IList<Aula> AulasNaDataDeHojeColab(int IdColaborador)
        {
            string query = @"SET LANGUAGE 'Brazilian';
                             SELECT a.TurmaId, a.MatriculaId, a.Presenca, a.Data FROM Aulas a
                             INNER JOIN Turmas t ON a.TurmaId = t.Id
                             WHERE a.Data = CONVERT(date, GETDATE()) AND
                             t.ColaboradorId = @ColaboradorId";
            IList<Aula> listaAulas = new List<Aula>();
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ColaboradorId", IdColaborador);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        Aula aula = new Aula();
                        aula.TurmaId = Convert.ToInt32(sdr["TurmaId"]);
                        aula.MatriculaId = Convert.ToInt32(sdr["MatriculaId"]);
                        aula.Presenca = Convert.ToBoolean(sdr["Presenca"]);
                        aula.Data = Convert.ToDateTime(sdr["Data"]);
                        listaAulas.Add(aula);
                    }
                }
            }
            return listaAulas;
        }

        public IList<Aula> ListaDeAlunosParaPresencaAtual()
        {
            string query = @"SET LANGUAGE 'Brazilian';
                                SELECT IdMatricula, IdTurma 
                                	FROM MatriculaTurma mt
                                	JOIN Turmas t ON t.Id = mt.IdTurma 
                                	JOIN Matriculas m ON m.Id = mt.IdMatricula
                                	where t.DiaDaSemana like '%' + REPLACE(datename(weekday,getDate()), '-feira', '') + '%'";
            IList<Aula> listaAulas = new List<Aula>();
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        Aula aula = new Aula();
                        aula.TurmaId = Convert.ToInt32(sdr["IdTurma"]);
                        aula.MatriculaId = Convert.ToInt32(sdr["IdMatricula"]);
                        listaAulas.Add(aula);
                    }
                }
            }
            return listaAulas;
        }

        public IList<Aula> ListaDeTurmas()
        {
            IList<Aula> aulas = new List<Aula>();
            string query = @"SET LANGUAGE 'Brazilian';
                            SELECT t.Id,
									t.Descricao
                                  ,c.Nome
                                  ,t.Tipo
                                  ,t.DiaDaSemana
                                  ,t.HorarioInicial
                                  ,t.HorarioFinal
                              FROM Turmas t
                              JOIN Colaboradores c ON c.Id = t.ColaboradorId
                            where t.DiaDaSemana like '%' + REPLACE(datename(weekday,getDate()), '-feira', '') + '%'";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        Aula aula = new Aula();
                        aula.TurmaId = Convert.ToInt32(sdr["Id"]);
                        aula.DescricaoTurma = sdr["Descricao"].ToString();
                        aula.NomeColaborador = sdr["Nome"].ToString();
                        aula.TipoFaixaEtaria = sdr["Tipo"].ToString();
                        aula.DiaDaSemana = sdr["DiaDaSemana"].ToString();
                        aula.HorarioInicial = sdr["HorarioInicial"].ToString();
                        aula.HorarioFinal = sdr["HorarioFinal"].ToString(); 
                        aulas.Add(aula);
                    }
                }
            }
            return aulas;
        }

        public void SalvarListaDePresencaParaDataAtual(IList<Aula> listaDeAlunosParaPresencaAtual)
        {
            using (var con = new SqlConnection(stringConexao))
            {
                foreach (var item in listaDeAlunosParaPresencaAtual)
                {
                    con.Open();
                    string query = @"INSERT INTO Aulas(TurmaId, MatriculaId, Presenca, Data) VALUES (@TurmaId, @MatriculaId, 0, getDate())";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@TurmaId", item.TurmaId);
                    cmd.Parameters.AddWithValue("@MatriculaId", item.MatriculaId);
                    cmd.ExecuteScalar();
                    con.Close();
                }
            }
        }
    }
}