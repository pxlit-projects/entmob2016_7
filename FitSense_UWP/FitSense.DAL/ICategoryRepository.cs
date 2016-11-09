using Fitsense.Models;
using System.Collections.Generic;

namespace FitSense.DAL
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        void AddCategory(Category categorie);
    }
}
