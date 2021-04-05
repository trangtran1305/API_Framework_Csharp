using Assignment06.API_Core;
using Assignment06.Model;
using Assignment06.reporter;
using Assignment06.Services;
using NUnit.Framework;
using System;

namespace Assignment06
{
    public class TestUserData
    {              
        UserDataService userDataService;
        User getUserData;
        APIReponse postUserData;
        string postUserId;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            common.InitReportDirection();
            HtmlReporter.CreateReport(common.REPORT_HTML_FILE);
            HtmlReporter.CreateTest(TestContext.CurrentContext.Test.ClassName);
        }

        [SetUp]
        public void beforeTest()
        {
            HtmlReporter.CreateNode(TestContext.CurrentContext.Test.ClassName, TestContext.CurrentContext.Test.MethodName);           
            userDataService = new UserDataService();
        }

        [TestCase("trangtran{0}", "trang", "tran", "changtrantt@gmail.com", "123456", "0389540405")]
        public void Test01_Create_User_Successfully(string username, string firstname, string lastname,string email,string password,string phone)
        {
            //Post
            username = String.Format(username, RandomNumber());
            postUserData = userDataService.PostUserData(username, firstname, lastname, email, password, phone);
            Assertion.Equals(postUserData.code, 200, "Can't create user", "Create user successfully");
            postUserId = postUserData.message;   
            
            //Get 
            getUserData = userDataService.GetUserData(username);
            Assertion.Equals(getUserData.id.ToString(),postUserId, "UserId isn't equal created userId", "UserId is equal created userId");
            Assertion.Equals(getUserData.username, username, "UserName isn't equal created userName", "UserName is equal created userName");
            Assertion.Equals(getUserData.firstName,firstname, "FirstName isn't equal created firstname", "FirstName is equal created firstname");
            Assertion.Equals(getUserData.lastName, lastname, "LastName isn't equal created lastname", "LastName is equal created lastname");
            Assertion.Equals(getUserData.email, email, "Email isn't equal created email", "Email is equal created email");
            Assertion.Equals(getUserData.password, password, "Password isn't equal created password", "Password is equal created password");
            Assertion.Equals(getUserData.phone, phone, "Phone isn't equal created phone", "Phone is equal created phone");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            HtmlReporter.flush();
        }
        public static int RandomNumber()
        {
            Random rand = new Random();
            return rand.Next(1, 10000);
        }

    }
}