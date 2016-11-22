using fitsense.DAL.dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitsense.models;

namespace test.fitsense.mocks.Repository
{
    class CompletedSetRepositoryMock : ICompletedSetRepository
    {
        public List<CompletedSet> CompletedSets;

        public async Task AddCompletedSet(CompletedSet completedSet, string baseUrl)
        {
            await Task.Run(() => CompletedSets.Add(completedSet));
        }

        public Task<List<CompletedSet>> GetCompletedSetsFromSetAsync(Set set, string baseUrl)
        {
            throw new NotImplementedException();
        }
    }
}
