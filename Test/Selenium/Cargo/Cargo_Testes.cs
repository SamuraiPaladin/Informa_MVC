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

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Cargos");

            Assert.Equal("Cargos - inForma", Utilities.driver.Title);

            PageObject.RegisterJob.CadastrarCargoButton();

            TestesCargoMetodos.AguardaModalCadastro();
            
            PageObject.RegisterJob.NomeCargoTextBox("Professor de Hidrostep");

            PageObject.RegisterJob.DescricaoCargoTextBox("Subir, descer e saltar, com diferentes velocidades e possibilidades de alternar as pernas e repetir movimentos.");

            Thread.Sleep(1000);

            PageObject.RegisterJob.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

        }

        [Fact]
        public void CampoObrigatorioDescricao()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Cargos");

            Assert.Equal("Cargos - inForma", Utilities.driver.Title);

            PageObject.RegisterJob.CadastrarCargoButton();

            TestesCargoMetodos.AguardaModalCadastro();

            PageObject.RegisterJob.NomeCargoTextBox("Professor de Hidrostep");

            Thread.Sleep(1000);

            PageObject.RegisterJob.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

        }

        [Fact]
        public void CampoObrigatorioNomeCargo()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Cargos");

            Assert.Equal("Cargos - inForma", Utilities.driver.Title);

            PageObject.RegisterJob.CadastrarCargoButton();

            TestesCargoMetodos.AguardaModalCadastro();

            //PageObject.RegisterJob.NomeCargoTextBox("Professor de Hidrostep");

            PageObject.RegisterJob.DescricaoCargoTextBox("Subir, descer e saltar, com diferentes velocidades e possibilidades de alternar as pernas e repetir movimentos.");


            Thread.Sleep(1000);

            PageObject.RegisterJob.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

        }

        [Fact]
        public void EditarCargo()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Cargos");

            Assert.Equal("Cargos - inForma", Utilities.driver.Title);

            PageObject.RegisterJob.CadastrarCargoButton();

            TestesCargoMetodos.AguardaModalCadastro();

            PageObject.RegisterJob.NomeCargoTextBox("Professor de Hidrostep");

            PageObject.RegisterJob.DescricaoCargoTextBox("Teste.");

            Thread.Sleep(1000);

            PageObject.RegisterJob.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            PageObject.RegisterJob.EditarCargoButton();

            TestesCargoMetodos.AguardaModalEditar();

            PageObject.RegisterJob.EditarDesricaoTextBox("Descrição alterada para teste.");

            PageObject.RegisterJob.FinalizarEditarCargoButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Editado");
        }
        [Fact]
        public void DeletarCargo()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Cargos");

            Assert.Equal("Cargos - inForma", Utilities.driver.Title);

            PageObject.RegisterJob.CadastrarCargoButton();

            TestesCargoMetodos.AguardaModalCadastro();

            PageObject.RegisterJob.NomeCargoTextBox("Professor de Hidrostep");

            PageObject.RegisterJob.DescricaoCargoTextBox("Subir, descer e saltar, com diferentes velocidades e possibilidades de alternar as pernas e repetir movimentos.");

            Thread.Sleep(1000);

            PageObject.RegisterJob.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5500);

            PageObject.RegisterJob.ExcluirCargoButton();

            TestesCargoMetodos.AguardaModalDeletar();

            PageObject.RegisterJob.FinalizarExcluirCargoButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Deletado");
        }
        [Fact]
        public void DuplicarCargo()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Cargos");

            Assert.Equal("Cargos - inForma", Utilities.driver.Title);

            PageObject.RegisterJob.CadastrarCargoButton();

            TestesCargoMetodos.AguardaModalCadastro();

            PageObject.RegisterJob.NomeCargoTextBox("Professor de Hidrostep");

            PageObject.RegisterJob.DescricaoCargoTextBox("Subir, descer e saltar, com diferentes velocidades e possibilidades de alternar as pernas e repetir movimentos.");

            Thread.Sleep(1000);

            PageObject.RegisterJob.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            PageObject.RegisterJob.CadastrarCargoButton();

            TestesCargoMetodos.AguardaModalCadastro();

            PageObject.RegisterJob.NomeCargoTextBox("Professor de Hidrostep");

            PageObject.RegisterJob.DescricaoCargoTextBox("Subir, descer e saltar, com diferentes velocidades e possibilidades de alternar as pernas e repetir movimentos.");

            Thread.Sleep(1000);

            PageObject.RegisterJob.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Já existe essas informações");
        }
    }
}
