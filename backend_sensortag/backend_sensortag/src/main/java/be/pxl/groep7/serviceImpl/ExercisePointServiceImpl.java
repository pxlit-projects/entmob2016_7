package be.pxl.groep7.serviceImpl;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import be.pxl.groep7.dao.IExercisePointRepository;
import be.pxl.groep7.models.ExercisePoint;
import be.pxl.groep7.services.IExercisePointService;

@Service
public class ExercisePointServiceImpl implements IExercisePointService {

	@Autowired
	private IExercisePointRepository rep;
	
	@Override
	public ExercisePoint createOrUpdateExercisePoint(ExercisePoint exercisePoint) {
		return rep.save(exercisePoint);
	}

	@Override
	public ExercisePoint findExercisePointById(int id) {
		return rep.findOne(id);
	}

	@Override
	public void deleteExercisePointById(int id) {
		rep.delete(id);
	}

	@Override
	public boolean doesExercisePointExist(int id) {
		return rep.exists(id);
	}
}
