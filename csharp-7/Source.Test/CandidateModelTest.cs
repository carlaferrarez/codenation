using System;
using Xunit;
using Codenation.Challenge.Models;

namespace Codenation.Challenge
{
    public sealed class CandidateModelTest : ModelBaseTest
    {
        public CandidateModelTest()
            : base(new CodenationContext())
        {
            Model = "Codenation.Challenge.Models.Candidate";
            Table = "candidate";
        }

        [Fact]
        public void Should_Has_Table()
        {
            AssertTable();
        }

        [Fact]
        public void Devera_Ter_Primary_Key()
        {
            ComparePrimaryKeys("user_id");
            ComparePrimaryKeys("acceleration_id");
            ComparePrimaryKeys("company_id");
        }


        [Theory]
        [InlineData("user_id", false, typeof(int), null)]
        [InlineData("acceleration_id", false, typeof(int), null)]
        [InlineData("company_id", false, typeof(int), null)]
        [InlineData("status", false, typeof(int), null)]
        [InlineData("created_at", false, typeof(DateTime), null)]
        public void Devera_Ter_Campos(string campoNome, bool ehNulo, Type campoTipo, int? campoTamanho)
        {
            CompararCampos(campoNome, ehNulo, campoTipo, campoTamanho);
        }

        [Theory]
        [InlineData("company_id", false, "company", "id")]
        [InlineData("acceleration_id", false, "acceleration", "id")]
        [InlineData("user_id", false, "user", "id")]


        public void Devera_Ter_FK(string campoNome, bool ehNulo, string tabelarelacionamento, string chaveRelacionamento)
        {
            CompararFK(campoNome, ehNulo, tabelarelacionamento, chaveRelacionamento);
        }

    }
}