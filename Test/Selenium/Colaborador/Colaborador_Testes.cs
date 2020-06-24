using Xunit;
using System.Threading;

namespace Test
{
    public class TesteIntegrado_Colaborador
    {
        [Fact]
        public void CriarColaborador()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Colaborador");

            Assert.Equal("Colaborador - inForma", Utilities.driver.Title);

            PageObject.RegisterEmployee.CadastrarColaboradorButton();

            TestesColaboradorMetodos.AguardaModalCadastro();

            PageObject.RegisterEmployee.NomeColaboradorTextBox("Ana Teste");

            Thread.Sleep(250);

            PageObject.RegisterEmployee.DataNascimentoTextBox("01/01/2000");

            PageObject.RegisterEmployee.CPFColaboradorTextBox("022.340.880-29");

            PageObject.RegisterEmployee.EmailColaboradorTextBox("aaa@aaa.com");

            PageObject.RegisterEmployee.RgColaboradorTextBox("22.322.852-7");

            PageObject.RegisterEmployee.TelefoneColaboradorTextBox("99999999999");

            PageObject.RegisterEmployee.CEPColaboradorTextBox("04664-020");

            Thread.Sleep(5000);

            PageObject.RegisterEmployee.NumeroColaboradorTextBox("50");

            PageObject.RegisterEmployee.SelecionarCargoButton();

            Thread.Sleep(250);

            TestesColaboradorMetodos.SelecionaCargo("Professor");

            Thread.Sleep(1500);

            PageObject.RegisterEmployee.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            TestesColaboradorMetodos.FinalizarTeste(1);

        }

        [Fact]
        public void CampoObrigatorioNomeColaborador()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Colaborador");

            Assert.Equal("Colaborador - inForma", Utilities.driver.Title);

            PageObject.RegisterEmployee.CadastrarColaboradorButton();

            TestesColaboradorMetodos.AguardaModalCadastro();

            //PageObject.RegisterEmployee.NomeColaboradorTextBox("Ana Teste");

            Thread.Sleep(250);

            PageObject.RegisterEmployee.DataNascimentoTextBox("01/01/2000");

            PageObject.RegisterEmployee.CPFColaboradorTextBox("070.640.880-29");

            PageObject.RegisterEmployee.EmailColaboradorTextBox("aaa@aaa.com");

            PageObject.RegisterEmployee.RgColaboradorTextBox("22.973.852-7");

            PageObject.RegisterEmployee.TelefoneColaboradorTextBox("99999999999");

            PageObject.RegisterEmployee.CEPColaboradorTextBox("04664-020");

            Thread.Sleep(5000);

            PageObject.RegisterEmployee.NumeroColaboradorTextBox("50");

            PageObject.RegisterEmployee.SelecionarCargoButton();

            Thread.Sleep(250);

            TestesColaboradorMetodos.SelecionaCargo("Professor");

            Thread.Sleep(1500);

