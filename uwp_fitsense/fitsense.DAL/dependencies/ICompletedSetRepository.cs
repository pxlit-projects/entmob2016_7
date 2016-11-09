using fitsense.models;
using System.Collections.Generic;

namespace fitsense.DAL.dependencies
{
    public interface ICompletedSetRepository
    {
        List<CompletedSet> GetCompletedSetsFromSet(Set set);
    }
}
