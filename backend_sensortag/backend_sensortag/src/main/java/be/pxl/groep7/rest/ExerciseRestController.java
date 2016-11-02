package be.pxl.groep7.rest;

import java.util.List;

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
import be.pxl.groep7.services.IExerciseService;

@RestController
@RequestMapping("/exercise")
public class ExerciseRestController {
	
	@Autowired
	private IExerciseService service;
	
	@RequestMapping(value="/bycategory/{categoryId}", method = RequestMethod.GET, produces = "application/json")
	public ResponseEntity<List<Exercise>> getExerciseByCategoryId(@PathVariable("categoryId") int categoryId){
		HttpStatus status = HttpStatus.OK;
		List<Exercise> exerciseList = service.getAllExercisesByCategoryId(categoryId);
		if(exerciseList == null){
			status = HttpStatus.NOT_FOUND;
		}
		return new ResponseEntity<>(exerciseList, status);
	}

	@RequestMapping(value="{id}", method = RequestMethod.GET, produces = "application/json")
	public ResponseEntity<Exercise> getExerciseById(@PathVariable("id") int id){
		HttpStatus status = HttpStatus.OK;
		Exercise exercise = service.findExerciseById(id);
		
		if (exercise == null) {
			status = HttpStatus.NOT_FOUND;
		}
		
		return new ResponseEntity<>(exercise, status);
	}
	
	@RequestMapping(method = RequestMethod.POST, consumes= "application/json")
	public ResponseEntity<Exercise> addExercise(@RequestBody Exercise exercise){
		HttpStatus status = HttpStatus.NO_CONTENT;
		Exercise newExercise = null;
		
		if (!service.doesExerciseExist(exercise.getId())){
			newExercise = service.createOrUpdateExercise(exercise);
		} else {
			status = HttpStatus.CONFLICT;
		}
		
		return new ResponseEntity<>(newExercise, status);	
	}
	
	@RequestMapping(value = "{id}", method = RequestMethod.PUT, consumes= "application/json")
	public ResponseEntity<Exercise> editExercise(@PathVariable("id") int id, @RequestBody Exercise exercise){
		HttpStatus status = HttpStatus.NO_CONTENT;
		Exercise newExercise = null;
		
		if (service.doesExerciseExist(id)){
			newExercise = service.createOrUpdateExercise(exercise);
		} else {
			status = HttpStatus.NOT_FOUND;
		}
		
		return new ResponseEntity<>(newExercise, status);	
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.DELETE)
	public ResponseEntity<String> deleteExercise(@PathVariable("id") int id) {
		HttpStatus status = HttpStatus.NO_CONTENT;
		
		if (service.doesExerciseExist(id)){
			service.deleteExerciseById(id);
		} else {
			status = HttpStatus.NOT_FOUND;
		}
		
		return new ResponseEntity<>(status);	
	}
}
