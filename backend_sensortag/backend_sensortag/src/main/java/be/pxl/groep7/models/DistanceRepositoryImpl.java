package be.pxl.groep7.models;


import javax.persistence.*;

import org.springframework.stereotype.Repository;

@Repository("distanceRepository")
public class DistanceRepositoryImpl implements DistanceRepository{

	private EntityManagerFactory emf;
	
	@PersistenceUnit
	public void setEntityManagerFactory(EntityManagerFactory emf){
		this.emf = emf;
	}
	
	public Distance2 getDistanceById(int id) {
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();
		
		Distance2 distance = em.find(Distance2.class, id);
		
		tx.commit();
		em.close();
		return distance;
	}
	
	public void addDistance(Distance2 distance){		//	public void addDistance(SensorModel distance){

		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();
		
		em.persist(distance);
		
		tx.commit();
		em.close();
		emf.close();
	}
	
}
