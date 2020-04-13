using System;
using System.Collections.Generic;
using Xunit;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;

namespace Codenation.Challenge
{
    public class ChallengeServiceTest
    {
        private CodenationContext _contexto;
        private FakeContext _contextoFake { get; }
        private ChallengeService _challengeService;

        public ChallengeServiceTest()
        {
            _contextoFake = new FakeContext("ChallengeService");
            _contextoFake.FillWithAll();

            _contexto = new CodenationContext(_contextoFake.FakeOptions);
            _challengeService = new ChallengeService(_contexto);

        }

        //[Theory]
        //[InlineData(1,1)]
        //[InlineData(2,2)]
        //[InlineData(3,3)]

        //public void Should_Return_Right_Challenge_When_Find_By_Id(int accelerationId, int userId)
        //{
        //    _contextoFake.FillWithAll();

        //    var challengeEsperado = _contextoFake.GetFakeData<Models.Candidate>()
        //        .Find(x => x.AccelerationId == accelerationId && x.UserId == userId);

        //    var accelerationEsperado = _contextoFake.GetFakeData<Models.Candidate>()
        //         .Find(x => x.AccelerationId == accelerationId);
        //    var userEsperado = _contextoFake.GetFakeData<Models.Candidate>()
        //        .Find(x = x.UserId == userId);

        //    var challengeReal = _challengeService.FindByAccelerationIdAndUserId(accelerationEsperado, userEsperado).ToList();

        //    Assert.Equal(challengeEsperado., accelerationReal.FirstOrDefault().Id);

        //}


        [Fact]
        public void Should_Add_New_Challenge_When_Save()
        {
            var fakeContext = new FakeContext("SaveNewChallenge");

            var fakeChallenge = new Models.Challenge
            {
                Name = "full name",
                Slug = "pass",
                CreatedAt = DateTime.Today
            };

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var service = new ChallengeService(context);
                var actual = service.Save(fakeChallenge);

                Assert.NotEqual(0, actual.Id);
            }
        }    

    }
}
