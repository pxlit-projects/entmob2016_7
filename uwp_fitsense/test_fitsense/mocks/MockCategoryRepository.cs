using fitsense.DAL.dependencies;
using fitsense.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_fitsense.mocks
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
