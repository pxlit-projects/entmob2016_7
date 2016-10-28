package be.pxl.groep7.dao;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import be.pxl.groep7.models.Exercise;

//@Repository
public interface IExerciseRepository extends CrudRepository<Exercise, Integer>{

	/*public Exercise getExcercise(int id);
	public void addExercise(Exercise exercise);
	public void updateExercise(Exercise exercise);
	public void deleteExercise(Exercise exercise);*/
}
