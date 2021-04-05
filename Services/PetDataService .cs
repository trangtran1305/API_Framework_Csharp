using Assigment06.API_Core;
using Assignment06.API_Core;
using Assignment06.Model;
using Assignment06.Test_Setup;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Assignment06.Services
{
    class PetDataService
    {
        UserLogin userLogin;
        string session;
        public string getPetDataPath = "/pet";
        public string postPetDataPath = "/pet";

        public PetDataService(UserLogin userLogin)
        {
            this.userLogin = userLogin;
        }
        //POST
        public Response PostPetRequest(string jsonString)
        {
            session = userLogin.message.Split(':')[1];
            Response response = new Request().SetUrl(Constant.API_HOST_SEVICE + postPetDataPath)
                                             .SetPost()
                                             .AddHeader("Session", session)
                                             .AddHeader("Accept", "application/json")
                                             .SetJsonBody(jsonString)
                                             .ExecuteRequest();
            return response;
        }
        public Pet PostPetData(string jsonString)
        {
            var postPetData = JsonConvert.DeserializeObject<Pet>(PostPetRequest(jsonString).GetResponseBody());
            return postPetData;
        }
        public Response GetPetRequest(int petID)
        {
            Response response = new Request().SetUrl(Constant.API_HOST_SEVICE + getPetDataPath + '/' + petID)
                                             .SetGet()
                                             .AddHeader("Session", session)
                                             .AddHeader("Accept", "application/json")
                                             .ExecuteRequest();
            return response;
        }
        public Pet GetPetData(int petID)
        {
            var PetData = JsonConvert.DeserializeObject<Pet>(GetPetRequest(petID).GetResponseBody());
            return PetData;
        }

    }
}