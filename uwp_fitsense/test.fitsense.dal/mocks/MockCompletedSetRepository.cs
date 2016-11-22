using fitsense.DAL.dependencies;
using fitsense.models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace test.fitsense.dal.mocks
{
    public class MockCompletedSetRepository : ICompletedSetRepository
    {
        public Task AddCompletedSet(CompletedSet completedSet, string baseUrl)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CompletedSet>> GetCompletedSetsFromSetAsync(Set set, string baseUrl)
        {
            // dummy data want je moet data combineren van meerdere sets
            return await Task.Run(() => TestData.completedSets.Where(completedSet => completedSet.SetID == set.SetID).ToList());
        }
    }
}
