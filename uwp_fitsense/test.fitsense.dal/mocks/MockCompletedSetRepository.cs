using fitsense.DAL.dependencies;
using fitsense.models;
using System.Collections.Generic;
using System.Linq;

namespace test.fitsense.dal.mocks
{
    public class MockCompletedSetRepository : ICompletedSetRepository
    {
        public List<CompletedSet> GetCompletedSetsFromSet(Set set)
        {
            // dummy data want je moet data combineren van meerdere sets
            return TestData.completedSets.Where(completedSet => completedSet.SetID == set.SetID).ToList();
        }
    }
}
