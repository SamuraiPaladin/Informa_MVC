using Web.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.BD.Interface;
using Web.BD.Repository;

namespace Web.Controllers
{
    public class ModalidadeController : Controller
    {
        private readonly IModalidadeDAO<Modalidade> _service = new ModalidadeDAO();
        private readonly IUsuarioDAO<Usuario> _serviceUsuario = new UsuarioDAO();

        public ActionResult Index()
        {
            if (_serviceUsuario.ValidaUsuarioNoCache()) {
                return View(_service.Lista());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public JsonResult Adicionar(Modalidade modalidade)
        {
            if (VerificaSeTemCampoVazioOuNulo(modalidade))
                return Json("Preenchimento obrigatório");
            else
            {
                if (!_service.VerificarSeJaExiste(modalidade, false))
                    return Json(_service.Adicionar(modalidade));
                else 
                    return Json(false);
            }
        }
        private static bool VerificaSeTemCampoVazioOuNulo(Modalidade modalidade)
        {
            return string.IsNullOrWhiteSpace(modalidade.Descricao) || string.IsNullOrWhiteSpace(modalidade.TipoModalidade);
        }
        public JsonResult Editar(Modalidade modalidade, Modalidade modalidadeEditar)
        {
            if (VerificaSeTemCampoVazioOuNulo(modalidadeEditar))
                return Json("Preenchimento obrigatório");
            else
            {
                if (!_service.VerificarSeJaExiste(modalidadeEditar, true))
                    return Json(_service.Atualizar(modalidade, modalidadeEditar));
                else
                    return Json(false);
            }
        }
        public JsonResult Deletar(Modalidade modalidade)
        {
            //if (VerificaSeTemCampoVazioOuNulo(modalidade))
            //    return Json("Preenchimento obrigatório");
            //else
            if (_service.VerificarSeJaExiste(modalidade, false))
                return Json(_service.Deletar(modalidade));
            else
                return Json(false);
        }
    }
}