package be.pxl.groep7.rest;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
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
	public Exercise getExerciseById(@PathVariable("id") int id){
		return dao.getExcercise(id);
	}
	
	@RequestMapping(method = RequestMethod.POST)
	public void addExercise(@RequestBody Exercise exercise){
		dao.addExercise(exercise);
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.PUT)
	public void editExercise(@PathVariable("id") int id, @RequestBody Exercise exercise){
		dao.updateExercise(exercise);
	}
	
	@RequestMapping(method = RequestMethod.DELETE)
	public void deleteExercise(@RequestBody Exercise exercise) {
		dao.deleteExercise(exercise);
	}
}
