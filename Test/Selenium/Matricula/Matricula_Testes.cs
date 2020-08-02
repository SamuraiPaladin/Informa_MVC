using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Test.Selenium.Matricula;
using Xunit;

namespace Test
{

    public class TesteIntegrado_Matricula
    {
        [Fact]
        public void CriarMatricula()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Matricula", "");

            Assert.Equal("Matricula - inForma", Utilities.driver.Title);

            PageObject.RegisterEnrollment.CadastrarMatriulaButton();

            Matricula_Metodos.AguardaModalCadastro();

            PageObject.RegisterEnrollment.NomeAlunoTextBox("AAA Teste AAA");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.DataNascimento("01/01/2000");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.SelecionaMenorIdadeButton();

            PageObject.RegisterEnrollment.SelecionaGerarNotaButton();

            PageObject.RegisterEnrollment.ResponsavelTextBox("Responsável Teste");

            PageObject.RegisterEnrollment.GrauParentescoResponsavelTextBox("Pai");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.DataNascimentoResponsavel("01/01/2000");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.CPFResponsavel("022.340.880-29");

            PageObject.RegisterEnrollment.RgResponsavel("22.322.852-7");

            PageObject.RegisterEnrollment.EmailResponsavel("teste@teste.com");

            PageObject.RegisterEnrollment.TelefoneResponsavel("11999999999");

            PageObject.RegisterEnrollment.DescricaoTelefoneResponsavel("Casa");

            PageObject.RegisterEnrollment.CEPResponsavel("04664-020");

            Thread.Sleep(1500);

            PageObject.RegisterEnrollment.NumeroResponsavel("21");

            PageObject.RegisterEnrollment.SelecionaAulaButton();

            Thread.Sleep(1500);

            PageObject.RegisterEnrollment.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Utilities.driver.Close();
        }

        [Fact]
        public void CampoObrigatorioAula()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Matricula", "");

            Assert.Equal("Matricula - inForma", Utilities.driver.Title);

            PageObject.RegisterEnrollment.CadastrarMatriulaButton();

            Matricula_Metodos.AguardaModalCadastro();

            PageObject.RegisterEnrollment.NomeAlunoTextBox("AAA Teste AAA");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.DataNascimento("01/01/2000");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.SelecionaMenorIdadeButton();

            PageObject.RegisterEnrollment.SelecionaGerarNotaButton();

            PageObject.RegisterEnrollment.ResponsavelTextBox("Responsável Teste");

            PageObject.RegisterEnrollment.GrauParentescoResponsavelTextBox("Pai");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.DataNascimentoResponsavel("01/01/2000");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.CPFResponsavel("022.340.880-29");

            PageObject.RegisterEnrollment.RgResponsavel("22.322.852-7");

            PageObject.RegisterEnrollment.EmailResponsavel("teste@teste.com");

            PageObject.RegisterEnrollment.TelefoneResponsavel("11999999999");

            PageObject.RegisterEnrollment.DescricaoTelefoneResponsavel("Casa");

            PageObject.RegisterEnrollment.CEPResponsavel("04664-020");

            Thread.Sleep(1500);

            PageObject.RegisterEnrollment.NumeroResponsavel("21");

            //PageObject.RegisterEnrollment.SelecionaAulaButton();

            Thread.Sleep(1500);

