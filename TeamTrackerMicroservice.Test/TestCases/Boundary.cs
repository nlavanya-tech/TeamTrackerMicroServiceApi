using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TeamsMicroservice.BusinessLayer.Interface;
using TeamsMicroservice.BusinessLayer.Services;
using TeamsMicroservice.BusinessLayer.Services.Repository;
using TeamsMicroservice.Entities;
using UsersMicroservice.BusinessLayer.Interface;
using UsersMicroservice.BusinessLayer.Services;
using UsersMicroservice.BusinessLayer.Services.Repository;
using UsersMicroservice.Entities;
using Xunit;

namespace TeamTrackerMicroservice.Test.TestCases
{
    public class Boundary
    {
        private ITeamService _Teamservices;
        public readonly Mock<ITeamRepository> Teamservice = new Mock<ITeamRepository>();
        private IUserService _Userservices;
        public readonly Mock<IUserRepository> Userservice = new Mock<IUserRepository>();
        static Boundary()
        {
            if (!File.Exists("../../../../output_boundary_revised.txt"))
                try
                {
                    File.Create("../../../../output_boundary_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_boundary_revised.txt");
                File.Create("../../../../output_boundary_revised.txt").Dispose();
            }
        }
        public Boundary()
        {
            _Teamservices = new TeamService(Teamservice.Object);
            _Userservices = new UserService(Userservice.Object);

        }
        // Boundary test  for validateEmptyString Teamname
        [Fact]
        public async Task<bool> Test_validateEmptyStringForTeamName()
        {
            bool finalvalue = false;
            //Assigning values
            var team = new Teams()
            {
                TeamName = "redbus",
                TeamMembers = "kishore",
                DomainOfWork = "traveller",
                TeamManager = "Ravi",
            };

            //setup
            Teamservice.Setup(repo => repo.TeamCreateAsync(team)).ReturnsAsync(team);
            var result = await _Teamservices.TeamCreateAsync(team);
            if (result.TeamName != "")
            {
                finalvalue = true;
            }
            else
                finalvalue = false;

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_boundary_revised.txt", "Test_validateEmptyStringForTeamName=" + finalvalue + "\n");

            return finalvalue;
        }
        // Boundary test  for validateEmptyString TeamMember
        [Fact]
        public async Task<bool> Test_validateEmptyStringForTeamMembers()
        {
            bool finalvalue = false;
            //Assigning values
            var team = new Teams()
            {
                TeamName = "redbus",
                TeamMembers = "kishore",
                DomainOfWork = "traveller",
                TeamManager = "Ravi",
            };

            //setup
            Teamservice.Setup(repo => repo.TeamCreateAsync(team)).ReturnsAsync(team);
            var result = await _Teamservices.TeamCreateAsync(team);
            if (result.TeamMembers != "")
            {
                finalvalue = true;
            }
            else
                finalvalue = false;

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_boundary_revised.txt", "Test_validateEmptyStringForTeamMembers=" + finalvalue + "\n");

            return finalvalue;
        }
        // Boundary test  for validateEmptyString TeamDomainofwork
        [Fact]
        public async Task<bool> Test_validateEmptyStringForDomainOfWork()
        {
            bool finalvalue = false;
            //Assigning values
            var team = new Teams()
            {
                TeamName = "redbus",
                TeamMembers = "kishore",
                DomainOfWork = "traveller",
                TeamManager = "Ravi",
            };

            //setup
            Teamservice.Setup(repo => repo.TeamCreateAsync(team)).ReturnsAsync(team);
            var result = await _Teamservices.TeamCreateAsync(team);
            if (result.DomainOfWork != "")
            {
                finalvalue = true;
            }
            else
                finalvalue = false;

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_boundary_revised.txt", "Test_validateEmptyStringForDomainOfWork=" + finalvalue + "\n");

            return finalvalue;
        }
        // Boundary test  for validateEmptyString TeamManager
        [Fact]
        public async Task<bool> Test_validateEmptyStringForTeamManager()
        {
            bool finalvalue = false;
            //Assigning values
            var team = new Teams()
            {
                TeamName = "redbus",
                TeamMembers = "kishore",
                DomainOfWork = "traveller",
                TeamManager = "Ravi",
            };

            //setup
            Teamservice.Setup(repo => repo.TeamCreateAsync(team)).ReturnsAsync(team);
            var result = await _Teamservices.TeamCreateAsync(team);
            if (result.TeamManager != "")
            {
                finalvalue = true;
            }
            else
                finalvalue = false;

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_boundary_revised.txt", "Test_validateEmptyStringForTeamManager=" + finalvalue + "\n");

            return finalvalue;
        }
        // Boundary test  for validateEmptyString userEmail
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
            File.AppendAllText("../../../../output_boundary_revised.txt", "Test_validateUserEmail=" + isEmail + "\n");
        }
        //// Boundary test  for validateEmptyString usertype
        [Fact]
        public async Task<bool> Test_ValidateEmptystringUsertype()
        {
            bool finalvalue = false;

            //asigning values
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

            //setup
            Userservice.Setup(repo => repo.UserCreateAsync(user)).ReturnsAsync(user);
            var result = await _Userservices.UserCreateAsync(user);
            if (result.UserType != "")
            {
                finalvalue = true;
            }
            else
                finalvalue = false;

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_boundary_revised.txt", "Test_ValidateEmptystringUsertype=" + finalvalue + "\n");
            return finalvalue;
        }
        //// Boundary test  for validateEmptyString reportingto   
        [Fact]
        public async Task<bool> Test_ValidateEmptystringReportingTo()
        {
            bool finalvalue = false;

            //asigning values
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

            //setup
            Userservice.Setup(repo => repo.UserCreateAsync(user)).ReturnsAsync(user);
            var result = await _Userservices.UserCreateAsync(user);
            if (result.ReportingTo != "")
            {
                finalvalue = true;
            }
            else
                finalvalue = false;

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_boundary_revised.txt", "Test_ValidateEmptystringReportingTo=" + finalvalue + "\n");
            return finalvalue;
        }
        // Boundary test  for validateEmptyString usermobile
        [Fact]
        public async Task<bool> Test_ValidateEmptystringMobile()
        {
            bool finalvalue = false;

            //asigning values
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

            //setup
            Userservice.Setup(repo => repo.UserCreateAsync(user)).ReturnsAsync(user);
            var result = await _Userservices.UserCreateAsync(user);
            if (result.Mobile != "")
            {
                finalvalue = true;
            }
            else
                finalvalue = false;

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_boundary_revised.txt", "Test_ValidateEmptystringMobile=" + finalvalue + "\n");
            return finalvalue;
        }
    
}
}
