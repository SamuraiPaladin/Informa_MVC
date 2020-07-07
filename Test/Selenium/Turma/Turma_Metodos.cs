using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Test;
using Xunit;

/// <summary>
/// Summary description for Class1
/// </summary>
public class TestesTurmaMetodos
{
	public static IWebDriver driver;
	
	public static Boolean AguardaModalCadastro()
	{
		int aux = 0;
		while (Utilities.driver.FindElement(By.Id("modaCadastrar")).Displayed.Equals(false))
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

	public static void SelecionaItemDropBox(String item)
	{
		int count = 0;
		Boolean clicked = false;
		while (clicked.Equals(false))
		{
			try
			{
				var t = "//*[contains(text(),'" + item + "')]";
				IWebElement Element = Utilities.driver.FindElement(By.XPath(t));
				//IWebElement Element = Utilities.driver.FindElement(By.LinkText(item));
				IJavaScriptExecutor executor = (IJavaScriptExecutor)Utilities.driver;
				executor.ExecuteScript("arguments[0].click();", Element);
				clicked = true;
			}
			catch (Exception e)
			{
				count = count + 1;
				Assert.False(count > 3, "Descrição da Falha: " + e);
			}
		}
	}

	public static void SelecionaDiaSemana(String item)
	{
		int count = 0;
		Boolean clicked = false;
		if (item.Equals("Segunda"))
		{
			while (clicked.Equals(false))
			{
				try
				{
					IWebElement Element = Utilities.driver.FindElement(By.XPath("//li[starts-with(@id,'select-options')]//span[contains(text(),'Segunda')]"));
					IJavaScriptExecutor executor = (IJavaScriptExecutor)Utilities.driver; 
					executor.ExecuteScript("arguments[0].click();", Element);
					clicked = true;
				}
				catch (Exception e)
				{
					count = count + 1;
					Assert.False(count > 3, "Descrição da Falha: " + e);
				}
			}
		} else if (item.Equals("Terça"))
		{
			while (clicked.Equals(false))
			{
				try
				{
					IWebElement Element = Utilities.driver.FindElement(By.XPath("//li[starts-with(@id,'select-options')]//span[contains(text(),'Terça')]"));
					IJavaScriptExecutor executor = (IJavaScriptExecutor)Utilities.driver;
					executor.ExecuteScript("arguments[0].click();", Element);
					clicked = true;
				}
				catch (Exception e)
				{
					count = count + 1;
					Assert.False(count > 3, "Descrição da Falha: " + e);
				}
			}
		} else if (item.Equals("Quarta"))
		{
			while (clicked.Equals(false))
			{
				try
				{
					IWebElement Element = Utilities.driver.FindElement(By.XPath("//li[starts-with(@id,'select-options')]//span[contains(text(),'Quarta')]"));
					IJavaScriptExecutor executor = (IJavaScriptExecutor)Utilities.driver;
					executor.ExecuteScript("arguments[0].click();", Element);
					clicked = true;
				}
				catch (Exception e)
				{
					count = count + 1;
					Assert.False(count > 3, "Descrição da Falha: " + e);
				}
			}
		} else if (item.Equals("Quinta"))
		{
			while (clicked.Equals(false))
			{
				try
				{
					IWebElement Element = Utilities.driver.FindElement(By.XPath("//li[starts-with(@id,'select-options')]//span[contains(text(),'Quinta')]"));
					IJavaScriptExecutor executor = (IJavaScriptExecutor)Utilities.driver;
					executor.ExecuteScript("arguments[0].click();", Element);
					clicked = true;
				}
				catch (Exception e)
				{
					count = count + 1;
					Assert.False(count > 3, "Descrição da Falha: " + e);
				}
			}
		} else if (item.Equals("Sexta"))
		{
			while (clicked.Equals(false))
			{
				try
				{
					IWebElement Element = Utilities.driver.FindElement(By.XPath("//li[starts-with(@id,'select-options')]//span[contains(text(),'Sexta')]"));
					IJavaScriptExecutor executor = (IJavaScriptExecutor)Utilities.driver;
					executor.ExecuteScript("arguments[0].click();", Element);
					clicked = true;
				}
				catch (Exception e)
				{
					count = count + 1;
					Assert.False(count > 3, "Descrição da Falha: " + e);
				}
			}
		} else if (item.Equals("Sábado"))
		{
			while (clicked.Equals(false))
			{
				try
				{
					IWebElement Element = Utilities.driver.FindElement(By.XPath("//li[starts-with(@id,'select-options')]//span[contains(text(),'Sábado')]"));
					IJavaScriptExecutor executor = (IJavaScriptExecutor)Utilities.driver;
					executor.ExecuteScript("arguments[0].click();", Element);
					clicked = true;
				}
				catch (Exception e)
				{
					count = count + 1;
					Assert.False(count > 3, "Descrição da Falha: " + e);
				}
			}
		} else if (item.Equals("Domingo"))
		{
			while (clicked.Equals(false))
			{
				try
				{
					IWebElement Element = Utilities.driver.FindElement(By.XPath("//li[starts-with(@id,'select-options')]//span[contains(text(),'Domingo')]"));
					IJavaScriptExecutor executor = (IJavaScriptExecutor)Utilities.driver;
					executor.ExecuteScript("arguments[0].click();", Element);
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

	public static void FinalizarTeste(int Operacao)
	{
		if (Operacao == 1)
		{
			Thread.Sleep(6500);

			PageObject.RegisterClass.ExcluirTurmaButton();

			TestesTurmaMetodos.AguardaModalDeletar();

			PageObject.RegisterClass.FinalizarCadastroTurmaButton();
		}

		Utilities.driver.Close();
	}
}
