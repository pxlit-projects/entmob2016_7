package be.pxl.groep7.serviceTests;

import java.util.ArrayList;
import java.util.List;

import org.junit.Assert;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.runners.MockitoJUnitRunner;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.ContextConfiguration;

import be.pxl.groep7.dao.ICategoryRepository;
import be.pxl.groep7.models.Category;
import be.pxl.groep7.serviceImpl.CategoryServiceImpl;
import be.pxl.groep7.test.config.TestConfigLite;

@RunWith(MockitoJUnitRunner.class)
@ContextConfiguration(classes = TestConfigLite.class)
@SpringBootTest
public class CategoryServiceTest {

	@Mock
	ICategoryRepository repMock;
	
	@InjectMocks
	public CategoryServiceImpl categoryService;
	
	@Test
	public void createOrUpdateCategoryTest() {
		Category category = new Category(4, "Category 4");
		Mockito.when(repMock.save(category)).thenReturn(category);
		
		Category category2 = categoryService.createOrUpdateCategory(category);
		
		Assert.assertEquals(category2, category);
	}
	
	@Test
	public void findCategoryByIdTest() {
		Category category = new Category(1, "Category 1");
		Mockito.when(repMock.findOne(1)).thenReturn(category);
		
		Category category2 = categoryService.findCategoryById(1);
		
		Assert.assertEquals(category, category2);
	}
	
	@Test
	public void getAllCategoriesTest() {
		List<Category> categories = new ArrayList<>();
		categories.add(new Category(1, "Category 1"));
		categories.add(new Category(2, "Category 2"));
		categories.add(new Category(3, "Category 3"));
		
		Mockito.when(repMock.getAllCategories()).thenReturn(categories);
		
		List<Category> categories2 = categoryService.getAllCategories();
		
		Assert.assertEquals(categories.size(), categories2.size());
		
		for (int i=0; i<categories.size(); i++){
			Assert.assertEquals(categories.get(i).getName(), categories2.get(i).getName());
			Assert.assertEquals(categories.get(i).getId(), categories2.get(i).getId());
		}
	}
	
	@Test(expected=Exception.class)
	public void deleteCategoryTest() {
		Mockito.doThrow(Exception.class).when(repMock).delete(1);
		categoryService.deleteCategoryById(1);
	}
	
	@Test
	public void doesCategoryExistTest() {
		Mockito.when(repMock.exists(1)).thenReturn(true);
		boolean exists = categoryService.doesCategoryExist(1);
		
		Assert.assertTrue(exists);
	}	
}
