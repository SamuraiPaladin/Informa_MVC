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

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Modalidade");

            Assert.Equal("Modalidade - inForma", Utilities.driver.Title);

            PageObject.RegisterModality.CadastrarModalidadeButton();

            TestesModalidadeMetodos.AguardaModalCadastro();
            
            PageObject.RegisterModality.NomeModalideTextBox("AA Teste AA");

            PageObject.RegisterModality.DescricaoModalideTextBox("Atividade para crianças de 7 a 9 anos.");

            Thread.Sleep(1000);

            PageObject.RegisterModality.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            TestesModalidadeMetodos.FinalizarTeste(1);

        }

        [Fact]
        public void CampoObrigatorioDescricao()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Modalidade");

            Assert.Equal("Modalidade - inForma", Utilities.driver.Title);

            PageObject.RegisterModality.CadastrarModalidadeButton();

            TestesModalidadeMetodos.AguardaModalCadastro();

            PageObject.RegisterModality.NomeModalideTextBox("AA Teste AA");

            //PageObject.RegisterModality.DescricaoModalideTextBox("Atividade para crianças de 7 a 9 anos.");

            Thread.Sleep(1000);

            PageObject.RegisterModality.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesModalidadeMetodos.FinalizarTeste(2);

        }

        [Fact]
        public void CampoObrigatorioNomeModalidade()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Modalidade");

            Assert.Equal("Modalidade - inForma", Utilities.driver.Title);

            PageObject.RegisterModality.CadastrarModalidadeButton();

            TestesModalidadeMetodos.AguardaModalCadastro();

            //PageObject.RegisterModality.NomeModalideTextBox("AA Teste AA");

            PageObject.RegisterModality.DescricaoModalideTextBox("Atividade para crianças de 7 a 9 anos.");

            Thread.Sleep(1000);

            PageObject.RegisterModality.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesModalidadeMetodos.FinalizarTeste(2);

        }

        [Fact]
        public void EditarModalidade()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Modalidade");

            Assert.Equal("Modalidade - inForma", Utilities.driver.Title);

            PageObject.RegisterModality.CadastrarModalidadeButton();

            TestesModalidadeMetodos.AguardaModalCadastro();

            PageObject.RegisterModality.NomeModalideTextBox("AA Teste AA");

            PageObject.RegisterModality.DescricaoModalideTextBox("Atividade para crianças de 7 a 9 anos.");

            Thread.Sleep(1000);

            PageObject.RegisterModality.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            PageObject.RegisterModality.EditarModalidadeButton();

            TestesModalidadeMetodos.AguardaModalEditar();

            PageObject.RegisterModality.EditarDesricaoTextBox("Descrição alterada para teste.");

            PageObject.RegisterModality.FinalizarEditarModalidadeButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Editado");

            TestesModalidadeMetodos.FinalizarTeste(1);
        }

        [Fact]
        public void DeletarModalidade()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Modalidade");

            Assert.Equal("Modalidade - inForma", Utilities.driver.Title);

            PageObject.RegisterModality.CadastrarModalidadeButton();

            TestesModalidadeMetodos.AguardaModalCadastro();

            PageObject.RegisterModality.NomeModalideTextBox("AA Teste AA");

            PageObject.RegisterModality.DescricaoModalideTextBox("Atividade para crianças de 7 a 9 anos.");

            Thread.Sleep(1000);

            PageObject.RegisterModality.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5500);

            PageObject.RegisterModality.ExcluirModalidadeButton();

            TestesModalidadeMetodos.AguardaModalDeletar();

            PageObject.RegisterModality.FinalizarExcluirModalidadeButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Deletado");

            TestesModalidadeMetodos.FinalizarTeste(2);
        }
        [Fact]
        public void DuplicarModalidade()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Modalidade");

            Assert.Equal("Modalidade - inForma", Utilities.driver.Title);

            PageObject.RegisterModality.CadastrarModalidadeButton();

            TestesModalidadeMetodos.AguardaModalCadastro();

            PageObject.RegisterModality.NomeModalideTextBox("Natação Infantil");

            PageObject.RegisterModality.DescricaoModalideTextBox("Atividade para crianças de 7 a 9 anos.");

            Thread.Sleep(1000);

            PageObject.RegisterModality.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            PageObject.RegisterModality.CadastrarModalidadeButton();

            TestesModalidadeMetodos.AguardaModalCadastro();

            PageObject.RegisterModality.NomeModalideTextBox("Natação Infantil");

            PageObject.RegisterModality.DescricaoModalideTextBox("Atividade para crianças de 7 a 9 anos.");

            Thread.Sleep(1000);

            PageObject.RegisterModality.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Já existe essas informações");

            TestesModalidadeMetodos.FinalizarTeste(1);
        }
    }
}
