using System;
using System.Collections.Generic;
using fitsense.models;
using FitSense.Dependencies;

namespace FitSense.Repositories
{
    public class DummyRepository : IDummyRepository
    {
        public IEnumerable<Category> GetAllCategories()
        {
            return categories;
        }

        private static List<Category> categories = new List<Category>()
        {
            new Category()
            {
                CategoryID = 0,
                Name = "Legs"
            },
            new Category()
            {
                CategoryID = 0,
                Name = "Arms"
            },
            new Category()
            {
                CategoryID = 0,
                Name = "Core"
            },
        };
    }
}
