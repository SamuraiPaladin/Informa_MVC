using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Test.Selenium.Matricula;
using Xunit;

namespace Test
{

    public class TesteIntegrado_Matricula
    {
        [Fact]
        public void CriarMatricula()
        {
            Utilities.OpenChrome();

            Utilities.LogininForma();

            Assert.Equal("Principal - inForma", Utilities.driver.Title);

            Utilities.AcessoGrid("Matricula", "");

            Assert.Equal("Matricula - inForma", Utilities.driver.Title);

            PageObject.RegisterEnrollment.CadastrarMatriulaButton();

            Matricula_Metodos.AguardaModalCadastro();

            PageObject.RegisterEnrollment.NomeAlunoTextBox("AAA Teste AAA");

            Thread.Sleep(250);

            PageObject.RegisterEnrollment.DataNascimento("01012000");

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




        }
    }
}
