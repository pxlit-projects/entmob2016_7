using fitsense.models;
using System.Collections.Generic;

namespace fitsense.DAL.dependencies
{
    public interface ISetRepository
    {
        List<Set> GetSetsFromExercise(Exercise exercise);
    }
}
