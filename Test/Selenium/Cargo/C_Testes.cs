using System;
using Xunit;
using OpenQA.Selenium;
using System.Threading;
using Xunit;

namespace Test
{
    public class TesteIntegradoCargo
    {
     
        [Fact]
        public void CriarCargo()
        {
            Utilities.OpenChrome();

            Assert.Contains("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Cargos");

            Assert.Contains("Cargos - inForma", Utilities.driver.Title);

            PageObject.RegisterJobRoleScreen.CadastrarCargoButton();

            CargoMetodos.AguardaModalCadastro();

            PageObject.RegisterJobRoleScreen.NomeCargoTextBox("Atendente");

            PageObject.RegisterJobRoleScreen.DescricaoCargoTextBox("Realizar atendimentos b�sicos aos clientes.");

            Thread.Sleep(1000);

            PageObject.RegisterJobRoleScreen.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");
        }

        [Fact]
        public void CampoObrigatorioPendente()
        {
            Utilities.OpenChrome();

            Assert.Contains("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Cargos");

            Assert.Contains("Cargos - inForma", Utilities.driver.Title);

            PageObject.RegisterJobRoleScreen.CadastrarCargoButton();

            CargoMetodos.AguardaModalCadastro();

            PageObject.RegisterJobRoleScreen.NomeCargoTextBox("Atendente");

            Thread.Sleep(1000);

            PageObject.RegisterJobRoleScreen.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigat�rio");
        }

        [Fact]
        public void EditarCargo()
        {
            Utilities.OpenChrome();

            Assert.Contains("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Cargos");

            Assert.Contains("Cargos - inForma", Utilities.driver.Title);

            PageObject.RegisterJobRoleScreen.CadastrarCargoButton();

            CargoMetodos.AguardaModalCadastro();

            PageObject.RegisterJobRoleScreen.NomeCargoTextBox("Atendente");

            PageObject.RegisterJobRoleScreen.DescricaoCargoTextBox("Realizar atendimentos b�sicos aos clientes.");

            Thread.Sleep(1000);

            PageObject.RegisterJobRoleScreen.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            PageObject.RegisterJobRoleScreen.EditarCargoButton();

            CargoMetodos.AguardaModalEditar();

            PageObject.RegisterJobRoleScreen.EdicaoDescricaoCargoTextBox("Edi��o de campo de descri��o.");

            Thread.Sleep(1500);

            PageObject.RegisterJobRoleScreen.FinalizarEdicaoButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Editado");

        }
        
        [Fact]
        public void DeletarCargo()
        {
            Utilities.OpenChrome();

            Assert.Contains("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Cargos");

            Assert.Contains("Cargos - inForma", Utilities.driver.Title);

            PageObject.RegisterJobRoleScreen.CadastrarCargoButton();

            CargoMetodos.AguardaModalCadastro();

            PageObject.RegisterJobRoleScreen.NomeCargoTextBox("Atendente");

            PageObject.RegisterJobRoleScreen.DescricaoCargoTextBox("Realizar atendimentos b�sicos aos clientes.");

            Thread.Sleep(1000);

            PageObject.RegisterJobRoleScreen.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            PageObject.RegisterJobRoleScreen.ExcluirCargoButton();

            CargoMetodos.AguardaModalDeletar();

            PageObject.RegisterJobRoleScreen.FinalizarExcluirCargoButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Deletado");
        }

        [Fact]
        public void DuplicarCargo()
        {
            Utilities.OpenChrome();

            Assert.Contains("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Cargos");

            Assert.Contains("Cargos - inForma", Utilities.driver.Title);

            PageObject.RegisterJobRoleScreen.CadastrarCargoButton();

            CargoMetodos.AguardaModalCadastro();

            PageObject.RegisterJobRoleScreen.NomeCargoTextBox("Atendente");

            PageObject.RegisterJobRoleScreen.DescricaoCargoTextBox("Realizar atendimentos b�sicos aos clientes.");

            Thread.Sleep(1000);

            PageObject.RegisterJobRoleScreen.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            PageObject.RegisterJobRoleScreen.CadastrarCargoButton();

            CargoMetodos.AguardaModalCadastro();

            PageObject.RegisterJobRoleScreen.NomeCargoTextBox("Atendente");

            PageObject.RegisterJobRoleScreen.DescricaoCargoTextBox("Realizar atendimentos b�sicos aos clientes.");

            Thread.Sleep(1000);

            PageObject.RegisterJobRoleScreen.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("J� existe essas informa��es");


        }
    }
}
