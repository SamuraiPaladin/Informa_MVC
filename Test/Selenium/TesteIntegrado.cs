using System;
using Xunit;
using OpenQA.Selenium;


namespace Test
{
    public class TesteIntegradoUnidade
    {
        [Fact]
        public void CriarUnidade()
        {
            Utilities.OpenChrome();

            Assert.Contains("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro","Unidade");

            Assert.Contains("Unidade - inForma", Utilities.driver.Title);

            PageObject.RegisterUnitScreen.NomeUnidadeTextBox("S�o Paulo");

            PageObject.RegisterUnitScreen.TelefoneTextBox("11999999999");

            PageObject.RegisterUnitScreen.CepTextBox("04664020");

            Utilities.CepValidates(
            "Avenida Ministro �lvaro de Souza Lima",     // Endere�o
            "Jardim Marajoara",                          // Bairro
            "S�o Paulo",                                 // Cidade
            "PR");                                       // Estado

            PageObject.RegisterUnitScreen.NumeroTextBox("666");

        }
    }
}
