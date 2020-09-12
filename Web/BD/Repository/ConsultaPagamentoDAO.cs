using Web.Model.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.BD.Interface;

namespace Web.BD.Repository
{
    public class ConsultaPagamentoDAO : IConsultaPagamentoDAO
    {
        private readonly string stringConexao = ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
        public IList<ConsultaPagamento> ListaDeValores(ConsultaPagamento consulta)
        {
            string condicaoWhere = "";
            if (consulta.DataFinal.ToString() != "01/01/0001 00:00:00")
            {
                condicaoWhere = " AND DataDeVencimento Between @DataInicial AND @DataFinal";
            }
            else
            {
                condicaoWhere = " AND DataDeVencimento = @DataInicial";
            }
            string query = $@"SET LANGUAGE 'Brazilian'; 
                                  select  DataDeVencimento
                                             , Dinheiro = sum(case when FormaDePagamento='Dinheiro' then valor end)
                                             , Debito = sum(case when FormaDePagamento='Debito' then valor end)
                                             , Credito = sum(case when FormaDePagamento='Credito' then valor end)
                                    from Mensalidades
                                    WHERE StatusDaMensalidade = 'Pago'
                                      {condicaoWhere}
                                    group by DataDeVencimento
                                    order by DataDeVencimento;";
            List<ConsultaPagamento> lista = new List<ConsultaPagamento>();
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DataInicial", consulta.DataInicial);
                if (consulta.DataFinal.ToString() != "01/01/0001 00:00:00")
                {
                    cmd.Parameters.AddWithValue("@DataFinal", consulta.DataFinal);
                }
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        ConsultaPagamento consultaPagamento = new ConsultaPagamento();
                        consultaPagamento.Dias = Convert.ToDateTime(sdr["DataDeVencimento"]).ToString("dd/MM/yyyy");
                        consultaPagamento.Debito = string.IsNullOrEmpty(sdr["Debito"].ToString()) == true ? 0 : Convert.ToDecimal(sdr["Debito"]);
                        consultaPagamento.Dinheiro = string.IsNullOrEmpty(sdr["Dinheiro"].ToString()) == true ? 0 : Convert.ToDecimal(sdr["Dinheiro"]);
                        consultaPagamento.Credito = string.IsNullOrEmpty(sdr["Credito"].ToString()) == true ? 0 : Convert.ToDecimal(sdr["Credito"]) ;
                        lista.Add(consultaPagamento);
                    }
                }
            }
            return lista;
        }
    }
}