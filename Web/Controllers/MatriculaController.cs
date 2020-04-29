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
    public class MatriculaController : Controller
    {
        private readonly IDAOMatricula<Matricula> dAO = new MatriculaDAO();
        private readonly MatriculaDAO dAOMatricula = new MatriculaDAO();
        public JsonResult BuscaCep(string cep)
        {
            var cepDados = ViaCEP.ViaCEPClient.Search(cep);
            Matricula model = new Matricula
            {
                Bairro = cepDados.Neighborhood,
                CEP = cep,
                Cidade = cepDados.City,
                Endereco = cepDados.Street,
                Estado = cepDados.StateInitials
            };
            return Json(model);
        }
        public ActionResult Index()
        {
            var model = new Matricula
            {
                ListaMatricula = dAOMatricula.Lista().ToList(),
                ListaMatriculaTurma = dAOMatricula.ListaMatriculaTurma().ToList(),
                DadosMatriculaTurma = new MatriculaTurma()
            };
            return View(model);
        }
        public JsonResult Adicionar(Matricula entity)
        {
            if (VerificaSeTemCampoVazioOuNulo(entity))
                return Json("Preenchimento obrigatório");
            else
            {

                if (dAO.VerificarSeJaExiste(entity))
                {
                    return Json(dAO.AtivarMatricula(entity));
                }
                else
                {
                    return Json(dAO.Adicionar(entity));
                }
            }
        }
        private static bool VerificaSeTemCampoVazioOuNulo(Matricula entity)
        {
            if (entity.DataNascimento.ToString("dd/MM/yyyy HH:mm:ss") == "01/01/0001 00:00:00" || string.IsNullOrWhiteSpace(entity.Nome) || string.IsNullOrWhiteSpace(entity.CPF) || string.IsNullOrWhiteSpace(entity.RG) || string.IsNullOrWhiteSpace(entity.CEP) || string.IsNullOrWhiteSpace(entity.Endereco)
                || string.IsNullOrWhiteSpace(entity.Numero) || string.IsNullOrWhiteSpace(entity.Bairro) || string.IsNullOrWhiteSpace(entity.Cidade) || string.IsNullOrWhiteSpace(entity.Estado) || string.IsNullOrWhiteSpace(entity.Telefone) || entity.Array == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public JsonResult Editar(Matricula entity, Matricula entityEditar)
        {
            if (VerificaSeTemCampoVazioOuNulo(entityEditar))
                return Json("Preenchimento obrigatório");
            else
                return Json(dAO.Atualizar(entity, entityEditar));
        }
        public JsonResult Deletar(Matricula entity)
        {
            List<int> listaIdMensalidade = dAO.ListaDeMensalidades(entity.Id);
            if (listaIdMensalidade.Count > 0)
            {
                dAO.DeletarListaMensalidade(listaIdMensalidade);
            }

            dAO.DeletarMatriculaTurma(entity.Id);
            return Json(dAO.Deletar(entity));
        }
        public JsonResult ModalEditar(int id)
        {

            var model = new Matricula()
            {
                DadosMatriculaTurma = dAO.DadosMatriculaPorId(id),
                ListaMatriculaTurma = dAO.ListaMatriulaTurmaPorId(id)
            };
            ViewBag.Nome = model.DadosMatriculaTurma.Nome;
            return Json(model);
        }
        public JsonResult Tabela(int id)
        {
            var listaMatriculaTurmaAtiva = dAO.ListaMatriulaTurmaPorId(id);
            var listaCompleta = dAO.ListaMatriculaTurma();
            var lista = new List<MatriculaTurma>();
            foreach (var item in listaCompleta)
            {
                if (listaMatriculaTurmaAtiva.Where(l => l.Id == item.Id).Count() > 0)
                {
                    item.Ativo = true;
                    lista.Add(item);
                }
                else
                {
                    lista.Add(item);
                }
            }
            //curso, tipo, professor, diadasemana, horarioinicial, horariofinal


            return Json(lista, JsonRequestBehavior.AllowGet);
        }
    }
}