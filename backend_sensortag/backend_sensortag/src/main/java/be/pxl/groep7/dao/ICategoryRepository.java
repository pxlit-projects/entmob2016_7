package be.pxl.groep7.dao;

import be.pxl.groep7.models.Category;

public interface ICategoryRepository {

	public Category getCategoryById(int id);
	public void addCategory(Category category);
	public void updateCategory(Category category);
	public void deleteCategory(Category category);
}