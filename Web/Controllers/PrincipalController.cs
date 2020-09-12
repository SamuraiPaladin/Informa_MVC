using Web.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Web.BD.Interface;
using Web.BD.Repository;

namespace Web.Controllers
{
    public class PrincipalController : Controller
    {
        private readonly IDAOPrincipal dAOPrincipal = new PrincipalDAO();
        private readonly IUsuarioDAO<Usuario> _serviceUsuario = new UsuarioDAO();
        private readonly IAulaTurmaDAO _service = new AulaTurmaDAO();

        public ActionResult Index()
        {
            if (_serviceUsuario.ValidaUsuarioNoCache())
            {
                new MensalidadeDAO().AlterarMensalidadeParaVencido();
                ViewBag.Quantidade = dAOPrincipal.QuantidadeDePagamentoAtraso();
                IList<Aula> aulasNaDataDeHoje = _service.AulasNaDataDeHoje();
                if (aulasNaDataDeHoje.Count() < 1)
                {
                    var listaDeAlunosParaPresencaAtual = _service.ListaDeAlunosParaPresencaAtual();
                    if (listaDeAlunosParaPresencaAtual.Count() > 0)
                    {
                        _service.SalvarListaDePresencaParaDataAtual(listaDeAlunosParaPresencaAtual);
                    }

                }
                return View(_service.ListaDeTurmas());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public JsonResult QuantidadeDeAtrasados()
        {
            return Json(dAOPrincipal.QuantidadeDePagamentoAtraso());
            //ViewBag.Quantidade = dAOPrincipal.QuantidadeDePagamentoAtraso();
        }
    }
}