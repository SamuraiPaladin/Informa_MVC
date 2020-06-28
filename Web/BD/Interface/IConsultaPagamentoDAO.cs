using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.BD.Interface
{
    public interface IConsultaPagamentoDAO
    {
        IList<ConsultaPagamento> ListaDeValores(ConsultaPagamento consulta);
    }
}
