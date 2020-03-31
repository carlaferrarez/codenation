using System;
using Xunit;
using Codenation.Challenge.Models;

namespace Codenation.Challenge
{
    public sealed class UserModelTest : ModelBaseTest
    {
        public UserModelTest()
            : base(new CodenationContext())
        {
            Model = "Codenation.Challenge.Models.User";
            Table = "user";
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
        [InlineData("full_name", false, typeof(string), 100)]
        [InlineData("email", false, typeof(string), 100)]
        [InlineData("nickname", false, typeof(string), 50)]
        [InlineData("password", false, typeof(string), 255)]
        [InlineData("created_at", false, typeof(DateTime), null)]
        public void Devera_Ter_Campos(string campoNome, bool ehNulo, Type campoTipo, int? campoTamanho)
        {
            CompararCampos(campoNome, ehNulo, campoTipo, campoTamanho);
        }

    }
}