package be.pxl.groep7.dao;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.EntityTransaction;
import javax.persistence.PersistenceUnit;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import be.pxl.groep7.models.Category;

@Repository("categoryRepository")
public class CategoryRepositoryImpl implements ICategoryRepository{
	@Autowired
	private EntityManagerFactory emf;

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
	}

	@Override
	public void updateCategory(Category category) {
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();
		
		em.persist(category);
		
		tx.commit();
		em.close();
	}

	@Override
	public void deleteCategory(Category category) {
		// TODO Auto-generated method stub
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		tx.begin();
		
		em.remove(category);
		
		tx.commit();
		em.close();
	}

}
