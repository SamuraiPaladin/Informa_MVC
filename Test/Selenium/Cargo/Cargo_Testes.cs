using Xunit;
using System.Threading;

namespace Test
{
    public class TesteIntegrado_Cargo
    {
        [Fact]
        public void CriarCargo()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Cargos");

            Assert.Equal("Cargos - inForma", Utilities.driver.Title);

            PageObject.RegisterJob.CadastrarCargoButton();

            TestesCargoMetodos.AguardaModalCadastro();
            
            PageObject.RegisterJob.NomeCargoTextBox("AAA Teste Integrado AAA");

            PageObject.RegisterJob.DescricaoCargoTextBox("AAA Teste Integrado AAA");

            Thread.Sleep(1000);

            PageObject.RegisterJob.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            TestesCargoMetodos.FinalizarTeste(1);

        }

        [Fact]
        public void CampoObrigatorioDescricao()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Cargos");

            Assert.Equal("Cargos - inForma", Utilities.driver.Title);

            PageObject.RegisterJob.CadastrarCargoButton();

            TestesCargoMetodos.AguardaModalCadastro();

            PageObject.RegisterJob.NomeCargoTextBox("Professor de Hidrostep");

            Thread.Sleep(1000);

            PageObject.RegisterJob.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesCargoMetodos.FinalizarTeste(2);

        }

        [Fact]
        public void CampoObrigatorioNomeCargo()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Cargos");

            Assert.Equal("Cargos - inForma", Utilities.driver.Title);

            PageObject.RegisterJob.CadastrarCargoButton();

            TestesCargoMetodos.AguardaModalCadastro();

            //PageObject.RegisterJob.NomeCargoTextBox("Professor de Hidrostep");

            PageObject.RegisterJob.DescricaoCargoTextBox("Subir, descer e saltar, com diferentes velocidades.");

            Thread.Sleep(1000);

            PageObject.RegisterJob.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesCargoMetodos.FinalizarTeste(2);

        }

        [Fact]
        public void EditarCargo()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Cargos");

            Assert.Equal("Cargos - inForma", Utilities.driver.Title);

            PageObject.RegisterJob.CadastrarCargoButton();

            TestesCargoMetodos.AguardaModalCadastro();

            PageObject.RegisterJob.NomeCargoTextBox("AAA Teste Integrado AAA");

            PageObject.RegisterJob.DescricaoCargoTextBox("AAA Teste Integrado AAA");

            Thread.Sleep(1000);

            PageObject.RegisterJob.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            PageObject.RegisterJob.EditarCargoButton();

            TestesCargoMetodos.AguardaModalEditar();

            PageObject.RegisterJob.EditarDesricaoTextBox("AAA Descrição alterada para teste. AAA");

            PageObject.RegisterJob.FinalizarEditarCargoButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Editado");

            TestesCargoMetodos.FinalizarTeste(1);
        }
        [Fact]
        public void DeletarCargo()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Cargos");

            Assert.Equal("Cargos - inForma", Utilities.driver.Title);

            PageObject.RegisterJob.CadastrarCargoButton();

            TestesCargoMetodos.AguardaModalCadastro();

            PageObject.RegisterJob.NomeCargoTextBox("AAA Teste Integrado AAA");

            PageObject.RegisterJob.DescricaoCargoTextBox("AAA Teste Integrado AAA");

            Thread.Sleep(1000);

            PageObject.RegisterJob.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5500);

            PageObject.RegisterJob.ExcluirCargoButton();

            TestesCargoMetodos.AguardaModalDeletar();

            PageObject.RegisterJob.FinalizarExcluirCargoButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Deletado");

            TestesCargoMetodos.FinalizarTeste(2);
        }
        [Fact]
        public void DuplicarCargo()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Cargos");

            Assert.Equal("Cargos - inForma", Utilities.driver.Title);

            PageObject.RegisterJob.CadastrarCargoButton();

            TestesCargoMetodos.AguardaModalCadastro();

            PageObject.RegisterJob.NomeCargoTextBox("AAA Teste Integrado AAA");

            PageObject.RegisterJob.DescricaoCargoTextBox("AAA Teste Integrado AAA");

            Thread.Sleep(1000);

            PageObject.RegisterJob.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            PageObject.RegisterJob.CadastrarCargoButton();

            TestesCargoMetodos.AguardaModalCadastro();

            PageObject.RegisterJob.NomeCargoTextBox("AAA Teste Integrado AAA");

            PageObject.RegisterJob.DescricaoCargoTextBox("AAA Teste Integrado AAA");

            Thread.Sleep(1000);

            PageObject.RegisterJob.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Já existe essas informações");

            TestesCargoMetodos.FinalizarTeste(1);
        }
    }
}
