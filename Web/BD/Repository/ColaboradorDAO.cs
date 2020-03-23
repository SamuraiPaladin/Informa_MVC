using Model.Entity;
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
    public class ColaboradorDAO : IDAO<Colaborador>
    {
        private readonly string stringConexao = ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
        public bool Adicionar(Colaborador entity)
        {
   //         string query = @"INSERT INTO Colaboradores
   //        (Nome
   //        ,DataNascimento
   //        ,CPF
   //        ,RG
   //        ,Endereco
   //        ,CEP
   //        ,Numero
   //        ,Bairro
   //        ,Cidade
   //        ,Estado
   //        ,Telefone
   //        ,FuncaoId)
			//Values(@Nome, @DataNascimento, @CPF, @RG, @Endereco, @CEP, @Numero, @Bairro, @Cidade, @Estado, @Telefone, @FuncaoId);
   //         SELECT @@IDENTITY";            
            
        string query = @"INSERT INTO Colaboradores
           (Nome
           ,FuncaoId)
			Values(@Nome, @FuncaoId);
            SELECT @@IDENTITY";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@Funcao", entity.FuncaoId);

                cmd.ExecuteNonQuery();
                return true;
            }

        }

    

        public bool Atualizar(Colaborador entityAntigo, Colaborador entityNovo)
        {
        //    string query = @"UPDATE Colaboradores 
        //SET
        //  Nome = @NomeNovo,
        //  DataNascimentoNovo = @DataNascimentoNovo,
        //  CPF = @CPFNovo,
        //  RG = @RGNovo,
        //  Endereco = @EnderecoNovo, 
        //  CEP = @CEPNovo, 
        //  Numero = @NumeroNovo, 
        //  Bairro =  @BairroNovo, 
        //  Cidade = @CidadeNovo, 
        //  Estado = @EstadoNovo ,
        //  Telefone = @TelefoneNovo, 
        //  FuncaoId =  @FuncaoIdNovo
        //WHERE   
        //  Nome = @NomeAntigo AND
        //  DataNascimentoAntigo = @DataNascimentoAntigo AND
        //  CPF = @CPFAntigo AND
        //  RG = @RGAntigo AND
        //  Endereco = @EnderecoAntigo AND
        //  CEP = @CEPAntigo AND
        //  Numero = @NumeroAntigo AND
        //  Bairro =  @BairroAntigo AND
        //  Cidade = @CidadeAntigo AND
        //  Estado = @EstadoAntigo AND
        //  Telefone = @TelefoneAntigo AND
        //  FuncaoId =  @FuncaoIdAntigo";
            
       string query = @"UPDATE Colaboradores 
        SET
          Nome = @NomeNovo,
          FuncaoId =  @FuncaoIdNovo
        WHERE   
          Nome = @NomeAntigo AND
          FuncaoId =  @FuncaoIdAntigo";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@NomeNovo", entityNovo.Nome);
                //cmd.Parameters.AddWithValue("@DataNascimentoNovo", entityNovo.DataNascimento);
                //cmd.Parameters.AddWithValue("@CPFNovo", entityNovo.CPF);
                //cmd.Parameters.AddWithValue("@RGNovo", entityNovo.RG);
                //cmd.Parameters.AddWithValue("@EnderecoNovo", entityNovo.Endereco);
                //cmd.Parameters.AddWithValue("@CEPNovo", entityNovo.CEP);
                //cmd.Parameters.AddWithValue("@NumeroNovo", entityNovo.Numero);
                //cmd.Parameters.AddWithValue("@BairroNovo", entityNovo.Bairro);
                //cmd.Parameters.AddWithValue("@CidadeNovo", entityNovo.Cidade);
                //cmd.Parameters.AddWithValue("@EstadoNovo", entityNovo.Estado);
                //cmd.Parameters.AddWithValue("@TelefoneNovo", entityNovo.Telefone);
                cmd.Parameters.AddWithValue("@FuncaoIdNovo", entityNovo.FuncaoId);

                cmd.Parameters.AddWithValue("@NomeAntigo", entityAntigo.Nome);
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
                cmd.Parameters.AddWithValue("@FuncaoIdAntigo", entityAntigo.FuncaoId);
                cmd.ExecuteNonQuery();
                return true;
            }
        }
        public bool Deletar(Colaborador entity)
        {
          //  string query = @"DELETE FROM Colaboradores
          //                  WHERE 
          //Nome = @Nome AND
          //DataNascimento = @DataNascimento AND
          //CPF = @CPF AND
          //RG = @RG AND
          //Endereco = @Endereco AND
          //CEP = @CEP AND
          //Numero = @Numero AND 
          //Bairro =  @Bairro AND
          //Cidade = @Cidade AND
          //Estado = @Estado AND
          //Telefone = @Telefone AND 
          //FuncaoId =  @FuncaoId";   
            
            
         string query = @"DELETE FROM Colaboradores
                            WHERE 
          Nome = @Nome AND
          FuncaoId =  @FuncaoId";
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                //cmd.Parameters.AddWithValue("@DataNascimento", entity.DataNascimento);
                //cmd.Parameters.AddWithValue("@CPF", entity.CPF);
                //cmd.Parameters.AddWithValue("@RG", entity.RG);
                //cmd.Parameters.AddWithValue("@Endereco", entity.Endereco);
                //cmd.Parameters.AddWithValue("@CEP", entity.CEP);
                //cmd.Parameters.AddWithValue("@Numero", entity.Numero);
                //cmd.Parameters.AddWithValue("@Bairro", entity.Bairro);
                //cmd.Parameters.AddWithValue("@Cidade", entity.Cidade);
                //cmd.Parameters.AddWithValue("@Estado", entity.Estado);
                //cmd.Parameters.AddWithValue("@Telefone", entity.Telefone);
                cmd.Parameters.AddWithValue("@FuncaoId", entity.FuncaoId);
                cmd.ExecuteNonQuery();
                return true;
            }
        }

        public IList<Colaborador> Lista()
        {
            throw new NotImplementedException();
        }

        public List<Funcao> ReturnColaboradorFuncoesLista()
        {
            string query = @"SELECT * FROM Funcoes Order by Descricao";
            List<Funcao> lista = new List<Funcao>();
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        var model = new Funcao
                        {
                            Id = (int)sdr["Id"],
                            Ativo = Convert.ToBoolean(sdr["Ativo"]),
                            Descricao = sdr["Descricao"].ToString(),
                            TipoFuncao = sdr["TipoFuncao"].ToString()
                        };
                        lista.Add(model);
                    }
                }
                con.Close();
                return lista;
            }



            //string query = "SELECT * FROM Funcoes Order by Descricao";
            //List<Funcao> funcoes = new List<Funcao>();
            //using (var con = new SqlConnection(stringConexao))
            //{
            //con.Open();
            //SqlCommand cmd = new SqlCommand(query, con);
            //SqlDataReader sdr = cmd.ExecuteReader();

            //if (sdr.HasRows)
            //{
            //    while (sdr.Read())
            //    {
            //        var model = new Colaborador
            //        {
            //            Nome = sdr["Nome"].ToString(),
            //            DataNascimento = sdr["DataNascimento"].ToString(),
            //            CPF = sdr["CPF"].ToString(),
            //            RG = sdr["RG"].ToString(),
            //            Endereco = sdr["Endereco"].ToString(),
            //            CEP = sdr["CEP"].ToString(),
            //            Numero = sdr["Numero"].ToString(),
            //            Bairro = sdr["Bairro"].ToString(),
            //            Cidade = sdr["Cidade"].ToString(),
            //            Estado = sdr["Estado"].ToString(),
            //            Telefone = sdr["Telefone"].ToString(),
            //            FuncaoId = (int)sdr["FuncaoId"],
            //        };
            //        colaboradores.Add(model);
            //    }
            //}
            //con.Close();

            //con.Open();
            //SqlCommand cmd = new SqlCommand(query, con);
            //var sdrFunc = cmd.ExecuteScalar();

            //if (sdrFunc.HasRows)
            //{
            //    while (sdrFunc.Read())
            //    {
            //        var model = new Funcao
            //        {
            //            Descricao = sdrFunc["Descricao"].ToString(),
            //            TipoFuncao = sdrFunc["TipoFuncao"].ToString(),
            //            Ativo = (bool)sdrFunc["Ativo"]
            //        };
            //        funcoes.Add(model);
            //    }
            //}

            //return funcoes;
            //}
        }

        public List<Colaborador> ReturnColaboradoresLista()
        {
            string query = @"SELECT c.*, f.Id, f.Descricao, f.TipoFuncao, f.Ativo 
                            from Colaboradores c inner join Funcoes f on c.FuncaoId = f.Id";
            List<Colaborador> colaboradores = new List<Colaborador>();
            using (var con = new SqlConnection(stringConexao))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        var model = new Colaborador
                        {
                            Id = (int)sdr["Id"],
                            Nome = sdr["Nome"].ToString(),
                            //DataNascimento = sdr["DataNascimento"].ToString(),
                            //CPF = sdr["CPF"].ToString(),
                            //RG = sdr["RG"].ToString(),
                            //Endereco = sdr["Endereco"].ToString(),
                            //CEP = sdr["CEP"].ToString(),
                            //Numero = sdr["Numero"].ToString(),
                            //Bairro = sdr["Bairro"].ToString(),
                            //Cidade = sdr["Cidade"].ToString(),
                            //Estado = sdr["Estado"].ToString(),
                            //Telefone = sdr["Telefone"].ToString(),
                            FuncaoId = (int)sdr["FuncaoId"],
                            Funcao = new Funcao() { Id = (int)sdr["FuncaoId"], Descricao = sdr["Descricao"].ToString(), TipoFuncao = sdr["TipoFuncao"].ToString(), Ativo = (bool)sdr["Ativo"] }  
                        };
                        colaboradores.Add(model);
                    }
                }
                con.Close();
                return colaboradores;
            }
        }
        public bool VerificarSeJaExiste(Colaborador entity)
        {
          //  string query = @"SELECT 
          //                      	count(1) as qtd
          //                      FROM 
          //                      	Colaboradores  
          //                      	                   WHERE 
          //Nome = @Nome AND
          //DataNascimento = @DataNascimento AND
          //CPF = @CPF AND
          //RG = @RG AND
          //Endereco = @Endereco AND
          //CEP = @CEP AND
          //Numero = @Numero AND
          //Bairro =  @Bairro AND
          //Cidade = @Cidade AND
          //Estado = @Estado AND
          //Telefone = @Telefone AND
          //FuncaoId =  @FuncaoId";   
            
            string query = @"SELECT 
                                	count(1) as qtd
                                FROM 
                                	Colaboradores  
                                	                   WHERE 
          Nome = @Nome AND
          FuncaoId =  @FuncaoId";
            return GravarERetornarVerdadeiroOuFalse(entity, query);
        }



        private bool GravarERetornarVerdadeiroOuFalse(Colaborador entity, string query)
        {
            using (var con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                //cmd.Parameters.AddWithValue("@DataNascimento", entity.DataNascimento);
                //cmd.Parameters.AddWithValue("@CPF", entity.CPF);
                //cmd.Parameters.AddWithValue("@RG", entity.RG);
                //cmd.Parameters.AddWithValue("@Endereco", entity.Endereco);
                //cmd.Parameters.AddWithValue("@CEP", entity.CEP);
                //cmd.Parameters.AddWithValue("@Numero", entity.Numero);
                //cmd.Parameters.AddWithValue("@Bairro", entity.Bairro);
                //cmd.Parameters.AddWithValue("@Cidade", entity.Cidade);
                //cmd.Parameters.AddWithValue("@Estado", entity.Estado);
                //cmd.Parameters.AddWithValue("@Telefone", entity.Telefone);
                cmd.Parameters.AddWithValue("@FuncaoId", entity.FuncaoId);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0 ? true : false;
            }
        }

    }
}