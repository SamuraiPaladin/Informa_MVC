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
    public class AulaController : Controller
    {
        private readonly IAulaTurmaDAO  _service = new AulaTurmaDAO();

        public ActionResult Index()
        {
            IList<Aula> aulasNaDataDeHoje = _service.AulasNaDataDeHoje();
            //Usar esse método no modal de matricula
            IList<Aula> listaDeAulasPorTurma = _service.AlunosPorTurma();
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
    }
}