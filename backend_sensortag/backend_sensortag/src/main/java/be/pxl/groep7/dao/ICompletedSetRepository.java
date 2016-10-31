package be.pxl.groep7.dao;

import java.util.List;

import org.springframework.data.repository.CrudRepository;
import be.pxl.groep7.models.CompletedSet;

public interface ICompletedSetRepository extends CrudRepository<CompletedSet, Integer> {
	
	public List<CompletedSet> getCompletedSetBySetId(int set_Id);
}
