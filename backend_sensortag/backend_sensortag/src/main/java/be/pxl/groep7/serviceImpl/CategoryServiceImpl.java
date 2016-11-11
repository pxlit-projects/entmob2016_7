package be.pxl.groep7.serviceImpl;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.context.annotation.Profile;
import org.springframework.stereotype.Service;

import be.pxl.groep7.dao.ICategoryRepository;
import be.pxl.groep7.models.Category;
import be.pxl.groep7.services.ICategoryService;

@Service
@Qualifier("test")
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

	@Override
	public void setCategoryRepository(ICategoryRepository rep) {
		this.rep = rep;
	}
}
