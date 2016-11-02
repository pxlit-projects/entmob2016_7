package be.pxl.groep7.serviceImpl;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import be.pxl.groep7.dao.ISetRepository;
import be.pxl.groep7.models.Set;
import be.pxl.groep7.services.ISetService;

@Service
public class SetServiceImpl implements ISetService {

	@Autowired
	public ISetRepository rep;
	
	@Override
	public Set createOrUpdateSet(Set set) {
		return rep.save(set);
	}

	@Override
	public Set findSetById(int id) {
		return rep.findOne(id);
	}

	@Override
	public void deleteSetById(int id) {
		rep.delete(id);
	}

	@Override
	public boolean doesSetExist(int id) {
		return rep.exists(id);
	}

	@Override
	public List<Set> getAllSetsByExerciseId(int exerciseId) {
		return rep.getSetsByExerciseId(exerciseId);
	}

}
