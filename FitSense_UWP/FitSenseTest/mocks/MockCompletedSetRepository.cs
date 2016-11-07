using FitSense.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitsense.Models;

namespace FitSenseTest.mocks
{
    public class MockCompletedSetRepository : ICompletedSetRepository
    {
        public List<CompletedSet> GetCompletedSetsFromSet(Set set)
        {
            return DummyData.completedSets.Where(completedSet => completedSet.SetID == set.ID).ToList();
        }
    }
}
