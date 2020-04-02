using OpenQA.Selenium;
using System;
using System.Threading;
using Test;
using Xunit;

/// <summary>
/// Summary description for Class1
/// </summary>
public class TestesUnidadeMetodos
{
	public static IWebDriver driver;
	
	public static void CepValidates(String Endereco, String Bairro, String Cidade, String Estado)
	{
		Thread.Sleep(1000);
		PageObject.RegisterUnitScreen.EnderecoTextBox(Endereco);
		PageObject.RegisterUnitScreen.BairroTextBox(Bairro);
		PageObject.RegisterUnitScreen.CidadeTextBox(Cidade);
		PageObject.RegisterUnitScreen.EstadoTextBox(Estado);
	}

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

	public static Boolean AguardaPreenchimentoCEP()
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
}