            PageObject.RegisterEmployee.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesColaboradorMetodos.FinalizarTeste(2);

        }

        [Fact]
        public void CampoObrigatorioDataNascimento()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Colaborador");

            Assert.Equal("Colaborador - inForma", Utilities.driver.Title);

            PageObject.RegisterEmployee.CadastrarColaboradorButton();

            TestesColaboradorMetodos.AguardaModalCadastro();

            PageObject.RegisterEmployee.NomeColaboradorTextBox("Ana Teste");

            Thread.Sleep(250);

            //PageObject.RegisterEmployee.DataNascimentoTextBox("01/01/2000");

            PageObject.RegisterEmployee.CPFColaboradorTextBox("070.640.880-29");

            PageObject.RegisterEmployee.EmailColaboradorTextBox("aaa@aaa.com");

            PageObject.RegisterEmployee.RgColaboradorTextBox("22.973.852-7");

            PageObject.RegisterEmployee.TelefoneColaboradorTextBox("99999999999");

            PageObject.RegisterEmployee.CEPColaboradorTextBox("04664-020");

            Thread.Sleep(5000);

            PageObject.RegisterEmployee.NumeroColaboradorTextBox("50");

            PageObject.RegisterEmployee.SelecionarCargoButton();

            Thread.Sleep(250);

            TestesColaboradorMetodos.SelecionaCargo("Professor");

            Thread.Sleep(1500);

            PageObject.RegisterEmployee.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesColaboradorMetodos.FinalizarTeste(2);

        }

        [Fact]
        public void CampoObrigatorioCPF()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Colaborador");

            Assert.Equal("Colaborador - inForma", Utilities.driver.Title);

            PageObject.RegisterEmployee.CadastrarColaboradorButton();

            TestesColaboradorMetodos.AguardaModalCadastro();

            PageObject.RegisterEmployee.NomeColaboradorTextBox("Ana Teste");

            Thread.Sleep(250);

            PageObject.RegisterEmployee.DataNascimentoTextBox("01/01/2000");

            //PageObject.RegisterEmployee.CPFColaboradorTextBox("070.640.880-29");

            PageObject.RegisterEmployee.EmailColaboradorTextBox("aaa@aaa.com");

            PageObject.RegisterEmployee.RgColaboradorTextBox("22.973.852-7");

            PageObject.RegisterEmployee.TelefoneColaboradorTextBox("99999999999");

            PageObject.RegisterEmployee.CEPColaboradorTextBox("04664-020");

            Thread.Sleep(5000);

            PageObject.RegisterEmployee.NumeroColaboradorTextBox("50");

            PageObject.RegisterEmployee.SelecionarCargoButton();

            Thread.Sleep(250);

            TestesColaboradorMetodos.SelecionaCargo("Professor");

            Thread.Sleep(1500);

            PageObject.RegisterEmployee.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesColaboradorMetodos.FinalizarTeste(2);

        }

        [Fact]
        public void CampoObrigatorioEmail()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Colaborador");

            Assert.Equal("Colaborador - inForma", Utilities.driver.Title);

            PageObject.RegisterEmployee.CadastrarColaboradorButton();

            TestesColaboradorMetodos.AguardaModalCadastro();

            PageObject.RegisterEmployee.NomeColaboradorTextBox("Ana Teste");

            Thread.Sleep(250);

            PageObject.RegisterEmployee.DataNascimentoTextBox("01/01/2000");

            PageObject.RegisterEmployee.CPFColaboradorTextBox("070.640.880-29");

            //PageObject.RegisterEmployee.EmailColaboradorTextBox("aaa@aaa.com");

            PageObject.RegisterEmployee.RgColaboradorTextBox("22.973.852-7");

            PageObject.RegisterEmployee.TelefoneColaboradorTextBox("99999999999");

            PageObject.RegisterEmployee.CEPColaboradorTextBox("04664-020");

            Thread.Sleep(5000);

            PageObject.RegisterEmployee.NumeroColaboradorTextBox("50");

            PageObject.RegisterEmployee.SelecionarCargoButton();

            Thread.Sleep(250);

            TestesColaboradorMetodos.SelecionaCargo("Professor");

            Thread.Sleep(1500);

            PageObject.RegisterEmployee.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesColaboradorMetodos.FinalizarTeste(2);

        }

        [Fact]
        public void CampoObrigatorioRG()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Colaborador");

            Assert.Equal("Colaborador - inForma", Utilities.driver.Title);

            PageObject.RegisterEmployee.CadastrarColaboradorButton();

            TestesColaboradorMetodos.AguardaModalCadastro();

            PageObject.RegisterEmployee.NomeColaboradorTextBox("Ana Teste");

            Thread.Sleep(250);

            PageObject.RegisterEmployee.DataNascimentoTextBox("01/01/2000");

            PageObject.RegisterEmployee.CPFColaboradorTextBox("070.640.880-29");

            PageObject.RegisterEmployee.EmailColaboradorTextBox("aaa@aaa.com");

            //PageObject.RegisterEmployee.RgColaboradorTextBox("22.973.852-7");

            PageObject.RegisterEmployee.TelefoneColaboradorTextBox("99999999999");

            PageObject.RegisterEmployee.CEPColaboradorTextBox("04664-020");

            Thread.Sleep(5000);

            PageObject.RegisterEmployee.NumeroColaboradorTextBox("50");

            PageObject.RegisterEmployee.SelecionarCargoButton();

            Thread.Sleep(250);

            TestesColaboradorMetodos.SelecionaCargo("Professor");

            Thread.Sleep(1500);

            PageObject.RegisterEmployee.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesColaboradorMetodos.FinalizarTeste(2);

        }
        
        [Fact]
        public void CampoObrigatorioTelefone()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Colaborador");

            Assert.Equal("Colaborador - inForma", Utilities.driver.Title);

            PageObject.RegisterEmployee.CadastrarColaboradorButton();

            TestesColaboradorMetodos.AguardaModalCadastro();

            PageObject.RegisterEmployee.NomeColaboradorTextBox("Ana Teste");

            Thread.Sleep(250);

            PageObject.RegisterEmployee.DataNascimentoTextBox("01/01/2000");

            PageObject.RegisterEmployee.CPFColaboradorTextBox("070.640.880-29");

            PageObject.RegisterEmployee.EmailColaboradorTextBox("aaa@aaa.com");

            PageObject.RegisterEmployee.RgColaboradorTextBox("22.973.852-7");

            //PageObject.RegisterEmployee.TelefoneColaboradorTextBox("99999999999");

            PageObject.RegisterEmployee.CEPColaboradorTextBox("04664-020");

            Thread.Sleep(5000);

            PageObject.RegisterEmployee.NumeroColaboradorTextBox("50");

            PageObject.RegisterEmployee.SelecionarCargoButton();

            Thread.Sleep(250);

            TestesColaboradorMetodos.SelecionaCargo("Professor");

            Thread.Sleep(1500);

            PageObject.RegisterEmployee.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesColaboradorMetodos.FinalizarTeste(2);

        }

        [Fact]
        public void CampoObrigatorioCEP()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Colaborador");

            Assert.Equal("Colaborador - inForma", Utilities.driver.Title);

            PageObject.RegisterEmployee.CadastrarColaboradorButton();

            TestesColaboradorMetodos.AguardaModalCadastro();

            PageObject.RegisterEmployee.NomeColaboradorTextBox("Ana Teste");

            Thread.Sleep(250);

            PageObject.RegisterEmployee.DataNascimentoTextBox("01/01/2000");

            PageObject.RegisterEmployee.CPFColaboradorTextBox("070.640.880-29");

            PageObject.RegisterEmployee.EmailColaboradorTextBox("aaa@aaa.com");

            PageObject.RegisterEmployee.RgColaboradorTextBox("22.973.852-7");

            PageObject.RegisterEmployee.TelefoneColaboradorTextBox("99999999999");

            //PageObject.RegisterEmployee.CEPColaboradorTextBox("04664-020");

            Thread.Sleep(5000);

            PageObject.RegisterEmployee.NumeroColaboradorTextBox("50");

            PageObject.RegisterEmployee.SelecionarCargoButton();

            Thread.Sleep(250);

            TestesColaboradorMetodos.SelecionaCargo("Professor");

            Thread.Sleep(1500);

            PageObject.RegisterEmployee.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesColaboradorMetodos.FinalizarTeste(2);

        }

        [Fact]
        public void CampoObrigatorioNumero()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Colaborador");

            Assert.Equal("Colaborador - inForma", Utilities.driver.Title);

            PageObject.RegisterEmployee.CadastrarColaboradorButton();

            TestesColaboradorMetodos.AguardaModalCadastro();

            PageObject.RegisterEmployee.NomeColaboradorTextBox("Ana Teste");

            Thread.Sleep(250);

            PageObject.RegisterEmployee.DataNascimentoTextBox("01/01/2000");

            PageObject.RegisterEmployee.CPFColaboradorTextBox("070.640.880-29");

            PageObject.RegisterEmployee.EmailColaboradorTextBox("aaa@aaa.com");

            PageObject.RegisterEmployee.RgColaboradorTextBox("22.973.852-7");

            PageObject.RegisterEmployee.TelefoneColaboradorTextBox("99999999999");

            PageObject.RegisterEmployee.CEPColaboradorTextBox("04664-020");

            Thread.Sleep(5000);

            //PageObject.RegisterEmployee.NumeroColaboradorTextBox("50");

            PageObject.RegisterEmployee.SelecionarCargoButton();

            Thread.Sleep(250);

            TestesColaboradorMetodos.SelecionaCargo("Professor");

            Thread.Sleep(1500);

            PageObject.RegisterEmployee.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesColaboradorMetodos.FinalizarTeste(2);

        }

        [Fact]
        public void CampoObrigatorioCargo()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Colaborador");

            Assert.Equal("Colaborador - inForma", Utilities.driver.Title);

            PageObject.RegisterEmployee.CadastrarColaboradorButton();

            TestesColaboradorMetodos.AguardaModalCadastro();

            PageObject.RegisterEmployee.NomeColaboradorTextBox("Ana Teste");

            Thread.Sleep(250);

            PageObject.RegisterEmployee.DataNascimentoTextBox("01/01/2000");

            PageObject.RegisterEmployee.CPFColaboradorTextBox("070.640.880-29");

            PageObject.RegisterEmployee.EmailColaboradorTextBox("aaa@aaa.com");

            PageObject.RegisterEmployee.RgColaboradorTextBox("22.973.852-7");

            PageObject.RegisterEmployee.TelefoneColaboradorTextBox("99999999999");

            PageObject.RegisterEmployee.CEPColaboradorTextBox("04664-020");

            Thread.Sleep(5000);

            PageObject.RegisterEmployee.NumeroColaboradorTextBox("50");

            //PageObject.RegisterEmployee.SelecionarCargoButton();

            //Thread.Sleep(250);

            //TestesColaboradorMetodos.SelecionaCargo("Professor");

            Thread.Sleep(1500);

            PageObject.RegisterEmployee.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesColaboradorMetodos.FinalizarTeste(2);

        }

        [Fact]
        public void EditarColaborador()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Colaborador");

            Assert.Equal("Colaborador - inForma", Utilities.driver.Title);

            PageObject.RegisterEmployee.CadastrarColaboradorButton();

            TestesColaboradorMetodos.AguardaModalCadastro();

            PageObject.RegisterEmployee.NomeColaboradorTextBox("Ana Teste");

            Thread.Sleep(250);

            PageObject.RegisterEmployee.DataNascimentoTextBox("01/01/2000");

            PageObject.RegisterEmployee.CPFColaboradorTextBox("844.640.127-30");

            PageObject.RegisterEmployee.EmailColaboradorTextBox("aaa@aaa.com");

            PageObject.RegisterEmployee.RgColaboradorTextBox("44.973.827-1");

            PageObject.RegisterEmployee.TelefoneColaboradorTextBox("99999999999");

            PageObject.RegisterEmployee.CEPColaboradorTextBox("04664-020");

            Thread.Sleep(5000);

            PageObject.RegisterEmployee.NumeroColaboradorTextBox("50");

            PageObject.RegisterEmployee.SelecionarCargoButton();

            Thread.Sleep(250);

            TestesColaboradorMetodos.SelecionaCargo("Professor");

            Thread.Sleep(1500);

            PageObject.RegisterEmployee.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            PageObject.RegisterEmployee.EditarColaboradorButton();

            TestesColaboradorMetodos.AguardaModalEditar();

            PageObject.RegisterEmployee.EditarNumeroColaboradorTextBox("75");

            PageObject.RegisterEmployee.FinalizarEditarColaboradorButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Editado");

            TestesColaboradorMetodos.FinalizarTeste(1);
        }
        
        [Fact]
        public void DeletarColaborador()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Colaborador");

            Assert.Equal("Colaborador - inForma", Utilities.driver.Title);

            PageObject.RegisterEmployee.CadastrarColaboradorButton();

            TestesColaboradorMetodos.AguardaModalCadastro();

            PageObject.RegisterEmployee.NomeColaboradorTextBox("Ana Teste");

            Thread.Sleep(250);

            PageObject.RegisterEmployee.DataNascimentoTextBox("01/01/2000");

            PageObject.RegisterEmployee.CPFColaboradorTextBox("070.140.660-25");

            PageObject.RegisterEmployee.EmailColaboradorTextBox("aaa@aaa.com");

            PageObject.RegisterEmployee.RgColaboradorTextBox("22.173.662-0");

            PageObject.RegisterEmployee.TelefoneColaboradorTextBox("99999999999");

            PageObject.RegisterEmployee.CEPColaboradorTextBox("04664-020");

            Thread.Sleep(5000);

            PageObject.RegisterEmployee.NumeroColaboradorTextBox("50");

            PageObject.RegisterEmployee.SelecionarCargoButton();

            Thread.Sleep(250);

            TestesColaboradorMetodos.SelecionaCargo("Professor");

            Thread.Sleep(1500);

            PageObject.RegisterEmployee.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            PageObject.RegisterEmployee.ExcluirColaboradorButton();

            TestesColaboradorMetodos.AguardaModalDeletar();

            PageObject.RegisterEmployee.FinalizarExcluirColaboradorButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Deletado");

            TestesColaboradorMetodos.FinalizarTeste(2);
        }
        [Fact]
        public void DuplicarColaborador()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Colaborador");

            Assert.Equal("Colaborador - inForma", Utilities.driver.Title);

            PageObject.RegisterEmployee.CadastrarColaboradorButton();

            TestesColaboradorMetodos.AguardaModalCadastro();

            PageObject.RegisterEmployee.NomeColaboradorTextBox("Ana Teste");

            Thread.Sleep(250);

            PageObject.RegisterEmployee.DataNascimentoTextBox("01/01/2000");

            PageObject.RegisterEmployee.CPFColaboradorTextBox("000.640.580-25");

            PageObject.RegisterEmployee.EmailColaboradorTextBox("aaa@aaa.com");

            PageObject.RegisterEmployee.RgColaboradorTextBox("00.973.552-0");

            PageObject.RegisterEmployee.TelefoneColaboradorTextBox("99999999999");

            PageObject.RegisterEmployee.CEPColaboradorTextBox("04664-020");

            Thread.Sleep(5000);

            PageObject.RegisterEmployee.NumeroColaboradorTextBox("50");

            PageObject.RegisterEmployee.SelecionarCargoButton();

            Thread.Sleep(250);

            TestesColaboradorMetodos.SelecionaCargo("Professor");

            Thread.Sleep(1500);

            PageObject.RegisterEmployee.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            PageObject.RegisterEmployee.CadastrarColaboradorButton();

            TestesColaboradorMetodos.AguardaModalCadastro();

            PageObject.RegisterEmployee.NomeColaboradorTextBox("Ana Teste");

            Thread.Sleep(250);

            PageObject.RegisterEmployee.DataNascimentoTextBox("01/01/2000");

            PageObject.RegisterEmployee.CPFColaboradorTextBox("000.640.580-25");

            PageObject.RegisterEmployee.EmailColaboradorTextBox("aaa@aaa.com");

            PageObject.RegisterEmployee.RgColaboradorTextBox("00.973.552-0");

            PageObject.RegisterEmployee.TelefoneColaboradorTextBox("99999999999");

            PageObject.RegisterEmployee.CEPColaboradorTextBox("04664-020");

            Thread.Sleep(6000);

            PageObject.RegisterEmployee.NumeroColaboradorTextBox("50");

            PageObject.RegisterEmployee.SelecionarCargoButton();

            Thread.Sleep(250);

            TestesColaboradorMetodos.SelecionaCargo("Professor");

            Thread.Sleep(1500);

            PageObject.RegisterEmployee.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Já existe essas informações");

            TestesColaboradorMetodos.FinalizarTeste(1);
        }
    }
}
