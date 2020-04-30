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

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Colaborador");

            Assert.Equal("Colaborador - inForma", Utilities.driver.Title);

            PageObject.RegisterEmployee.CadastrarColaboradorButton();

            TestesColaboradorMetodos.AguardaModalCadastro();

            PageObject.RegisterEmployee.NomeColaboradorTextBox("Thauan Moser Doce");

            Thread.Sleep(250);

            PageObject.RegisterEmployee.SelecionarCargoButton();

            Thread.Sleep(250);

            TestesColaboradorMetodos.SelecionaCargo("Teste");

            Thread.Sleep(1500);

            PageObject.RegisterEmployee.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

        }

        [Fact]
        public void CampoObrigatorioFaltante()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Colaborador");

            Assert.Equal("Colaborador - inForma", Utilities.driver.Title);

            PageObject.RegisterEmployee.CadastrarColaboradorButton();

            TestesColaboradorMetodos.AguardaModalCadastro();

            PageObject.RegisterEmployee.NomeColaboradorTextBox("Thauan Moser Doce");

            PageObject.RegisterEmployee.SelecionarCargoButton();

            Thread.Sleep(1000);

            PageObject.RegisterEmployee.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

        }

            [Fact]
        public void EditarColaborador()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Colaborador");

            Assert.Equal("Colaborador - inForma", Utilities.driver.Title);

            PageObject.RegisterEmployee.CadastrarColaboradorButton();

            TestesColaboradorMetodos.AguardaModalCadastro();

            PageObject.RegisterEmployee.NomeColaboradorTextBox("Thauan Moser Doce");

            Thread.Sleep(250);

            PageObject.RegisterEmployee.SelecionarCargoButton();

            Thread.Sleep(250);

            TestesColaboradorMetodos.SelecionaCargo("Teste");

            Thread.Sleep(1500);

            PageObject.RegisterEmployee.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            PageObject.RegisterEmployee.EditarColaboradorButton();

            TestesColaboradorMetodos.AguardaModalEditar();

            PageObject.RegisterEmployee.EditarCargoButton();

            TestesColaboradorMetodos.EditaCargo("Outro teste");

            PageObject.RegisterEmployee.FinalizarEditarColaboradorButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Editado");
        }
        [Fact]
        public void DeletarColaborador()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Colaborador");

            Assert.Equal("Colaborador - inForma", Utilities.driver.Title);

            PageObject.RegisterEmployee.CadastrarColaboradorButton();

            TestesColaboradorMetodos.AguardaModalCadastro();

            PageObject.RegisterEmployee.NomeColaboradorTextBox("Thauan Moser Doce");

            Thread.Sleep(250);

            PageObject.RegisterEmployee.SelecionarCargoButton();

            Thread.Sleep(250);

            TestesColaboradorMetodos.SelecionaCargo("Teste");

            Thread.Sleep(1500);

            PageObject.RegisterEmployee.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            PageObject.RegisterEmployee.ExcluirColaboradorButton();

            TestesColaboradorMetodos.AguardaModalDeletar();

            PageObject.RegisterEmployee.FinalizarExcluirColaboradorButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Deletado");
        }
        [Fact]
        public void DuplicarColaborador()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Colaborador");

            Assert.Equal("Colaborador - inForma", Utilities.driver.Title);

            PageObject.RegisterEmployee.CadastrarColaboradorButton();

            TestesColaboradorMetodos.AguardaModalCadastro();

            PageObject.RegisterEmployee.NomeColaboradorTextBox("Thauan Moser Doce");

            Thread.Sleep(250);

            PageObject.RegisterEmployee.SelecionarCargoButton();

            Thread.Sleep(250);

            TestesColaboradorMetodos.SelecionaCargo("Teste");

            Thread.Sleep(1500);

            PageObject.RegisterEmployee.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Colaborador");

            Assert.Equal("Colaborador - inForma", Utilities.driver.Title);

            PageObject.RegisterEmployee.CadastrarColaboradorButton();

            TestesColaboradorMetodos.AguardaModalCadastro();

            PageObject.RegisterEmployee.NomeColaboradorTextBox("Thauan Moser Doce");

            Thread.Sleep(250);

            PageObject.RegisterEmployee.SelecionarCargoButton();

            Thread.Sleep(250);

            TestesColaboradorMetodos.SelecionaCargo("Teste");

            Thread.Sleep(1500);

            PageObject.RegisterEmployee.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Já existe essas informações");
        }
    }
}
