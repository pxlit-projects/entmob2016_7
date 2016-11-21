using fitsense.DAL.dependencies;
using fitsense.models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.fitsense.dal.mocks
{
    public class MockSetRepository : ISetRepository
    {
        public async Task<List<Set>> GetSetsFromExerciseAsync(Exercise exercise, string baseUrl)
        {
            if (exercise != null)
                return await Task.Run(() => TestData.sets.Where(set => set.ExerciseID == exercise.ExerciseID).ToList());
            else
                return null;
        }
    }
}