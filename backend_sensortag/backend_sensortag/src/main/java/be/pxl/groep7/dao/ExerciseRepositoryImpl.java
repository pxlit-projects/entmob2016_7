package be.pxl.groep7.dao;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.EntityTransaction;
import javax.persistence.PersistenceUnit;

import org.springframework.stereotype.Repository;

import be.pxl.groep7.models.Exercise;

@Repository("exerciseRepository")
public class ExerciseRepositoryImpl implements IExerciseRepository{

	private EntityManagerFactory emf;

	@PersistenceUnit
	public void setEntityManagerFactory(EntityManagerFactory emf){
		this.emf = emf;
	}

	@Override
	public Exercise getExcercise(int id) {
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();

		Exercise exercise = em.find(Exercise.class, id);

		tx.commit();
		em.close();
		return exercise;
	}

	@Override
	public void addExercise(Exercise exercise) {
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();

		em.persist(exercise);

		tx.commit();
		em.close();
		emf.close();
	}

	@Override
	public void updateExercise(Exercise exercise) {
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();
		
		em.persist(exercise);
		
		tx.commit();
		em.close();
		emf.close();
		
	}

	@Override
	public void deleteExercise(Exercise exercise) {
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();
		
		em.remove(exercise);
		
		tx.commit();
		em.close();
		emf.close();		
	}

}
