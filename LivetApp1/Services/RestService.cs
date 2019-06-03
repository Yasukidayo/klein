﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using LivetApp1.Models;
using Newtonsoft.Json;

namespace LivetApp1.Services
{
    class RestService : IRestService
    {
      
        private HttpClient Client;
        private string BaseUrl;

        public RestService()
        {
            this.Client = new HttpClient();
            this.BaseUrl = "https://localhost:5001";
        }

        #region rogon処理
        public async Task<User> LogonAsync(User user)
        {
            var jObject = JsonConvert.SerializeObject(user);
            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            User responseUser = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Logon", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUser = JsonConvert.DeserializeObject<User>(responseContent);
                }
            }
            catch (Exception e)
            {
                // TODO
                System.Diagnostics.Debug.WriteLine("Exception in RestService.LogonAsync: " + e);
            }
            return responseUser;
        }


        public async Task<User> LogonAsync2(User user)
        {
            var jObject = JsonConvert.SerializeObject(user);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            User responseUser = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Logon2", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUser = JsonConvert.DeserializeObject<User>(responseContent);
                }
            }
            catch (Exception e)
            {
                // TODO
                System.Diagnostics.Debug.WriteLine("Exception in RestService.LogonAsync2: " + e);
            }
            return responseUser;
        }
        #endregion

        #region User

        public async Task<List<User>> GetUsersAsync()
        {
            List<User> responseUsers = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/users");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUsers = JsonConvert.DeserializeObject<List<User>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetUsersAsync: " + e);
            }
            return responseUsers;
        }

        public async Task<User> PostUserAsync(User user)
        {
            var jObject = JsonConvert.SerializeObject(user);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            User responseUser = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Users", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUser = JsonConvert.DeserializeObject<User>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostUserAsync: " + e);
            }
            return responseUser;
        }

        public async Task<User> PutUserAsync(User user)
        {
            var jObject = JsonConvert.SerializeObject(user);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            User responseUser = null;
            try
            {
                var response = await Client.PutAsync(this.BaseUrl + "/api/Users/" + user.Id, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUser = JsonConvert.DeserializeObject<User>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PutUserAsync: " + e);
            }
            return responseUser;
        }

        public async Task<User> DeleteUserAsync(long Id)
        {
            User responseUser = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/Users/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUser = JsonConvert.DeserializeObject<User>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteUserAsync: " + e);
            }
            return responseUser;
        }
        #endregion

        #region ThanksCard
        public async Task<List<ThanksCard>> GetThanksCardsAsync()
        {
            List<ThanksCard> responseThanksCards = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/ThanksCard");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseThanksCards = JsonConvert.DeserializeObject<List<ThanksCard>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetThanksCardsAsync: " + e);
            }
            return responseThanksCards;
        }

        public async Task<ThanksCard> PostThanksCardAsync(ThanksCard thanksCard)
        {
            var jObject = JsonConvert.SerializeObject(thanksCard);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            ThanksCard responseThanksCard = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/ThanksCard", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseThanksCard = JsonConvert.DeserializeObject<ThanksCard>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostThanksCardAsync: " + e);
            }
            return responseThanksCard;
        }
        #endregion

        #region Department
        public async Task<List<Department>> GetDepartmentsAsync()
        {
            List<Department> responseDepartments = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/Departments");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseDepartments = JsonConvert.DeserializeObject<List<Department>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetDepartmentsAsync: " + e);
            }
            return responseDepartments;
        }

        public async Task<Department> PostDepartmentAsync(Department department)
        {
            var jObject = JsonConvert.SerializeObject(department);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Department responseDepartment = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Departments", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseDepartment = JsonConvert.DeserializeObject<Department>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostDepartmentAsync: " + e);
            }
            return responseDepartment;
        }

        public async Task<Department> PutDepartmentAsync(Department department)
        {
            var jObject = JsonConvert.SerializeObject(department);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Department responseDepartment = null;
            try
            {
                var response = await Client.PutAsync(this.BaseUrl + "/api/Departments/" + department.Id, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseDepartment = JsonConvert.DeserializeObject<Department>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PutDepartmentAsync: " + e);
            }
            return responseDepartment;
        }

        public async Task<Department> DeleteDepartmentAsync(long Id)
        {
            Department responseDepartment = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/Departments/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseDepartment = JsonConvert.DeserializeObject<Department>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteDepartmentAsync: " + e);
            }
            return responseDepartment;
        }
        #endregion

    }
}