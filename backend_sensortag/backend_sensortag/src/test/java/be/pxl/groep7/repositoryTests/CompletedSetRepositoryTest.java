package be.pxl.groep7.repositoryTests;

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

import be.pxl.groep7.dao.ICompletedSetRepository;
import be.pxl.groep7.models.CompletedSet;
import be.pxl.groep7.test.config.TestConfigLite;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(classes = TestConfigLite.class)
@DirtiesContext
@SpringBootTest
public class CompletedSetRepositoryTest {

	@Autowired
	public ICompletedSetRepository completedSetRepository;
	
	private int id1;
	private int id2;
	private int id3;
	private int id4;
	
	
	@Before
	public void initialSetupTest() {
		completedSetRepository.deleteAll();
		
		id1 = completedSetRepository.save(new CompletedSet(1, 1, 200, 50, 1)).getId();
		id2 = completedSetRepository.save(new CompletedSet(2, 2, 180, 30, 1)).getId();
		id3 = completedSetRepository.save(new CompletedSet(3, 1, 210, 250, 1)).getId();
		id4 = completedSetRepository.save(new CompletedSet(4, 2, 140, 40, 1)).getId();
	}
	
	 @Test
	 public void postCompletedSetRepositoryTest() {
		 CompletedSet inputCompletedSet = new CompletedSet(5, 2, 110, 30, 1);
		 
		 CompletedSet outputCompletedSet = completedSetRepository.save(inputCompletedSet);
		 Assert.assertNotNull(outputCompletedSet);
	 }
	 
	 @Test
	 public void getCompletedSetRepositoryTest(){
		 CompletedSet outputCompletedSet = completedSetRepository.findOne(id1);
		 
		 Assert.assertEquals(200, outputCompletedSet.getTime());
		 Assert.assertEquals(50, outputCompletedSet.getDuration());
		 Assert.assertEquals(1, outputCompletedSet.getSetId());
		 Assert.assertEquals(1, outputCompletedSet.getUserId());
	 }
	 
	 @Test
	 public void putCompletedSetRepositoryTest() {
		 CompletedSet inputCompletedSet = new CompletedSet(id2, 2, 110, 30, 1);
		 CompletedSet outputCompletedSet = completedSetRepository.save(inputCompletedSet);
		 
		 Assert.assertEquals(110, outputCompletedSet.getTime());
		 Assert.assertEquals(30, outputCompletedSet.getDuration());
		 Assert.assertEquals(2, outputCompletedSet.getSetId());
		 Assert.assertEquals(1, outputCompletedSet.getUserId());
	 }
	 
	 @Test
	 public void deleteCompletedSetRespositoryTest(){
		 completedSetRepository.delete(id3);
		 CompletedSet outputCompletedSet = completedSetRepository.findOne(id3);
		 
		 Assert.assertTrue(outputCompletedSet == null);
	 }
	 
	 @Test
	 public void getListOfCompletedSetsBySetIdTest() {
		 List<CompletedSet> completedSets = completedSetRepository.getCompletedSetsBySetId(1);
		 
		 Assert.assertTrue(completedSets.size() == 2);
	 }

	
}
