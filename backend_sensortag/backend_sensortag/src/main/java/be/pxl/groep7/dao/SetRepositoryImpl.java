package be.pxl.groep7.dao;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.EntityTransaction;
import javax.persistence.PersistenceUnit;

import org.springframework.stereotype.Repository;

import be.pxl.groep7.models.Set;

/*@Repository("setRepository")
public class SetRepositoryImpl implements ISetRepository{

	private EntityManagerFactory emf;

	@PersistenceUnit
	public void setEntityManagerFactory(EntityManagerFactory emf){
		this.emf = emf;
	}

	@Override
	public Set getSet(int id) {
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();

		Set set = em.find(Set.class, id);

		tx.commit();
		em.close();
		emf.close();
		return set;
	}

	@Override
	public void addSet(Set set) {
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();

		em.persist(set);

		tx.commit();
		em.close();
		emf.close();
	}

	@Override
	public void updateSet(Set set) {
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();
		
		em.persist(set);
		
		tx.commit();
		em.close();
		emf.close();
		
	}

	@Override
	public void deleteSet(Set set) {
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();
		
		em.remove(set);
		
		tx.commit();
		em.close();
		emf.close();
		
	}
}*/
