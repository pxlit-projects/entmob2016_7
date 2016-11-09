using fitsense.DAL.dependencies;
using fitsense.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_fitsense.mocks
{
    public class MockSetRepository : ISetRepository
    {
        public List<Set> GetSetsFromExercise(Exercise exercise)
        {
            return TestData.sets.Where(set => set.ExerciseID == exercise.ExerciseID).ToList();
        }
    }
}