package be.pxl.groep7.dao;

import org.springframework.data.repository.RepositoryDefinition;

import be.pxl.groep7.models.User;

@RepositoryDefinition(domainClass=User.class, idClass=Integer.class)
public interface IUserRepository {

	User findOne(int id);
    User save(User user);
    boolean exists(int id);
    void delete(int id);
}
