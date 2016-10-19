package be.pxl.groep7.dao;

import be.pxl.groep7.models.CompletedSet;

public interface ICompletedSetRepository {

	public CompletedSet getCompletedSerieById(int id);
	public void addCompletedSerie(CompletedSet serie);
}
