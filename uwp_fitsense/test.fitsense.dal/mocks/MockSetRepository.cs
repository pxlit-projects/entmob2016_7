using fitsense.DAL.dependencies;
using fitsense.models;
using System.Collections.Generic;
using System.Linq;

namespace test.fitsense.dal.mocks
{
    public class MockSetRepository : ISetRepository
    {
        public List<Set> GetSetsFromExercise(Exercise exercise)
        {
            return TestData.sets.Where(set => set.ExerciseID == exercise.ExerciseID).ToList();
        }
    }
}