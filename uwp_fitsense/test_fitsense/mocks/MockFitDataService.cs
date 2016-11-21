using fitsense.DAL.Constants;
using fitsense.DAL.dependencies;
using fitsense.models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using test.fitsense.dal.mocks;
using uwp_fitsense.dependencies;

namespace test_fitsense.mocks
{
    public class MockFitDataService : IFitDataService
    {
        private ICategoryRepository categoryRepository = new MockCategoryRepository();
        private IExerciseRepository exerciseRepository = new MockExerciseRepository();
        private ISetRepository setRepository = new MockSetRepository();
        private ICompletedSetRepository completedSetRepository = new MockCompletedSetRepository();

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await categoryRepository.GetCategoriesAsync(ApiUrl.BASEURL);
        }

        public async Task<List<CompletedSet>> GetCompletedSetsFromSetAsync(Set set)
        {
            return await completedSetRepository.GetCompletedSetsFromSetAsync(set, ApiUrl.BASEURL);
        }

        public async Task<List<Exercise>> GetExercisesFromCategoryAsync(Category category)
        {
            if (category == null)
                return null;
            List<Exercise> exercises = await exerciseRepository.GetExercisesFromCategoryAsync(category, ApiUrl.BASEURL);
            foreach (Exercise e in exercises)
            {
                e.Sets = await GetSetsFromExerciseAsync(e);
            }
            return exercises;
        }

        public async Task<List<Set>> GetSetsFromExerciseAsync(Exercise exercise)
        {
            List<Set> sets = await setRepository.GetSetsFromExerciseAsync(exercise, ApiUrl.BASEURL);
            foreach (Set s in sets)
            {
                s.CompletedSets = await GetCompletedSetsFromSetAsync(s);
            }
            return sets;
        }

        public Set ToggleSelectedSetVisibility(Set set)
        {
            set.ShowCompletedSets = !set.ShowCompletedSets;
            return set;
        }

        public async Task AddCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}