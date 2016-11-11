package be.pxl.groep7.services;

import be.pxl.groep7.models.ExercisePoint;

public interface IExercisePointService {

	public ExercisePoint createOrUpdateExercisePoint(ExercisePoint exercisePoint);
	public ExercisePoint findExercisePointById(int id);
	public void deleteExercisePointById(int id);
	public boolean doesExercisePointExist(int id);
}
