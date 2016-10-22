package be.pxl.groep7.rest;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import be.pxl.groep7.dao.ICategoryRepository;
import be.pxl.groep7.dao.ICompletedSetRepository;
import be.pxl.groep7.models.Category;
import be.pxl.groep7.models.CompletedSet;

@RestController
@RequestMapping("/completedset")
public class CompletedSetRestController {

	@Autowired
	private ICompletedSetRepository dao;
	
	@RequestMapping(value="{id}", method = RequestMethod.GET, produces = "application/json")
	public ResponseEntity<CompletedSet> getCategoryById(@PathVariable("id") int id){
		//System.out.println("were in get");
		HttpStatus status = HttpStatus.OK;
		CompletedSet set = dao.findOne(id);
		if (set == null){
			status = HttpStatus.NOT_FOUND;
		}
		return new ResponseEntity<>(set, status);
	} 
	
	@RequestMapping(method = RequestMethod.POST, consumes= "application/json")
	public void addCategory(@RequestBody CompletedSet completedSet){
		dao.save(completedSet);
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.PUT, consumes= "application/json")
	public void editCategory(@PathVariable("id") int id, @RequestBody CompletedSet completedSet){
		dao.save(completedSet);
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.DELETE)
	public void deleteCategory(@PathVariable int id) {
		dao.delete(id);
	} 
}
