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
import be.pxl.groep7.dao.ISetRepository;
import be.pxl.groep7.models.Set;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(classes = AppConfig.class)
@WebAppConfiguration
@DirtiesContext
@SpringBootTest
public class SetRepositoryTest {

	@Autowired
	public ISetRepository setRepository;
	
	private int id1;
	private int id2;
	private int id3;
	
	
	@Before
	public void initialSetupTest() {
		setRepository.deleteAll();
		
		id1 = setRepository.save(new Set(1, 5, 1, 10, 20)).getId();
		id2 = setRepository.save(new Set(2, 10, 2, 5, 30)).getId();
		id3 = setRepository.save(new Set(3, 15, 2, 15, 50)).getId();
	}
	
	 @Test
	 public void postSetRepositoryTest() {
		 Set inputSet = new Set(4, 5, 1, 13, 30);
		 
		 Set outputSet = setRepository.save(inputSet);
		 Assert.assertNotNull(outputSet);
	 }
	 
	 @Test
	 public void getSetRepositoryTest(){
		 Set outputSet = setRepository.findOne(id1);
		 
		 Assert.assertEquals(1, outputSet.getExerciseId());
		 Assert.assertEquals(20, outputSet.getMaxTime());
		 Assert.assertEquals(10, outputSet.getPoints());
		 Assert.assertEquals(5, outputSet.getRepeats());
	 }
	 
	 @Test
	 public void putSetRepositoryTest() {
		 Set inputSet = new Set(id3, 5, 1, 13, 30);
		 Set outputSet = setRepository.save(inputSet);
		 
		 Assert.assertEquals(1, outputSet.getExerciseId());
		 Assert.assertEquals(30, outputSet.getMaxTime());
		 Assert.assertEquals(13, outputSet.getPoints());
		 Assert.assertEquals(5, outputSet.getRepeats());
	 }
	 
	 @Test
	 public void deleteSetRespositoryTest(){
		 setRepository.delete(id3);
		 Set outputSet = setRepository.findOne(id3);
		 
		 Assert.assertTrue(outputSet == null);
	 }
	 
	 @Test
	 public void getListOfSetsByExerciseIdTest() {
		 List<Set> sets = setRepository.getSetsByExerciseId(1);
		 
		 Assert.assertTrue(sets.size() == 1);
	 }
}
