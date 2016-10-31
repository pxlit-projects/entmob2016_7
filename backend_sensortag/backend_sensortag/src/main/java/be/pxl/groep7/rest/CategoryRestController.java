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

import be.pxl.groep7.dao.ICategoryRepository;
import be.pxl.groep7.models.Category;


@RestController
@RequestMapping("/category")
public class CategoryRestController {

	@Autowired
	private ICategoryRepository dao;
	
	@RequestMapping(value="/all", method = RequestMethod.GET, produces = "application/json")
	public ResponseEntity<List<Category>> getAllCategories(){
		HttpStatus status = HttpStatus.OK;
		List<Category> categoryList = dao.getAllCategories();
		
		if (categoryList == null) {
			status = HttpStatus.NOT_FOUND;
		}
		
		return new ResponseEntity<>(categoryList, status);
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.GET, produces = "application/json")
	@Secured({"ROLE_USER"})
	public ResponseEntity<Category> getCategoryById(@PathVariable("id") int id) {
		//System.out.println("were in get");
		HttpStatus status = HttpStatus.OK;
		Category category = dao.findOne(id);
		
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
			
		//if (!dao.exists(category.getId())){
			dao.save(category);
		//} else {
			//status = HttpStatus.CONFLICT;
		//}
		
		return new ResponseEntity<>(status);
	}
	
	@Secured("ROLE_USER")
	@RequestMapping(method = RequestMethod.PUT, consumes= "application/json")
	public ResponseEntity<String> editCategory(@RequestBody Category category){
		HttpStatus status = HttpStatus.NO_CONTENT;
		
		//if (!dao.exists(category.getId())){
			//status = HttpStatus.CONFLICT;
		//} else {
			dao.save(category);
		//}
		
		return new ResponseEntity<>(status);
	}
	
	@Secured("ROLE_USER")
	@RequestMapping(value="{id}", method = RequestMethod.DELETE)
	public ResponseEntity<String> deleteCategory(@PathVariable int id) {
		HttpStatus status = HttpStatus.NO_CONTENT;
		
		if (!dao.exists(id)){
			status = HttpStatus.CONFLICT;
		} else {
			dao.delete(id);
		}
		
		return new ResponseEntity<>(status);
	} 
}
