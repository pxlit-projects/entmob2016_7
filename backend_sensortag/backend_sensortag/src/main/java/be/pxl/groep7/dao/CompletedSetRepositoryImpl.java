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
	
	public CompletedSet getCompletedSerieById(int id){
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();
		
		CompletedSet serie = em.find(CompletedSet.class, id);
		
		tx.commit();
		em.close();
		return serie;
	}
	
	public void addCompletedSerie(CompletedSet serie){
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();
		
		em.persist(serie);
		
		tx.commit();
		em.close();
		emf.close();
	}
}
