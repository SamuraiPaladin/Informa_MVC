using Xunit;
using System.Threading;

namespace Test
{
    public class TesteIntegrado_Turma
    {
        [Fact]
        public void CriarTurma()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Turma");

            Assert.Equal("Turma - inForma", Utilities.driver.Title);

            PageObject.RegisterClass.CadastrarTurmaButton();

            TestesTurmaMetodos.AguardaModalCadastro();

            PageObject.RegisterClass.NomeTurmaTextBox("Aula Teste");

            Thread.Sleep(250);

            //PageObject.RegisterClass.SelecionaDataButton();

            //TestesTurmaMetodos.SelecionaDiaSemana("Segunda");

            //TestesTurmaMetodos.SelecionaDiaSemana("Quarta");

            PageObject.RegisterClass.SelecionaColaboradorButton();

            TestesTurmaMetodos.SelecionaItemDropBox("TESTE");

            PageObject.RegisterClass.SelecionaFaixaEtariaButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Adulto");

            Thread.Sleep(250);

            PageObject.RegisterClass.Seleciona_ModalidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Natação");

            PageObject.RegisterClass.HoraInicioTextBox("22:30");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraTerminoTextBox("23:30");

            PageObject.RegisterClass.SelecionaUnidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Poá");

            //PageObject.RegisterClass.SelecionaModalidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Natação");

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");


        }

        [Fact]
        public void CampoObrigatorioNomeTurma()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Turma");

            Assert.Equal("Turma - inForma", Utilities.driver.Title);

            PageObject.RegisterClass.CadastrarTurmaButton();

            TestesTurmaMetodos.AguardaModalCadastro();

            //PageObject.RegisterClass.NomeTurmaTextBox("Hidroginástica");

            Thread.Sleep(250);

            PageObject.RegisterClass.SelecionaColaboradorButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Teste");

            PageObject.RegisterClass.SelecionaFaixaEtariaButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Adulto");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraInicioTextBox("22:30");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraTerminoTextBox("23:30");

            PageObject.RegisterClass.SelecionaUnidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("São Paulo");

