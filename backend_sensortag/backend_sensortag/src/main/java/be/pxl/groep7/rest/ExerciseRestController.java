package be.pxl.groep7.rest;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import be.pxl.groep7.dao.IExerciseRepository;
import be.pxl.groep7.models.Exercise;

@RestController
@RequestMapping("/exercise")
public class ExerciseRestController {
	
	@Autowired
	private IExerciseRepository dao;

	@RequestMapping(value="{id}", method = RequestMethod.GET, produces = "application/json")
	public ResponseEntity<Exercise> getExerciseById(@PathVariable("id") int id){
		HttpStatus status = HttpStatus.OK;
		Exercise exercise = dao.findOne(id);
		
		if (exercise == null) {
			status = HttpStatus.NOT_FOUND;
		}
		
		return new ResponseEntity<>(exercise, status);
	}
	
	@RequestMapping(method = RequestMethod.POST, consumes= "application/json")
	public ResponseEntity<String> addExercise(@RequestBody Exercise exercise){
		HttpStatus status = HttpStatus.NO_CONTENT;
		System.out.println("In post");
		if (!dao.exists(exercise.getId())){
			dao.save(exercise);
		} else {
			status = HttpStatus.CONFLICT;
		}
		
		return new ResponseEntity<>(status);	
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.PUT, consumes= "application/json")
	public ResponseEntity<String> editExercise(@PathVariable("id") int id, @RequestBody Exercise exercise){
		HttpStatus status = HttpStatus.NO_CONTENT;
		
		if (dao.exists(exercise.getId())){
			dao.save(exercise);
		} else {
			status = HttpStatus.CONFLICT;
		}
		
		return new ResponseEntity<>(status);	
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.DELETE)
	public ResponseEntity<String> deleteExercise(@PathVariable("id") int id) {
		HttpStatus status = HttpStatus.NO_CONTENT;
		
		if (dao.exists(id)){
			dao.delete(id);
		} else {
			status = HttpStatus.CONFLICT;
		}
		
		return new ResponseEntity<>(status);	
	}
}
