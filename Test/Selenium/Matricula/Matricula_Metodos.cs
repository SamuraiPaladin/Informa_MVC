using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Test.Selenium.Matricula
{
    class Matricula_Metodos
    {
		public static IWebDriver driver;

		public static Boolean AguardaModalCadastro()
		{
			int aux = 0;
			while (Utilities.driver.FindElement(By.Id("modaCadastrar")).Displayed.Equals(false))
			{
				Thread.Sleep(1000);
				Assert.False(aux == 5, "Sistema não exibiu modal de Cadastro");
				aux++;
			}
			return true;
		}

		public static Boolean AguardaModalDeletar()
		{
			int aux = 0;
			while (Utilities.driver.FindElement(By.Id("modalDeletar")).Displayed.Equals(false))
			{
				Thread.Sleep(1000);
				Assert.False(aux == 5, "Sistema não exibiu modal de Cadastro");
				aux++;
			}
			return true;
		}

		public static Boolean AguardaModalEditar()
		{
			int aux = 0;
			while (Utilities.driver.FindElement(By.Id("modalEditar")).Displayed.Equals(false))
			{
				Thread.Sleep(1000);
				Assert.False(aux == 5, "Sistema não exibiu modal de Cadastro");
				aux++;
			}
			return true;
		}

		public static void FinalizarTeste(int Operacao)
		{
			if (Operacao == 1)
			{
				Thread.Sleep(5500);

				PageObject.RegisterModality.ExcluirModalidadeButton();

				AguardaModalDeletar();

				PageObject.RegisterModality.FinalizarExcluirModalidadeButton();

				PageObject.RegisterUnitScreen.MensagemOperacao("Deletado");
			}
			Utilities.driver.Close();
		}
	}
}
