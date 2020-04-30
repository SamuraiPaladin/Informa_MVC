using Xunit;
using System.Threading;

namespace Test
{
    public class TesteIntegrado_Modalidade
    {
        [Fact]
        public void CriarModalidade()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Modalidade");

            Assert.Equal("Modalidade - inForma", Utilities.driver.Title);

            PageObject.RegisterModality.CadastrarModalidadeButton();

            TestesModalidadeMetodos.AguardaModalCadastro();
            
            PageObject.RegisterModality.NomeModalideTextBox("Nata��o Infantil");

            PageObject.RegisterModality.DescricaoModalideTextBox("Atividade para crian�as de 7 a 9 anos.");

            Thread.Sleep(1000);

            PageObject.RegisterModality.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

        }

        [Fact]
        public void CampoObrigatorioFaltante()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Modalidade");

            Assert.Equal("Modalidade - inForma", Utilities.driver.Title);

            PageObject.RegisterModality.CadastrarModalidadeButton();

            TestesModalidadeMetodos.AguardaModalCadastro();

            PageObject.RegisterModality.NomeModalideTextBox("Nata��o Infantil");

            Thread.Sleep(1000);

            PageObject.RegisterModality.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigat�rio");

        }

            [Fact]
        public void EditarModalidade()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Modalidade");

            Assert.Equal("Modalidade - inForma", Utilities.driver.Title);

            PageObject.RegisterModality.CadastrarModalidadeButton();

            TestesModalidadeMetodos.AguardaModalCadastro();

            PageObject.RegisterModality.NomeModalideTextBox("Nata��o Infantil");

            PageObject.RegisterModality.DescricaoModalideTextBox("Atividade para crian�as de 7 a 9 anos.");

            Thread.Sleep(1000);

            PageObject.RegisterModality.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            PageObject.RegisterModality.EditarModalidadeButton();

            TestesModalidadeMetodos.AguardaModalEditar();

            PageObject.RegisterModality.EditarDesricaoTextBox("Descri��o alterada para teste.");

            PageObject.RegisterModality.FinalizarEditarModalidadeButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Editado");
        }
        [Fact]
        public void DeletarModalidade()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Modalidade");

            Assert.Equal("Modalidade - inForma", Utilities.driver.Title);

            PageObject.RegisterModality.CadastrarModalidadeButton();

            TestesModalidadeMetodos.AguardaModalCadastro();

            PageObject.RegisterModality.NomeModalideTextBox("Nata��o Infantil");

            PageObject.RegisterModality.DescricaoModalideTextBox("Atividade para crian�as de 7 a 9 anos.");

            Thread.Sleep(1000);

            PageObject.RegisterModality.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5500);

            PageObject.RegisterModality.ExcluirModalidadeButton();

            TestesModalidadeMetodos.AguardaModalDeletar();

            PageObject.RegisterModality.FinalizarExcluirModalidadeButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Deletado");
        }
        [Fact]
        public void DuplicarModalidade()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Modalidade");

            Assert.Equal("Modalidade - inForma", Utilities.driver.Title);

            PageObject.RegisterModality.CadastrarModalidadeButton();

            TestesModalidadeMetodos.AguardaModalCadastro();

            PageObject.RegisterModality.NomeModalideTextBox("Nata��o Infantil");

            PageObject.RegisterModality.DescricaoModalideTextBox("Atividade para crian�as de 7 a 9 anos.");

            Thread.Sleep(1000);

            PageObject.RegisterModality.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            PageObject.RegisterModality.CadastrarModalidadeButton();

            TestesModalidadeMetodos.AguardaModalCadastro();

            PageObject.RegisterModality.NomeModalideTextBox("Nata��o Infantil");

            PageObject.RegisterModality.DescricaoModalideTextBox("Atividade para crian�as de 7 a 9 anos.");

            Thread.Sleep(1000);

            PageObject.RegisterModality.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("J� existe essas informa��es");
        }
    }
}
