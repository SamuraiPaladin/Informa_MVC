using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.BD.Interface;
using Web.BD.Repository;

namespace Web.Controllers
{
    public class ConsultaPagamentoController : Controller
    {
        private readonly IConsultaPagamentoDAO consultaPagamentoDAO = new ConsultaPagamentoDAO();
        // GET: ConsultaPagamento
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ConsultaTabela(ConsultaPagamento consultaPagamento)
        {
            if (!VerificaSeTemCampoVazioOuNulo(consultaPagamento))
            {
                return Json(consultaPagamentoDAO.ListaDeValores(consultaPagamento));
            }
            else
            {
                return Json("");
            }

        }

        private bool VerificaSeTemCampoVazioOuNulo(ConsultaPagamento consultaPagamento)
        {
            return  consultaPagamento.DataInicial.ToString() == "01/01/0001 00:00:00" || string.IsNullOrEmpty(consultaPagamento.DataInicial.ToString()) ;
        }
    }
}