using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fitsense.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace FitSense.DAL
{
    public class CategoryRepository : ICategoryRepository
    {
        public void AddCategory(Category categorie)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081/sensortagapi/category");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "user", "123456"))));

                var myContent = JsonConvert.SerializeObject(categorie);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = client.PostAsync("", byteContent).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
            }
        }

        public List<Category> GetCategories()
        {
            /*string categories = "http://localhost:8081/sensortagapi/category/all";
            var uri = new Uri(String.Format("{0}?format=json", categories));
            var client = new HttpClient();
            var response = Task.Run(() =>
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "user", "123456"))));
                return client.GetAsync(uri);
            }).Result;

            response.EnsureSuccessStatusCode();

            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            var root = JsonConvert.DeserializeObject<List<Category>>(result);
            return root;*/
            return DummyData.categories;
        }
    }
}
