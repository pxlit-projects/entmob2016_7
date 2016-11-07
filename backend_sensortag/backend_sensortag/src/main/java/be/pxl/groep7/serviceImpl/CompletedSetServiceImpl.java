package be.pxl.groep7.serviceImpl;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import be.pxl.groep7.dao.ICompletedSetRepository;
import be.pxl.groep7.models.CompletedSet;
import be.pxl.groep7.services.ICompletedSetService;

@Service
public class CompletedSetServiceImpl implements ICompletedSetService {

	@Autowired
	private ICompletedSetRepository rep;
	
	@Override
	public CompletedSet createOrUpdateCompletedSet(CompletedSet completedSet) {
		return rep.save(completedSet);
	}

	@Override
	public CompletedSet findCompletedSetById(int id) {
		return rep.findOne(id);
	}

	@Override
	public void deleteCompletedSetById(int id) {
		rep.delete(id);
	}

	@Override
	public boolean doesCompletedSetExist(int id) {
		return rep.exists(id);
	}

	@Override
	public List<CompletedSet> getAllCompletedSetsByExerciseId(int exerciseId) {
		return rep.getCompletedSetByExerciseId(exerciseId);
	}

}
