using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace Test
{
    class PageObject
    {

        public static class LoginScreen
        {
            public static void NomeUsuario(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("login"));
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void NomeSenha(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("password"));
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void LogarinFormaButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/form/div[3]/a"));
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

        public static class MainScreen
        {
            public static void GridIcone()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("/html/body/nav/div/ul[1]/li[1]/a"));
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

            public class Cadastro
            {
                public static void CadastroList()
                {
                    int count = 0;
                    Boolean clicked = false;
                    while (clicked.Equals(false))
                    {
                        try
                        {
                            IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"slide-out\"]/li[3]/ul/li/div[1]"));

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

                public static void CadastroUnidadeLink()
                {
                    int count = 0;
                    Boolean clicked = false;
                    if (clicked.Equals(false))
                    {
                        try
                        {
                            IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"slide-out\"]/li[3]/ul/li/div[2]/ul/li[1]/a"));
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

                public static void CadastroModalidadeLink()
                {
                    int count = 0;
                    Boolean clicked = false;
                    if (clicked.Equals(false))
                    {
                        try
                        {
                            IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"slide-out\"]/li[3]/ul/li/div[2]/ul/li[2]/a"));
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

                public static void CadastroCargosLink()
                {
                    int count = 0;
                    Boolean clicked = false;
                    if (clicked.Equals(false))
                    {
                        try
                        {
                            IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"slide-out\"]/li[3]/ul/li/div[2]/ul/li[3]/a"));
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

                public static void CadastroColaboradoresLink()
                {
                    int count = 0;
                    Boolean clicked = false;
                    if (clicked.Equals(false))
                    {
                        try
                        {
                            IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"slide-out\"]/li[3]/ul/li/div[2]/ul/li[4]/a"));
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

                public static void CadastroTurmaLink()
                {
                    int count = 0;
                    Boolean clicked = false;
                    if (clicked.Equals(false))
                    {
                        try
                        {
                            IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"slide-out\"]/li[3]/ul/li/div[2]/ul/li[5]/a"));
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

            public class Matricula
            {
                public static void MatriculaList()
                {
                    int count = 0;
                    Boolean clicked = false;
                    while (clicked.Equals(false))
                    {
                        try
                        {
                            IWebElement Element = Utilities.driver.FindElement(By.Id("matricula"));
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

            public class Financeiro
            {
                public static void FinanceiroList()
                {
                    int count = 0;
                    Boolean clicked = false;
                    while (clicked.Equals(false))
                    {
                        try
                        {
                            IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"slide-out\"]/li[4]/ul/li/div[1]"));
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
                public static void GerenciarPagamentoLink()
                {
                    int count = 0;
                    Boolean clicked = false;
                    while (clicked.Equals(false))
                    {
                        try
                        {
                            IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"slide-out\"]/li[4]/ul/li/div[2]/ul/li/a"));
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

            public class Estoque
            {
                public static void EstoqueList()
                {
                    int count = 0;
                    Boolean clicked = false;
                    while (clicked.Equals(false))
                    {
                        try
                        {
                            IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"slide-out\"]/li[5]/ul/li/div[2]/ul/li/a"));
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

                public static void LinkLink()
                {
                    int count = 0;
                    Boolean clicked = false;
                    while (clicked.Equals(false))
                    {
                        try
                        {
                            IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"slide-out\"]/li[5]/ul/li/div[1]"));
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
        }
        
        public static class RegisterUnitScreen
        {
            public static void CadastrarUnidadeButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("/html/body/div[1]/div[1]/a"));
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

            public static void NomeUnidadeTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("descricao"));
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void TelefoneTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("telefone"));
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void CepTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("cep"));
                        Element.SendKeys(Unidade + Keys.Tab);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void EnderecoTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("endereco"));
                        if (Element.GetAttribute("value").Equals(""))
                        {
                            Element.SendKeys(Unidade + Keys.Tab);
                        }
                        Text = Element.GetAttribute("value");
                        Assert.True(Unidade.Equals(Text), "CEP informado não condiz com Endereço");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
            }

            public static void NumeroTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("numero"));
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void BairroTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("bairro"));
                        if (Element.GetAttribute("value").Equals(""))
                        {
                            Element.SendKeys(Unidade + Keys.Tab);
                        }

                        Text = Element.GetAttribute("value");
                        Assert.True(Unidade.Equals(Text), "CEP informado não condiz com Bairro");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
            }

            public static void CidadeTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("cidade"));
                        if (Element.GetAttribute("value").Equals(""))
                        {
                            Element.SendKeys(Unidade + Keys.Tab);
                        }

                        Text = Element.GetAttribute("value");
                        Assert.True(Unidade.Equals(Text), "CEP informado não condiz com Cidade");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
            }

            public static void EstadoTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("estado"));
                        if (Element.GetAttribute("value").Equals(""))
                        {
                            Element.SendKeys(Unidade + Keys.Tab);
                        }

                        Text = Element.GetAttribute("value");
                        Assert.True(Unidade.Equals(Text), "CEP informado não condiz com Estado");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
            }

            public static void FinalizarCadastrarButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"modaCadastrar\"]/div[2]/a[2]"));
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

            public static void MensagemOperacao(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (Text.Equals(""))
                {
                    try
                    {
                        Text = Utilities.driver.FindElement(By.XPath("//*[@id=\"toast-container\"]/div")).Text;
                    }
                    catch (Exception e)
                    {
                        Thread.Sleep(750);
                        count = count + 1;
                        Assert.False(count == 50, "Sistema demorou tempo demais para retornar mensagem de sucesso!" + e);
                    }
                }
                Assert.True(Text.Contains(Unidade), "Mensagem esperada: " + Unidade + " Mengadem obtida:" + Text);
            }

            public static void ExcluirUnidadeButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"deletarUnidade\"]/i"));
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

            public static void FinalizarExcluirUnidadeButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("deletar"));
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

            public static void EditarUnidadeButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"editarUnidade\"]/i"));
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

            public static void EditarNumeroTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("numeroEditar"));
                        Element.Clear();
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void FinalizarEditarUnidadeButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"modalEditar\"]/div[2]/a[2]"));
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

        public static class RegisterModality
        {
            public static void CadastrarModalidadeButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/a"));
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

            public static void NomeModalideTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("modalidade"));
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void DescricaoModalideTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("descricao"));
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void FinalizarCadastrarButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"cadastrarModalidade\"]/div[2]/a[2]"));
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

            public static void EditarModalidadeButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"tabelaPrincipal\"]/tbody/tr[1]/td[3]/a[1]/i"));
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

            public static void EditarDesricaoTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("descricaoEditar"));
                        Element.Clear();
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void FinalizarEditarModalidadeButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"modalEditar\"]/div[2]/a[2]"));
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

            public static void ExcluirModalidadeButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"tabelaPrincipal\"]/tbody/tr[1]/td[3]/a[2]/i"));
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

            public static void FinalizarExcluirModalidadeButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"modalDeletar\"]/div[2]/a[2]"));
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

        public static class RegisterJob
        {
            public static void CadastrarCargoButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/a"));
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

            public static void NomeCargoTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("funcao"));
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void DescricaoCargoTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("descricao"));
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void FinalizarCadastrarButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("cadastrar"));
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

            public static void EditarCargoButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"editarCargo\"]/i"));
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

            public static void EditarDesricaoTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("descricaoEditar"));
                        Element.Clear();
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void FinalizarEditarCargoButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("editar"));
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

            public static void ExcluirCargoButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"deletarCargo\"]/i"));
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

            public static void FinalizarExcluirCargoButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("deletar"));
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

        public static class RegisterEmployee
        {
            public static void CadastrarColaboradorButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("cadastrarColaborador"));
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

            public static void NomeColaboradorTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("nome"));
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void DataNascimentoTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (Text.Equals(""))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("datadenascimento"));
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
               //Assert.Contains(Unidade, Text);
            }

            public static void CPFColaboradorTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("cpf"));
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void EmailColaboradorTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("email"));
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void RgColaboradorTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("rg"));
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void TelefoneColaboradorTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("telefone"));
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void CEPColaboradorTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("cep"));
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void NumeroColaboradorTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("numero"));
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void SelecionarCargoButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"modalCadastrar\"]/div[1]/div[2]/form/div[13]/div/input"));
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

            public static void FinalizarCadastrarButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("cadastar"));
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

            public static void EditarColaboradorButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"editarColaborador\"]/i"));
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

            public static void EditarNumeroColaboradorTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("numeroEditar"));
                        Element.Clear();
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void EditarCargoButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("textoDropDownEditar"));
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

            public static void FinalizarEditarColaboradorButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("editar"));
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

            public static void ExcluirColaboradorButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"deletarColaborador\"]/i"));
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

            public static void FinalizarExcluirColaboradorButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("Deletar"));
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

        public static class RegisterClass
        {
            public static void CadastrarTurmaButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("/html/body/div[1]/div[1]/a"));
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

            public static void NomeTurmaTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("descricao"));
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void SelecionaDataButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"formularioEditar\"]/div[2]/div/input"));
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



            public static void SelecionaColaboradorButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath ("//*[@id=\"formularioEditar\"]/div[3]/div/input"));
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

            public static void SelecionaFaixaEtariaButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"formularioEditar\"]/div[4]/div/input"));
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

            public static void Seleciona_ModalidadeButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"formularioEditar\"]/div[5]/div/input"));
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

            public static void HoraInicioTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("horarioinicial"));
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void HoraTerminoTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("horariofinal"));
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void SelecionaUnidadeButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"formularioEditar\"]/div[8]/div/input"));
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

            public static void SelecionaModalidadeButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("modalidadeDropDownCadastrar"));
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

            public static void FinalizarCadastroTurmaButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("cadastrar"));
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

            public static void ExcluirTurmaButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.XPath("//*[@id=\"deletarTurma\"]/i"));
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

            public static void FinalizarExcluirTurmaButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("deletar"));
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

        public static class RegisterEnrollment
        {
            public static void CadastrarMatriulaButton()
            {
                int count = 0;
                Boolean clicked = false;
                while (clicked.Equals(false))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("cadastrarAluno"));
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

            public static void NomeAlunoTextBox(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("nome"));
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }

            public static void DataNascimento(string Unidade)
            {
                int count = 0;
                string Text = "";
                while (!Text.Equals(Unidade))
                {
                    try
                    {
                        IWebElement Element = Utilities.driver.FindElement(By.Id("datadenascimento"));
                        Element.SendKeys(Unidade);
                        Text = Element.GetAttribute("value");
                    }
                    catch (Exception e)
                    {
                        count = count + 1;
                        Assert.False(count > 3, "Descrição da Falha: " + e);
                    }
                }
                Assert.Contains(Unidade, Text);
            }



        }
    }
}
