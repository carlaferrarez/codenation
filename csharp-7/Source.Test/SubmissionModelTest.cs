using System;
using Xunit;
using Codenation.Challenge.Models;

namespace Codenation.Challenge
{
    public sealed class SubmissionModelTest : ModelBaseTest
    {
        public SubmissionModelTest()
            : base(new CodenationContext())
        {
            Model = "Codenation.Challenge.Models.Submission";
            Table = "submission";
        }

        [Fact]
        public void Should_Has_Table()
        {
            AssertTable();
        }

        [Fact]
        public void Devera_Ter_Primary_Key()
        {
            ComparePrimaryKeys("challenge_id");
            ComparePrimaryKeys("user_id");
        }


        [Theory]
        [InlineData("user_id", false, typeof(int), null)]
        [InlineData("challenge_id", false, typeof(int), null)]
        [InlineData("score", false, typeof(decimal), null)]
        [InlineData("created_at", false, typeof(DateTime), null)]
        public void Devera_Ter_Campos(string campoNome, bool ehNulo, Type campoTipo, int? campoTamanho)
        {
            CompararCampos(campoNome, ehNulo, campoTipo, campoTamanho);
        }

        [Theory]
        [InlineData("challenge_id", false, "challenge", "id")]
        [InlineData("user_id", false, "user", "id")]
        public void Devera_Ter_FK(string campoNome, bool ehNulo, string tabelarelacionamento, string chaveRelacionamento)
        {
            CompararFK(campoNome, ehNulo, tabelarelacionamento, chaveRelacionamento);
        }

    }
}