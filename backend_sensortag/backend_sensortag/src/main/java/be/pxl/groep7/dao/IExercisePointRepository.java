package be.pxl.groep7.dao;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import be.pxl.groep7.models.ExercisePoint;

//@Repository
public interface IExercisePointRepository extends CrudRepository<ExercisePoint, Integer> {

	/*public ExercisePoint getExercisePoint(int id);
	public void addExercisePoint(ExercisePoint ePoint);
	public void updateExercisePoint(ExercisePoint ePoint);
	public void deleteExercisePoint(ExercisePoint ePoint);*/
}
