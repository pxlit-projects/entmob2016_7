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
    public class SetRepository : ISetRepository
    {

        public List<Set> GetSetsFromExercise(Exercise exercise)
        {
            string apiCompletedSet = string.Format("http://localhost:8081/sensortagapi/set/setbyexercise/{0}", exercise.ExerciseID);
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
            var root = JsonConvert.DeserializeObject<List<Set>>(result);
            return root;
            //return DummyData.sets.Where(s => s.ExerciseID == exercise.ExerciseID).ToList();
        }
    }
}
