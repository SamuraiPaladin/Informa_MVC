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
    public class UsuarioSistemaController : Controller
    {
        private readonly IUsuarioDAO<Usuario> _service = new UsuarioDAO();

        public ActionResult Index()
        {
            if (_service.ValidaUsuarioNoCache()) {
                var usuario = new Usuario()
                {
                    ListaDeUsuarios = _service.Lista(),
                    ListaDeColaboradores = _service.ListaColaboradores()
                };
                return View(usuario);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public JsonResult Adicionar(Usuario usuario)
        {
            if (VerificaSeTemCampoVazioOuNulo(usuario))
                return Json("Preenchimento obrigatório");
            else
            {
                if (_service.VerificarSeJaExiste(usuario))
                {
                    return Json("Já existe este usuário no sistema");
                }
                else
                {
                    return Json(_service.Adicionar(usuario));
                }
            }
        }
        public JsonResult Editar(Usuario usuario)
        {
            return Json(_service.DadosDoUsuario(usuario.Id));
        }
        public JsonResult Atualizar(Usuario usuario)
        {
            if (VerificaSeTemCampoVazioOuNulo(usuario))
                return Json("Preenchimento obrigatório");
            else
            {
                return Json(_service.Atualizar(usuario));
            }
        }
        public JsonResult Deletar(Usuario usuario)
        {
                return Json(_service.Deletar(usuario));
        }
        private bool VerificaSeTemCampoVazioOuNulo(Usuario usuario)
        {
            return (string.IsNullOrEmpty(usuario.Nome)) || (string.IsNullOrEmpty(usuario.PerfilUsuario)) 
                || (string.IsNullOrEmpty(usuario.Senha));
        }
    }
}