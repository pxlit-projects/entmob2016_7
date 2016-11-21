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
        public async Task<List<Exercise>> GetExercisesFromCategoryAsync(Category category)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                       Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", "user", "123456"))));
            Uri uri = null;

            if (category != null)
            {
                string apiExercise = string.Format("http://localhost:8081/sensortagapi/exercise/bycategory/{0}", category.CategoryID);
                uri = new Uri(String.Format("{0}?format=json", apiExercise));
            } 
            else
            {
                string apiExercise = "http://localhost:8081/sensortagapi/exercise/all";
                uri = new Uri(String.Format("{0}?format=json", apiExercise));
            }
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var root = JsonConvert.DeserializeObject<List<Exercise>>(result);
                return root;
            }
            return null;
        }
    }
}
