using Xunit;
using System.Threading;

namespace Test
{
    public class TesteIntegradoUnidade
    {
        // PONTOS DE MELHORIA //
        /*
            1 - Reduzir tempo em finalizar o modal após finalizar um cadastro, edição, delete.
            2 - Colocar botão 'Sair' em todos os modais de Unidade (Cadastrar, Editar e Deletar)
            3 - Quando há um erro no cadastro, sistema não informa qual campo está errado/faltando. Pode ser uma mensagem padrão
            4 - Nos modais está sendo exibido 'tal' ao invés do nome da unidade a ser deletada
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
            
            PageObject.RegisterUnitScreen.NomeUnidadeTextBox("São Paulo");

            PageObject.RegisterUnitScreen.TelefoneTextBox("11999999999");

            PageObject.RegisterUnitScreen.CepTextBox("04664020");

            TestesUnidadeMetodos.CepValidates(
            "Avenida Ministro Álvaro de Souza Lima",     // Endereço
            "Jardim Marajoara",                          // Bairro
            "São Paulo",                                 // Cidade
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

            PageObject.RegisterUnitScreen.NomeUnidadeTextBox("São Paulo");

            PageObject.RegisterUnitScreen.TelefoneTextBox("11999999999");

            PageObject.RegisterUnitScreen.CepTextBox("04664020");

            TestesUnidadeMetodos.CepValidates(
            "Avenida Ministro Álvaro de Souza Lima",     // Endereço
            "Jardim Marajoara",                          // Bairro
            "São Paulo",                                 // Cidade
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

            PageObject.RegisterUnitScreen.NomeUnidadeTextBox("São Paulo");

            PageObject.RegisterUnitScreen.TelefoneTextBox("11999999999");

            PageObject.RegisterUnitScreen.CepTextBox("04664020");

            TestesUnidadeMetodos.CepValidates(
            "Avenida Ministro Álvaro de Souza Lima",     // Endereço
            "Jardim Marajoara",                          // Bairro
            "São Paulo",                                 // Cidade
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

            PageObject.RegisterUnitScreen.NomeUnidadeTextBox("São Paulo");

            PageObject.RegisterUnitScreen.TelefoneTextBox("11999999999");

            PageObject.RegisterUnitScreen.CepTextBox("04664020");

            TestesUnidadeMetodos.CepValidates(
            "Avenida Ministro Álvaro de Souza Lima",     // Endereço
            "Jardim Marajoara",                          // Bairro
            "São Paulo",                                 // Cidade
            "SP");                                       // Estado 

            PageObject.RegisterUnitScreen.NumeroTextBox("666");

            Thread.Sleep(1000);

            PageObject.RegisterUnitScreen.FinalizarCadastrarButton();

            //TestesUnidadeMetodos.AguardaMensagemOperacao();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            PageObject.RegisterUnitScreen.CadastrarUnidadeButton();

            TestesUnidadeMetodos.AguardaModalCadastro();

            PageObject.RegisterUnitScreen.NomeUnidadeTextBox("São Paulo");

            PageObject.RegisterUnitScreen.TelefoneTextBox("11999999999");

            PageObject.RegisterUnitScreen.CepTextBox("04664020");

            TestesUnidadeMetodos.CepValidates(
            "Avenida Ministro Álvaro de Souza Lima",     // Endereço
            "Jardim Marajoara",                          // Bairro
            "São Paulo",                                 // Cidade
            "SP");                                       // Estado 

            PageObject.RegisterUnitScreen.NumeroTextBox("666");

            PageObject.RegisterUnitScreen.FinalizarCadastrarButton();

            //TestesUnidadeMetodos.AguardaMensagemOperacao();

            PageObject.RegisterUnitScreen.MensagemOperacao("Já existe essas informações");
        }
    }
}
