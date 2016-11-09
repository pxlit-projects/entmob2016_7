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
    class FitDataService : IFitDataService
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

        public List<Category> GetAllCategories()
        {
            return categoryRepository.GetCategories();
        }

        public List<Exercise> GetExercisesFromCategory(Category category)
        {
            List<Exercise> exercises = exerciseRepository.GetExercisesFromCategory(category);
            foreach (Exercise e in exercises)
            {
                e.Sets = GetSetsFromExercise(e);
            }
            return exercises;
        }

        public List<Set> GetSetsFromExercise(Exercise exercise)
        {
            List<Set> sets = setRepository.GetSetsFromExercise(exercise);
            foreach (Set s in sets)
            {
                s.CompletedSets = GetCompletedSetsFromSet(s);
            }
            return sets;
        }

        public Set ToggleSelectedSetVisibility(Set set)
        {
            set.ShowCompletedSets = !set.ShowCompletedSets;
            return set;
        }

        public List<CompletedSet> GetCompletedSetsFromSet(Set set)
        {

            return completedSetRepository.GetCompletedSetsFromSet(set);
        }

        public void AddCategory(Category category)
        {
            categoryRepository.AddCategory(category);
        }
    }
}
