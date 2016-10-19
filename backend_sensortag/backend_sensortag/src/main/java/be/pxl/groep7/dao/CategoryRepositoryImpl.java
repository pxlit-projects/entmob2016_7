package be.pxl.groep7.dao;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.EntityTransaction;

import org.springframework.stereotype.Repository;

import be.pxl.groep7.models.Category;

@Repository("categoryRepository")
public class CategoryRepositoryImpl implements ICategoryRepository{

	private EntityManagerFactory emf;

	public void setEntityManagerFactory(EntityManagerFactory emf){
		this.emf = emf;
	}

	public Category getCategoryById(int id){
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();

		Category category = em.find(Category.class, id);

		tx.commit();
		em.close();
		return category;
	}

	public void addCategory(Category category){
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();

		em.persist(category);

		tx.commit();
		em.close();
		emf.close();
	}

}
