using System;
using System.Collections.Generic;
using Xunit;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;

namespace Codenation.Challenge
{
    public class ChallengeServiceTest
    {
        //[Theory]
        //[InlineData(1)]
        //[InlineData(2)]
        //[InlineData(3)]
        //public void Should_Return_Right_Challenge_When_Find_By_Id(int accelerationId, int userId)
        //{
        //    var fakeContext = new FakeContext("ChallengeByAccelerationAndUserId");            
        //    fakeContext.FillWith<Models.Challenge>();

        //    using (var context = new CodenationContext(fakeContext.FakeOptions))
        //    {
        //        var expected = fakeContext.GetFakeData<Models.Acceleration>().Find(x => x.Id == accelerationId && );

        //        var service = new ChallengeService(context);                
        //        var actual = service.FindByAccelerationIdAndUserId(accelerationId, userId);

        //        Assert.Equal(expected, actual, new ChallengeIdComparer());
        //    }
        //}
  
        [Fact]
        public void Should_Add_New_User_When_Save()
        {
            var fakeContext = new FakeContext("SaveNewUser");
            
            var fakeUser = new User();
            fakeUser.FullName = "full name";
            fakeUser.Email = "email";
            fakeUser.Nickname = "nickname";
            fakeUser.Password = "pass";
            fakeUser.CreatedAt = DateTime.Today;

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var service = new UserService(context);
                var actual = service.Save(fakeUser);

                Assert.NotEqual(0, actual.Id);
            }
        }    

    }
}
