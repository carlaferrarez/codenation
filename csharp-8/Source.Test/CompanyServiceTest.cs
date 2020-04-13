using System;
using System.Collections.Generic;
using Xunit;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using System.Linq;

namespace Codenation.Challenge
{
    public class CompanyServiceTest
    {
        private CodenationContext _contexto;
        private FakeContext _contextoFake { get; }
        private CompanyService _companyService;

        public CompanyServiceTest()
        {
            _contextoFake = new FakeContext("CompanyTest");
            _contextoFake.FillWithAll();

            _contexto = new CodenationContext(_contextoFake.FakeOptions);
            _companyService = new CompanyService(_contexto);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]

        public void Should_Return_Right_Company_When_Find_By_Acceleration_Id(int accelerationId)
        {
            _contextoFake.FillWithAll();

            var companyEsperado = _contextoFake.GetFakeData<Acceleration>()
                .Find(x => x.Id == accelerationId);

            var companyReal = _companyService.FindByAccelerationId(companyEsperado.Id).ToList();

            Assert.Equal(companyEsperado.Id, companyReal.FirstOrDefault().Id);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]

        public void Should_Return_Right_Company_When_Find_By_User_Id(int userId)
        {
            _contextoFake.FillWithAll();

            var candidateEsperado = _contextoFake.GetFakeData<User>()
                .Find(x => x.Id == userId);

            var candidateReal = _companyService.FindByUserId(candidateEsperado.Id).ToList();

            Assert.Equal(candidateEsperado.Id, candidateReal.FirstOrDefault().Id);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Return_Right_Company_When_Find_By_Id(int id)
        {
            var fakeContext = new FakeContext("CompanyById");            
            fakeContext.FillWith<Company>();


            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var expected = fakeContext.GetFakeData<Company>().Find(x => x.Id == id);

                var service = new CompanyService(context);
                var actual = service.FindById(id);

                Assert.Equal(expected, actual, new CompanyIdComparer());
            }
        }


        [Fact]
        public void Should_Add_New_Company_When_Save()
        {
            var fakeContext = new FakeContext("SaveNewCompany");
            
            var fakeCompany = new Company();
            fakeCompany.Name = "name";
            fakeCompany.Slug = "slug";
            fakeCompany.CreatedAt = DateTime.Today;
 

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var service = new CompanyService(context);
                var actual = service.Save(fakeCompany);

                Assert.NotEqual(0, actual.Id);
            }
        }    

    }
}
