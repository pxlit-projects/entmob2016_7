﻿using fitsense.DAL.dependencies;
using System;
using System.Collections.Generic;
using fitsense.models;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace fitsense.DAL
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task AddCategoryAsync(Category categorie)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081/sensortagapi/category");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", "user", "123456"))));


                var myContent = JsonConvert.SerializeObject(categorie);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var categorieJson = JsonConvert.SerializeObject(categorie);
                StringContent postBody = new StringContent(categorieJson, Encoding.UTF8, "application/json");
                var result = client.PostAsync("", postBody).Result;
                string resultContent = await result.Content.ReadAsStringAsync();
            }
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            string categories = "http://localhost:8081/sensortagapi/category/all";
            var uri = new Uri(String.Format("{0}?format=json", categories));
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                  Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", "user", "123456"))));
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
                var root = JsonConvert.DeserializeObject<List<Category>>(result);
                return root;
            }

            return null;
            //return DummyData.categories;
        }
    }
}
