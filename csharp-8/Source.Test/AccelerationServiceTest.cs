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
        public void Should_Return_Right_Acceleration_When_Find_By_CompanyId()
        {
            var fakeContext = new FakeContext("AccelerationById");
            fakeContext.FillWith<Company>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var expected = fakeContext.GetFakeData<Company>()
                    .Where(x => x.Id == companyId)
                    .Join(_contexto)
                    .SelectMany(x => x.Candidates)
                    .Select(x => x.Acceleration)
                    .Distinct()
                    .ToList();

                var service = new AccelerationService(context);
                var actual = service.FindByCompanyId(companyId);

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
