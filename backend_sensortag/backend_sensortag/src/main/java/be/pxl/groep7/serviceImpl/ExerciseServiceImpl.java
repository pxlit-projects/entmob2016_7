package be.pxl.groep7.serviceImpl;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import be.pxl.groep7.dao.IExerciseRepository;
import be.pxl.groep7.models.Exercise;
import be.pxl.groep7.services.IExerciseService;

@Service
public class ExerciseServiceImpl implements IExerciseService {

	@Autowired
	private IExerciseRepository rep;
	
	@Override
	public Exercise createOrUpdateExercise(Exercise exercise) {
		return rep.save(exercise);
	}

	@Override
	public Exercise findExerciseById(int id) {
		return rep.findOne(id);
	}

	@Override
	public void deleteExerciseById(int id) {
		rep.delete(id);
		
	}

	@Override
	public boolean doesExerciseExist(int id) {
		return rep.exists(id);
	}

	@Override
	public List<Exercise> getAllExercisesByCategoryId(int categoryId) {
		return rep.getExercisesByCategoryId(categoryId);
	}
}
