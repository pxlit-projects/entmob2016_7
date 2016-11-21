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

import be.pxl.groep7.dao.IExerciseRepository;
import be.pxl.groep7.dao.ISetRepository;
import be.pxl.groep7.models.Exercise;
import be.pxl.groep7.models.Set;
import be.pxl.groep7.services.ISetService;

@RestController
@RequestMapping("/set")
@Secured("ROLE_USER")
public class SetRestController {
	
	public static final String BASEURL = "/set";

	@Autowired
	private ISetService service;
	
	@RequestMapping(value="/setbyexercise/{exerciseId}", method=RequestMethod.GET, produces = "application/json; charset=utf-8")
	public ResponseEntity<List<Set>> getSetByExerciseId(@PathVariable("exerciseId") int exerciseId){
		HttpStatus status = HttpStatus.OK;
		List<Set> setList = service.getAllSetsByExerciseId(exerciseId);
		
		if(setList.size() == 0){
			status = HttpStatus.NOT_FOUND;
		}
		return new ResponseEntity<>(setList, status);
	}

	@RequestMapping(value="/getById/{id}", method = RequestMethod.GET, produces = "application/json; charset=utf-8")
	public ResponseEntity<Set> getSetById(@PathVariable("id") int id) {
		HttpStatus status = HttpStatus.OK;
		Set set = service.findSetById(id);
		
		if (set == null) {
			status = HttpStatus.NOT_FOUND;
		}
		
		return new ResponseEntity<Set>(set, status);
	}
	
	@RequestMapping(method = RequestMethod.POST, consumes= "application/json; charset=utf-8", produces= "application/json; charset=utf-8")
	public ResponseEntity<Set> addSet(@RequestBody Set set){
		HttpStatus status = HttpStatus.NO_CONTENT;
		Set newSet = null;
		
		if (!service.doesSetExist(set.getId())){
			newSet = service.createOrUpdateSet(set);
		} else {
			status = HttpStatus.CONFLICT;
		}
		
		return new ResponseEntity<>(newSet, status);	
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.PUT, consumes= "application/json; charset=utf-8", produces= "application/json; charset=utf-8")
	public ResponseEntity<Set> editSet(@PathVariable("id") int id, @RequestBody Set set){
		HttpStatus status = HttpStatus.NO_CONTENT;
		Set newSet = null;
		
		if (service.doesSetExist(id)){
			newSet = service.createOrUpdateSet(set);
		} else {
			status = HttpStatus.NOT_FOUND;
		}
		
		return new ResponseEntity<>(newSet, status);	
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.DELETE)
	public ResponseEntity<String> deleteSet(@PathVariable int id) {
		HttpStatus status = HttpStatus.NO_CONTENT;
		
		if (service.doesSetExist(id)){
			service.deleteSetById(id);
		} else {
			status = HttpStatus.NOT_FOUND;
		}
		
		return new ResponseEntity<>(status);	
	}
}
