package be.pxl.groep7.dao;

import org.springframework.stereotype.Repository;

import be.pxl.groep7.models.CompletedSet;

@Repository
public interface ICompletedSetRepository {

	public CompletedSet getCompletedSetById(int id);
	public void addCompletedSet(CompletedSet set);
	public void updateCompletedSet(CompletedSet set);
	public void deleteCompletedSet(CompletedSet set);
}
