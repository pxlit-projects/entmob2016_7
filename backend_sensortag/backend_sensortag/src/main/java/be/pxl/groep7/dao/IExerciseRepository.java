package be.pxl.groep7.dao;

import java.util.List;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import be.pxl.groep7.models.Exercise;

//@Repository
public interface IExerciseRepository extends CrudRepository<Exercise, Integer>{

	public List<Exercise> getExerciseByCategoryId(int category_Id);
}
