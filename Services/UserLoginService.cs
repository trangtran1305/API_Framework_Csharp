using Assigment06.API_Core;
using Assignment06.API_Core;
using Assignment06.Model;
using Assignment06.Test_Setup;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment06.Services
{
    class UserLoginService
    {
        public string getUserLoginPath = "/user/login";

        public Response LoginRequest(string username, string password)
        {
            Response response = new Request().SetUrl(Constant.API_HOST_SEVICE + getUserLoginPath)
                                             .SetGet()
                                             .AddHeader("Accept", "Application/json")
                                             .AddParameter("username", username)
                                             .AddParameter("password", password)
                                             .ExecuteRequest();
            return response;
        }
        public UserLogin LoginUser(string username, string password)
        {
            UserLogin userLogin = JsonConvert.DeserializeObject<UserLogin>(LoginRequest(username, password).GetResponseBody());
            return userLogin;
        }

    }
}
