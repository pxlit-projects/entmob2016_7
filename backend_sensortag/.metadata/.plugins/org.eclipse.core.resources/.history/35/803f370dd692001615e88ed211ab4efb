package be.pxl.groep7.repository;


import javax.persistence.*;

import org.springframework.stereotype.Repository;

import be.pxl.groep7.models.Distance;

@Repository("distanceRepository")
public class DistanceRepositoryImpl {

	private EntityManagerFactory emf;
	
	@PersistenceUnit
	public void setEntityManagerFactory(EntityManagerFactory emf){
		this.emf = emf;
	}
	
	public Distance getDistanceById(int id) {
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();
		
		Distance distance = em.find(Distance.class, id);
		
		tx.commit();
		em.close();
		return distance;
	}
	
	public void addDistance(Distance distance){
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();
		
		em.persist(distance);
		
		tx.commit();
		em.close();
		emf.close();
	}
	
}
