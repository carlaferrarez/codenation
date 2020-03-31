using System;
using Xunit;
using Codenation.Challenge.Models;

namespace Codenation.Challenge
{
    public sealed class AccelerationModelTest : ModelBaseTest
    {
        public AccelerationModelTest()
            : base(new CodenationContext())
        {
            Model = "Codenation.Challenge.Models.Acceleration";
            Table = "acceleration";
        }

        [Fact]
        public void Should_Has_Table()
        {
            AssertTable();
        }

        [Fact]
        public void Devera_Ter_Primary_Key()
        {
            ComparePrimaryKeys("id");
        }

        [Theory]
        [InlineData("id", false, typeof(int), null)]
        [InlineData("name", false, typeof(string), 100)]
        [InlineData("slug", false, typeof(string), 50)]
        [InlineData("challenge_id", false, typeof(int), null)]
        [InlineData("created_at", false, typeof(DateTime), null)]
        public void Devera_Ter_Campos(string campoNome, bool ehNulo, Type campoTipo, int? campoTamanho)
        {
            CompararCampos(campoNome, ehNulo, campoTipo, campoTamanho);
        }

        [Theory]
        [InlineData("challenge_id", false, "challenge", "id")]
        public void Devera_Ter_FK(string campoNome, bool ehNulo, string tabelarelacionamento, string chaveRelacionamento)
        {
            CompararFK(campoNome, ehNulo, tabelarelacionamento, chaveRelacionamento);
        }

    }
}