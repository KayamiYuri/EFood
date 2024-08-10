using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Core.Database.Models; // Replace with your actual namespace
using Web.Areas.Admin.Controllers; // Update with your actual namespace
using Web.Areas.Admin.Models; // Update with your actual namespace
using Web.Models.EF;

public class MemberControllerTests
{
    private readonly MemberController _controller;
    private readonly FoodContext _dbContext;

    public MemberControllerTests()
    {
        var options = new DbContextOptionsBuilder<FoodContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        _dbContext = new FoodContext(options);

        // Seed the database with test data
        SeedDatabase();

        // Create a mock IWebHostEnvironment
        var mockEnvironment = new Mock<IWebHostEnvironment>();
        _controller = new MemberController(_dbContext, mockEnvironment.Object); // Initialize with both parameters
    }

    private void SeedDatabase()
    {
        _dbContext.Members.Add(new Member
        {
            LoginName = "admin",
            Password = MD5Hash("securepassword"), // Ensure this matches your hashing logic
            GroupId = Guid.NewGuid() // Assuming GroupId is a Guid
        });
        _dbContext.SaveChanges();
    }

    [Fact]
    public void TestSqlInjection()
    {
        var loginViewModel = new LoginViewModel
        {
            LoginName = "admin' --", // SQL injection attempt
            Password = "anything"
        };

        var result = _controller.Login(loginViewModel) as RedirectToActionResult;

        // Check if the login was bypassed or if an error occurred
        Assert.NotEqual("Index", result?.ActionName); // Adjust based on your expected failure outcome
    }

    private string MD5Hash(string input)
    {
        using (var md5 = System.Security.Cryptography.MD5.Create())
        {
            var inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);
            return System.BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}
