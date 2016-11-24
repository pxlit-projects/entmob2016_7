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
    public class SetMockRepository : ISetRepository
    {

        public async Task<List<Set>> GetSetsFromExerciseAsync(Exercise exercise, string baseUrl)
        {
            return await Task.Run(() => DummyData.sets.Where(s => s.ExerciseID == exercise.ExerciseID).ToList());
        }
    }
}
