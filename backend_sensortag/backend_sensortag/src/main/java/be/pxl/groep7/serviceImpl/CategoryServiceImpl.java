package be.pxl.groep7.serviceImpl;

import java.util.List;


import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Isolation;
import org.springframework.transaction.annotation.Propagation;
import org.springframework.transaction.annotation.Transactional;

import be.pxl.groep7.dao.ICategoryRepository;
import be.pxl.groep7.models.Category;
import be.pxl.groep7.services.ICategoryService;

@Service
@Transactional(isolation=Isolation.READ_COMMITTED,		//isolation level is determined by the database, this is a way to set it
propagation=Propagation.REQUIRED)	//STANDARD!
public class CategoryServiceImpl implements ICategoryService {

	@Autowired
	private ICategoryRepository rep;
	
	@Override
	public Category createOrUpdateCategory(Category category) {
		return rep.save(category);
	}

	@Override
	@Transactional(readOnly=true)
	public Category findCategoryById(int id) {
		return rep.findOne(id);
	}

	@Override
	public void deleteCategoryById(int id) {
		rep.delete(id);
	}

	@Override
	@Transactional(readOnly=true)
	public boolean doesCategoryExist(int id) {
		return rep.exists(id);
	}

	@Override
	@Transactional(readOnly=true)
	public List<Category> getAllCategories() {
		return rep.getAllCategories();
	}
}
