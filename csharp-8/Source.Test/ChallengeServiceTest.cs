using System;
using System.Collections.Generic;
using Xunit;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using System.Linq;

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

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]

        public void Should_Return_Right_Challenge_When_Find_By_Id(int accelerationId, int userId)
        {
            _contextoFake.FillWithAll();

            var userEsperado = _contextoFake.GetFakeData<Candidate>()
                .Find(x => x.UserId == userId);

            // seleciona candidato por accelerationId e userId
            var candidateEsperado = _contextoFake.GetFakeData<Candidate>()
                 .Find(x => x.AccelerationId == accelerationId && x.UserId == userId);

            // seleciona a aceleração de acordo com o que achamos anteriormente
            var accelerationEsperado = _contextoFake.GetFakeData<Acceleration>()
                 .Find(x => x.Id == candidateEsperado.AccelerationId);

            // seleciona challenge de acordo com o que achamos anteriormente
            var challengeEsperado = _contextoFake.GetFakeData<Models.Challenge>()
                .Find(x => x.Id == accelerationEsperado.ChallengeId);

            var challengeReal = _challengeService.FindByAccelerationIdAndUserId(accelerationEsperado.Id, userEsperado.UserId);

             Assert.Equal(challengeEsperado.Id, challengeReal.FirstOrDefault().Id);

        }


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
