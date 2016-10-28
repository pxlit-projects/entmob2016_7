package be.pxl.groep7.dao;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.EntityTransaction;
import javax.persistence.PersistenceUnit;

import org.springframework.stereotype.Repository;

import be.pxl.groep7.models.User;

/*@Repository("userRepository")
public class UserRepositoryImpl implements IUserRepository{

	private EntityManagerFactory emf;

	@PersistenceUnit
	public void setEntityManagerFactory(EntityManagerFactory emf){
		this.emf = emf;
	}


	@Override
	public User getUser(int id) {
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();

		User user = em.find(User.class, id);

		tx.commit();
		em.close();
		return user;
	}

	@Override
	public void addUser(User user) {
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();

		em.persist(user);

		tx.commit();
		em.close();
		emf.close();

	}


	@Override
	public void updateUser(User user) {
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();
		
		em.persist(user);
		
		tx.commit();
		em.close();
		emf.close();		
	}


	@Override
	public void deleteUser(User user) {
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();
		
		em.remove(user);
		
		tx.commit();
		em.close();
		emf.close();
		
	}
}*/
