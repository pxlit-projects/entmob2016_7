package be.pxl.groep7.dao;

import be.pxl.groep7.models.Exercise;

public interface IExerciseRepository {

	public Exercise getExcercise(int id);
	public void addExercise(Exercise exercise);
}
