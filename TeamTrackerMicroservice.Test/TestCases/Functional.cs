using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
    public class Functional
    {
        private ITeamService _Teamservices;
        public readonly Mock<ITeamRepository> Teamservice = new Mock<ITeamRepository>();
        private IUserService _Userservices;
        public readonly Mock<IUserRepository> Userservice = new Mock<IUserRepository>();
        static Functional()
        {
            if (!File.Exists("../../../../output_revised.txt"))
                try
                {
                    File.Create("../../../../output_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_revised.txt");
                File.Create("../../../../output_revised.txt").Dispose();
            }
        }
        public Functional()
        {
            _Teamservices = new TeamService(Teamservice.Object);
            _Userservices = new UserService(Userservice.Object);

        }
        /// Test Read Functionality
        [Fact]
        public async void Test_GetAllTeams()
        {
            //assigning value
            bool finalresult = false;

            //setup
            Teamservice.Setup(repo => repo.TeamReadAsync());
            var result = await _Teamservices.TeamReadAsync();
            if (result != null) { finalresult = true; }

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_GetAllTeams=" + finalresult + "\n");

            Assert.NotNull(result);
        }
        //Test Create Team Functionality
        [Fact]
        public async void Test_CreateTeam()
        {
            //Assigning values 
            var team = new Teams()
            {
                TeamName = "redbus",
                TeamMembers = "kishore",
                DomainOfWork = "traveller",
                TeamManager = "Ravi",
            };
            bool final = false;

            //setup
            Teamservice.Setup(repo => repo.TeamCreateAsync(team)).ReturnsAsync(team);
            var result = await _Teamservices.TeamCreateAsync(team);
            if (team == result)
                final = true;


            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_CreateTeam=" + final + "\n");
        }

        //Test Uppdate Teams Functionality

        [Fact]
        public async void Test_UpdatedTeam()
        {
            //assigning values
            var team = new Teams()
            {
                TeamName = "redbus",
                TeamMembers = "kishore",
                DomainOfWork = "traveller",
                TeamManager = "Ravi",
            };
            bool finalresult = false;

            //setup
            Teamservice.Setup(repo => repo.TeamUpdateAsync(team)).ReturnsAsync(team);
            var result = await _Teamservices.TeamUpdateAsync(team);
            if (team == result) { finalresult = true; }


            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_UpdatedTeam=" + finalresult + "\n");
        }
        //Test Delete Teams functionality

        [Fact]
        public async void Test_DeleteTeams()
        {
            //asigning values
            var team = new Teams()
            {
                TeamName = "redbus",
                TeamMembers = "kishore",
                DomainOfWork = "traveller",
                TeamManager = "Ravi",
            };
            //setup
            Teamservice.Setup(repo => repo.TeamDeleteAsync(team.TeamName)).ReturnsAsync(true);
            bool result = await _Teamservices.TeamDeleteAsync(team.TeamName);

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_DeleteTeams=" + result + "\n");
            Assert.True(result);
        }

        //Test the Empty Teams Not null
        [Fact]
        public async void Test_ValidateEmptyTeam()
        {
            //assigning values
            var team = new Teams() { };
            bool finalresult = false;

            //setup
            Teamservice.Setup(repo => repo.TeamUpdateAsync(team)).ReturnsAsync(team);
            var result = await _Teamservices.TeamUpdateAsync(team);
            if (result != null)
                finalresult = true;

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_ValidateEmptyTeam=" + finalresult + "\n");
            Assert.NotNull(result);
        }

        ////To Test Read User Functionality
        ///
        [Fact]
        public async void Test_GetAllUsers()
        {
            //assigning value
            bool finalresult = false;

            //setup
            Userservice.Setup(repo => repo.UserReadAsync());
            var result = await _Userservices.UserReadAsync();
            if (result != null) { finalresult = true; }

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_GetAllUsers=" + finalresult + "\n");

            Assert.NotNull(result);
        }
        //Test Create user Functionality
        [Fact]
        public async void Test_CreateUser()
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
            bool final = false;

            //setup
            Userservice.Setup(repo => repo.UserCreateAsync(user)).ReturnsAsync(user);
            var result = await _Userservices.UserCreateAsync(user);
            if (user == result)
                final = true;


            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_CreateUser=" + final + "\n");
        }

        //Test Uppdate Teams Functionality

        [Fact]
        public async void Test_UpdatedUser()
        {
            //assigning values
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
            bool finalresult = false;

            //setup
            Userservice.Setup(repo => repo.UserUpdateAsync(user)).ReturnsAsync(user);
            var result = await _Userservices.UserUpdateAsync(user);
            if (user == result) { finalresult = true; }


            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_UpdatedTeam=" + finalresult + "\n");
        }
        //Test Delete Teams functionality

        [Fact]
        public async void Test_DeleteUser()
        {
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
            Userservice.Setup(repo => repo.UserDeleteAsync(user.Email)).ReturnsAsync(true);
            bool result = await _Userservices.UserDeleteAsync(user.Email);

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_DeleteUser=" + result + "\n");
            Assert.True(result);
        }

        //Test the Empty Teams Not null
        [Fact]
        public async void Test_ValidateEmptyUser()
        {
            //assigning values
            var user = new Users() { };
            bool finalresult = false;

            //setup
            Userservice.Setup(repo => repo.UserUpdateAsync(user)).ReturnsAsync(user);
            var result = await _Userservices.UserUpdateAsync(user);
            if (result != null)
                finalresult = true;

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_ValidateEmptyUser=" + finalresult + "\n");
            Assert.NotNull(result);
        }
    }
}
