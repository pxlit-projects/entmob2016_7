package be.pxl.groep7.dao;

import be.pxl.groep7.models.ExercisePoint;

public interface IExercisePointRepository {

	public ExercisePoint getExercisePoint(int id);
	public void addExercisePoint(ExercisePoint ePoint);
	public void updateExercisePoint(ExercisePoint ePoint);
	public void deleteExercisePoint(ExercisePoint ePoint);
}