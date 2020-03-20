﻿using Model;
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
            return View(dAOColaborador.ReturnColaboradorFormViewModel());
        }
        public JsonResult Adicionar(Colaborador Colaborador)
        {
            if (VerificaSeTemCampoVazioOuNulo(Colaborador))
                return Json("Preenchimento obrigatório");
            else
                return Json(dAO.Adicionar(Colaborador));
        }

        private static bool VerificaSeTemCampoVazioOuNulo(Colaborador Colaborador)
        {
            return string.IsNullOrWhiteSpace(Colaborador.Nome.Trim());
        }

        public JsonResult Editar(Colaborador Colaborador, Colaborador ColaboradorEditar)
        {
            if (VerificaSeTemCampoVazioOuNulo(ColaboradorEditar))
                return Json("Preenchimento obrigatório");
            else
                return Json(dAO.Atualizar(Colaborador, ColaboradorEditar));
        }
        public JsonResult Deletar(Colaborador Colaborador)
        {
            if (VerificaSeTemCampoVazioOuNulo(Colaborador))
                return Json("Preenchimento obrigatório");
            else
                return Json(dAO.Deletar(Colaborador));
        }
        //public ActionResult Cadastrar()
        //{
        //    var viewModel = dAOColaborador.ReturnColaboradorFormViewModel();

        //    return View(viewModel);
        //}
    }
}
