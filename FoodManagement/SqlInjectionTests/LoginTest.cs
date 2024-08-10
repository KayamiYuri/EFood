using Core.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Controllers;
using Web.Areas.Admin.Models;
using Web.Models.EF;
using Xunit;

namespace SqlInjectionTests
{
    public class MemberControllerTests
    {
        [Fact]
        public async Task Login_ValidCredentials_RedirectsToHomeIndex()
        {
            // Arrange
            var dbContextMock = new Mock<FoodContext>();
            var member = new Member
            {
                LoginName = "testuser",
                Password = "password"
            };
            var members = new List<Member> { member };
            var memberDbSetMock = members.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(db => db.Members).Returns(memberDbSetMock.Object);

            var controller = new MemberController(dbContextMock.Object, null); // Pass null as the second argument

            var loginViewModel = new LoginViewModel
            {
                LoginName = "testuser",
                Password = "password"
            };

            // Act
            var result = await controller.Login(loginViewModel) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Home", result.ControllerName);
        }

        [Fact]
        public async Task Login_InvalidCredentials_RedirectsToLogin()
        {
            // Arrange
            var dbContextMock = new Mock<FoodContext>();
            var member = new Member
            {
                LoginName = "testuser",
                Password = "password"
            };
            var members = new List<Member> { member };
            var memberDbSetMock = members.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(db => db.Members).Returns(memberDbSetMock.Object);

            var controller = new MemberController(dbContextMock.Object, null); // Pass null as the second argument

            var loginViewModel = new LoginViewModel
            {
                LoginName = "testuser",
                Password = "wrongpassword"
            };

            // Act
            var result = await controller.Login(loginViewModel) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Login", result.ActionName);
            Assert.Equal("Member", result.ControllerName);
        }
    }
}