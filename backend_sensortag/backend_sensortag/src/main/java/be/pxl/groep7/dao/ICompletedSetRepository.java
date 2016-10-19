package be.pxl.groep7.dao;

import be.pxl.groep7.models.CompletedSet;

public interface ICompletedSetRepository {

	public CompletedSet getCompletedSetById(int id);
	public void addCompletedSet(CompletedSet set);
	public void updateCompletedSet(CompletedSet set);
	public void deleteCompletedSet(CompletedSet set);
}
