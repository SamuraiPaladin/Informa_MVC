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


        }
    }
}