            PageObject.RegisterEnrollment.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            Utilities.driver.Close();
        }

        [Fact]
        public void CampoObrigatorioAluno()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Matricula", "");

            Assert.Equal("Matricula - inForma", Utilities.driver.Title);

            PageObject.RegisterEnrollment.CadastrarMatriulaButton();

            Matricula_Metodos.AguardaModalCadastro();

            //PageObject.RegisterEnrollment.NomeAlunoTextBox("AAA Teste AAA");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.DataNascimento("01/01/2000");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.SelecionaMenorIdadeButton();

            PageObject.RegisterEnrollment.SelecionaGerarNotaButton();

            PageObject.RegisterEnrollment.ResponsavelTextBox("Responsável Teste");

            PageObject.RegisterEnrollment.GrauParentescoResponsavelTextBox("Pai");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.DataNascimentoResponsavel("01/01/2000");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.CPFResponsavel("022.340.880-29");

            PageObject.RegisterEnrollment.RgResponsavel("22.322.852-7");

            PageObject.RegisterEnrollment.EmailResponsavel("teste@teste.com");

            PageObject.RegisterEnrollment.TelefoneResponsavel("11999999999");

            PageObject.RegisterEnrollment.DescricaoTelefoneResponsavel("Casa");

            PageObject.RegisterEnrollment.CEPResponsavel("04664-020");

            Thread.Sleep(1500);

            PageObject.RegisterEnrollment.NumeroResponsavel("21");

            PageObject.RegisterEnrollment.SelecionaAulaButton();

            Thread.Sleep(1500);

            PageObject.RegisterEnrollment.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            Utilities.driver.Close();
        }

        [Fact]
        public void CampoObrigatorioDataNascAluno()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Matricula", "");

            Assert.Equal("Matricula - inForma", Utilities.driver.Title);

            PageObject.RegisterEnrollment.CadastrarMatriulaButton();

            Matricula_Metodos.AguardaModalCadastro();

            PageObject.RegisterEnrollment.NomeAlunoTextBox("AAA Teste AAA");

            Thread.Sleep(250);

            //PageObject.RegisterEnrollment.DataNascimento("01/01/2000");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.SelecionaMenorIdadeButton();

            PageObject.RegisterEnrollment.SelecionaGerarNotaButton();

            PageObject.RegisterEnrollment.ResponsavelTextBox("Responsável Teste");

            PageObject.RegisterEnrollment.GrauParentescoResponsavelTextBox("Pai");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.DataNascimentoResponsavel("01/01/2000");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.CPFResponsavel("022.340.880-29");

            PageObject.RegisterEnrollment.RgResponsavel("22.322.852-7");

            PageObject.RegisterEnrollment.EmailResponsavel("teste@teste.com");

            PageObject.RegisterEnrollment.TelefoneResponsavel("11999999999");

            PageObject.RegisterEnrollment.DescricaoTelefoneResponsavel("Casa");

            PageObject.RegisterEnrollment.CEPResponsavel("04664-020");

            Thread.Sleep(1500);

            PageObject.RegisterEnrollment.NumeroResponsavel("21");

            PageObject.RegisterEnrollment.SelecionaAulaButton();

            Thread.Sleep(1500);

            PageObject.RegisterEnrollment.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            Utilities.driver.Close();
        }

        [Fact]
        public void CampoObrigatorioResponsavel()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Matricula", "");

            Assert.Equal("Matricula - inForma", Utilities.driver.Title);

            PageObject.RegisterEnrollment.CadastrarMatriulaButton();

            Matricula_Metodos.AguardaModalCadastro();

            PageObject.RegisterEnrollment.NomeAlunoTextBox("AAA Teste AAA");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.DataNascimento("01/01/2000");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.SelecionaMenorIdadeButton();

            PageObject.RegisterEnrollment.SelecionaGerarNotaButton();

            //PageObject.RegisterEnrollment.ResponsavelTextBox("Responsável Teste");

            //PageObject.RegisterEnrollment.GrauParentescoResponsavelTextBox("Pai");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.DataNascimentoResponsavel("01/01/2000");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.CPFResponsavel("022.340.880-29");

            PageObject.RegisterEnrollment.RgResponsavel("22.322.852-7");

            PageObject.RegisterEnrollment.EmailResponsavel("teste@teste.com");

            PageObject.RegisterEnrollment.TelefoneResponsavel("11999999999");

            PageObject.RegisterEnrollment.DescricaoTelefoneResponsavel("Casa");

            PageObject.RegisterEnrollment.CEPResponsavel("04664-020");

            Thread.Sleep(1500);

            PageObject.RegisterEnrollment.NumeroResponsavel("21");

            PageObject.RegisterEnrollment.SelecionaAulaButton();

            Thread.Sleep(1500);

            PageObject.RegisterEnrollment.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            Utilities.driver.Close();
        }

        [Fact]
        public void CampoObrigatorioCEP()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Matricula", "");

            Assert.Equal("Matricula - inForma", Utilities.driver.Title);

            PageObject.RegisterEnrollment.CadastrarMatriulaButton();

            Matricula_Metodos.AguardaModalCadastro();

            PageObject.RegisterEnrollment.NomeAlunoTextBox("AAA Teste AAA");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.DataNascimento("01/01/2000");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.SelecionaMenorIdadeButton();

            PageObject.RegisterEnrollment.SelecionaGerarNotaButton();

            PageObject.RegisterEnrollment.ResponsavelTextBox("Responsável Teste");

            PageObject.RegisterEnrollment.GrauParentescoResponsavelTextBox("Pai");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.DataNascimentoResponsavel("01/01/2000");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.CPFResponsavel("022.340.880-29");

            PageObject.RegisterEnrollment.RgResponsavel("22.322.852-7");

            PageObject.RegisterEnrollment.EmailResponsavel("teste@teste.com");

            PageObject.RegisterEnrollment.TelefoneResponsavel("11999999999");

            PageObject.RegisterEnrollment.DescricaoTelefoneResponsavel("Casa");

            //PageObject.RegisterEnrollment.CEPResponsavel("04664-020");

            Thread.Sleep(1500);

            PageObject.RegisterEnrollment.NumeroResponsavel("21");

            PageObject.RegisterEnrollment.SelecionaAulaButton();

            Thread.Sleep(1500);

            PageObject.RegisterEnrollment.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            Utilities.driver.Close();
        }

        [Fact]
        public void CampoObrigatorioNumeroCEP()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Matricula", "");

            Assert.Equal("Matricula - inForma", Utilities.driver.Title);

            PageObject.RegisterEnrollment.CadastrarMatriulaButton();

            Matricula_Metodos.AguardaModalCadastro();

            PageObject.RegisterEnrollment.NomeAlunoTextBox("AAA Teste AAA");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.DataNascimento("01/01/2000");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.SelecionaMenorIdadeButton();

            PageObject.RegisterEnrollment.SelecionaGerarNotaButton();

            PageObject.RegisterEnrollment.ResponsavelTextBox("Responsável Teste");

            PageObject.RegisterEnrollment.GrauParentescoResponsavelTextBox("Pai");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.DataNascimentoResponsavel("01/01/2000");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.CPFResponsavel("022.340.880-29");

            PageObject.RegisterEnrollment.RgResponsavel("22.322.852-7");

            PageObject.RegisterEnrollment.EmailResponsavel("teste@teste.com");

            PageObject.RegisterEnrollment.TelefoneResponsavel("11999999999");

            PageObject.RegisterEnrollment.DescricaoTelefoneResponsavel("Casa");

            PageObject.RegisterEnrollment.CEPResponsavel("04664-020");

            Thread.Sleep(1500);

            //PageObject.RegisterEnrollment.NumeroResponsavel("21");

            PageObject.RegisterEnrollment.SelecionaAulaButton();

            Thread.Sleep(1500);

            PageObject.RegisterEnrollment.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            Utilities.driver.Close();
        }

        [Fact]
        public void CampoObrigatorioTelefone()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Matricula", "");

            Assert.Equal("Matricula - inForma", Utilities.driver.Title);

            PageObject.RegisterEnrollment.CadastrarMatriulaButton();

            Matricula_Metodos.AguardaModalCadastro();

            PageObject.RegisterEnrollment.NomeAlunoTextBox("AAA Teste AAA");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.DataNascimento("01/01/2000");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.SelecionaMenorIdadeButton();

            PageObject.RegisterEnrollment.SelecionaGerarNotaButton();

            PageObject.RegisterEnrollment.ResponsavelTextBox("Responsável Teste");

            PageObject.RegisterEnrollment.GrauParentescoResponsavelTextBox("Pai");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.DataNascimentoResponsavel("01/01/2000");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.CPFResponsavel("022.340.880-29");

            PageObject.RegisterEnrollment.RgResponsavel("22.322.852-7");

            PageObject.RegisterEnrollment.EmailResponsavel("teste@teste.com");

            //PageObject.RegisterEnrollment.TelefoneResponsavel("11999999999");

            PageObject.RegisterEnrollment.DescricaoTelefoneResponsavel("Casa");

            PageObject.RegisterEnrollment.CEPResponsavel("04664-020");

            Thread.Sleep(1500);

            PageObject.RegisterEnrollment.NumeroResponsavel("21");

            PageObject.RegisterEnrollment.SelecionaAulaButton();

            Thread.Sleep(1500);

            PageObject.RegisterEnrollment.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            Utilities.driver.Close();
        }

        [Fact]
        public void CampoObrigatorioCPF()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Matricula", "");

            Assert.Equal("Matricula - inForma", Utilities.driver.Title);

            PageObject.RegisterEnrollment.CadastrarMatriulaButton();

            Matricula_Metodos.AguardaModalCadastro();

            PageObject.RegisterEnrollment.NomeAlunoTextBox("AAA Teste AAA");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.DataNascimento("01/01/2000");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.SelecionaMenorIdadeButton();

            PageObject.RegisterEnrollment.SelecionaGerarNotaButton();

            PageObject.RegisterEnrollment.ResponsavelTextBox("Responsável Teste");

            PageObject.RegisterEnrollment.GrauParentescoResponsavelTextBox("Pai");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.DataNascimentoResponsavel("01/01/2000");

            Thread.Sleep(250);

            //PageObject.RegisterEnrollment.CPFResponsavel("022.340.880-29");

            PageObject.RegisterEnrollment.RgResponsavel("22.322.852-7");

            PageObject.RegisterEnrollment.EmailResponsavel("teste@teste.com");

            PageObject.RegisterEnrollment.TelefoneResponsavel("11999999999");

            PageObject.RegisterEnrollment.DescricaoTelefoneResponsavel("Casa");

            PageObject.RegisterEnrollment.CEPResponsavel("04664-020");

            Thread.Sleep(1500);

            PageObject.RegisterEnrollment.NumeroResponsavel("21");

            PageObject.RegisterEnrollment.SelecionaAulaButton();

            Thread.Sleep(1500);

            PageObject.RegisterEnrollment.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            Utilities.driver.Close();
        }

        [Fact]
        public void CampoObrigatorioRg()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Matricula", "");

            Assert.Equal("Matricula - inForma", Utilities.driver.Title);

            PageObject.RegisterEnrollment.CadastrarMatriulaButton();

            Matricula_Metodos.AguardaModalCadastro();

            PageObject.RegisterEnrollment.NomeAlunoTextBox("AAA Teste AAA");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.DataNascimento("01/01/2000");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.SelecionaMenorIdadeButton();

            PageObject.RegisterEnrollment.SelecionaGerarNotaButton();

            PageObject.RegisterEnrollment.ResponsavelTextBox("Responsável Teste");

            PageObject.RegisterEnrollment.GrauParentescoResponsavelTextBox("Pai");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.DataNascimentoResponsavel("01/01/2000");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.CPFResponsavel("022.340.880-29");

            //PageObject.RegisterEnrollment.RgResponsavel("22.322.852-7");

            PageObject.RegisterEnrollment.EmailResponsavel("teste@teste.com");

            PageObject.RegisterEnrollment.TelefoneResponsavel("11999999999");

            PageObject.RegisterEnrollment.DescricaoTelefoneResponsavel("Casa");

            PageObject.RegisterEnrollment.CEPResponsavel("04664-020");

            Thread.Sleep(1500);

            PageObject.RegisterEnrollment.NumeroResponsavel("21");

            PageObject.RegisterEnrollment.SelecionaAulaButton();

            Thread.Sleep(1500);

            PageObject.RegisterEnrollment.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            Utilities.driver.Close();
        }
    }
}
