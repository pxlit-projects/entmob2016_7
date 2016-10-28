package be.pxl.groep7.dao;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import be.pxl.groep7.models.Set;

//@Repository
public interface ISetRepository extends CrudRepository<Set, Integer> {

	/*public Set getSet(int id);
	public void addSet(Set set);
	public void updateSet(Set set);
	public void deleteSet(Set set);*/
}
