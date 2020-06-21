using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using Web.BD.Interface;
using Web.BD.Repository;

namespace Web.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioDAO<Usuario> _service = new UsuarioDAO();
        Cache cache = new Cache();

        // GET: Login
        public ActionResult Index()
        {
            if (cache["DadosDoUsuario"] != null)
            {
                cache.Remove("DadosDoUsuario");
            }
            return View();
        }

        public JsonResult Logar(Usuario usuario)
        {
            if (VerificaSeTemCampoVazioOuNulo(usuario))
            {
                return Json("Usuário e/ou Senha obrigatórios");
            }
            else
            {
                if (_service.VerificarSeJaExiste(usuario))
                {
                    Usuario usuarioEmCache = _service.Autentica(usuario);

                    if (usuarioEmCache.Id == 0 || string.IsNullOrEmpty(usuarioEmCache.Nome) || string.IsNullOrEmpty(usuarioEmCache.PerfilUsuario)) 
                    {
                        return Json(false);
                    }
                    cache["DadosDoUsuario"] = usuarioEmCache;
                    cache["DadosDoUsuario.Nome"] = usuarioEmCache.Nome;
                    cache["DadosDoUsuario.PerfilUsuario"] = usuarioEmCache.PerfilUsuario;
                }
                else
                {
                    return Json(false);
                }
            }
            return Json(true);
        }

        private bool VerificaSeTemCampoVazioOuNulo(Usuario usuario)
        {
            return (string.IsNullOrEmpty(usuario.Nome)) || (string.IsNullOrEmpty(usuario.Senha));
        }

    }
}