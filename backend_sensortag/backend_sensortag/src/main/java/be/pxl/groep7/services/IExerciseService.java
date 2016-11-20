package be.pxl.groep7.services;

import java.util.List;

import be.pxl.groep7.models.Exercise;

public interface IExerciseService {

	public Exercise createOrUpdateExercise(Exercise exercise);
	public Exercise findExerciseById(int id);
	public void deleteExerciseById(int id);
	public boolean doesExerciseExist(int id);
	public List<Exercise> getAllExercisesByCategoryId(int categoryId);
	public List<Exercise> getAllExercises();
}
