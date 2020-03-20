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
    public class FuncaoController : Controller
    {
        private readonly IDAO<Funcao> _service = new FuncaoDAO();
        public ActionResult Index()
        {
            return View(_service.Lista());
        }
        public JsonResult Adicionar(Funcao funcao)
        {
            if (VerificaSeTemCampoVazioOuNulo(funcao))
                    return Json("Preenchimento obrigatório");
            else
            {
                if (_service.VerificarSeJaExiste(funcao))
                    return Json(false);
                else
                    return Json(_service.Adicionar(funcao));
            }
        }

        private static bool VerificaSeTemCampoVazioOuNulo(Funcao funcao)
        {
            return string.IsNullOrWhiteSpace(funcao.Descricao) || string.IsNullOrWhiteSpace(funcao.TipoFuncao);
        }

        public JsonResult Editar(Funcao funcao, Funcao funcaoEditar)
        {
            if (VerificaSeTemCampoVazioOuNulo(funcaoEditar))
                return Json("Preenchimento obrigatório");
            else
            {
                if (_service.VerificarSeJaExiste(funcaoEditar))
                    return Json(false);
                else
                    return Json(_service.Atualizar(funcao, funcaoEditar));
            }
        }
        public JsonResult Deletar(Funcao funcao)
        {
            if (VerificaSeTemCampoVazioOuNulo(funcao))
                return Json("Preenchimento obrigatório");
            else
            {
               return Json(_service.Deletar(funcao));
            }
        }
    }
}