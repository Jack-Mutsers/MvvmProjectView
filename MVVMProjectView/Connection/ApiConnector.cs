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
        public List<Category> Get_categories()
        {
            var client = new RestClient("https://localhost:5001/api/category");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Postman-Token", "efcb9d6f-2cab-42ba-82de-6cd5aa0159b5");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("ApiKey", StaticResources.ApiKey.ToString());
            IRestResponse response = client.Execute(request);

            ResponseValidation(response.StatusCode);

            string responseContent = response.Content.Replace("\"", "'");

            List<Category> jsonResponse = JsonConvert.DeserializeObject<List<Category>>(responseContent);

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

                StaticResources.ApiKey = jsonResponse.access_token;
                StaticResources.UserData = jsonResponse.user;
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
            request.AddHeader("ApiKey", StaticResources.ApiKey.ToString());
            request.AddParameter("undefined", "{\n \"username\": \"" + user.username + "\",\n \"password\": \"" + user.password + "\"\n}", ParameterType.RequestBody); ;
            IRestResponse response = client.Execute(request);

            ResponseValidation(response.StatusCode);
            if (response.IsSuccessful)
            {
                return true;
            }

            return false;
        }

        public bool NewCategory()
        {
            ExtendLoginTime();

            var client = new RestClient("https://localhost:5001/api/category");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Postman-Token", "f1e620dc-11b2-4f4b-937d-308a20c058d1");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("ApiKey", StaticResources.ApiKey.ToString());
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\n    \"name\": \"" + StaticResources.resources.CategoryName + "\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            
            ResponseValidation(response.StatusCode);
            if (response.IsSuccessful)
            {
                return true;
            }

            return false;
        }

        public bool NewComponent(int id)
        {
            ExtendLoginTime();

            var client = new RestClient("https://localhost:5001/api/component");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Content-Length", "75");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Host", "localhost:5001");
            request.AddHeader("Postman-Token", "f8825be5-6d50-440b-8a36-5d74bd8f4ad5,6aa963df-5b2b-4e34-8df5-53dcc4698ff2");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.20.1");
            request.AddHeader("ApiKey", StaticResources.ApiKey.ToString());
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\r\n \"name\": \"" + StaticResources.resources.ComponentName + "\",\r\n \"categoryid\": " + id + ",\r\n \"alarm_status\": false\r\n}", ParameterType.RequestBody);
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

        public bool UpdateUser(User user)
        {

            ExtendLoginTime();

            var client = new RestClient("https://localhost:5001/api/user");
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Postman-Token", "efcb9d6f-2cab-42ba-82de-6cd5aa0159b5");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("ApiKey", StaticResources.ApiKey.ToString());
            request.AddParameter("undefined", "{\n \"id\": \"" + user.id + "\",\n \"password\": \"" + user.password + "\"\n}", ParameterType.RequestBody); ;
            IRestResponse response = client.Execute(request);

            ResponseValidation(response.StatusCode);
            if (response.IsSuccessful)
            {
                return true;
            }

            return false;
        }

        public bool DeleteUser()
        {
            ExtendLoginTime();
            User user = StaticResources.UserData;

            var client = new RestClient("https://localhost:5001/api/user/" + user.id);
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Postman-Token", "efcb9d6f-2cab-42ba-82de-6cd5aa0159b5");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("ApiKey", StaticResources.ApiKey.ToString());
            IRestResponse response = client.Execute(request);

            ResponseValidation(response.StatusCode);
            if (response.IsSuccessful)
            {
                return true;
            }

            return false;

        }

        public bool Logout()
        {
            var client = new RestClient("https://localhost:5001/api/user/logout");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Postman-Token", "81bd9ed6-1cfc-41a0-804d-9104290a019f");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("ApiKey", StaticResources.ApiKey.ToString());
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "\"" + StaticResources.ApiKey.ToString() + "\"", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            ResponseValidation(response.StatusCode);
            if (response.IsSuccessful)
            {
                return true;
            }

            return false;

        }

        private void ResponseValidation(HttpStatusCode response){
            if (response == HttpStatusCode.Unauthorized) {
                StaticResources.resources.ResetValues();
                StaticResources.resources.LoggedIn = false;
                StaticResources.resources.LoginMessage = "Session expired, Please log in again";
                StaticResources.mainWindow.DataContext = new LoginViewModel();
            }
        }



    }
}
