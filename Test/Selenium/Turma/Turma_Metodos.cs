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
				//IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[contains(text(),'Teste')]"));
				IWebElement Element = Utilities.driver.FindElement(By.LinkText(item));
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
					IWebElement Element = Utilities.driver.FindElement(By.LinkText("Segunda"));
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
					IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"select-options-c399c200-11ab-267d-b436-2170c0c952d32\"]/span"));
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
					IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"select-options-c399c200-11ab-267d-b436-2170c0c952d33\"]/span/label/span"));
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
					IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"select-options-c399c200-11ab-267d-b436-2170c0c952d34\"]/span/label/span"));
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
					IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"select-options-c399c200-11ab-267d-b436-2170c0c952d35\"]/span/label/span"));
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
					IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"select-options-c399c200-11ab-267d-b436-2170c0c952d36\"]/span/label/span"));
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
					IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"select-options-c399c200-11ab-267d-b436-2170c0c952d37\"]/span/label/span"));
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

}
