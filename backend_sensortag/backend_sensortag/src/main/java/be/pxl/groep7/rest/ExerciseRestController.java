package be.pxl.groep7.rest;

import org.springframework.http.MediaType;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import be.pxl.groep7.models.Exercise;

@RestController
@RequestMapping("/exercise")
public class ExerciseRestController {
	
	private ExerciseDao dao;

	@RequestMapping(value="{id}", method = RequestMethod.GET, produces = "application/json")
	public Exercise getExerciseById(@PathVariable("id") int id){
		return dao.getExerciseById(id);
	}
	
	@RequestMapping(method = RequestMethod.POST)
	public void addExercise(@RequestBody Exercise exercise){
		dao.addExercise(exercise);
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.PUT)
	public void editExercise(@PathVariable("id") int id, @RequestBody Exercise exercise){
		dao.editExercise(id, exercise);
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.DELETE)
	public void deleteExercise(@PathVariable("id") int id) {
		dao.deleteExercise(id);
	}
}
