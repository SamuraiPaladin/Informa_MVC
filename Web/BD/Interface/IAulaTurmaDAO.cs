using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.BD.Interface
{
    public interface IAulaTurmaDAO
    {
        IList<Aula> ListaDeTurmas();
        IList<Aula> AulasNaDataDeHoje();
        IList<Aula> ListaDeAlunosParaPresencaAtual();
        void SalvarListaDePresencaParaDataAtual(IList<Aula> listaDeAlunosParaPresencaAtual);
        IList<Aula> AlunosPorTurma(int turmaId);
    }
}