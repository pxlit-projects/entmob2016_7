package be.pxl.groep7.services;

import java.util.List;

import be.pxl.groep7.models.Set;

public interface ISetService {

	public Set createOrUpdateSet(Set set);
	public Set findSetById(int id);
	public void deleteSetById(int id);
	public boolean doesSetExist(int id);
	public List<Set> getAllSetsByExerciseId(int exerciseId);
}
