﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace Common
{
    class ServerAPI
    {
        private static string token = "";
        private static bool isAuthorized = false;
        private static BasicGeoposition coordinate = new BasicGeoposition();//59.875585, 29.825813);
        
        private static string LoginUrl = "Token";
        private static string RegisterUrl = "api/Account/Register";
        private static string GetEventsUrl = "api/Events";
        private static string AddEventUrl = "api/Events";
        private static string AddCommentUrl = "api/eventComments";
        private static string SubscribeUrl = "api/Friends/Follow";
        private static string SiteUrl = "icreate.azurewebsites.net/api";

        public static bool IsAuthorised()
        {
            return isAuthorized;
        }

        public static async Task<bool> Login(string login, string password)
        {
            var client = new HttpClient();
            var data = "grant_type=password&username=" + login + "&password=" + password;
            var content = new StringContent(data.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded");
            try
            {
                var result = await client.PostAsync(SiteUrl + LoginUrl, content);
                var message = result.ReasonPhrase;
                var responseString = await result.Content.ReadAsStringAsync();
                var user = JObject.Parse(responseString);
                token = user["access_token"].Value<string>();
                isAuthorized = true;
            }
            catch (WebException we)
            {
                token = we.Message;
                isAuthorized = false;
                return false;
            }
            return true;
        }

        public static async Task<bool> Register(string login, string password, string confirm)
        {
            var client = new HttpClient();
            var data = JsonConvert.SerializeObject(new
            {
                UserName = login,
                Password = password,
                ConfirmPassword = confirm
            });
            var content = new StringContent(data.ToString(), Encoding.UTF8, "application/json");
            try
            {
                var result = await client.PostAsync(SiteUrl + RegisterUrl, content);
                var responseString = await result.Content.ReadAsStringAsync();
                await Login(login, password);
            }
            catch (WebException we)
            {
                token = we.Message;
                isAuthorized = false;
            }
            return true;
        }

        public static async void AddEvent(string description, DateTime datetime)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            try
            {
                var data = JsonConvert.SerializeObject(new
                {
                    Latitude = coordinate.Latitude.ToString().Replace(",", "."),
                    Longitude = coordinate.Longitude.ToString().Replace(",", "."),
                    Description = description,
                    EventDate = datetime.ToString()
                });

                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var ss = data.ToString();
                var result = await client.PostAsync(SiteUrl + AddEventUrl, content);
                var message = result.ReasonPhrase;
                var s = await content.ReadAsStringAsync();
            }
            catch (Exception exc)
            {
                var message = exc.ToString();
            }

        }

        public static async Task<string> GetEvents()
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync(SiteUrl + GetEventsUrl);
            return result;
        }
    }
}