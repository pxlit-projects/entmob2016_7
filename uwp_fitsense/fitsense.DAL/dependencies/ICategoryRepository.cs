using fitsense.models;
using System.Collections.Generic;

namespace fitsense.DAL.dependencies
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        void AddCategory(Category categorie);
    }
}
