﻿using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.BD.Interface
{
    public interface IDAOMatricula<T> : IDAO<T>
    {
        IList<MatriculaTurma> ListaMatriculaTurma();
        IList<MatriculaTurma> ListaMatriulaTurmaPorId(int id);
        void DeletarMatriculaTurma(int id);
        MatriculaTurma DadosMatriculaPorId(int id);
    }
}