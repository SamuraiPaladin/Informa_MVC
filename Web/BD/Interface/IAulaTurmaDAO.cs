﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Model.Entity;

namespace Web.BD.Interface
{
    public interface IAulaTurmaDAO
    {
        IList<Aula> ListaDeTurmas();
        IList<Aula> AulasNaDataDeHoje();
        IList<Aula> AulasNaDataDeHojeColab(int IdColaborador);
        IList<Aula> ListaDeAlunosParaPresencaAtual();
        void SalvarListaDePresencaParaDataAtual(IList<Aula> listaDeAlunosParaPresencaAtual);
        IList<Aula> AlunosPorTurma(int turmaId);
        void Atualizar(Aula[] entity);
    }
}