            PageObject.RegisterClass.SelecionaModalidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Natação");

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

        }

        [Fact]
        public void CampoObrigatorioColaborador()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Turma");

            Assert.Equal("Turma - inForma", Utilities.driver.Title);

            PageObject.RegisterClass.CadastrarTurmaButton();

            TestesTurmaMetodos.AguardaModalCadastro();

            PageObject.RegisterClass.NomeTurmaTextBox("Hidroginástica");

            Thread.Sleep(250);

            //PageObject.RegisterClass.SelecionaColaboradorButton();

            //TestesTurmaMetodos.SelecionaItemDropBox("Teste");

            PageObject.RegisterClass.SelecionaFaixaEtariaButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Adulto");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraInicioTextBox("22:30");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraTerminoTextBox("23:30");

            PageObject.RegisterClass.SelecionaUnidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("São Paulo");

            PageObject.RegisterClass.SelecionaModalidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Natação");

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

        }

        [Fact]
        public void CampoObrigatorioTipoAula()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Turma");

            Assert.Equal("Turma - inForma", Utilities.driver.Title);

            PageObject.RegisterClass.CadastrarTurmaButton();

            TestesTurmaMetodos.AguardaModalCadastro();

            PageObject.RegisterClass.NomeTurmaTextBox("Hidroginástica");

            Thread.Sleep(250);

            PageObject.RegisterClass.SelecionaColaboradorButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Teste");

            //PageObject.RegisterClass.SelecionaFaixaEtariaButton();

            //TestesTurmaMetodos.SelecionaItemDropBox("Adulto");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraInicioTextBox("22:30");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraTerminoTextBox("23:30");

            PageObject.RegisterClass.SelecionaUnidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("São Paulo");

            PageObject.RegisterClass.SelecionaModalidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Natação");

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

        }

        [Fact]
        public void CampoObrigatorioHoraInicio()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Turma");

            Assert.Equal("Turma - inForma", Utilities.driver.Title);

            PageObject.RegisterClass.CadastrarTurmaButton();

            TestesTurmaMetodos.AguardaModalCadastro();

            PageObject.RegisterClass.NomeTurmaTextBox("Hidroginástica");

            Thread.Sleep(250);

            PageObject.RegisterClass.SelecionaColaboradorButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Teste");

            PageObject.RegisterClass.SelecionaFaixaEtariaButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Adulto");

            Thread.Sleep(250);

            //PageObject.RegisterClass.HoraInicioTextBox("22:30");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraTerminoTextBox("23:30");

            PageObject.RegisterClass.SelecionaUnidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("São Paulo");

            PageObject.RegisterClass.SelecionaModalidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Natação");

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

        }

        [Fact]
        public void CampoObrigatorioHoraFim()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Turma");

            Assert.Equal("Turma - inForma", Utilities.driver.Title);

            PageObject.RegisterClass.CadastrarTurmaButton();

            TestesTurmaMetodos.AguardaModalCadastro();

            PageObject.RegisterClass.NomeTurmaTextBox("Hidroginástica");

            Thread.Sleep(250);

            PageObject.RegisterClass.SelecionaColaboradorButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Teste");

            PageObject.RegisterClass.SelecionaFaixaEtariaButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Adulto");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraInicioTextBox("22:30");

            Thread.Sleep(250);

            //PageObject.RegisterClass.HoraTerminoTextBox("23:30");

            PageObject.RegisterClass.SelecionaUnidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("São Paulo");

            PageObject.RegisterClass.SelecionaModalidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Natação");

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

        }

        [Fact]
        public void CampoObrigatorioUnidade()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Turma");

            Assert.Equal("Turma - inForma", Utilities.driver.Title);

            PageObject.RegisterClass.CadastrarTurmaButton();

            TestesTurmaMetodos.AguardaModalCadastro();

            PageObject.RegisterClass.NomeTurmaTextBox("Hidroginástica");

            Thread.Sleep(250);

            PageObject.RegisterClass.SelecionaColaboradorButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Teste");

            PageObject.RegisterClass.SelecionaFaixaEtariaButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Adulto");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraInicioTextBox("22:30");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraTerminoTextBox("23:30");

            //PageObject.RegisterClass.SelecionaUnidadeButton();

            //TestesTurmaMetodos.SelecionaItemDropBox("São Paulo");

            PageObject.RegisterClass.SelecionaModalidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Natação");

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

        }

        [Fact]
        public void CampoObrigatorioModalidade()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Turma");

            Assert.Equal("Turma - inForma", Utilities.driver.Title);

            PageObject.RegisterClass.CadastrarTurmaButton();

            TestesTurmaMetodos.AguardaModalCadastro();

            PageObject.RegisterClass.NomeTurmaTextBox("Hidroginástica");

            Thread.Sleep(250);

            PageObject.RegisterClass.SelecionaColaboradorButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Teste");

            PageObject.RegisterClass.SelecionaFaixaEtariaButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Adulto");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraInicioTextBox("22:30");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraTerminoTextBox("23:30");

            PageObject.RegisterClass.SelecionaUnidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("São Paulo");

            //PageObject.RegisterClass.SelecionaModalidadeButton();

            //TestesTurmaMetodos.SelecionaItemDropBox("Natação");

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

        }

        [Fact]
        public void EditarTurma()
        { 
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Turma");

            Assert.Equal("Turma - inForma", Utilities.driver.Title);

            PageObject.RegisterClass.CadastrarTurmaButton();

            TestesTurmaMetodos.AguardaModalCadastro();

            PageObject.RegisterClass.NomeTurmaTextBox("Hidroginástica");

            Thread.Sleep(250);

            PageObject.RegisterClass.SelecionaColaboradorButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Teste");

            PageObject.RegisterClass.SelecionaFaixaEtariaButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Adulto");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraInicioTextBox("22:30");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraTerminoTextBox("23:30");

            PageObject.RegisterClass.SelecionaUnidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("São Paulo");

            PageObject.RegisterClass.SelecionaModalidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Natação");

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(6000);

            PageObject.RegisterClass.CadastrarTurmaButton();

            TestesTurmaMetodos.AguardaModalCadastro();

            PageObject.RegisterClass.NomeTurmaTextBox("Hidroginástica");

            Thread.Sleep(250);

            PageObject.RegisterClass.SelecionaColaboradorButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Teste");

            PageObject.RegisterClass.SelecionaFaixaEtariaButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Adulto");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraInicioTextBox("22:20");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraTerminoTextBox("23:20");

            PageObject.RegisterClass.SelecionaUnidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("São Paulo");

            PageObject.RegisterClass.SelecionaModalidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Natação");

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Mensagem de Turma já cadastrada");


        }

        [Fact]
        public void DeletarTurma()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Colaborador");

            Assert.Equal("Colaborador - inForma", Utilities.driver.Title);

            PageObject.RegisterEmployee.CadastrarColaboradorButton();

            TestesTurmaMetodos.AguardaModalCadastro();

            PageObject.RegisterEmployee.NomeColaboradorTextBox("Thauan Moser Doce");

            Thread.Sleep(250);

            PageObject.RegisterEmployee.SelecionarCargoButton();

            Thread.Sleep(250);

            TestesColaboradorMetodos.SelecionaCargo("Teste");

            Thread.Sleep(1500);

            PageObject.RegisterEmployee.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            PageObject.RegisterEmployee.ExcluirColaboradorButton();

            TestesTurmaMetodos.AguardaModalDeletar();

            PageObject.RegisterEmployee.FinalizarExcluirColaboradorButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Deletado");
        }
        [Fact]
        public void DuplicarTurma()
        {
            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Colaborador");

            Assert.Equal("Colaborador - inForma", Utilities.driver.Title);

            PageObject.RegisterEmployee.CadastrarColaboradorButton();

            TestesTurmaMetodos.AguardaModalCadastro();

            PageObject.RegisterEmployee.NomeColaboradorTextBox("Thauan Moser Doce");

            Thread.Sleep(250);

            PageObject.RegisterEmployee.SelecionarCargoButton();

            Thread.Sleep(250);

            TestesColaboradorMetodos.SelecionaCargo("Teste");

            Thread.Sleep(1500);

            PageObject.RegisterEmployee.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            Utilities.OpenChrome();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Colaborador");

            Assert.Equal("Colaborador - inForma", Utilities.driver.Title);

            PageObject.RegisterEmployee.CadastrarColaboradorButton();

            TestesTurmaMetodos.AguardaModalCadastro();

            PageObject.RegisterEmployee.NomeColaboradorTextBox("Thauan Moser Doce");

            Thread.Sleep(250);

            PageObject.RegisterEmployee.SelecionarCargoButton();

            Thread.Sleep(250);

            TestesColaboradorMetodos.SelecionaCargo("Teste");

            Thread.Sleep(1500);

            PageObject.RegisterEmployee.FinalizarCadastrarButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Já existe essas informações");
        }
    }
}
