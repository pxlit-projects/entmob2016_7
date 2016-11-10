package be.pxl.groep7.repositorytests;

import java.util.List;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.springframework.test.context.web.WebAppConfiguration;

import be.pxl.groep7.AppConfig;
import be.pxl.groep7.dao.ICategoryRepository;
import be.pxl.groep7.models.Category;


@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(classes = AppConfig.class)
@WebAppConfiguration
@DirtiesContext
@SpringBootTest
public class CategoryRepositoryTest {
	
	@Autowired
	public ICategoryRepository categoryRepository;
	
	private int id1;
	private int id2;
	private int id3;
	
	
	@Before
	public void initialSetupTest() {
		categoryRepository.deleteAll();
		
		id1 = categoryRepository.save(new Category(1, "Category 1")).getId();
		id2 = categoryRepository.save(new Category(2, "Category 2")).getId();
		id3 = categoryRepository.save(new Category(3, "Category 3")).getId();
	}
	
	 @Test
	 public void postCategoryRepositoryTest() {
		 Category inputCat = new Category(4, "testCat");
		 
		 Category outputCat = categoryRepository.save(inputCat);
		 Assert.assertNotNull(outputCat);
	 }
	 
	 @Test
	 public void getCategoryRepositoryTest(){
		 Category outputCat = categoryRepository.findOne(id1);
		 Assert.assertEquals("Category 1", outputCat.getName());
	 }
	 
	 @Test
	 public void putCategoryRepositoryTest() {
		 Category inputCat = new Category(id2,"newCategory");
		 Category outputCat = categoryRepository.save(inputCat);
		 
		 Assert.assertTrue(inputCat.getName().equals(outputCat.getName()));
	 }
	 
	 @Test
	 public void deleteCategoryRespositoryTest(){
		 categoryRepository.delete(id3);
		 Category outputCategory = categoryRepository.findOne(id3);
		 
		 Assert.assertTrue(outputCategory == null);
	 }
	 
	 @Test
	 public void getListOfCategoriesTest() {
		 List<Category> categories = categoryRepository.getAllCategories();
		 
		 Assert.assertTrue(categories.size() == 3);
	 }
}
