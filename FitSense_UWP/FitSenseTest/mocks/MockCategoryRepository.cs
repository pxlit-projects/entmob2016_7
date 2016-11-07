using FitSense.DAL;
using Fitsense.Models;
using System;
using System.Collections.Generic;

namespace FitSenseTest.mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
        private List<Category> categories;

        public MockCategoryRepository()
        {
            this.loadCategories();
        }

        private void loadCategories()
        {
            categories = new List<Category>()
            {
                new Category()
                {
                    ID = 0,
                    Name = "Arms"
                },
                new Category()
                {
                    ID = 1,
                    Name = "Chest"
                }
            };
        }

        public List<Category> GetCategories()
        {
            return categories;
        }
    }
}
