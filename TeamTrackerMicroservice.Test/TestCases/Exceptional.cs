using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using TeamsMicroservice.BusinessLayer.Interface;
using TeamsMicroservice.BusinessLayer.Services;
using TeamsMicroservice.BusinessLayer.Services.Repository;
using UsersMicroservice.BusinessLayer.Interface;
using UsersMicroservice.BusinessLayer.Services;
using UsersMicroservice.BusinessLayer.Services.Repository;
using UsersMicroservice.Entities;
using Xunit;

namespace TeamTrackerMicroservice.Test.TestCases
{
   public class Exceptional
    {
        private ITeamService _Teamservices;
        public readonly Mock<ITeamRepository> Teamservice = new Mock<ITeamRepository>();
        private IUserService _Userservices;
        public readonly Mock<IUserRepository> Userservice = new Mock<IUserRepository>();
        static Exceptional()
        {
            if (!File.Exists("../../../../output_exception_revised.txt"))
                try
                {
                    File.Create("../../../../output_exception_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_exception_revised.txt");
                File.Create("../../../../output_exception_revised.txt").Dispose();
            }
        }
        public Exceptional()
        {
            _Teamservices = new TeamService(Teamservice.Object);
            _Userservices = new UserService(Userservice.Object);

        }
        [Fact]
        public void Test_validateUserEmail()
        {
            //Assigning values
            var user = new Users()
            {
                FirstName = "N",
                LastName = "kishore",
                Email = "traveller@gmail.com",
                UserType = "intern",
                Status = "N0",
                InterviewStatus = "pending",
                ReportingTo = "ddf",
                Mobile = "7836343234",
            };
            bool isEmail = false;
            isEmail = Regex.IsMatch(user.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            //Assert
            Assert.True(isEmail);

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_exception_revised.txt", "Test_validateUserEmail=" + isEmail + "\n");
        }
    
}
}
