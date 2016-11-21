using fitsense.DAL.dependencies;
using fitsense.models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace test.fitsense.dal.mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await Task.Run(() => TestData.categories);
        }

        public async Task AddCategoryAsync(Category categorie)
        {
            throw new NotImplementedException();
        }
    }
}
