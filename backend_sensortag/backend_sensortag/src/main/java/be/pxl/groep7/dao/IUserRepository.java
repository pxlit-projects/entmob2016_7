package be.pxl.groep7.dao;

import be.pxl.groep7.models.User;

public interface IUserRepository {

	public User getUser(int id);
	public void addUser(User user);
	public void updateUser(User user);
	public void deleteUser(User user);
}