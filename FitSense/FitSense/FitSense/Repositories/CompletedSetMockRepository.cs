using fitsense.DAL.dependencies;
using fitsense.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace fitsense.DAL
{
    public class CompletedSetMockRepository : ICompletedSetRepository
    {
        public async Task<List<CompletedSet>> GetCompletedSetsFromSetAsync(Set set, string baseUrl)
        {
            return await Task.Run(() => DummyData.completedSets.Where(completedSet => completedSet.SetID == set.SetID).ToList());
        }

       public async Task AddCompletedSet(CompletedSet completedSet, string baseUrl)
        {
            await Task.Run(() => DummyData.completedSets.Add(completedSet));
        }
    }
}
