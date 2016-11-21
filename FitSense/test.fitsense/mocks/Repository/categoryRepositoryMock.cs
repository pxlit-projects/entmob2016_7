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

        public Task AddCategoryAsync(Category categorie, string baseUrl)
        {
            return new Task(() => Categories.Add(categorie));
        }

        public Task<List<Category>> GetCategoriesAsync(string baseUrl)
        {
            return new Task<List<Category>>(() => Categories);
        }
    }
}
