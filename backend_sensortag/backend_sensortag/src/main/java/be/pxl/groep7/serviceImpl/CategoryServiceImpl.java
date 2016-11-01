package be.pxl.groep7.serviceImpl;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import be.pxl.groep7.dao.ICategoryRepository;
import be.pxl.groep7.models.Category;
import be.pxl.groep7.services.ICategoryService;

@Service
public class CategoryServiceImpl implements ICategoryService {

	@Autowired
	private ICategoryRepository rep;
	
	@Override
	public Category createOrUpdateCategory(Category category) {
		return rep.save(category);
	}

	@Override
	public Category findCategoryById(int id) {
		return rep.findOne(id);
	}

	@Override
	public void deleteCategoryById(int id) {
		rep.delete(id);
	}

	@Override
	public boolean doesCategoryExist(int id) {
		return rep.exists(id);
	}

	@Override
	public List<Category> getAllCategories() {
		return rep.getAllCategories();
	}

}
