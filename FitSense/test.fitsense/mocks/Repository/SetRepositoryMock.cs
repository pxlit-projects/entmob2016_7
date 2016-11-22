using fitsense.DAL.dependencies;
using fitsense.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.fitsense.mocks.Repository
{
    class SetRepositoryMock : ISetRepository
    {
        public List<Set> Sets { get; set; }

        public async Task<List<Set>> GetSetsFromExerciseAsync(Exercise exercise, string baseUrl)
        {
            if (exercise != null)
                return await Task.Run(() => Sets.Where(set => set.ExerciseID == exercise.ExerciseID).ToList());
            else
                return null;
        }
    }
}
