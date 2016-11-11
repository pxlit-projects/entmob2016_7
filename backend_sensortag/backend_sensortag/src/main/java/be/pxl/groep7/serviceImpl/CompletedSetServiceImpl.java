package be.pxl.groep7.serviceImpl;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Isolation;
import org.springframework.transaction.annotation.Propagation;
import org.springframework.transaction.annotation.Transactional;

import be.pxl.groep7.dao.ICompletedSetRepository;
import be.pxl.groep7.models.CompletedSet;
import be.pxl.groep7.services.ICompletedSetService;

@Service
@Transactional(isolation=Isolation.READ_COMMITTED,
propagation=Propagation.REQUIRED)	//STANDARD!
public class CompletedSetServiceImpl implements ICompletedSetService {

	@Autowired
	private ICompletedSetRepository rep;
	
	@Override
	public CompletedSet createOrUpdateCompletedSet(CompletedSet completedSet) {
		return rep.save(completedSet);
	}

	@Override
	@Transactional(readOnly = true)
	public CompletedSet findCompletedSetById(int id) {
		return rep.findOne(id);
	}

	@Override
	public void deleteCompletedSetById(int id) {
		rep.delete(id);
	}

	@Override
	@Transactional(readOnly = true)
	public boolean doesCompletedSetExist(int id) {
		return rep.exists(id);
	}

	@Override
	@Transactional(readOnly = true)
	public List<CompletedSet> getAllCompletedSetsBySetId(int setId) {
		return rep.getCompletedSetsBySetId(setId);
	}
}
