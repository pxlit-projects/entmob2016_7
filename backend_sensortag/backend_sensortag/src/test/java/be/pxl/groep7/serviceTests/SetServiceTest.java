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

import be.pxl.groep7.dao.ISetRepository;
import be.pxl.groep7.models.Set;
import be.pxl.groep7.serviceImpl.SetServiceImpl;
import be.pxl.groep7.test.config.TestConfigLite;

@RunWith(MockitoJUnitRunner.class)
@ContextConfiguration(classes = TestConfigLite.class)
@SpringBootTest
public class SetServiceTest {

	@Mock
	ISetRepository repMock;
	
	@InjectMocks
	public SetServiceImpl setService;
	
	@Test
	public void createOrUpdateSetTest() {
		Set set = new Set(1, 6, 1, 10, 50);
		Mockito.when(repMock.save(set)).thenReturn(set);
		
		Set set2 = setService.createOrUpdateSet(set);
		
		Assert.assertEquals(set, set2);
	}
	
	@Test
	public void findSetByIdTest() {
		Set set = new Set(1, 6, 1, 10, 50);
		Mockito.when(repMock.findOne(1)).thenReturn(set);
		
		Set set2 = setService.findSetById(1);
		
		Assert.assertEquals(set, set2);
	}
	
	@Test
	public void getAllSetsByExerciseIdTest() {
		List<Set> sets = new ArrayList<>();
		sets.add(new Set(1, 6, 1, 10, 50));
		sets.add(new Set(2, 10, 2, 15, 100));
		
		Mockito.when(repMock.getSetsByExerciseId(1)).thenReturn(sets);
		
		List<Set> sets2 = setService.getAllSetsByExerciseId(1);
		
		Assert.assertEquals(sets.size(), sets2.size());
		
		for (int i=0; i<sets.size(); i++){
			Assert.assertEquals(sets.get(i).getExerciseId(), sets2.get(i).getExerciseId());
			Assert.assertEquals(sets.get(i).getId(), sets2.get(i).getId());
			Assert.assertEquals(sets.get(i).getPoints(), sets2.get(i).getPoints());
			Assert.assertEquals(sets.get(i).getMaxTime(), sets2.get(i).getMaxTime());
			Assert.assertEquals(sets.get(i).getRepeats(), sets2.get(i).getRepeats());
		}
	}
	
	
	@Test(expected=Exception.class)
	public void deleteSetTest() {
		Mockito.doThrow(Exception.class).when(repMock).delete(1);
		setService.deleteSetById(1);
	}
	
	@Test
	public void doesSetExistTest() {
		Mockito.when(repMock.exists(1)).thenReturn(true);
		boolean exists = setService.doesSetExist(1);
		
		Assert.assertTrue(exists);
	}
}
