package be.pxl.groep7.serviceImpl;

import java.util.List;

import org.assertj.core.util.Lists;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Isolation;
import org.springframework.transaction.annotation.Propagation;
import org.springframework.transaction.annotation.Transactional;

import be.pxl.groep7.dao.IExerciseRepository;
import be.pxl.groep7.models.Exercise;
import be.pxl.groep7.services.IExerciseService;

@Service
@Transactional(isolation=Isolation.READ_COMMITTED,
propagation=Propagation.REQUIRED)	//STANDARD!
public class ExerciseServiceImpl implements IExerciseService {

	@Autowired
	private IExerciseRepository rep;
	
	@Override
	public Exercise createOrUpdateExercise(Exercise exercise) {
		return rep.save(exercise);
	}

	@Override
	@Transactional(readOnly = true)
	public Exercise findExerciseById(int id) {
		return rep.findOne(id);
	}

	@Override
	public void deleteExerciseById(int id) {
		rep.delete(id);
		
	}

	@Override
	@Transactional(readOnly = true)
	public boolean doesExerciseExist(int id) {
		return rep.exists(id);
	}

	@Override
	@Transactional(readOnly = true)
	public List<Exercise> getAllExercisesByCategoryId(int categoryId) {
		return rep.getExercisesByCategoryId(categoryId);
	}

	@Override
	@Transactional(readOnly = true)
	public List<Exercise> getAllExercises() {
		return Lists.newArrayList(rep.findAll());
	}
}
