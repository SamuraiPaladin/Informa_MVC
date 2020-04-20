using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.BD.Interface;

namespace Web.BD.Repository
{
    public class PrincipalDAO : IDAOPrincipal
    {
        private readonly string stringConexao = ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
        public int QuantidadeDePagamentoAtraso()
        {
            string query = "SELECT count(1) Quantidade FROM Mensalidades WHERE StatusDaMensalidade = 'Vencido'";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                return Convert.ToInt32(cmd.ExecuteScalar()); 
            }
        }
    }
}