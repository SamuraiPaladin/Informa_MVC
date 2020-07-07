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

            PageObject.RegisterClass.SelecionaDataButton();

            Thread.Sleep(500);

            TestesTurmaMetodos.SelecionaDiaSemana("Segunda");

            TestesTurmaMetodos.SelecionaDiaSemana("Quarta");

            PageObject.RegisterClass.SelecionaColaboradorButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("TESTE");

            PageObject.RegisterClass.SelecionaFaixaEtariaButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("Adulto");

            Thread.Sleep(250);

            PageObject.RegisterClass.Seleciona_ModalidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Arte Marcial");

            PageObject.RegisterClass.HoraInicioTextBox("22:30");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraTerminoTextBox("23:30");

            PageObject.RegisterClass.SelecionaUnidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("OSASCO");

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");
           
            TestesTurmaMetodos.FinalizarTeste(1);

        }

        [Fact]
        public void CampoObrigatorioNomeTurma()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Cadastro", "Turma");

            Assert.Equal("Turma - inForma", Utilities.driver.Title);

            PageObject.RegisterClass.CadastrarTurmaButton();

            TestesTurmaMetodos.AguardaModalCadastro();

            //PageObject.RegisterClass.NomeTurmaTextBox("Aula Teste");

            Thread.Sleep(250);

            PageObject.RegisterClass.SelecionaDataButton();

            Thread.Sleep(500);

            TestesTurmaMetodos.SelecionaDiaSemana("Segunda");

            TestesTurmaMetodos.SelecionaDiaSemana("Quarta");

            PageObject.RegisterClass.SelecionaColaboradorButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("TESTE");

            PageObject.RegisterClass.SelecionaFaixaEtariaButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("Adulto");

            Thread.Sleep(250);

            PageObject.RegisterClass.Seleciona_ModalidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Arte Marcial");

            PageObject.RegisterClass.HoraInicioTextBox("22:30");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraTerminoTextBox("23:30");

            PageObject.RegisterClass.SelecionaUnidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("OSASCO");

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesTurmaMetodos.FinalizarTeste(2);

        }

        [Fact]
        public void CampoObrigatorioDiaSemana()
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

            Thread.Sleep(500);

            //TestesTurmaMetodos.SelecionaDiaSemana("Segunda");

            //TestesTurmaMetodos.SelecionaDiaSemana("Quarta");

            PageObject.RegisterClass.SelecionaColaboradorButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("TESTE");

            PageObject.RegisterClass.SelecionaFaixaEtariaButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("Adulto");

            Thread.Sleep(250);

            PageObject.RegisterClass.Seleciona_ModalidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Arte Marcial");

            PageObject.RegisterClass.HoraInicioTextBox("22:30");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraTerminoTextBox("23:30");

            PageObject.RegisterClass.SelecionaUnidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("OSASCO");

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesTurmaMetodos.FinalizarTeste(2);

        }

        [Fact]
        public void CampoObrigatorioResponsavelTurma()
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

            PageObject.RegisterClass.SelecionaDataButton();

            Thread.Sleep(500);

            TestesTurmaMetodos.SelecionaDiaSemana("Segunda");

            TestesTurmaMetodos.SelecionaDiaSemana("Quarta");

            //PageObject.RegisterClass.SelecionaColaboradorButton();

            //Thread.Sleep(250);

            //TestesTurmaMetodos.SelecionaItemDropBox("TESTE");

            PageObject.RegisterClass.SelecionaFaixaEtariaButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("Adulto");

            Thread.Sleep(250);

            PageObject.RegisterClass.Seleciona_ModalidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Arte Marcial");

            PageObject.RegisterClass.HoraInicioTextBox("22:30");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraTerminoTextBox("23:30");

            PageObject.RegisterClass.SelecionaUnidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("OSASCO");

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesTurmaMetodos.FinalizarTeste(2);

        }

        [Fact]
        public void CampoObrigatorioFaixaEtaria()
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

            PageObject.RegisterClass.SelecionaDataButton();

            Thread.Sleep(500);

            TestesTurmaMetodos.SelecionaDiaSemana("Segunda");

            TestesTurmaMetodos.SelecionaDiaSemana("Quarta");

            PageObject.RegisterClass.SelecionaColaboradorButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("TESTE");

            //PageObject.RegisterClass.SelecionaFaixaEtariaButton();

            //Thread.Sleep(250);

            //TestesTurmaMetodos.SelecionaItemDropBox("Adulto");

            Thread.Sleep(250);

            PageObject.RegisterClass.Seleciona_ModalidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Arte Marcial");

            PageObject.RegisterClass.HoraInicioTextBox("22:30");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraTerminoTextBox("23:30");

            PageObject.RegisterClass.SelecionaUnidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("OSASCO");

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesTurmaMetodos.FinalizarTeste(2);

        }

        [Fact]
        public void CampoObrigatorioModalidade()
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

            PageObject.RegisterClass.SelecionaDataButton();

            Thread.Sleep(500);

            TestesTurmaMetodos.SelecionaDiaSemana("Segunda");

            TestesTurmaMetodos.SelecionaDiaSemana("Quarta");

            PageObject.RegisterClass.SelecionaColaboradorButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("TESTE");

            PageObject.RegisterClass.SelecionaFaixaEtariaButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("Adulto");

            Thread.Sleep(250);

            //PageObject.RegisterClass.Seleciona_ModalidadeButton();

            //TestesTurmaMetodos.SelecionaItemDropBox("Arte Marcial");

            PageObject.RegisterClass.HoraInicioTextBox("22:30");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraTerminoTextBox("23:30");

            PageObject.RegisterClass.SelecionaUnidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("OSASCO");

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesTurmaMetodos.FinalizarTeste(2);

        }

        [Fact]
        public void CampoObrigatorioHoraInicio()
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

            PageObject.RegisterClass.SelecionaDataButton();

            Thread.Sleep(500);

            TestesTurmaMetodos.SelecionaDiaSemana("Segunda");

            TestesTurmaMetodos.SelecionaDiaSemana("Quarta");

            PageObject.RegisterClass.SelecionaColaboradorButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("TESTE");

            PageObject.RegisterClass.SelecionaFaixaEtariaButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("Adulto");

            Thread.Sleep(250);

            PageObject.RegisterClass.Seleciona_ModalidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Arte Marcial");

            //PageObject.RegisterClass.HoraInicioTextBox("22:30");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraTerminoTextBox("23:30");

            PageObject.RegisterClass.SelecionaUnidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("OSASCO");

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesTurmaMetodos.FinalizarTeste(2);

        }

        [Fact]
        public void CampoObrigatorioHoraFim()
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

            PageObject.RegisterClass.SelecionaDataButton();

            Thread.Sleep(500);

            TestesTurmaMetodos.SelecionaDiaSemana("Segunda");

            TestesTurmaMetodos.SelecionaDiaSemana("Quarta");

            PageObject.RegisterClass.SelecionaColaboradorButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("TESTE");

            PageObject.RegisterClass.SelecionaFaixaEtariaButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("Adulto");

            Thread.Sleep(250);

            PageObject.RegisterClass.Seleciona_ModalidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Arte Marcial");

            PageObject.RegisterClass.HoraInicioTextBox("22:30");

            Thread.Sleep(250);

            //PageObject.RegisterClass.HoraTerminoTextBox("23:30");

            PageObject.RegisterClass.SelecionaUnidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("OSASCO");

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesTurmaMetodos.FinalizarTeste(2);

        }

        [Fact]
        public void CampoObrigatorioUnidade()
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

            PageObject.RegisterClass.SelecionaDataButton();

            Thread.Sleep(500);

            TestesTurmaMetodos.SelecionaDiaSemana("Segunda");

            TestesTurmaMetodos.SelecionaDiaSemana("Quarta");

            PageObject.RegisterClass.SelecionaColaboradorButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("TESTE");

            PageObject.RegisterClass.SelecionaFaixaEtariaButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("Adulto");

            Thread.Sleep(250);

            PageObject.RegisterClass.Seleciona_ModalidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Arte Marcial");

            PageObject.RegisterClass.HoraInicioTextBox("22:30");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraTerminoTextBox("23:30");

            //PageObject.RegisterClass.SelecionaUnidadeButton();

            //TestesTurmaMetodos.SelecionaItemDropBox("OSASCO");

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Preenchimento obrigatório");

            TestesTurmaMetodos.FinalizarTeste(2);

        }

        [Fact]
        public void EditarTurma()
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

            PageObject.RegisterClass.SelecionaDataButton();

            Thread.Sleep(500);

            TestesTurmaMetodos.SelecionaDiaSemana("Segunda");

            TestesTurmaMetodos.SelecionaDiaSemana("Quarta");

            PageObject.RegisterClass.SelecionaColaboradorButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("TESTE");

            PageObject.RegisterClass.SelecionaFaixaEtariaButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("Adulto");

            Thread.Sleep(250);

            PageObject.RegisterClass.Seleciona_ModalidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Arte Marcial");

            PageObject.RegisterClass.HoraInicioTextBox("22:30");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraTerminoTextBox("23:30");

            PageObject.RegisterClass.SelecionaUnidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("OSASCO");

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(5000);

            TestesTurmaMetodos.FinalizarTeste(1);

        }

        [Fact]
        public void DeletarTurma()
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

            PageObject.RegisterClass.SelecionaDataButton();

            Thread.Sleep(500);

            TestesTurmaMetodos.SelecionaDiaSemana("Segunda");

            TestesTurmaMetodos.SelecionaDiaSemana("Quarta");

            PageObject.RegisterClass.SelecionaColaboradorButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("TESTE");

            PageObject.RegisterClass.SelecionaFaixaEtariaButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("Adulto");

            Thread.Sleep(250);

            PageObject.RegisterClass.Seleciona_ModalidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Arte Marcial");

            PageObject.RegisterClass.HoraInicioTextBox("22:30");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraTerminoTextBox("23:30");

            PageObject.RegisterClass.SelecionaUnidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("OSASCO");

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            Thread.Sleep(6500);

            PageObject.RegisterClass.ExcluirTurmaButton();

            TestesTurmaMetodos.AguardaModalDeletar();

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Deletado");

            TestesTurmaMetodos.FinalizarTeste(2);
        }

        [Fact]
        public void DuplicarTurma()
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

            PageObject.RegisterClass.SelecionaDataButton();

            Thread.Sleep(500);

            TestesTurmaMetodos.SelecionaDiaSemana("Segunda");

            TestesTurmaMetodos.SelecionaDiaSemana("Quarta");

            PageObject.RegisterClass.SelecionaColaboradorButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("TESTE");

            PageObject.RegisterClass.SelecionaFaixaEtariaButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("Adulto");

            Thread.Sleep(250);

            PageObject.RegisterClass.Seleciona_ModalidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Arte Marcial");

            PageObject.RegisterClass.HoraInicioTextBox("22:30");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraTerminoTextBox("23:30");

            PageObject.RegisterClass.SelecionaUnidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("OSASCO");

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Salvo");

            PageObject.RegisterClass.CadastrarTurmaButton();

            TestesTurmaMetodos.AguardaModalCadastro();

            PageObject.RegisterClass.NomeTurmaTextBox("Aula Teste");

            Thread.Sleep(250);

            PageObject.RegisterClass.SelecionaDataButton();

            Thread.Sleep(500);

            TestesTurmaMetodos.SelecionaDiaSemana("Segunda");

            TestesTurmaMetodos.SelecionaDiaSemana("Quarta");

            PageObject.RegisterClass.SelecionaColaboradorButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("TESTE");

            PageObject.RegisterClass.SelecionaFaixaEtariaButton();

            Thread.Sleep(250);

            TestesTurmaMetodos.SelecionaItemDropBox("Adulto");

            Thread.Sleep(250);

            PageObject.RegisterClass.Seleciona_ModalidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("Arte Marcial");

            PageObject.RegisterClass.HoraInicioTextBox("22:30");

            Thread.Sleep(250);

            PageObject.RegisterClass.HoraTerminoTextBox("23:30");

            PageObject.RegisterClass.SelecionaUnidadeButton();

            TestesTurmaMetodos.SelecionaItemDropBox("OSASCO");

            PageObject.RegisterClass.FinalizarCadastroTurmaButton();

            PageObject.RegisterUnitScreen.MensagemOperacao("Já existe essas informações");

            TestesTurmaMetodos.FinalizarTeste(1);
        }
    }
}
