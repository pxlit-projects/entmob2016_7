package be.pxl.groep7.dao;

import be.pxl.groep7.models.Set;

public interface ISetRepository {

	public Set getSet(int id);
	public void addSet(Set set);
	public void updateSet(Set set);
	public void deleteSet(Set set);
}