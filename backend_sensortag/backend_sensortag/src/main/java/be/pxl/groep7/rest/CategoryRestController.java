package be.pxl.groep7.rest;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import be.pxl.groep7.models.Category;
import be.pxl.groep7.services.ICategoryService;


@RestController
@RequestMapping("/category")
public class CategoryRestController {

	public final static String BASEURL = "/category";
	
	@Autowired
	private ICategoryService service;
	
	@Secured("ROLE_USER")
	@RequestMapping(value="/all", method = RequestMethod.GET, produces = "application/json")
	public ResponseEntity<List<Category>> getAllCategories(){
		HttpStatus status = HttpStatus.OK;
		List<Category> categoryList = service.getAllCategories();
		
		if (categoryList == null) {
			status = HttpStatus.NOT_FOUND;
		}
		
		return new ResponseEntity<>(categoryList, status);
	}
	
	@Secured("ROLE_USER")
	@RequestMapping(value="/getById/{id}", method = RequestMethod.GET, produces = "application/json")
	public ResponseEntity<Category> getCategoryById(@PathVariable("id") int id) {
		HttpStatus status = HttpStatus.OK;
		Category category = service.findCategoryById(id);
		
		if (category == null) {
			status = HttpStatus.NOT_FOUND;
		}
		
		return new ResponseEntity<>(category, status);
	} 
	
	@Secured("ROLE_USER")
	@RequestMapping(method = RequestMethod.POST, consumes= "application/json")
	public ResponseEntity<String> addCategory(@RequestBody Category category) {
		System.out.println("POST!");
		HttpStatus status = HttpStatus.NO_CONTENT;
			
		if (!service.doesCategoryExists(category.getId())){
			service.createOrUpdateCategory(category);
		} else {
			status = HttpStatus.CONFLICT;
		}
		
		return new ResponseEntity<>(status);
	}
	
	@Secured("ROLE_USER")
	@RequestMapping(method = RequestMethod.PUT, consumes= "application/json")
	public ResponseEntity<String> editCategory(@RequestBody Category category){
		HttpStatus status = HttpStatus.NO_CONTENT;
		
		if (!service.doesCategoryExists(category.getId())){
			status = HttpStatus.CONFLICT;
		} else {
			service.createOrUpdateCategory(category);
		}
		
		return new ResponseEntity<>(status);
	}
	
	@Secured("ROLE_USER")
	@RequestMapping(value="{id}", method = RequestMethod.DELETE)
	public ResponseEntity<String> deleteCategory(@PathVariable int id) {
		HttpStatus status = HttpStatus.NO_CONTENT;
		
		if (!service.doesCategoryExists(id)){
			status = HttpStatus.CONFLICT;
		} else {
			service.deleteCategoryById(id);
		}
		
		return new ResponseEntity<>(status);
	} 
}
