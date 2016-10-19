package be.pxl.groep7.dao;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.EntityTransaction;
import javax.persistence.PersistenceUnit;

import org.springframework.stereotype.Repository;

import be.pxl.groep7.models.Exercise;
import be.pxl.groep7.models.ExercisePoint;

@Repository("exercisePointRepository")
public class ExercisePointRepositoryImpl implements IExercisePointRepository{

	private EntityManagerFactory emf;

	@PersistenceUnit
	public void setEntityManagerFactory(EntityManagerFactory emf){
		this.emf = emf;
	}	

	@Override
	public ExercisePoint getExercisePoint(int id) {
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();		

		ExercisePoint ePoint = em.find(ExercisePoint.class, id);

		tx.commit();
		em.close();		
		return ePoint;
	}

	@Override
	public void addExercisePoint(ExercisePoint ePoint) {
		// TODO Auto-generated method stub
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();

		em.persist(ePoint);

		tx.commit();
		em.close();
		emf.close();
	}

	@Override
	public void updateExercisePoint(ExercisePoint ePoint) {
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();
		
		em.persist(ePoint);
		
		tx.commit();
		em.close();
		emf.close();
		
	}

	@Override
	public void deleteExercisePoint(ExercisePoint ePoint) {
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();
		
		em.remove(ePoint);
		
		tx.commit();
		em.close();
		emf.close();
		
	}

}
