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
    public class ExerciseRepository : IExerciseRepository
    {
        public List<Exercise> GetExercisesFromCategory(Category category)
        {
            if (category != null)
            {
                string apiExercise = string.Format("http://localhost:8081/sensortagapi/exercise/bycategory/{0}", category.CategoryID);
                var uri = new Uri(String.Format("{0}?format=json", apiExercise));
                var client = new HttpClient();
                var response = Task.Run(() =>
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", "user", "123456"))));
                    return client.GetAsync(uri);
                }).Result;

                response.EnsureSuccessStatusCode();

                var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
                var root = JsonConvert.DeserializeObject<List<Exercise>>(result);
                return root;
            } 
            else
            {
                string apiExercise = "http://localhost:8081/sensortagapi/exercise/all";
                var uri = new Uri(String.Format("{0}?format=json", apiExercise));
                var client = new HttpClient();
                var response = Task.Run(() =>
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", "user", "123456"))));
                    return client.GetAsync(uri);
                }).Result;

                response.EnsureSuccessStatusCode();

                var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
                var root = JsonConvert.DeserializeObject<List<Exercise>>(result);
                return root;
            }
        }
    }
}
