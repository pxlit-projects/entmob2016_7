package be.pxl.groep7.dao;

import java.util.List;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import be.pxl.groep7.models.Set;

//@Repository
public interface ISetRepository extends CrudRepository<Set, Integer> {

	public List<Set> getSetByExerciseId(int exercise_Id);
}
