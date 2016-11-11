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

import be.pxl.groep7.dao.ICompletedSetRepository;
import be.pxl.groep7.models.CompletedSet;
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
		completedSets.add(new CompletedSet(3, 1, 40, 210, 1));
		
		Mockito.when(repMock.getCompletedSetsBySetId(1)).thenReturn(completedSets);
		
		List<CompletedSet> completedSets2 = completedSetService.getAllCompletedSetsBySetId(1);
		
		Assert.assertEquals(completedSets.size(), completedSets2.size());
		
		for (int i=0; i<completedSets.size(); i++){
			Assert.assertEquals(completedSets.get(i).getTime(), completedSets2.get(i).getTime());
			Assert.assertEquals(completedSets.get(i).getDuration(), completedSets2.get(i).getDuration());
			Assert.assertEquals(completedSets.get(i).getId(), completedSets2.get(i).getId());
			Assert.assertEquals(completedSets.get(i).getSetId(), completedSets2.get(i).getSetId());
			Assert.assertEquals(completedSets.get(i).getUserId(), completedSets2.get(i).getUserId());
		}
	}
	
	@Test(expected=Exception.class)
	public void deleteCompletedSetTest() {
		Mockito.doThrow(Exception.class).when(repMock).delete(1);
		completedSetService.deleteCompletedSetById(1);
	}
	
	@Test
	public void doesCompletedSetExistTest() {
		Mockito.when(repMock.exists(1)).thenReturn(true);
		boolean exists = completedSetService.doesCompletedSetExist(1);
		
		Assert.assertTrue(exists);
	}
}
