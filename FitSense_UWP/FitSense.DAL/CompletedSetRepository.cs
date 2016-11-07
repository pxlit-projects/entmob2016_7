using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitsense.Models;

namespace FitSense.DAL
{
    public class CompletedSetRepository : ICompletedSetRepository
    {
        public List<CompletedSet> GetCompletedSetsFromSet(Set set)
        {
            return DummyData.completedSets.Where(completedSet => completedSet.SetID == set.ID).ToList();
        }
    }
}
