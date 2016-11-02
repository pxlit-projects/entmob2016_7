package be.pxl.groep7.services;

import java.util.List;

import be.pxl.groep7.models.User;

public interface IUserService {
	public User createOrUpdateUser(User user);
	public User findUserById(int id);
	public void deleteUserById(int id);
	public boolean doesUserExist(int id);
}
