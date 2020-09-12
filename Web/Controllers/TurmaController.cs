using Model;
using Web.Model.Entity;
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
    public class TurmaController : Controller
    {

        //private readonly IServiceTurma<Turma> dAO;

        private readonly IDAO<Turma> dAO = new TurmaDAO();
        private readonly TurmaDAO dAOTurma = new TurmaDAO();
        private readonly IUsuarioDAO<Usuario> _serviceUsuario = new UsuarioDAO();


        public ActionResult Index()
        {
            if (_serviceUsuario.ValidaUsuarioNoCache())
            {
                var model = new Turma
                {
                    ListaUnidade = dAOTurma.ReturnTurmaUnidadesLista(),
                    ListaModalidade = dAOTurma.ReturnTurmaModalidadesLista(),
                    ListaColaborador = dAOTurma.ReturnTurmaColaboradorLista(),
                    ListaTurma = dAOTurma.ReturnTurmaLista(),
                    DiasDaSemana = Enum.GetValues(typeof(EnumDays.DaysOfWeek)),
                    TipoClientes = Enum.GetValues(typeof(EnumClients.Clients))
                };

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
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
                if (VerificaHorario(Turma.HorarioInicial, Turma.HorarioFinal))
                    return Json("Horário inicial não pode ser maior que o final.");
                else if (VerificaSeExisteTurmaNesseHorarios(Turma))
                {
                    return Json($"Professor já tem aula nesse horário.");
                }
                else
                {
                    return Json(dAO.Adicionar(Turma));
                }
            }
        }

        private bool VerificaSeExisteTurmaNesseHorarios(Turma turma)
        {
            return dAOTurma.VerificaSeExisteTurmaNesseHorarios(turma);
        }

        private static bool VerificaSeTemCampoVazioOuNulo(Turma Turma)
        {
            return string.IsNullOrWhiteSpace(Turma.Descricao) || Turma.ColaboradorId == 0 || string.IsNullOrEmpty(Turma.DiaDaSemana) || string.IsNullOrEmpty(Turma.HorarioFinal)
                 || string.IsNullOrEmpty(Turma.HorarioInicial) || Turma.ModalidadeId == 0 || string.IsNullOrEmpty(Turma.Tipo) || Turma.UnidadeId == 0;
        }

        private bool VerificaHorario(string inicial, string final)
        {
            if (DateTime.Compare(Convert.ToDateTime(inicial), Convert.ToDateTime(final)) > 0)
                return true;
            else
                return false;
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
                if (VerificaHorario(Turma.HorarioInicial, Turma.HorarioFinal))
                    return Json("Horário inicial não pode ser maior que o final.");
                else
                    if (VerificaSeExisteTurmaNesseHorarios(TurmaEditar))
                        return Json($"Professor já tem aula nesse horário.");
                    else
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
