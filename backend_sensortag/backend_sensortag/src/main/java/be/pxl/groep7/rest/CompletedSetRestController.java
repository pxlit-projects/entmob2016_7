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
	public ResponseEntity<String> addCategory(@RequestBody CompletedSet completedSet){
		HttpStatus status = HttpStatus.NO_CONTENT;
		
		if (!dao.exists(completedSet.getId())){
			dao.save(completedSet);
		} else {
			status = HttpStatus.CONFLICT;
		}
		
		return new ResponseEntity<>(status);	
	}
	
	@RequestMapping(method=RequestMethod.PUT, consumes= "application/json")
	public ResponseEntity<String> editCategory(@RequestBody CompletedSet completedSet){
		HttpStatus status = HttpStatus.NO_CONTENT;
		
		if (dao.exists(completedSet.getId())){
			dao.save(completedSet);
		} else {
			status = HttpStatus.CONFLICT;
		}
		
		return new ResponseEntity<>(status);	
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.DELETE)
	public ResponseEntity<String> deleteCategory(@PathVariable int id) {
		HttpStatus status = HttpStatus.NO_CONTENT;
		
		if (dao.exists(id)){
			dao.delete(id);
		} else {
			status = HttpStatus.CONFLICT;
		}
		
		return new ResponseEntity<>(status);	
	} 
}
