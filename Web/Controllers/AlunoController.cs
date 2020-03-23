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
    public class AlunoController : Controller
    {

        //private readonly IServiceAluno<Aluno> dAO;

        //public AlunoController(IServiceAluno<Aluno> service)
        //{
        //    dAO = service;
        //}


        private readonly IDAO<Aluno> dAO = new AlunoDAO();
        private readonly AlunoDAO dAOAluno = new AlunoDAO();

        public JsonResult BuscaCep(string cep)
        {
        var cepDados = ViaCEP.ViaCEPClient.Search(cep);
            Aluno aluno = new Aluno
            {
                Bairro = cepDados.Neighborhood,
                CEP = cep,
                Cidade = cepDados.City,
                Endereco = cepDados.Street,
                Estado = cepDados.StateInitials
            };
            return Json(aluno);
        }

        public ActionResult Index()
       {
            var model = new Aluno
            {
                ListaAluno = dAOAluno.ReturnAlunosLisat()
            };

            return View(model);
        }
        public JsonResult Adicionar(Aluno Aluno)
        {
            if (VerificaSeTemCampoVazioOuNulo(Aluno))
                return Json("Preenchimento obrigatório");
            else
                return Json(dAO.Adicionar(Aluno));
        }

        private static bool VerificaSeTemCampoVazioOuNulo(Aluno Aluno)
        {
            return string.IsNullOrWhiteSpace(Aluno.Nome.Trim());
        }

        public JsonResult Editar(Aluno Aluno, Aluno AlunoEditar)
        {
            if (VerificaSeTemCampoVazioOuNulo(AlunoEditar))
                return Json("Preenchimento obrigatório");
            else
                return Json(dAO.Atualizar(Aluno, AlunoEditar));
        }
        public JsonResult Deletar(Aluno Aluno)
        {
            if (VerificaSeTemCampoVazioOuNulo(Aluno))
                return Json("Preenchimento obrigatório");
            else
                return Json(dAO.Deletar(Aluno));
        }
        //public ActionResult Cadastrar()
        //{
        //    var viewModel = dAOAluno.ReturnAlunoFormViewModel();

        //    return View(viewModel);
        //}
    }
}
