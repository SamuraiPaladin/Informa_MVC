using OpenQA.Selenium;
using System;
using System.IO;
using System.Threading;
using Test;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Utilities
{
	public static IWebDriver driver;
	public static void OpenChrome()
	{
		//var t = Directory.GetCurrentDirectory().Remove(Directory.GetCurrentDirectory().ToString().Length - 45);
		var t = System.AppDomain.CurrentDomain.BaseDirectory.ToString().Remove(System.AppDomain.CurrentDomain.BaseDirectory.ToString().Length - 9);

		driver = new OpenQA.Selenium.Chrome.ChromeDriver(t); //<-Add your path
		driver.Manage().Window.Maximize();
		////driver.Manage().Window.Size = new Size(1366, 800);
		driver.Navigate().GoToUrl("http://localhost:5200/");
	}

	public static void AcessoGrid(String Modulo, String Sessao)
	{
		PageObject.MainScreen.GridIcone();

		if (Modulo.Equals("Cadastro"))
		{
			
			PageObject.MainScreen.Cadastro.CadastroList();
			Thread.Sleep(1000);

			if(Sessao.Equals("Unidade"))
			{
				PageObject.MainScreen.Cadastro.CadastroUnidadeLink();
			} else if (Sessao.Equals("Modalidade"))
			{
				PageObject.MainScreen.Cadastro.CadastroModalidadeLink();
			} else if (Sessao.Equals("Cargos"))
			{
				PageObject.MainScreen.Cadastro.CadastroCargosLink();
			} else if (Sessao.Equals("Colaborador"))
			{
				PageObject.MainScreen.Cadastro.CadastroColaboradoresLink();
			} else if (Sessao.Equals("Fornecedor"))
			{
				PageObject.MainScreen.Cadastro.CadastroFornecedoresLink();
			}

		} else if (Modulo.Equals("Financeiro"))
		{
			PageObject.MainScreen.Financeiro.FinanceiroList();
			if (Sessao.Equals("Gerenciar Pagamento"))
			{
				PageObject.MainScreen.Financeiro.GerenciarPagamentoLink();
			}

		} else if (Modulo.Equals("Estoque"))
		{
			PageObject.MainScreen.Estoque.EstoqueList();
			if (Sessao.Equals("Link"))
			{
				PageObject.MainScreen.Estoque.LinkLink();
			}
		}
	}

}
