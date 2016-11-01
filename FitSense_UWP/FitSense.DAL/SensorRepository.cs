using Fitsense.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using FitSense.DAL;

namespace FitSense.DAL
{
    public class SensorRepository : ISensorRepository
    { 
        public void RemoveCategory(Category record)
        {
            DummyData.categories.Remove(record);
        }

        public Category GetCategoryDetail(int id)
        {
            return DummyData.categories.Where(r => r.ID == id).FirstOrDefault();
        }

        public void UpdateCategory(Category dist)
        {
            Category recordToUpdate = DummyData.categories.Where(r => r.ID == dist.ID).FirstOrDefault();
            recordToUpdate = dist;
        }

        public List<Category> GetAllCategories()
        {
            return DummyData.categories;
        }

        public List<Exercise> GetExercisesFromCategory(Category category)
        {

            if (category != null)
            {
                List<Exercise> exercises = DummyData.exercises.Where(ex => ex.CategoryID == category.ID).ToList();
                foreach (Exercise e in exercises)
                {
                    e.Sets = GetSetsFromExercise(e);
                }
                return exercises;
            }

            else
                return new List<Exercise>();
        }

        public List<Exercise> GetAllExercises()
        {
            return DummyData.exercises;
        }

        public List<Set> GetSetsFromExercise(Exercise exercise)
        {
            List<Set> sets = DummyData.sets.Where(s => s.ExerciseID == exercise.ID).ToList();
            foreach (Set s in sets)
            {
                s.CompletedSets = GetCompletedSetsFromSet(s);
            }
            return sets;
        }

        public List<CompletedSet> GetCompletedSetsFromSet(Set set)
        {
            return DummyData.completedSets.Where(s => s.SetID == set.ID).ToList();
        }
    }
}

