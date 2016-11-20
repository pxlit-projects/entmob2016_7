using fitsense.DAL.dependencies;
using fitsense.models;
using System;
using System.Collections.Generic;

namespace test.fitsense.dal.mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public List<Category> GetCategories()
        {
            return TestData.categories;
        }

        public void AddCategory(Category categorie)
        {
            throw new NotImplementedException();
        }
    }
}
