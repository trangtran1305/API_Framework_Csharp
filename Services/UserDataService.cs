using Assigment06.API_Core;
using Assignment06.API_Core;
using Assignment06.Model;
using Assignment06.Test_Setup;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Assignment06.Services
{
    class UserDataService
    {
        string session;
        public string getUserDataPath = "/user";
        public string postUserDataPath = "/user";

        public UserDataService()
        {
        }
        //POST
        public Response PostUserRequest(string username, string firstname, string lastname, string email, string password, string phone)
        {
            JObject jObjectbody = new JObject();
            jObjectbody.Add("username", username);
            jObjectbody.Add("firstName", firstname);
            jObjectbody.Add("lastName", lastname);
            jObjectbody.Add("email", email);
            jObjectbody.Add("password", password);
            jObjectbody.Add("phone", phone);
            
            Response response = new Request().SetUrl(Constant.API_HOST_SEVICE + postUserDataPath)
                                             .SetPost()                                             
                                             .AddHeader("Accept", "application/json")
                                             .SetJsonBody(jObjectbody)
                                             .ExecuteRequest();
            return response;
        }
        public APIReponse PostUserData(string username, string firstname, string lastname, string email, string password, string phone)
        {
            var postUserData = JsonConvert.DeserializeObject<APIReponse>(PostUserRequest(username, firstname, lastname, email, password, phone).GetResponseBody());
            return postUserData;
        }
        public Response GetUserRequest(string username)
        {
            Response response = new Request().SetUrl(Constant.API_HOST_SEVICE + getUserDataPath + '/' + username)
                                             .SetGet()
                                             .AddHeader("Session", session)
                                             .AddHeader("Accept", "application/json")
                                             .ExecuteRequest();
            return response;
        }
        public User GetUserData(string username)
        {
            var userData = JsonConvert.DeserializeObject<User>(GetUserRequest(username).GetResponseBody());
            return userData;
        }

    }
}