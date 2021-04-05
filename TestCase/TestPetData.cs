using Assignment06.API_Core;
using Assignment06.Model;
using Assignment06.reporter;
using Assignment06.Services;
using NUnit.Framework;
using System;

namespace Assignment06
{
    public class TestPetData
    {              
        UserLoginService userLoginService;
        UserLogin userLogin;
        PetDataService petDataService;
        Pet postPetData;
        Pet getPetData;
       
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
            userLoginService = new UserLoginService();
            userLogin = userLoginService.LoginUser("trangtran", "1305");
            petDataService = new PetDataService(userLogin);
        }
        [Test]
        public void Test01_Create_Pet_Successfully()
        {

            string jsonString = @"{
                                ""id"": 10,
                                ""category"": {
                                             ""name"": ""animal""
                                              },
                                ""name"":    ""cat"",
                                ""photoUrls"": [
                                             ""picture.png""
                                              ],
                                ""tags"": [
                                           {
                                            ""name"": ""fun""
                                           }
                                          ],
                                ""status"": ""available""
                                }";

            postPetData = petDataService.PostPetData(jsonString);
            Assertion.Equals(petDataService.PostPetRequest(jsonString).GetStatusCode(), 200, "Can't create Pet", "Create Pet successfully");
            Assertion.Equals(postPetData.id, 10 , "responsed petId is fail", "responsed petId is true");
            Assertion.Equals(postPetData.category.name,"animal", "responsed category's name is fail", "responsed category's name is true");
            Assertion.Equals(postPetData.name, "cat", "responsed name is fail", "responsed name is true");
            Assertion.Equals(postPetData.photoUrls[0], "picture.png", "responsed photoUrl is fail", "responsed photoUrl is true");
            Assertion.Equals(postPetData.tags[0].name, "fun", "responsed tag's name is fail", "responsed tag's name is true");
            Assertion.Equals(postPetData.status, "available", "responsed status is fail", "responsed status is true");

        }
        [Test]
        public void Test02_Get_User_By_Username_Successfully()
        {
            getPetData = petDataService.GetPetData(10);        
            Assertion.Equals(getPetData.category.name, "animal", "Category's name isn't equal posted PedId", "Category's name is equal posted PedId ");
            Assertion.Equals(getPetData.name, "cat", "name isn't equal posted name ", "Name isn't equal posted name ");
            Assertion.Equals(getPetData.photoUrls[0], "picture.png", "PhotoUrl isn't equal posted photoUrl ", "PhotoUrl is equal posted PhotoUrl ");
            Assertion.Equals(getPetData.tags[0].name, "fun", "Tag's name isn't equal posted Tag's name ", "Tag's name is equal posted Tag's name");
            Assertion.Equals(getPetData.status, "available", "Status isn't equal posted status", "Status is equal posted PedId ");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            HtmlReporter.flush();
        }

    }
}