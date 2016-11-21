using fitsense.DAL.dependencies;
using fitsense.models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace test.fitsense.dal.mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public async Task<List<Category>> GetCategoriesAsync(string baseUrl)
        {
            return await Task.Run(() => TestData.categories);
        }

        public async Task AddCategoryAsync(Category categorie, string baseUrl)
        {
            await Task.Run(() => TestData.categories.Add(categorie));
        }
    }
}
