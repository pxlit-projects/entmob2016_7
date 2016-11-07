﻿using FitSense.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitsense.Models;

namespace FitSenseTest.mocks
{
    public class MockExerciseRepository : IExerciseRepository
    {
        public List<Exercise> GetExercisesFromCategory(Category category)
        {
            return DummyData.exercises.Where(exercise => exercise.CategoryID == category.ID).ToList();
        }
    }
}