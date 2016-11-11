package be.pxl.groep7.serviceImpl;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Isolation;
import org.springframework.transaction.annotation.Propagation;
import org.springframework.transaction.annotation.Transactional;

import be.pxl.groep7.dao.IUserRepository;
import be.pxl.groep7.models.User;
import be.pxl.groep7.services.IUserService;

@Service
@Transactional(isolation=Isolation.READ_COMMITTED,
propagation=Propagation.REQUIRED)	//STANDARD!
public class UserServiceImpl implements IUserService {

	@Autowired
	private IUserRepository rep;
	
	@Override
	public User createOrUpdateUser(User user) {
		return rep.save(user);
	}

	@Override
	@Transactional(readOnly = true)
	public User findUserById(int id) {
		return rep.findOne(id);
	}

	@Override
	public void deleteUserById(int id) {
		rep.delete(id);
	}

	@Override
	@Transactional(readOnly = true)
	public boolean doesUserExist(int id) {
		return rep.exists(id);
	}
}
