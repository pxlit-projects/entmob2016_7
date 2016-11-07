package be.pxl.groep7.services;

import java.util.List;

import be.pxl.groep7.models.CompletedSet;

public interface ICompletedSetService {

	public CompletedSet createOrUpdateCompletedSet(CompletedSet completedSet);
	public CompletedSet findCompletedSetById(int id);
	public void deleteCompletedSetById(int id);
	public boolean doesCompletedSetExist(int id);
	public List<CompletedSet> getAllCompletedSetsByExerciseId(int exerciseId);
}
