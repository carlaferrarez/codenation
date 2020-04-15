using System;
using System.Collections.Generic;
using Xunit;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using System.Linq;

namespace Codenation.Challenge
{
    public class SubmissionServiceTest
    {
        private CodenationContext _contexto;
        private FakeContext _contextoFake { get; }
        private SubmissionService _submissionService;

        public SubmissionServiceTest()
        {
            _contextoFake = new FakeContext("SubmissionTest");
            _contextoFake.FillWithAll();

            _contexto = new CodenationContext(_contextoFake.FakeOptions);
            _submissionService = new SubmissionService(_contexto);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]

        public void Should_Return_Right_Score_When_Find_By_Challenge_Id(int challengeId)
        {
            _contextoFake.FillWithAll();
            
            var scoreEsperado = _contextoFake.GetFakeData<Submission>()
                .Where(x => x.ChallengeId == challengeId).Select(x => x.Score).Max(x => x);

            var scoreReal = _submissionService.FindHigherScoreByChallengeId(challengeId);

            Assert.Equal(scoreEsperado, scoreReal);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]

        public void Should_Return_Right_Submission_When_Find_By_Id(int challengeId, int accelerationId)
        {
            _contextoFake.FillWithAll();

            var submissionEsperado = _contextoFake.GetFakeData<Submission>()
                .Find(x => x.ChallengeId == challengeId);

            var accelerationEsperado = _contextoFake.GetFakeData<Acceleration>()
                .Find(x => x.Id == accelerationId);


            var submissionReal = _submissionService.FindByChallengeIdAndAccelerationId(submissionEsperado.ChallengeId, accelerationEsperado.Id);

            Assert.Equal(submissionEsperado.ChallengeId, submissionReal.FirstOrDefault().ChallengeId);

        }



        [Fact]
        public void Should_Add_New_Company_When_Save()
        {
            var fakeContext = new FakeContext("SaveNewSubmission");
            
            var fakeSubmission = new Submission();
            fakeSubmission.Score = 1;
            fakeSubmission.CreatedAt = DateTime.Today;
 

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var service = new SubmissionService(context);
                var actual = service.Save(fakeSubmission);

                Assert.NotEqual(0, actual.UserId);
                Assert.NotEqual(0, actual.ChallengeId);
            }
        }    

    }
}
