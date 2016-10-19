package be.pxl.groep7.dao;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.EntityTransaction;
import javax.persistence.PersistenceUnit;

import org.springframework.stereotype.Repository;

import be.pxl.groep7.models.CompletedSet;

@Repository("completedSerieRepository")
public class CompletedSetRepositoryImpl implements ICompletedSetRepository {


	private EntityManagerFactory emf;

	@PersistenceUnit
	public void setEntityManagerFactory(EntityManagerFactory emf){
		this.emf = emf;
	}

	public CompletedSet getCompletedSetById(int id){
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();

		CompletedSet set = em.find(CompletedSet.class, id);

		tx.commit();
		em.close();
		return set;
	}

	public void addCompletedSet(CompletedSet set){
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();

		em.persist(set);

		tx.commit();
		em.close();
		emf.close();
	}

	

	@Override
	public void updateCompletedSet(CompletedSet set) {
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();

		em.persist(set);

		tx.commit();
		em.close();
		emf.close();		
	}

	@Override
	public void deleteCompletedSet(CompletedSet set) {
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();
		
		em.remove(set);
		
		tx.commit();
		em.close();
		emf.close();
		
	}
}