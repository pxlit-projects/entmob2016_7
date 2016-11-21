using fitsense.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FitSense.Repositories
{
    public class CategoryRepository
    {

        public async Task<List<Category>> GetCategories()
        {
            string categories = Constants.ApiUrl.BASEURL +"category/all";
            var uri = new Uri(String.Format("{0}?format=json", categories));
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                   Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", "user", "123456"))));

            var response = await Task.Run(() =>
            {
                return client.GetAsync(uri);
            });

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
