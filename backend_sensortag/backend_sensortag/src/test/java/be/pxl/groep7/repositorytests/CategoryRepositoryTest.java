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
	
	
	
	 
	 @Test
	 public void testCategoryRepository() throws Exception{
		 Category inputCat = new Category(1, "testCat");
		 
		 categoryRepository.save(inputCat);
		 
		 Category outputCat = categoryRepository.findOne(1);
		 
		 Assert.assertNotNull(outputCat);
		 //Assert.assertEquals("testCat", outputCat.getName());
	 }

}
