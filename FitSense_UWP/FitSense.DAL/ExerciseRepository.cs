﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitsense.Models;

namespace FitSense.DAL
{
    public class ExerciseRepository : IExerciseRepository
    {
        public List<Exercise> GetExercisesFromCategory(Category category)
        {
            return DummyData.exercises.Where(exercise => exercise.CategoryID == category.ID).ToList();
        }
    }
}
