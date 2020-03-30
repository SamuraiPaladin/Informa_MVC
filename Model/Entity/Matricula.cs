﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entity
{
    public class Matricula
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string RG { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public IList<MatriculaTurma> ListaMatriculaTurma { get; set; }
        public List<Matricula> ListaMatricula { get; set; }
        public string[] Array { get; set; }
        public MatriculaTurma DadosMatriculaTurma { get; set; }
    }
}