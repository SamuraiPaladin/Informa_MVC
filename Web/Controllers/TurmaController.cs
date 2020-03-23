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
    public class TurmaController : Controller
    {

        //private readonly IServiceTurma<Turma> dAO;

        private readonly IDAO<Turma> dAO = new TurmaDAO();
        private readonly TurmaDAO dAOTurma = new TurmaDAO();


        public ActionResult Index()
        {
            var model = new Turma
            {
                ListaUnidade = dAOTurma.ReturnTurmaUnidadesLista(),
                ListaModalidade = dAOTurma.ReturnTurmaModalidadesLista(),
                ListaColaborador = dAOTurma.ReturnTurmaColaboradorLista(),
                ListaTurma = dAOTurma.ReturnTurmaLista(),
            };

            return View(model);
        }
        public JsonResult Adicionar(Turma Turma)
        {
            if (VerificaSeTemCampoVazioOuNulo(Turma))
                return Json("Preenchimento obrigatório");
            else
                if (dAO.VerificarSeJaExiste(Turma))
            {
                return Json(false);
            }
            else
            {
                return Json(dAO.Adicionar(Turma));
            }
        }

        private static bool VerificaSeTemCampoVazioOuNulo(Turma Turma)
        {
            return string.IsNullOrWhiteSpace(Turma.Descricao.Trim());
        }

        public JsonResult Editar(Turma Turma, Turma TurmaEditar)
        {
            if (VerificaSeTemCampoVazioOuNulo(TurmaEditar))
                return Json("Preenchimento obrigatório");
            else
               if (dAO.VerificarSeJaExiste(TurmaEditar))
            {
                return Json(false);
            }
            else
            {
                return Json(dAO.Atualizar(Turma, TurmaEditar));
            }
        }
        public JsonResult Deletar(Turma Turma)
        {
            if (VerificaSeTemCampoVazioOuNulo(Turma))
                return Json("Preenchimento obrigatório");
            else
                return Json(dAO.Deletar(Turma));
        }
        //public ActionResult Cadastrar()
        //{
        //    var viewModel = dAOTurma.ReturnTurmaFormViewModel();

        //    return View(viewModel);
        //}
    }
}