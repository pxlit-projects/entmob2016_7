using fitsense.DAL.dependencies;
using fitsense.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitsense.DAL
{
    public class CompletedSetRepository : ICompletedSetRepository
    {
        public List<CompletedSet> GetCompletedSetsFromSet(Set set)
        {
            /*string apiCompletedSet = "http://localhost:8081/sensortagapi/completedset/set/";
            var uri = new Uri(String.Format("{0}?format=json", apiCompletedSet));
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
            return root;
            return DummyData.completedSets.Where(completedSet => completedSet.SetID == set.ID).ToList();*/
            return null;
        }
    }
}
