﻿using fitsense.DAL.dependencies;
using fitsense.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.fitsense.mocks.Repository
{
    class SetRepositoryMock : ISetRepository
    {
        public List<Set> Sets { get; set; }

        public Task<List<Set>> GetSetsFromExerciseAsync(Exercise exercise, string baseUrl)
        {
            return new Task<List<Set>>(() =>
            Sets.FindAll((s) =>
            s.ExerciseID == exercise.ExerciseID));
        }
    }
}
