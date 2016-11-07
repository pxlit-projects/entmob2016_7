package be.pxl.groep7.dao;

import java.util.List;
import org.springframework.data.repository.CrudRepository;

import be.pxl.groep7.models.Set;

public interface ISetRepository extends CrudRepository<Set, Integer> {

	public List<Set> getSetsByExerciseId(int exerciseId);
}
