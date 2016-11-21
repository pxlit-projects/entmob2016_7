using fitsense.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitsense.DAL.dependencies
{
    public interface ISetRepository
    {
        Task<List<Set>> GetSetsFromExerciseAsync(Exercise exercise);
    }
}
