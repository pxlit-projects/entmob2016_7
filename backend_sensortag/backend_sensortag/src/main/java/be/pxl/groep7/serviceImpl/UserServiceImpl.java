package be.pxl.groep7.serviceImpl;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import be.pxl.groep7.dao.IUserRepository;
import be.pxl.groep7.models.User;
import be.pxl.groep7.services.IUserService;

@Service
public class UserServiceImpl implements IUserService {

	@Autowired
	private IUserRepository rep;
	
	@Override
	public User createOrUpdateUser(User user) {
		return rep.save(user);
	}

	@Override
	public User findUserById(int id) {
		return rep.findOne(id);
	}

	@Override
	public void deleteUserById(int id) {
		rep.delete(id);
	}

	@Override
	public boolean doesUserExist(int id) {
		return rep.exists(id);
	}

}
