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
import be.pxl.groep7.dao.ICompletedSetRepository;
import be.pxl.groep7.models.Category;
import be.pxl.groep7.models.CompletedSet;
import be.pxl.groep7.services.ICompletedSetService;

@RestController
@RequestMapping("/completedset")
@Secured("ROLE_USER")
public class CompletedSetRestController {

	public final static String BASEURL = "/completedset";
	
	@Autowired
	private ICompletedSetService service;
	
	@RequestMapping(value="/sets/{setId}", method = RequestMethod.GET, produces = "application/json")
	public ResponseEntity<List<CompletedSet>> getCompletedSetsBySetId(@PathVariable("setId") int setId){
		HttpStatus status = HttpStatus.OK;
		List<CompletedSet> setList = service.getAllCompletedSetsBySetId(setId);
		
		if(setList == null){
			status = HttpStatus.NOT_FOUND;
		}
		return new ResponseEntity<>(setList, status);
	}
	
	@RequestMapping(value="/getById/{id}", method = RequestMethod.GET, produces = "application/json")
	public ResponseEntity<CompletedSet> getCompletedSetById(@PathVariable("id") int id){
		HttpStatus status = HttpStatus.OK;
		CompletedSet set = service.findCompletedSetById(id);
		if (set == null){
			status = HttpStatus.NOT_FOUND;
		}
		return new ResponseEntity<>(set, status);
	} 
	
	@RequestMapping(method = RequestMethod.POST, consumes= "application/json")
	public ResponseEntity<CompletedSet> addCompletedSet(@RequestBody CompletedSet completedSet){
		HttpStatus status = HttpStatus.NO_CONTENT;
		CompletedSet newSet = null;
		
		if (!service.doesCompletedSetExist(completedSet.getId())){
			newSet = service.createOrUpdateCompletedSet(completedSet);
		} else {
			status = HttpStatus.CONFLICT;
		}
		
		return new ResponseEntity<>(newSet, status);	
	}
	
	@RequestMapping(value = "{id}", method=RequestMethod.PUT, consumes= "application/json")
	public ResponseEntity<CompletedSet> editCompletedSet(@PathVariable("id") int id, @RequestBody CompletedSet completedSet){
		HttpStatus status = HttpStatus.NO_CONTENT;
		CompletedSet newCompletedSet = null;
		
		if (service.doesCompletedSetExist(id)){
			newCompletedSet = service.createOrUpdateCompletedSet(completedSet);
		} else {
			status = HttpStatus.NOT_FOUND;
		}
		
		return new ResponseEntity<>(newCompletedSet,status);	
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.DELETE)
	public ResponseEntity<String> deleteCompletedSet(@PathVariable int id) {
		HttpStatus status = HttpStatus.NO_CONTENT;
		
		if (service.doesCompletedSetExist(id)){
			service.deleteCompletedSetById(id);
		} else {
			status = HttpStatus.NOT_FOUND;
		}
		
		return new ResponseEntity<>(status);	
	} 
}
