package be.pxl.groep7.rest;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import be.pxl.groep7.dao.IExercisePointRepository;
import be.pxl.groep7.dao.IExerciseRepository;
import be.pxl.groep7.models.Exercise;
import be.pxl.groep7.models.ExercisePoint;

@RestController
@RequestMapping("/exercisePoint")
public class ExercisePointRestController {

	@Autowired
	private IExercisePointRepository dao;

	@RequestMapping(value="{id}", method = RequestMethod.GET, produces = "application/json")
	public ResponseEntity<ExercisePoint> getExerciseById(@PathVariable("id") int id){
		HttpStatus status = HttpStatus.OK;
		ExercisePoint point = dao.findOne(id);
		
		if (point == null){
			status = HttpStatus.NOT_FOUND;
		}
		
		return new ResponseEntity<>(point, status);
	}
	
	@RequestMapping(method = RequestMethod.POST, consumes= "application/json")
	public void addExercisePoint(@RequestBody ExercisePoint exercisePoint){
		dao.save(exercisePoint);
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.PUT, consumes= "application/json")
	public void editExercisePoint(@PathVariable("id") int id, @RequestBody ExercisePoint exercisePoint){
		dao.save(exercisePoint);
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.DELETE)
	public void deleteExercisePoint(@PathVariable int id) {
		dao.delete(id);
	}
}
