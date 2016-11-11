package be.pxl.groep7.serviceImpl;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Isolation;
import org.springframework.transaction.annotation.Propagation;
import org.springframework.transaction.annotation.Transactional;

import be.pxl.groep7.dao.ISetRepository;
import be.pxl.groep7.models.Set;
import be.pxl.groep7.services.ISetService;

@Service
@Transactional(isolation=Isolation.READ_COMMITTED,
propagation=Propagation.REQUIRED)	//STANDARD!
public class SetServiceImpl implements ISetService {

	@Autowired
	public ISetRepository rep;
	
	@Override
	public Set createOrUpdateSet(Set set) {
		return rep.save(set);
	}

	@Override
	@Transactional(readOnly = true)
	public Set findSetById(int id) {
		return rep.findOne(id);
	}

	@Override
	public void deleteSetById(int id) {
		rep.delete(id);
	}

	@Override
	@Transactional(readOnly = true)
	public boolean doesSetExist(int id) {
		return rep.exists(id);
	}

	@Override
	@Transactional(readOnly = true)
	public List<Set> getAllSetsByExerciseId(int exerciseId) {
		return rep.getSetsByExerciseId(exerciseId);
	}

}
