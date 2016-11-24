using fitsense.DAL.dependencies;
using System;
using System.Collections.Generic;
using fitsense.models;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace fitsense.DAL
{
    public class CategoryMockRepository : ICategoryRepository
    {
        public async Task AddCategoryAsync(Category categorie, string baseUrl)
        {
            await Task.Run(() => DummyData.categories.Add(categorie));
        }

        public async Task<List<Category>> GetCategoriesAsync(string baseUrl)
        {
            return await Task.Run(() => DummyData.categories);
        }
    }
}
