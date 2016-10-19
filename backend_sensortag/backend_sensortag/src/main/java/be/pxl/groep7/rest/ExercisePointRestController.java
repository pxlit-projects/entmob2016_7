package be.pxl.groep7.rest;

import org.springframework.beans.factory.annotation.Autowired;
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
	public ExercisePoint getExerciseById(@PathVariable("id") int id){
		return dao.getExercisePoint(id);
	}
	
	@RequestMapping(method = RequestMethod.POST)
	public void addExercisePoint(@RequestBody ExercisePoint exercisePoint){
		dao.addExercisePoint(exercisePoint);
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.PUT)
	public void editExercisePoint(@PathVariable("id") int id, @RequestBody ExercisePoint exercise){
		dao.editExercisePoint(id, exercise);
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.DELETE)
	public void deleteExercisePoint(@PathVariable("id") int id) {
		dao.deleteExercisePoint(id);
	}
}
