﻿using Model.Entity;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.BD.Interface;

namespace Web.BD.Repository
{
    public class AlunoDAO : IDAO<Aluno>
    {
        private readonly string stringConexao = ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
        public bool Adicionar(Aluno entity)
        {
            
            string query = @"INSERT INTO Alunos
               (Nome, CPF, DataNascimento, RG, CEP, Endereco, Numero, Bairro, Cidade, Estado, Telefone)
			    Values(@Nome, @CPF, @DataNascimento, @RG, @CEP, @Endereco, @Numero, @Bairro, @Cidade, @Estado, @Telefone);
                SELECT @@IDENTITY";

            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@DataNascimento", entity.DataNascimento);
                cmd.Parameters.AddWithValue("@CPF", entity.CPF);
                cmd.Parameters.AddWithValue("@RG", entity.RG);
                cmd.Parameters.AddWithValue("@Endereco", entity.Endereco);
                cmd.Parameters.AddWithValue("@CEP", entity.CEP);
                cmd.Parameters.AddWithValue("@Numero", entity.Numero);
                cmd.Parameters.AddWithValue("@Bairro", entity.Bairro);
                cmd.Parameters.AddWithValue("@Cidade", entity.Cidade);
                cmd.Parameters.AddWithValue("@Estado", entity.Estado);
                cmd.Parameters.AddWithValue("@Telefone", entity.Telefone);

                cmd.ExecuteNonQuery();
                return true;
            }
        }

    

        public bool Atualizar(Aluno entityAntigo, Aluno entityNovo)
        {
        
            string query = @"UPDATE Alunos 
                SET
                  Nome = @NomeNovo,
                  CPF = @CPFNovo,
                  DataNascimento = @DataNascimentoNovo,
                  RG = @RGNovo,
                  CEP =  @CEPNovo,
                  Endereco = @EnderecoNovo,
                  Numero = @NumeroNovo,
                  Bairro = @BairroNovo,
                  Cidade = @CidadeNovo,
                  Estado = @EstadoNovo,
                  Telefone = @TelefoneNovo
                WHERE   
                  ID = @IDAntigo";

            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@NomeNovo", entityNovo.Nome);
                cmd.Parameters.AddWithValue("@DataNascimentoNovo", entityNovo.DataNascimento);
                cmd.Parameters.AddWithValue("@CPFNovo", entityNovo.CPF);
                cmd.Parameters.AddWithValue("@RGNovo", entityNovo.RG);
                cmd.Parameters.AddWithValue("@EnderecoNovo", entityNovo.Endereco);
                cmd.Parameters.AddWithValue("@CEPNovo", entityNovo.CEP);
                cmd.Parameters.AddWithValue("@NumeroNovo", entityNovo.Numero);
                cmd.Parameters.AddWithValue("@BairroNovo", entityNovo.Bairro);
                cmd.Parameters.AddWithValue("@CidadeNovo", entityNovo.Cidade);
                cmd.Parameters.AddWithValue("@EstadoNovo", entityNovo.Estado);
                cmd.Parameters.AddWithValue("@TelefoneNovo", entityNovo.Telefone);

                cmd.Parameters.AddWithValue("@IDAntigo", entityAntigo.Id);
                //cmd.Parameters.AddWithValue("@DataNascimentoAntigo", entityAntigo.DataNascimento);
                //cmd.Parameters.AddWithValue("@CPFAntigo", entityAntigo.CPF);
                //cmd.Parameters.AddWithValue("@RGAntigo", entityAntigo.RG);
                //cmd.Parameters.AddWithValue("@EnderecoAntigo", entityAntigo.Endereco);
                //cmd.Parameters.AddWithValue("@CEPAntigo", entityAntigo.CEP);
                //cmd.Parameters.AddWithValue("@NumeroAntigo", entityAntigo.Numero);
                //cmd.Parameters.AddWithValue("@BairroAntigo", entityAntigo.Bairro);
                //cmd.Parameters.AddWithValue("@CidadeAntigo", entityAntigo.Cidade);
                //cmd.Parameters.AddWithValue("@EstadoAntigo", entityAntigo.Estado);
                //cmd.Parameters.AddWithValue("@TelefoneAntigo", entityAntigo.Telefone);
                cmd.ExecuteNonQuery();
                return true;
            }
        }
        public bool Deletar(Aluno entity)
        {
            string query = @"DELETE FROM Alunos
                              WHERE 
                              ID = @ID";

            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", entity.Id);
                cmd.ExecuteNonQuery();
                return true;
            }
        }

        public IList<Aluno> Lista()
        {
            throw new NotImplementedException();
        }

        public List<Aluno> ReturnAlunosLisat()
        {
            string query = "SELECT * from Alunos";
            List<Aluno> alunos = new List<Aluno>();
            using (var con = new SqlConnection(stringConexao))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        var model = new Aluno
                        {
                            Id = (int)sdr["Id"],
                            Nome = sdr["Nome"].ToString(),
                            DataNascimento = DateTime.Parse(sdr["DataNascimento"].ToString()),
                            CPF = sdr["CPF"].ToString(),
                            RG = sdr["RG"].ToString(),
                            Endereco = sdr["Endereco"].ToString(),
                            CEP = sdr["CEP"].ToString(),
                            Numero = sdr["Numero"].ToString(),
                            Bairro = sdr["Bairro"].ToString(),
                            Cidade = sdr["Cidade"].ToString(),
                            Estado = sdr["Estado"].ToString(),
                            Telefone = sdr["Telefone"].ToString(),
                        };
                        alunos.Add(model);
                    }
                }
                con.Close();
                return alunos;
            }
        }

        public bool VerificarSeJaExiste(Aluno entity)
        {
            string query = @"SELECT COUNT(1) AS qtd
                            FROM Alunos WHERE 
                            Nome = @Nome AND
                            DataNascimento = @DataNascimento AND
                            CPF = @CPF AND
                            RG = @RG AND
                            Endereco = @Endereco AND
                            CEP = @CEP AND
                            Numero = @Numero AND
                            Bairro =  @Bairro AND
                            Cidade = @Cidade AND
                            Estado = @Estado AND
                            Telefone = @Telefone";   

            return GravarERetornarVerdadeiroOuFalse(entity, query);
        }

        private bool GravarERetornarVerdadeiroOuFalse(Aluno entity, string query)
        {
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@DataNascimento", entity.DataNascimento);
                cmd.Parameters.AddWithValue("@CPF", entity.CPF);
                cmd.Parameters.AddWithValue("@RG", entity.RG);
                cmd.Parameters.AddWithValue("@Endereco", entity.Endereco);
                cmd.Parameters.AddWithValue("@CEP", entity.CEP);
                cmd.Parameters.AddWithValue("@Numero", entity.Numero);
                cmd.Parameters.AddWithValue("@Bairro", entity.Bairro);
                cmd.Parameters.AddWithValue("@Cidade", entity.Cidade);
                cmd.Parameters.AddWithValue("@Estado", entity.Estado);
                cmd.Parameters.AddWithValue("@Telefone", entity.Telefone);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0 ? true : false;
            }
        }

    }
}