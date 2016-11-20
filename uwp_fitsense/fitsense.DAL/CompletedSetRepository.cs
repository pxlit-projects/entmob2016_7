using fitsense.DAL.dependencies;
using fitsense.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace fitsense.DAL
{
    public class CompletedSetRepository : ICompletedSetRepository
    {
        public List<CompletedSet> GetCompletedSetsFromSet(Set set)
        {
            string apiCompletedSet = string.Format("http://localhost:8081/sensortagapi/completedset/sets/{0}", set.SetID);
            var uri = new Uri(String.Format("{0}?format=json", apiCompletedSet));
            var client = new HttpClient();
            var response = Task.Run(() =>
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", "user", "123456"))));
                return client.GetAsync(uri);
            }).Result;

            response.EnsureSuccessStatusCode();

            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            var root = JsonConvert.DeserializeObject<List<CompletedSet>>(result);
            return root;
            //return DummyData.completedSets.Where(completedSet => completedSet.SetID == set.ID).ToList();
            //return DummyData.completedSets.Where(completedSet => completedSet.SetID == set.SetID).ToList();
        }

       public void AddCompletedSet(CompletedSet completedSet)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081/sensortagapi/category");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", "user", "123456"))));


                var myContent = JsonConvert.SerializeObject(completedSet);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var test = JsonConvert.SerializeObject(completedSet);
                StringContent postBody = new StringContent(test, Encoding.UTF8, "application/json");
                var result = client.PostAsync("", postBody).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
