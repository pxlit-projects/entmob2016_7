package be.pxl.groep7.rest;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import be.pxl.groep7.dao.IExercisePointRepository;
import be.pxl.groep7.models.ExercisePoint;
import be.pxl.groep7.services.IExercisePointService;

@RestController
@RequestMapping("/exercisePoint")
@Secured("ROLE_USER")
public class ExercisePointRestController {

	public static final String BASEURL = "/exercisePoint";
	
	@Autowired
	private IExercisePointService service;
	
	public ExercisePointRestController(IExercisePointService service, IExercisePointRepository rep) {
		this.service = service;
		this.service.setIExercisePointRepository(rep);
	}

	@RequestMapping(value="/getById/{id}", method = RequestMethod.GET, produces = "application/json")
	public ResponseEntity<ExercisePoint> getExerciseById(@PathVariable("id") int id){
		HttpStatus status = HttpStatus.OK;
		ExercisePoint point = service.findExercisePointById(id);
		
		if (point == null){
			status = HttpStatus.NOT_FOUND;
		}
		
		return new ResponseEntity<>(point, status);
	}
	
	@RequestMapping(method = RequestMethod.POST, consumes= "application/json", produces = "application/json")
	public ResponseEntity<ExercisePoint> addExercisePoint(@RequestBody ExercisePoint exercisePoint){
		HttpStatus status = HttpStatus.NO_CONTENT;
		ExercisePoint newExercisePoint = null;
		
		if (!service.doesExercisePointExist(exercisePoint.getId())){
			newExercisePoint = service.createOrUpdateExercisePoint(exercisePoint);
		} else {
			status = HttpStatus.CONFLICT;
		}
		
		return new ResponseEntity<>(newExercisePoint, status);	
	}
	
	@RequestMapping(value = "{id}", method = RequestMethod.PUT, consumes= "application/json")
	public ResponseEntity<ExercisePoint> editExercisePoint(@PathVariable("id") int id, @RequestBody ExercisePoint exercisePoint){
		HttpStatus status = HttpStatus.NO_CONTENT;
		ExercisePoint newExercisePoint = null;
		
		if (service.doesExercisePointExist(id)){
			newExercisePoint = service.createOrUpdateExercisePoint(exercisePoint);
		} else {
			status = HttpStatus.NOT_FOUND;
		}
		
		return new ResponseEntity<>(newExercisePoint, status);	
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.DELETE)
	public ResponseEntity<String> deleteExercisePoint(@PathVariable int id) {
		HttpStatus status = HttpStatus.NO_CONTENT;
		
		if (service.doesExercisePointExist(id)){
			service.deleteExercisePointById(id);
		} else {
			status = HttpStatus.NOT_FOUND;
		}
		
		return new ResponseEntity<>(status);	
	}
}
