using Web.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.BD.Interface;
using Web.BD.Repository;
using System.Web.Caching;

namespace Web.Controllers
{
    public class AulaController : Controller
    {
        private readonly IAulaTurmaDAO _service = new AulaTurmaDAO();
        private IList<Aula> listaDeAulasPorTurma = new List<Aula>();
        private readonly IUsuarioDAO<Usuario> _serviceUsuario = new UsuarioDAO();

        public ActionResult Index()
        {
            if (_serviceUsuario.ValidaUsuarioNoCache()) {
                var usuarioCache = (Usuario) new Cache()["DadosDoUsuario"];

                IList<Aula> aulasNaDataDeHoje = null;

                if (usuarioCache.PerfilUsuario == "Administrador")
                {
                    aulasNaDataDeHoje = _service.AulasNaDataDeHoje();
                }
                else
                {
                    aulasNaDataDeHoje = _service.AulasNaDataDeHojeColab(usuarioCache.IdColaborador);
                }
                if (aulasNaDataDeHoje.Count() < 1)
                {
                    var listaDeAlunosParaPresencaAtual = _service.ListaDeAlunosParaPresencaAtual();
                    if (listaDeAlunosParaPresencaAtual.Count() > 0)
                    {
                        _service.SalvarListaDePresencaParaDataAtual(listaDeAlunosParaPresencaAtual);
                    }

                }
                return View(_service.ListaDeTurmas());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public JsonResult CarregarListaDeChamada(int turmaId)
        {
            listaDeAulasPorTurma = _service.AlunosPorTurma(turmaId);
            return Json(listaDeAulasPorTurma);
        }

        public JsonResult Editar(Aula[] entity)
        {
            _service.Atualizar(entity);
            return Json(true);
        }
    }
}