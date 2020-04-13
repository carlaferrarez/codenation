using System;
using System.Collections.Generic;
using Xunit;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using System.Linq;

namespace Codenation.Challenge
{
    public class AccelerationServiceTest
    {
        private CodenationContext _contexto;
        private FakeContext _contextoFake { get; }
        private AccelerationService _accelerationService;

        public AccelerationServiceTest()
        {
            _contextoFake = new FakeContext("AccelerationTest");
            _contextoFake.FillWithAll();

            _contexto = new CodenationContext(_contextoFake.FakeOptions);
            _accelerationService = new AccelerationService(_contexto);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]

        public void Should_Return_Right_Acceleration_When_Find_By_Company_Id(int companyId)
        {
            _contextoFake.FillWithAll();

            var accelerationEsperado = _contextoFake.GetFakeData<Company>()
                .Find(x => x.Id == companyId);

            var accelerationReal = _accelerationService.FindByCompanyId(accelerationEsperado.Id).ToList();

            Assert.Equal(accelerationEsperado.Id, accelerationReal.FirstOrDefault().Id);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Return_Right_Acceleration_When_Find_By_Id(int id)
        {
            var fakeContext = new FakeContext("AccelerationById");            
            fakeContext.FillWith<Acceleration>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var expected = fakeContext.GetFakeData<Acceleration>().Find(x => x.Id == id);

                var service = new AccelerationService(context);
                var actual = service.FindById(id);

                Assert.Equal(expected, actual, new AccelerationIdComparer());
            }
        }


        [Fact]
        public void Should_Add_New_Acceleration_When_Save()
        {
            var fakeContext = new FakeContext("SaveNewAcceleration");
            
            var fakeUser = new Acceleration();
            fakeUser.Name = "carla";
            fakeUser.Slug = "oi";
            fakeUser.CreatedAt = DateTime.Today;
            fakeUser.ChallengeId = 1;

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var service = new AccelerationService(context);
                var actual = service.Save(fakeUser);

                Assert.NotEqual(0, actual.Id);
            }
        }    

    }
}
