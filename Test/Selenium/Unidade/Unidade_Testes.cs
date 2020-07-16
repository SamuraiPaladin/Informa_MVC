using Xunit;
using System.Threading;

namespace Test
{
    public class TesteIntegrado_Unidade
    {
        [Fact]
        public void CriarUnidade()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro","Unidade");

            Assert.Equal("Unidade - inForma", Utilities.driver.Title);

            PageObject.RegisterUnitScreen.CadastrarUnidadeButton();

            TestesUnidadeMetodos.AguardaModalCadastro();
            
            PageObject.RegisterUnitScreen.NomeUnidadeTextBox("AAA TESTE AAA");

            PageObject.RegisterUnitScreen.TelefoneTextBox("11999999999");

            Thread.Sleep(1500);

            PageObject.RegisterUnitScreen.CepTextBox("04664020");

            TestesUnidadeMetodos.CepValidates(
            "Avenida Ministro Álvaro de Souza Lima",     // Endereço
            "Jardim Marajoara",                          // Bairro
            "São Paulo",                                 // Cidade
            "SP");                                       // Estado 

            Thread.Sleep(1000);

            PageObject.RegisterUnitScreen.NumeroTextBox("666");

            Thread.Sleep(1000);

            PageObject.RegisterUnitScreen.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            TestesUnidadeMetodos.FinalizarTeste(1);

        }

        [Fact]
        public void CampoObrigatorioNomeUnidade()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Unidade");

            Assert.Equal("Unidade - inForma", Utilities.driver.Title);

            PageObject.RegisterUnitScreen.CadastrarUnidadeButton();

            TestesUnidadeMetodos.AguardaModalCadastro();

            //PageObject.RegisterUnitScreen.NomeUnidadeTextBox("AAA TESTE AAA");

            PageObject.RegisterUnitScreen.TelefoneTextBox("11999999999");

            PageObject.RegisterUnitScreen.CepTextBox("04664020");

            Thread.Sleep(1500);

            TestesUnidadeMetodos.CepValidates(
            "Avenida Ministro Álvaro de Souza Lima",     // Endereço
            "Jardim Marajoara",                          // Bairro
            "São Paulo",                                 // Cidade
            "SP");                                       // Estado 

            Thread.Sleep(1000);

            PageObject.RegisterUnitScreen.NumeroTextBox("666");

            Thread.Sleep(1000);

