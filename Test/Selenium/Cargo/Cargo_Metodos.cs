using OpenQA.Selenium;
using System;
using System.Threading;
using Test;
using Xunit;

/// <summary>
/// Summary description for Class1
/// </summary>
public class TestesCargoMetodos
{
	public static IWebDriver driver;
	
	public static Boolean AguardaModalCadastro()
	{
		int aux = 0;
		while (Utilities.driver.FindElement(By.Id("cadastrarCargo")).Displayed.Equals(false))
		{
			Thread.Sleep(1000);
			 Assert.False(aux == 5,"Sistema não exibiu modal de Cadastro");
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

	public static void FinalizarTeste(int Oper)
	{
		if (Oper == 1)
		{
			Thread.Sleep(5500);

			PageObject.RegisterJob.ExcluirCargoButton();

			TestesCargoMetodos.AguardaModalDeletar();

			PageObject.RegisterJob.FinalizarExcluirCargoButton();

			PageObject.RegisterUnitScreen.MensagemOperacao("Deletado");
		
		} 

		Utilities.driver.Close();
	}
}
