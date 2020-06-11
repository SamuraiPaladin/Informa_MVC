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