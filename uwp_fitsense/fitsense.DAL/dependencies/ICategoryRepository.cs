﻿using fitsense.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitsense.DAL.dependencies
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoriesAsync();
        Task AddCategoryAsync(Category categorie);
        //Task<List<Category>> GetCategoriesAsync(string baseUrl);
        //Task AddCategoryAsync(Category categorie, string baseUrl);
    }
}
