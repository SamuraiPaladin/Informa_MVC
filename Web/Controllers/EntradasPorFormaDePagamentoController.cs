using Web.Model.Entity;
using Model.Enums;
using System;
using System.Linq;
using System.Web.Mvc;
using Web.BD.Interface;
using Web.BD.Repository;

namespace Web.Controllers
{
    public class EntradasPorFormaDePagamentoController : Controller
    {
        private readonly IDAO<Mensalidade> dAO = new MensalidadeDAO();
        private readonly MensalidadeDAO dAOMensalidade = new MensalidadeDAO();
        private readonly IUsuarioDAO<Usuario> _serviceUsuario = new UsuarioDAO();


        public ActionResult Index()
        {
            if (_serviceUsuario.ValidaUsuarioNoCache())
            {
                dAOMensalidade.AlterarMensalidadeParaVencido();
                Mensalidade model = new Mensalidade
                {
                    EntradasPorPagamento = dAOMensalidade.EntradasPorPagamento(),
                };

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}