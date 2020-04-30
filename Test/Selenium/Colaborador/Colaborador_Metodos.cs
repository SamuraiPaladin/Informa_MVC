using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Test;
using Xunit;

/// <summary>
/// Summary description for Class1
/// </summary>
public class TestesColaboradorMetodos
{
	public static IWebDriver driver;
	
	public static Boolean AguardaModalCadastro()
	{
		int aux = 0;
		while (Utilities.driver.FindElement(By.Id("modalCadastrar")).Displayed.Equals(false))
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

	public static void SelecionaCargo(String item)
	{
		int count = 0;
		Boolean clicked = false;
		while (clicked.Equals(false))
		{
			try
			{
				//IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[contains(text(),'Teste')]"));
				IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[contains(text(),'" + item + "')]"));
				Element.Click();
				clicked = true;
			}
			catch (Exception e)
			{
				count = count + 1;
				Assert.False(count > 3, "Descrição da Falha: " + e);
			}
		}
	}

	public static void EditaCargo(String item)
	{
		int count = 0;
		Boolean clicked = false;
		while (clicked.Equals(false))
		{
			try
			{
				//IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[contains(text(),'Teste')]"));
				IWebElement Element = Utilities.driver.FindElement(By.LinkText(item));
				Element.Click();
				clicked = true;
			}
			catch (Exception e)
			{
				count = count + 1;
				Assert.False(count > 3, "Descrição da Falha: " + e);
			}
		}
	}



}