            PageObject.RegisterUnitScreen.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesUnidadeMetodos.FinalizarTeste(2);
        }

        [Fact]
        public void CampoObrigatorioTelefone()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Unidade");

            Assert.Equal("Unidade - inForma", Utilities.driver.Title);

            PageObject.RegisterUnitScreen.CadastrarUnidadeButton();

            TestesUnidadeMetodos.AguardaModalCadastro();

            PageObject.RegisterUnitScreen.NomeUnidadeTextBox("AAA TESTE AAA");

            //PageObject.RegisterUnitScreen.TelefoneTextBox("11999999999");

            PageObject.RegisterUnitScreen.CepTextBox("04664020");

            Thread.Sleep(1500);

            TestesUnidadeMetodos.CepValidates(
            "Avenida Ministro Álvaro de Souza Lima",     // Endereço
            "Jardim Marajoara",                          // Bairro
            "São Paulo",                                 // Cidade
            "SP");                                       // Estado 

            Thread.Sleep(1000);

            PageObject.RegisterUnitScreen.NumeroTextBox("666");

            Thread.Sleep(1000);

            PageObject.RegisterUnitScreen.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesUnidadeMetodos.FinalizarTeste(2);
        }

        [Fact]
        public void CampoObrigatorioCEP()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Unidade");

            Assert.Equal("Unidade - inForma", Utilities.driver.Title);

            PageObject.RegisterUnitScreen.CadastrarUnidadeButton();

            TestesUnidadeMetodos.AguardaModalCadastro();

            PageObject.RegisterUnitScreen.NomeUnidadeTextBox("AAA TESTE AAA");

            PageObject.RegisterUnitScreen.TelefoneTextBox("11999999999");

            //PageObject.RegisterUnitScreen.CepTextBox("04664020");

            //TestesUnidadeMetodos.CepValidates(
            //"Avenida Ministro Álvaro de Souza Lima",     // Endereço
            //"Jardim Marajoara",                          // Bairro
            //"São Paulo",                                 // Cidade
            //"SP");                                       // Estado 

            Thread.Sleep(1000);

            PageObject.RegisterUnitScreen.NumeroTextBox("666");

            Thread.Sleep(1000);

            PageObject.RegisterUnitScreen.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesUnidadeMetodos.FinalizarTeste(2);

        }

        [Fact]
        public void CampoObrigatorioNumeroCEP()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Unidade");

            Assert.Equal("Unidade - inForma", Utilities.driver.Title);

            PageObject.RegisterUnitScreen.CadastrarUnidadeButton();

            TestesUnidadeMetodos.AguardaModalCadastro();

            PageObject.RegisterUnitScreen.NomeUnidadeTextBox("AAA TESTE AAA");

            PageObject.RegisterUnitScreen.TelefoneTextBox("11999999999");

            PageObject.RegisterUnitScreen.CepTextBox("04664020");

            Thread.Sleep(1500);

            TestesUnidadeMetodos.CepValidates(
            "Avenida Ministro Álvaro de Souza Lima",     // Endereço
            "Jardim Marajoara",                          // Bairro
            "São Paulo",                                 // Cidade
            "SP");                                       // Estado 

            Thread.Sleep(1000);

            //PageObject.RegisterUnitScreen.NumeroTextBox("666");

            Thread.Sleep(1000);

            PageObject.RegisterUnitScreen.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesUnidadeMetodos.FinalizarTeste(2);
        }

        [Fact]
        public void EditarUnidade()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Unidade");

            Assert.Equal("Unidade - inForma", Utilities.driver.Title);

            PageObject.RegisterUnitScreen.CadastrarUnidadeButton();

            TestesUnidadeMetodos.AguardaModalCadastro();

            PageObject.RegisterUnitScreen.NomeUnidadeTextBox("AAA TESTE AAA");

            PageObject.RegisterUnitScreen.TelefoneTextBox("11999999999");

            PageObject.RegisterUnitScreen.CepTextBox("04664020");

            Thread.Sleep(1500);

            TestesUnidadeMetodos.CepValidates(
            "Avenida Ministro Álvaro de Souza Lima",     // Endereço
            "Jardim Marajoara",                          // Bairro
            "São Paulo",                                 // Cidade
            "SP");                                       // Estado 

            Thread.Sleep(1000);

            PageObject.RegisterUnitScreen.NumeroTextBox("666");

            Thread.Sleep(1000);

            PageObject.RegisterUnitScreen.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            PageObject.RegisterUnitScreen.EditarUnidadeButton();

            TestesUnidadeMetodos.AguardaModalEditar();

            PageObject.RegisterUnitScreen.EditarNumeroTextBox("777");

            PageObject.RegisterUnitScreen.FinalizarEditarUnidadeButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Editado");

            TestesUnidadeMetodos.FinalizarTeste(1);
        }
        [Fact]
        public void DeletarUnidade()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Unidade");

            Assert.Equal("Unidade - inForma", Utilities.driver.Title);

            PageObject.RegisterUnitScreen.CadastrarUnidadeButton();

            TestesUnidadeMetodos.AguardaModalCadastro();

            PageObject.RegisterUnitScreen.NomeUnidadeTextBox("AAA TESTE AAA");

            PageObject.RegisterUnitScreen.TelefoneTextBox("11999999999");

            PageObject.RegisterUnitScreen.CepTextBox("04664020");

            Thread.Sleep(1500);

            TestesUnidadeMetodos.CepValidates(
            "Avenida Ministro Álvaro de Souza Lima",     // Endereço
            "Jardim Marajoara",                          // Bairro
            "São Paulo",                                 // Cidade
            "SP");                                       // Estado 

            Thread.Sleep(1000);

            PageObject.RegisterUnitScreen.NumeroTextBox("666");

            Thread.Sleep(1000);

            PageObject.RegisterUnitScreen.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            TestesUnidadeMetodos.FinalizarTeste(1);
        }
        [Fact]
        public void DuplicarUnidade()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Unidade");

            Assert.Equal("Unidade - inForma", Utilities.driver.Title);

            PageObject.RegisterUnitScreen.CadastrarUnidadeButton();

            TestesUnidadeMetodos.AguardaModalCadastro();

            PageObject.RegisterUnitScreen.NomeUnidadeTextBox("AAA TESTE AAA");

            PageObject.RegisterUnitScreen.TelefoneTextBox("11999999999");

            PageObject.RegisterUnitScreen.CepTextBox("04664020");

            TestesUnidadeMetodos.CepValidates(
            "Avenida Ministro Álvaro de Souza Lima",     // Endereço
            "Jardim Marajoara",                          // Bairro
            "São Paulo",                                 // Cidade
            "SP");                                       // Estado 

            Thread.Sleep(1000);

            PageObject.RegisterUnitScreen.NumeroTextBox("666");

            Thread.Sleep(1000);

            PageObject.RegisterUnitScreen.FinalizarCadastrarButton();

            //TestesUnidadeMetodos.AguardaMensagemOperacao();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            PageObject.RegisterUnitScreen.CadastrarUnidadeButton();

            TestesUnidadeMetodos.AguardaModalCadastro();

            PageObject.RegisterUnitScreen.NomeUnidadeTextBox("AAA TESTE AAA");

            PageObject.RegisterUnitScreen.TelefoneTextBox("11999999999");

            PageObject.RegisterUnitScreen.CepTextBox("04664020");

            Thread.Sleep(1500);

            TestesUnidadeMetodos.CepValidates(
            "Avenida Ministro Álvaro de Souza Lima",     // Endereço
            "Jardim Marajoara",                          // Bairro
            "São Paulo",                                 // Cidade
            "SP");                                       // Estado 

            PageObject.RegisterUnitScreen.NumeroTextBox("666");

            PageObject.RegisterUnitScreen.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Já existe essas informações");

            TestesUnidadeMetodos.FinalizarTeste(1);
        }
    }
}
