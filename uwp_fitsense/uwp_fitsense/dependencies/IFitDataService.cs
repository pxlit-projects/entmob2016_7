﻿using fitsense.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uwp_fitsense.dependencies
{
    public interface IFitDataService
    {
        List<Category> GetAllCategories();
        void AddCategory(Category category);
        List<Exercise> GetExercisesFromCategory(Category category);
        List<Set> GetSetsFromExercise(Exercise exercise);
        Set ToggleSelectedSetVisibility(Set set);
        List<CompletedSet> GetCompletedSetsFromSet(Set set);
    }
}
