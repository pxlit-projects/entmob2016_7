using fitsense.DAL.Constants;
using fitsense.DAL.dependencies;
using fitsense.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uwp_fitsense.dependencies;

namespace uwp_fitsense.services
{
    public class FitDataService : IFitDataService
    {
        ICategoryRepository categoryRepository;
        IExerciseRepository exerciseRepository;
        ISetRepository setRepository;
        ICompletedSetRepository completedSetRepository;

        public FitDataService(ICategoryRepository categoryRepository,
            IExerciseRepository exerciseRepository,
            ISetRepository setRepository,
            ICompletedSetRepository completedSetRepository)
        {
            this.categoryRepository = categoryRepository;
            this.exerciseRepository = exerciseRepository;
            this.setRepository = setRepository;
            this.completedSetRepository = completedSetRepository;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await categoryRepository.GetCategoriesAsync(ApiUrl.BASEURL);
        }

        public async Task<List<Exercise>> GetExercisesFromCategoryAsync(Category category)
        {
            List<Exercise> exercises = await exerciseRepository.GetExercisesFromCategoryAsync(category, ApiUrl.BASEURL);
            if (exercises == null)
            {
                return null;
            }
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

        public async Task<List<CompletedSet>> GetCompletedSetsFromSetAsync(Set set)
        {
            return await completedSetRepository.GetCompletedSetsFromSetAsync(set, ApiUrl.BASEURL);
        }

        public async Task AddCategoryAsync(Category category)
        {
            await categoryRepository.AddCategoryAsync(category, ApiUrl.BASEURL);
        }
    }
}
