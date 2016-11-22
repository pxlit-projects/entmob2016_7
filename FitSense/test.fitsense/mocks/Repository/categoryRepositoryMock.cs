using fitsense.DAL.dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitsense.models;

namespace test.fitsense.mocks.Repository
{
    class CategoryRepositoryMock : ICategoryRepository
    {
        public List<Category> Categories { get; set; }

        public async Task<List<Category>> GetCategoriesAsync(string baseUrl)
        {
            return await Task.Run(() => Categories);
        }

        public async Task AddCategoryAsync(Category categorie, string baseUrl)
        {
            await Task.Run(() => Categories.Add(categorie));
        }
    }
}
