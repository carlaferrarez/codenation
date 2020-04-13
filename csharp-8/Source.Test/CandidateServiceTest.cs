using System;
using System.Collections.Generic;
using Xunit;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using System.Linq;

namespace Codenation.Challenge
{
    public class CandidateServiceTest
    {
        private CodenationContext _contexto;
        private FakeContext _contextoFake { get; }
        private CandidateService _candidateService;

        public CandidateServiceTest()
        {
            _contextoFake = new FakeContext("CandidateTest");
            _contextoFake.FillWithAll();

            _contexto = new CodenationContext(_contextoFake.FakeOptions);
            _candidateService = new CandidateService(_contexto);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]

        public void Should_Return_Right_Candidate_When_Find_By_Acceleration_Id(int accelerationId)
        {
            _contextoFake.FillWithAll();

            var candidateEsperado = _contextoFake.GetFakeData<Acceleration>()
                .Find(x => x.Id == accelerationId);

            var candidateReal = _candidateService.FindByAccelerationId(candidateEsperado.Id).ToList();

            Assert.Equal(candidateEsperado.Id, candidateReal.FirstOrDefault().AccelerationId);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]

        public void Should_Return_Right_Candidate_When_Find_By_Company_Id(int companyId)
        {
            _contextoFake.FillWithAll();

            var candidateEsperado = _contextoFake.GetFakeData<Company>()
                .Find(x => x.Id == companyId);

            var candidateReal = _candidateService.FindByAccelerationId(candidateEsperado.Id).ToList();

            Assert.Equal(candidateEsperado.Id, candidateReal.FirstOrDefault().CompanyId);

        }

        [Theory]
        [InlineData(1,1,1)]
        [InlineData(2,2,2)]
        [InlineData(3,3,3)]
        public void Should_Return_Right_Candidate_When_Find_By_Id(int userId, int accelerationId, int companyId)
        {
            var fakeContext = new FakeContext("CandidateById");            
            fakeContext.FillWith<Candidate>();


            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var expected = fakeContext.GetFakeData<Candidate>().Find(x => x.AccelerationId == accelerationId
                && x.CompanyId == companyId && x.UserId == userId);

                var service = new CandidateService(context);
                var actual = service.FindById(userId, accelerationId, companyId);

                Assert.Equal(expected, actual, new CandidateIdComparer());
            }
        }


        [Fact]
        public void Should_Add_New_Candidate_When_Save()
        {
            var fakeContext = new FakeContext("SaveNewCandidate");
            
            var fakeCandidate = new Candidate();
            fakeCandidate.UserId = 12;
            fakeCandidate.AccelerationId = 12;
            fakeCandidate.CompanyId = 12;
            fakeCandidate.Status = 1;
            fakeCandidate.CreatedAt = DateTime.Today;
 

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var service = new CandidateService(context);
                var actual = service.Save(fakeCandidate);

                Assert.NotEqual(0, actual.AccelerationId);
                Assert.NotEqual(0, actual.CompanyId);
                Assert.NotEqual(0, actual.UserId);
            }
        }    

    }
}
