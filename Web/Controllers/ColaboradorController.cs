using Model;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.BD.Interface;
using Web.BD.Repository;

namespace Web.Controllers
{
    public class ColaboradorController : Controller
    {

        //private readonly IServiceColaborador<Colaborador> dAO;

        //public ColaboradorController(IServiceColaborador<Colaborador> service)
        //{
        //    dAO = service;
        //}


        private readonly IDAO<Colaborador> dAO = new ColaboradorDAO();
        private readonly ColaboradorDAO dAOColaborador = new ColaboradorDAO();


        public ActionResult Index()
        {
            var model = new Colaborador
            {
                ListaFuncao = dAOColaborador.ReturnColaboradorFuncoesLista(),
                ListaColaborador = dAOColaborador.ReturnColaboradoresLista()
            };

            return View(model);
        }
        public JsonResult Adicionar(Colaborador Colaborador)
        {
            if (VerificaSeTemCampoVazioOuNulo(Colaborador))
                return Json("Preenchimento obrigatório");
            else
                if (dAOColaborador.VerificarSeJaExiste(Colaborador, 0))
            {
                return Json(false);
            }
            else
            {
                return Json(dAO.Adicionar(Colaborador));
            }
        }

        private static bool VerificaSeTemCampoVazioOuNulo(Colaborador entity)
        {
            if (entity.DataNascimento.ToString("dd/MM/yyyy HH:mm:ss") == "01/01/0001 00:00:00" || string.IsNullOrWhiteSpace(entity.Nome) || string.IsNullOrWhiteSpace(entity.CPF) || string.IsNullOrWhiteSpace(entity.RG) || string.IsNullOrWhiteSpace(entity.CEP) || string.IsNullOrWhiteSpace(entity.Endereco)
            || string.IsNullOrWhiteSpace(entity.Numero) || string.IsNullOrWhiteSpace(entity.Bairro) || string.IsNullOrWhiteSpace(entity.Cidade) || string.IsNullOrWhiteSpace(entity.Estado) || string.IsNullOrWhiteSpace(entity.Telefone) 
            || string.IsNullOrWhiteSpace(entity.Email) || !entity.Email.Contains('@') || entity.FuncaoId == 0) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public JsonResult Editar(Colaborador Colaborador, Colaborador ColaboradorEditar)
        {
            if (VerificaSeTemCampoVazioOuNulo(ColaboradorEditar))
                return Json("Preenchimento obrigatório");
            else
               if (dAOColaborador.VerificarSeJaExiste(ColaboradorEditar, 1))
            {
                return Json(false);
            }
            else
            {
                return Json(dAO.Atualizar(Colaborador, ColaboradorEditar));
            }
        }
        public JsonResult Deletar(Colaborador colaborador)
        {
            if (colaborador.Id == 0)
                return Json("Preenchimento obrigatório");
            else
                return Json(dAO.Deletar(colaborador));
        }
    }
}
