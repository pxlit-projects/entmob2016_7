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
import be.pxl.groep7.dao.ICompletedSetRepository;
import be.pxl.groep7.models.Category;
import be.pxl.groep7.models.CompletedSet;
import be.pxl.groep7.serviceImpl.CategoryServiceImpl;
import be.pxl.groep7.serviceImpl.CompletedSetServiceImpl;
import be.pxl.groep7.test.config.TestConfigLite;

@RunWith(MockitoJUnitRunner.class)
@ContextConfiguration(classes = TestConfigLite.class)
@SpringBootTest
public class CompletedSetServiceTest {

	@Mock
	ICompletedSetRepository repMock;
	
	@InjectMocks
	public CompletedSetServiceImpl completedSetService;
	
	@Test
	public void createOrUpdateCompletedSetTest() {
		CompletedSet completedSet = new CompletedSet(1, 1, 50, 200, 1);
		Mockito.when(repMock.save(completedSet)).thenReturn(completedSet);
		
		CompletedSet completedSet2 = completedSetService.createOrUpdateCompletedSet(completedSet);
		
		Assert.assertEquals(completedSet, completedSet2);
	}
	
	@Test
	public void findCompletedSetByIdTest() {
		CompletedSet completedSet = new CompletedSet(1, 1, 50, 200, 1);
		Mockito.when(repMock.findOne(1)).thenReturn(completedSet);
		
		CompletedSet completedSet2 = completedSetService.findCompletedSetById(1);
		
		Assert.assertEquals(completedSet, completedSet2);
	}
	
	@Test
	public void getAllCompletedSetsBySetIdTest() {
		List<CompletedSet> completedSets = new ArrayList<>();
		completedSets.add(new CompletedSet(1, 1, 50, 200, 1));
		completedSets.add(new CompletedSet(2, 2, 60, 150, 2));
		completedSets.add(new CompletedSet(3, 1, 40, 210, 1));
		
		Mockito.when(repMock.getCompletedSetsBySetId(1)).thenReturn(completedSets.stream().filter(cs -> cs.getSetId() == 1));
		
		List<CompletedSet> completedSets2 = completedSetService.getAllCompletedSetsBySetId(1);
		
		Assert.assertEquals(completedSets.size(), completedSets.size());
		
		for (int i=0; i<completedSets.size(); i++){
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
