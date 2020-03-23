using Xunit;
using System.Threading;

namespace Test
{
    public class TesteIntegradoUnidade
    {
        // PONTOS DE MELHORIA //
        /*
            1 - Reduzir tempo em finalizar o modal ap�s finalizar um cadastro, edi��o, delete.
            2 - Colocar bot�o 'Sair' em todos os modais de Unidade (Cadastrar, Editar e Deletar)
            3 - Quando h� um erro no cadastro, sistema n�o informa qual campo est� errado/faltando. Pode ser uma mensagem padr�o
            4 - Nos modais est� sendo exibido 'tal' ao inv�s do nome da unidade a ser deletada
        */

        [Fact]
        public void CriarUnidade()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro","Unidade");

            Assert.Equal("Unidade - inForma", Utilities.driver.Title);

            PageObject.RegisterUnitScreen.CadastrarUnidadeButton();

            TestesUnidadeMetodos.AguardaModalCadastro();
            
            PageObject.RegisterUnitScreen.NomeUnidadeTextBox("S�o Paulo");

            PageObject.RegisterUnitScreen.TelefoneTextBox("11999999999");

            PageObject.RegisterUnitScreen.CepTextBox("04664020");

            TestesUnidadeMetodos.CepValidates(
            "Avenida Ministro �lvaro de Souza Lima",     // Endere�o
            "Jardim Marajoara",                          // Bairro
            "S�o Paulo",                                 // Cidade
            "SP");                                       // Estado 

            PageObject.RegisterUnitScreen.NumeroTextBox("666");

            Thread.Sleep(1000);

            PageObject.RegisterUnitScreen.FinalizarCadastrarButton();

            //TestesUnidadeMetodos.AguardaMensagemOperacao();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

        }
        [Fact]
        public void EditarUnidade()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Unidade");

            Assert.Equal("Unidade - inForma", Utilities.driver.Title);

            PageObject.RegisterUnitScreen.CadastrarUnidadeButton();

            TestesUnidadeMetodos.AguardaModalCadastro();

            PageObject.RegisterUnitScreen.NomeUnidadeTextBox("S�o Paulo");

            PageObject.RegisterUnitScreen.TelefoneTextBox("11999999999");

            PageObject.RegisterUnitScreen.CepTextBox("04664020");

            TestesUnidadeMetodos.CepValidates(
            "Avenida Ministro �lvaro de Souza Lima",     // Endere�o
            "Jardim Marajoara",                          // Bairro
            "S�o Paulo",                                 // Cidade
            "SP");                                       // Estado 

            PageObject.RegisterUnitScreen.NumeroTextBox("666");

            Thread.Sleep(1000);

            PageObject.RegisterUnitScreen.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            PageObject.RegisterUnitScreen.EditarUnidadeButton();

            TestesUnidadeMetodos.AguardaModalEditar();

            PageObject.RegisterUnitScreen.EditarNumeroTextBox("777");

            PageObject.RegisterUnitScreen.FinalizarEditarUnidadeButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Deletado");
        }
        [Fact]
        public void DeletarUnidade()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Unidade");

            Assert.Equal("Unidade - inForma", Utilities.driver.Title);

            PageObject.RegisterUnitScreen.CadastrarUnidadeButton();

            TestesUnidadeMetodos.AguardaModalCadastro();

            PageObject.RegisterUnitScreen.NomeUnidadeTextBox("S�o Paulo");

            PageObject.RegisterUnitScreen.TelefoneTextBox("11999999999");

            PageObject.RegisterUnitScreen.CepTextBox("04664020");

            TestesUnidadeMetodos.CepValidates(
            "Avenida Ministro �lvaro de Souza Lima",     // Endere�o
            "Jardim Marajoara",                          // Bairro
            "S�o Paulo",                                 // Cidade
            "SP");                                       // Estado 

            PageObject.RegisterUnitScreen.NumeroTextBox("666");

            Thread.Sleep(1000);

            PageObject.RegisterUnitScreen.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            PageObject.RegisterUnitScreen.ExcluirUnidadeButton();

            TestesUnidadeMetodos.AguardaModalDeletar();

            PageObject.RegisterUnitScreen.FinalizarExcluirUnidadeButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Deletado");
        }
        [Fact]
        public void DuplicarUnidade()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Unidade");

            Assert.Equal("Unidade - inForma", Utilities.driver.Title);

            PageObject.RegisterUnitScreen.CadastrarUnidadeButton();

            TestesUnidadeMetodos.AguardaModalCadastro();

            PageObject.RegisterUnitScreen.NomeUnidadeTextBox("S�o Paulo");

            PageObject.RegisterUnitScreen.TelefoneTextBox("11999999999");

            PageObject.RegisterUnitScreen.CepTextBox("04664020");

            TestesUnidadeMetodos.CepValidates(
            "Avenida Ministro �lvaro de Souza Lima",     // Endere�o
            "Jardim Marajoara",                          // Bairro
            "S�o Paulo",                                 // Cidade
            "SP");                                       // Estado 

            PageObject.RegisterUnitScreen.NumeroTextBox("666");

            Thread.Sleep(1000);

            PageObject.RegisterUnitScreen.FinalizarCadastrarButton();

            //TestesUnidadeMetodos.AguardaMensagemOperacao();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            PageObject.RegisterUnitScreen.CadastrarUnidadeButton();

            TestesUnidadeMetodos.AguardaModalCadastro();

            PageObject.RegisterUnitScreen.NomeUnidadeTextBox("S�o Paulo");

            PageObject.RegisterUnitScreen.TelefoneTextBox("11999999999");

            PageObject.RegisterUnitScreen.CepTextBox("04664020");

            TestesUnidadeMetodos.CepValidates(
            "Avenida Ministro �lvaro de Souza Lima",     // Endere�o
            "Jardim Marajoara",                          // Bairro
            "S�o Paulo",                                 // Cidade
            "SP");                                       // Estado 

            PageObject.RegisterUnitScreen.NumeroTextBox("666");

            PageObject.RegisterUnitScreen.FinalizarCadastrarButton();

            //TestesUnidadeMetodos.AguardaMensagemOperacao();

            PageObject.RegisterUnitScreen.MensagemOperacao("J� existe essas informa��es");
        }
    }
}
