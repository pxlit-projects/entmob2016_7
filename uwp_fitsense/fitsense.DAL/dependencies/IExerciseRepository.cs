using fitsense.models;
using System.Collections.Generic;

namespace fitsense.DAL.dependencies
{
    public interface IExerciseRepository
    {
        List<Exercise> GetExercisesFromCategory(Category category);
    }
}
