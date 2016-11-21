using fitsense.DAL.dependencies;
using fitsense.models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.fitsense.dal.mocks
{
    public class MockCompletedSetRepository : ICompletedSetRepository
    {
        public async Task<List<CompletedSet>> GetCompletedSetsFromSetAsync(Set set)
        {
            // dummy data want je moet data combineren van meerdere sets
            return await Task.Run(() => TestData.completedSets.Where(completedSet => completedSet.SetID == set.SetID).ToList());
        }
    }
}
