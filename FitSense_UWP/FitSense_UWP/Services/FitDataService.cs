using FitSense.DAL;
using FitSense.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace FitSense_UWP.Services
{
    class FitDataService : IFitDataService
    {
        SensorRepository<Category> categoryRepository;
        SensorRepository<Exercise> exerciseRepository;

        public FitDataService()
        {
            categoryRepository = new SensorRepository<Category>();
            exerciseRepository = new SensorRepository<Exercise>();
        }

        public void DeleteCategory(Category category)
        {
            throw new NotImplementedException();
            //categoryRepository.DeleteRecord(category);
        }

        public void DeleteExercise(Exercise exercise)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllCategories()
        {
            return DummyData.categories;
            //return categoryRepository.GetAllRecords();
        }

        public List<Exercise> GetExercisesFromCategory(Category category)
        {
            if (category != null)
                return DummyData.exercises.Where(ex => ex.CategoryID == category.ID).ToList();
            else
                return new List<Exercise>();
        }

        public List<Exercise> GetAllExercises()
        {
            return DummyData.exercises;
            throw new NotImplementedException();
            //return exerciseRepository.GetAllRecords();
        }

        public Category GetCategoryDetail(int id)
        {
            throw new NotImplementedException();
            //return categoryRepository.GetRecordDetail(id);
        }

        public Exercise GetExerciseDetail(int id)
        {
            throw new NotImplementedException();
            //return exerciseRepository.GetRecordDetail(id);
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
            //categoryRepository.UpdateRecord(category);
        }

        public void UpdateExercuse(Exercise exercise)
        {
            throw new NotImplementedException();
            //exerciseRepository.UpdateRecord(exercise);
        }

        public List<Set> GetSetsFromExercise(Exercise exercise)
        {
            List<Set> sets = DummyData.sets.Where(s => s.ExerciseID == exercise.ID).ToList();
           foreach(Set s in sets)
            {
                s.CompletedSets = GetCompletedSetsFromSet(s);
            }
            return sets;
        }

        public Set ToggleSelectedSetVisibility(Set set)
        {
            if (set.ShowCompletedSets == Visibility.Collapsed)
                set.ShowCompletedSets = Visibility.Visible;
            else
                set.ShowCompletedSets = Visibility.Collapsed;
            return set;
        }

        public List<CompletedSet> GetCompletedSetsFromSet(Set set)
        {
            return DummyData.completedSets.Where(s => s.SetID == set.ID).ToList();
        }
    }
}
