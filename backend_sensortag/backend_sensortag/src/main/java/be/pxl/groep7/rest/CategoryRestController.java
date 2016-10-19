package be.pxl.groep7.rest;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import be.pxl.groep7.dao.CategoryRepositoryImpl;
import be.pxl.groep7.dao.ICategoryRepository;
import be.pxl.groep7.models.Category;
import be.pxl.groep7.models.Exercise;

@RestController
@RequestMapping("/category")
public class CategoryRestController {

	@Autowired
	private ICategoryRepository dao;

	@RequestMapping(value="{id}", method = RequestMethod.GET, produces = "application/json")
	public Category getCategoryById(@PathVariable("id") int id){
		return dao.getCategoryById(id);
	}
	
	@RequestMapping(method = RequestMethod.POST)
	public void addCategory(@RequestBody Category category){
		dao.addCategory(category);
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.PUT)
	public void editCategory(@PathVariable("id") int id, @RequestBody Category category){
		dao.editCategory(id, category);
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.DELETE)
	public void deleteCategory(@PathVariable("id") int id) {
		dao.deleteCategory(id);
	}
}
