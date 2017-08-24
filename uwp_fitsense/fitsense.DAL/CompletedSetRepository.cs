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
        public async Task<List<CompletedSet>> GetCompletedSetsFromSetAsync(Set set, string baseUrl)
        {
            string apiCompletedSet = string.Format(baseUrl + "completedset/sets/{0}", set.SetID);
            var uri = new Uri(String.Format("{0}?format=json", apiCompletedSet));
            var client = new HttpClient();
            //disabled auth
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
            //       Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", "user", "123456"))));
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var root = JsonConvert.DeserializeObject<List<CompletedSet>>(result);
                return root;
            }
            return null;
            
            //return DummyData.completedSets.Where(completedSet => completedSet.SetID == set.ID).ToList();
            //return DummyData.completedSets.Where(completedSet => completedSet.SetID == set.SetID).ToList();
        }

       public async Task AddCompletedSet(CompletedSet completedSet, string baseUrl)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl + "completedset");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", "user", "123456"))));


                var myContent = JsonConvert.SerializeObject(completedSet);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var test = JsonConvert.SerializeObject(completedSet);
                StringContent postBody = new StringContent(test, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("", postBody);
                string resultContent = result.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
