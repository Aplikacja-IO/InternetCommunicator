using InternetCommunicator.Domain.Models;
using InternetMessengerApp.Models.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace InternetMessengerApp.Models.Services
{
    public class ServerAPIServices
    {
        string baseUrl = "https://localhost:44369/"; //tymczasowe, tutaj idzie adres serwera

        public async Task<string> GetUserJWTToken(UserInfo userInfo)
        {
            string jsonUserString = JsonSerializer.Serialize(userInfo);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonUserString);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json'"));
            HttpResponseMessage responseMessage = await client.PostAsync("/api/Token", byteContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                var token = responseMessage.Content.ReadAsStringAsync().Result;
                return token;
            }
            return "Nieprawidlowe poswiadczenia";
        }
        public async Task<List<Group>> GetAllUserGroupsAsync(int userId, string token)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await client.GetAsync($"/api/Group/AllUserGroups/{userId}");

            var jsonObjectGroups = responseMessage.Content.ReadAsStringAsync().Result;

            var groups = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Group>>(jsonObjectGroups);
            return groups;
        }
    }
}
