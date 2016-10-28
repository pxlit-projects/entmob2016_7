package be.pxl.groep7.dao;



import org.springframework.data.repository.CrudRepository;

import be.pxl.groep7.models.Category;


public interface ICategoryRepository extends CrudRepository<Category, Integer> {
	
}
