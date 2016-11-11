package be.pxl.groep7.services;

import java.util.List;

import be.pxl.groep7.dao.ICategoryRepository;
import be.pxl.groep7.models.Category;


public interface ICategoryService {

	public Category createOrUpdateCategory(Category category);
	public Category findCategoryById(int id);
	public void deleteCategoryById(int id);
	public boolean doesCategoryExist(int id);
	public List<Category> getAllCategories();
	public void setCategoryRepository(ICategoryRepository rep);
}
