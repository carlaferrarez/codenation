using System;
using Xunit;
using Codenation.Challenge.Models;

namespace Codenation.Challenge
{
    public sealed class CompanyModelTest: ModelBaseTest
    {
        public CompanyModelTest()
            : base(new CodenationContext())
        {            
            Model = "Codenation.Challenge.Models.Company";
            Table = "company";
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
        [InlineData("created_at", false, typeof(DateTime), null)]
        public void Devera_Ter_Campos(string campoNome, bool ehNulo, Type campoTipo, int? campoTamanho)
        {
            CompararCampos(campoNome, ehNulo, campoTipo, campoTamanho);
        }

    }
}