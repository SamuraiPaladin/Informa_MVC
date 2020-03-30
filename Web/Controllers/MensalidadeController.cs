﻿using Model;
using Model.Entity;
using Model.Enums;
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
    public class MensalidadeController : Controller
    {

        //private readonly IServiceMensalidade<Mensalidade> dAO;

        private readonly IDAO<Mensalidade> dAO = new MensalidadeDAO();
        private readonly MensalidadeDAO dAOMensalidade = new MensalidadeDAO();

        public Mensalidade model = new Mensalidade();

        public ActionResult Index()
        {
            model = new Mensalidade
            {
                ListaMensalidade = dAOMensalidade.ListaMensalidade(),
                ListaAluno = dAOMensalidade.ReturnMensalidadeAlunoLista(),
                ListaModalidade = dAOMensalidade.ReturnMensalidadeModalidadesLista(),
                ListaTurma = dAOMensalidade.ReturnMensalidadeTurmasLista(),
                FormasDePagamentos = Enum.GetValues(typeof(EnumPaymentForms.PaymentForms)),
                StatusDasMensalidades = Enum.GetValues(typeof(EnumPaymentStatus.PaymentStatus))
            };

            return View(model);
        }
        public JsonResult Adicionar(Mensalidade Mensalidade)
        {
            if (VerificaSeTemCampoVazioOuNulo(Mensalidade))
                return Json("Preenchimento obrigatório");
            else
                if (dAO.VerificarSeJaExiste(Mensalidade))
            {
                return Json(false);
            }
            else
            {
                return Json(dAO.Adicionar(Mensalidade));
            }
        }

        public ActionResult BuscaPorNome(string Nome)
        {
            var model = new Mensalidade();
            if (!String.IsNullOrEmpty(Nome)) {
                model = new Mensalidade
                {
                    ListaMensalidade = dAOMensalidade.ListaMensalidadePorNome(Nome),
                    ListaAluno = dAOMensalidade.ReturnMensalidadeAlunoLista(),
                    ListaModalidade = dAOMensalidade.ReturnMensalidadeModalidadesLista(),
                    ListaTurma = dAOMensalidade.ReturnMensalidadeTurmasLista(),
                    FormasDePagamentos = Enum.GetValues(typeof(EnumPaymentForms.PaymentForms)),
                    StatusDasMensalidades = Enum.GetValues(typeof(EnumPaymentStatus.PaymentStatus))
                };
            }
            else
            {
                return Json("Preenchimento obrigatório");
            }

            return PartialView("Index", model);
        }


        private static bool VerificaSeTemCampoVazioOuNulo(Mensalidade Mensalidade)
        {
            return string.IsNullOrWhiteSpace(Mensalidade.DataDeVencimento.ToString());
        }

        public JsonResult Editar(Mensalidade Mensalidade, Mensalidade MensalidadeEditar)
        {
            if (VerificaSeTemCampoVazioOuNulo(MensalidadeEditar))
                return Json("Preenchimento obrigatório");
            else
               if (dAO.VerificarSeJaExiste(MensalidadeEditar))
            {
                return Json(false);
            }
            else
            {
                return Json(dAO.Atualizar(Mensalidade, MensalidadeEditar));
            }
        }
        public JsonResult Deletar(Mensalidade Mensalidade)
        {
            if (VerificaSeTemCampoVazioOuNulo(Mensalidade))
                return Json("Preenchimento obrigatório");
            else
                return Json(dAO.Deletar(Mensalidade));
        }
        //public ActionResult Cadastrar()
        //{
        //    var viewModel = dAOMensalidade.ReturnMensalidadeFormViewModel();

        //    return View(viewModel);
        //}
    }
}