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
    public class UnidadeController : Controller
    {
        private readonly IUnidadeDAO<Unidade> dAO = new UnidadeDAO();
        private readonly IUsuarioDAO<Usuario> _serviceUsuario = new UsuarioDAO();


        public ActionResult Index()
        {
            if (_serviceUsuario.ValidaUsuarioNoCache())
            {
                return View(dAO.Lista());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public JsonResult BuscaCep(string cep)
        {
            var cepDados = ViaCEP.ViaCEPClient.Search(cep);
            Unidade unidade = new Unidade
            {
                Bairro = cepDados.Neighborhood,
                CEP = cep,
                Cidade = cepDados.City,
                Endereco = cepDados.Street,
                Estado = cepDados.StateInitials
            };
            return Json(unidade);
        }
        public JsonResult Adicionar(Unidade unidade)
        {
            if (VerificaSeTemCampoVazioOuNulo(unidade))
                return Json("Preenchimento obrigatório");
            else
            {
                if (!dAO.VerificarSeJaExiste(unidade, 0))
                    return Json(dAO.Adicionar(unidade));
                else
                    return Json(false);
            }
        }
        private bool VerificaSeTemCampoVazioOuNulo(Unidade unidade)
        {
            return string.IsNullOrEmpty(unidade.Bairro) || string.IsNullOrEmpty(unidade.CEP) || string.IsNullOrEmpty(unidade.Cidade) ||
                string.IsNullOrEmpty(unidade.Descricao) || string.IsNullOrEmpty(unidade.Endereco) || string.IsNullOrEmpty(unidade.Estado)
                || string.IsNullOrEmpty(unidade.Numero) || string.IsNullOrEmpty(unidade.Telefone) || string.IsNullOrEmpty(unidade.JurosMensal.ToString());
        }
        public JsonResult Editar(Unidade unidade, Unidade unidadeEditar)
        {
            if (VerificaSeTemCampoVazioOuNulo(unidadeEditar))
                return Json("Preenchimento obrigatório");
            else
                if (!dAO.VerificarSeJaExiste(unidadeEditar, 1))
                return Json(dAO.Atualizar(unidade, unidadeEditar));
            else
                return Json(false);
        }
        public JsonResult Deletar(Unidade unidade)
        {
            if (VerificaSeTemCampoVazioOuNulo(unidade))
                return Json("Preenchimento obrigatório");
            else
                if (dAO.VerificarSeJaExiste(unidade, 0))
                {
                    if (dAO.VerificarSeTemFilho(unidade))
                        return Json("Há Turmas cadastradas nessa Unidade. Não é possível deletar.");
                    else
                    return Json(dAO.Deletar(unidade));
                }
            else
                return Json(false);
        }
    }
}
