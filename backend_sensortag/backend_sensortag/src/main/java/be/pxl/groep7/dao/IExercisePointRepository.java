package be.pxl.groep7.dao;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import be.pxl.groep7.models.ExercisePoint;

public interface IExercisePointRepository extends CrudRepository<ExercisePoint, Integer> {

}
