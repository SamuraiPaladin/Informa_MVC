using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.BD.Interface;
using Web.BD.Repository;

namespace Web.Controllers
{
    public class PrincipalController : Controller
    {
        private readonly IDAOPrincipal dAOPrincipal = new PrincipalDAO();
        public ActionResult Index()
        {
            new MensalidadeDAO().AlterarMensalidadeParaVencido();
            ViewBag.Quantidade = dAOPrincipal.QuantidadeDePagamentoAtraso();
            return View();
        }
        public JsonResult QuantidadeDeAtrasados()
        {
            return Json(dAOPrincipal.QuantidadeDePagamentoAtraso());
            //ViewBag.Quantidade = dAOPrincipal.QuantidadeDePagamentoAtraso();
        }
    }
}