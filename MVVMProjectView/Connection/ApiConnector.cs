using MVVMProjectView.Models;
using MVVMProjectView.Resources;
using MVVMProjectView.ViewModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MVVMProjectView.Connection
{
    class ApiConnector
    {
        public List<Categorie> Get_categories()
        {
            var client = new RestClient("https://localhost:5001/api/category");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Postman-Token", "efcb9d6f-2cab-42ba-82de-6cd5aa0159b5");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("ApiKey", API.ApiKey.ToString());
            IRestResponse response = client.Execute(request);

            ResponseValidation(response.StatusCode);

            string responseContent = response.Content.Replace("\"", "'");

            List<Categorie> jsonResponse = JsonConvert.DeserializeObject<List<Categorie>>(responseContent);

            return jsonResponse;
        }

        public bool Login(string username, string password)
        {
            var client = new RestClient("https://localhost:5001/api/user/login");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Postman-Token", "efcb9d6f-2cab-42ba-82de-6cd5aa0159b5");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\n \"username\": \"" + username + "\",\n \"password\": \"" + password + "\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            string responseContent = response.Content.Replace("\"", "'");

            if (response.IsSuccessful)
            {
                var jsonResponse = JsonConvert.DeserializeObject<Validation>(responseContent);

                API.ApiKey = jsonResponse.access_token;
                API.UserData = jsonResponse.user;
                return true;
            }

            return false;
        }

        public bool NewUser(User user)
        {
            ExtendLoginTime();

            var client = new RestClient("https://localhost:5001/api/user");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Postman-Token", "efcb9d6f-2cab-42ba-82de-6cd5aa0159b5");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("ApiKey", API.ApiKey.ToString());
            request.AddParameter("undefined", "{\n \"username\": \"" + user.username + "\",\n \"password\": \"" + user.password + "\"\n}", ParameterType.RequestBody); ;
            IRestResponse response = client.Execute(request);

            ResponseValidation(response.StatusCode);
            if (response.IsSuccessful)
            {
                return true;
            }

            return false;
        }

        public void ExtendLoginTime()
        {

        }


        private void ResponseValidation(HttpStatusCode response){
            if (response == HttpStatusCode.Unauthorized) {
                API.mainWindow.DataContext = new LoginViewModel();
                API.resources.LoggedIn = false;
                API.resources.LoginMessage = "Session expired, Please log in again";
            }
        }



    }
}
