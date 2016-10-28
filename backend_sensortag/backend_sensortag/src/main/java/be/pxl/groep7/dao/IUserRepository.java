package be.pxl.groep7.dao;

import org.springframework.data.repository.RepositoryDefinition;

import be.pxl.groep7.models.User;

@RepositoryDefinition(domainClass=User.class, idClass=Integer.class)
public interface IUserRepository {

	User findOne(Integer id);
    User save(User user);
    boolean exists(Integer id);
    void delete(Integer id);
	/*public User getUser(int id);
	public void addUser(User user);
	public void updateUser(User user);
	public void deleteUser(User user);*/
}
