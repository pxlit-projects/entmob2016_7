package be.pxl.groep7.rest;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import be.pxl.groep7.dao.IExerciseRepository;
import be.pxl.groep7.dao.ISetRepository;
import be.pxl.groep7.models.Exercise;
import be.pxl.groep7.models.Set;

@RestController
@RequestMapping("/set")
public class SetRestController {

	@Autowired
	private ISetRepository dao;
	
	@RequestMapping(value="/setbyexercise/{id}", method=RequestMethod.GET, produces = "application/json")
	public ResponseEntity<List<Set>> getSetByExerciseId(@PathVariable("id") int exerciseId){
		HttpStatus status = HttpStatus.OK;
		List<Set> setList = dao.getSetByExerciseId(exerciseId);
		if(setList == null){
			status = HttpStatus.NOT_FOUND;
		}
		return new ResponseEntity<>(setList, status);
	}

	@RequestMapping(value="{id}", method = RequestMethod.GET, produces = "application/json")
	public ResponseEntity<Set> getSetById(@PathVariable("id") int id) {
		HttpStatus status = HttpStatus.OK;
		Set set = dao.findOne(id);
		
		if (set == null) {
			status = HttpStatus.NOT_FOUND;
		}
		
		return new ResponseEntity<Set>(set, status);
	}
	
	@RequestMapping(method = RequestMethod.POST, consumes= "application/json")
	public ResponseEntity<String> addSet(@RequestBody Set set){
		HttpStatus status = HttpStatus.NO_CONTENT;
		
		if (!dao.exists(set.getId())){
			dao.save(set);
		} else {
			status = HttpStatus.CONFLICT;
		}
		
		return new ResponseEntity<>(status);	
	}
	
	@RequestMapping(method = RequestMethod.PUT, consumes= "application/json")
	public ResponseEntity<String> editSet(@RequestBody Set set){
		HttpStatus status = HttpStatus.NO_CONTENT;
		
		if (dao.exists(set.getId())){
			dao.save(set);
		} else {
			status = HttpStatus.CONFLICT;
		}
		
		return new ResponseEntity<>(status);	
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.DELETE)
	public ResponseEntity<String> deleteSet(@PathVariable int id) {
		HttpStatus status = HttpStatus.NO_CONTENT;
		
		if (dao.exists(id)){
			dao.delete(id);
		} else {
			status = HttpStatus.CONFLICT;
		}
		
		return new ResponseEntity<>(status);	
	}
}
