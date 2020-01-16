using MVVMProjectView.Models;
using MVVMProjectView.Resources;
using MVVMProjectView.ViewModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
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


            string responseContent = "";
            if (response.IsSuccessful)
            {
                responseContent = response.Content.Replace("\"", "'");
                List<PreCategory> jsonResponse = JsonConvert.DeserializeObject<List<PreCategory>>(responseContent);

                List<Category> CategoryList = new List<Category>();
                foreach (PreCategory row in jsonResponse)
                {
                    Category category = new Category();
                    category.id = row.id;
                    category.name = row.name;
                    category.Components = row.Components;

                    if (row.icon != "")
                    {
                        byte[] byteArray = StaticResources.StringToByteArray(row.icon);

                        category.icon = StaticResources.resources.byteToImage(byteArray);
                    }

                    CategoryList.Add(category);
                }

                return CategoryList;
            }

            var errorResponse = JsonConvert.DeserializeObject<Response>(response.Content);
            return null;
        }

        public bool Login(string username, string password)
        {
            var client = new RestClient("https://localhost:5001/api/user/login");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Postman-Token", "efcb9d6f-2cab-42ba-82de-6cd5aa0159b5");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");

            List<string> ParamArr = new List<string>();
            ParamArr.Add("\r\n \"username\": \"" + username + "\"");
            ParamArr.Add("\r\n \"password\": \"" + password + "\"");

            string param = "{" + String.Join(",", ParamArr) + "\r\n}";
            request.AddParameter("undefined", param, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            string responseContent = "";
            if (response.IsSuccessful)
            {
                responseContent = response.Content.Replace("\"", "'");
                var jsonResponse = JsonConvert.DeserializeObject<Validation>(responseContent);

                StaticResources.ApiKey = jsonResponse.access_token;
                StaticResources.UserData = jsonResponse.user;
                return true;
            }

            var errorResponse = JsonConvert.DeserializeObject<Response>(response.Content);
            return false;
        }

        public bool NewUser(User user)
        {
            ExtendLoginTime();

            string sPassword = user.password;

            //het aanmaken van een salt
            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            sPassword = sPassword + StaticResources.extention;

            // hash and save a password
            user.password = BCrypt.Net.BCrypt.HashPassword(sPassword, salt);


            var client = new RestClient("https://localhost:5001/api/user");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Postman-Token", "efcb9d6f-2cab-42ba-82de-6cd5aa0159b5");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("ApiKey", StaticResources.ApiKey.ToString());
            request.AddParameter("undefined", "{\n \"username\": \"" + user.username + "\",\n \"password\": \"" + user.password + "\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            ResponseValidation(response.StatusCode);
            if (response.IsSuccessful)
            {
                return true;
            }

            var errorResponse = JsonConvert.DeserializeObject<Response>(response.Content);
            return false;
        }

        public bool NewCategory(Category cat)
        {
            ExtendLoginTime();

            byte[] byteArray = StaticResources.resources.ByteImage;
            var StringImage = StaticResources.ByteArrayToString(byteArray);

            var client = new RestClient("https://localhost:5001/api/category");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Postman-Token", "f1e620dc-11b2-4f4b-937d-308a20c058d1");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("ApiKey", StaticResources.ApiKey.ToString());
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\n \"name\": \"" + cat.name + "\",\n \"icon\": \"" + StringImage + "\"\n}", ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            ResponseValidation(response.StatusCode);
            if (response.IsSuccessful)
            {
                return true;
            }

            var errorResponse = JsonConvert.DeserializeObject<Response>(response.Content);
            return false;
        }

        public bool NewComponent(Component comp)
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

            List<string> ParamArr = new List<string>();
            ParamArr.Add("\r\n \"name\": \"" + comp.name + "\"");
            ParamArr.Add("\r\n \"categoryid\": " + comp.categoryid);
            ParamArr.Add("\r\n \"alarm_status\": false");
            ParamArr.Add("\r\n \"ip_adress\": \"" + comp.ip_adress + "\"");

            string param = "{" + String.Join(",", ParamArr) + "\r\n}";
            request.AddParameter("undefined", param, ParameterType.RequestBody);


            //request.AddParameter("undefined", "{\r\n \"name\": \"" + StaticResources.resources.ComponentName + "\",\r\n \"categoryid\": " + id + ",\r\n \"alarm_status\": false\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            ResponseValidation(response.StatusCode);
            if (response.IsSuccessful)
            {
                return true;
            }

            var errorResponse = JsonConvert.DeserializeObject<Response>(response.Content);
            return false;
        }

        public void ExtendLoginTime()
        {
            var client = new RestClient("https://localhost:5001/api/user/extend");

            var request = new RestRequest(Method.PUT);
            request.AddHeader("Postman-Token", "efcb9d6f-2cab-42ba-82de-6cd5aa0159b5");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("ApiKey", StaticResources.ApiKey.ToString());

            List<string> ParamArr = new List<string>();
            ParamArr.Add("\r\n \"access_token\": \"" + StaticResources.ApiKey.ToString() + "\"");

            string param = "{" + String.Join(",", ParamArr) + "\r\n}";
            request.AddParameter("undefined", param, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

        }

        public bool UpdateCategory(Category cat)
        {
            ExtendLoginTime();

            byte[] byteArray = StaticResources.resources.ImageToByte(cat.icon);
            var StringImage = StaticResources.ByteArrayToString(byteArray);

            var client = new RestClient("https://localhost:5001/api/category");
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Postman-Token", "efcb9d6f-2cab-42ba-82de-6cd5aa0159b5");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("ApiKey", StaticResources.ApiKey.ToString());

            List<string> ParamArr = new List<string>();
            ParamArr.Add("\r\n \"id\": " + cat.id);
            ParamArr.Add("\r\n \"name\": \"" + cat.name + "\"");
            ParamArr.Add("\r\n \"icon\": \"" + StringImage + "\"");

            string param = "{" + String.Join(",", ParamArr) + "\r\n}";
            request.AddParameter("undefined", param, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            ResponseValidation(response.StatusCode);

            if (response.IsSuccessful)
            {
                return true;
            }

            var errorResponse = JsonConvert.DeserializeObject<Response>(response.Content);
            return false;
        }

        public bool UpdateComponent(Component comp)
        {
            ExtendLoginTime();

            var client = new RestClient("https://localhost:5001/api/component");
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Postman-Token", "efcb9d6f-2cab-42ba-82de-6cd5aa0159b5");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("ApiKey", StaticResources.ApiKey.ToString());

            List<string> ParamArr = new List<string>();
            ParamArr.Add("\r\n \"id\": " + comp.id);
            ParamArr.Add("\r\n \"name\": \"" + comp.name + "\"");
            ParamArr.Add("\r\n \"categoryid\": " + comp.categoryid);
            ParamArr.Add("\r\n \"value\": " + comp.value);
            ParamArr.Add("\r\n \"ip_adress\": \"" + comp.ip_adress + "\"");
            ParamArr.Add("\r\n \"arduino_id\": " + comp.arduino_id);
            ParamArr.Add("\r\n \"status\": " + comp.status.ToString().ToLower());

            string param = "{" + String.Join(",", ParamArr) + "\r\n}";
            request.AddParameter("undefined", param, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            ResponseValidation(response.StatusCode);

            if (response.IsSuccessful)
            {
                return true;
            }

            var errorResponse = JsonConvert.DeserializeObject<Response>(response.Content);
            return false;
        }

        public bool UpdateUser(User user)
        {

            ExtendLoginTime();

            string sPassword = user.password;

            //het aanmaken van een salt
            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            sPassword = sPassword + StaticResources.extention;

            // hash and save a password
            user.password = BCrypt.Net.BCrypt.HashPassword(sPassword, salt);

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

            var errorResponse = JsonConvert.DeserializeObject<Response>(response.Content);
            return false;
        }

        public bool DeleteComponent(Component comp)
        {
            ExtendLoginTime();

            var client = new RestClient("https://localhost:5001/api/component/" + comp.id);
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

            var errorResponse = JsonConvert.DeserializeObject<Response>(response.Content);
            return false;

        }

        public bool DeleteCategory(int id)
        {
            ExtendLoginTime();

            var client = new RestClient("https://localhost:5001/api/category/" + id);
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

            var errorResponse = JsonConvert.DeserializeObject<Response>(response.Content);
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

            var errorResponse = JsonConvert.DeserializeObject<Response>(response.Content);
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

            var errorResponse = JsonConvert.DeserializeObject<Response>(response.Content);
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

        public void SendArduinoCall(string id)
        {
            var client = new RestClient("https://localhost:5001/api/arduino");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Postman-Token", "f1e620dc-11b2-4f4b-937d-308a20c058d1");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("ApiKey", StaticResources.ApiKey.ToString());
            request.AddHeader("Content-Type", "application/json");

            List<string> ParamArr = new List<string>();
            ParamArr.Add("\r\n \"id\": " + id);

            string param = "{" + String.Join(",", ParamArr) + "\r\n}";
            request.AddParameter("undefined", param, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {

            }
            else
            {

                //var errorResponse = JsonConvert.DeserializeObject<Response>(response.Content);
            }

        }

    }
}
