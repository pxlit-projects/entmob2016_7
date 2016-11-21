using fitsense.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitsense.DAL.dependencies
{
    public interface ICompletedSetRepository
    {
        Task<List<CompletedSet>> GetCompletedSetsFromSetAsync(Set set, string baseUrl);
    }
}
