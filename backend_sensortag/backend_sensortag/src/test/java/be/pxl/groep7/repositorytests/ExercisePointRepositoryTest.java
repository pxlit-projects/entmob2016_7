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
import be.pxl.groep7.dao.IExercisePointRepository;
import be.pxl.groep7.models.ExercisePoint;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(classes = AppConfig.class)
@WebAppConfiguration
@DirtiesContext
@SpringBootTest
public class ExercisePointRepositoryTest {

	@Autowired
	public IExercisePointRepository exercisePointRepository;
	
	private int id1;
	private int id2;
	private int id3;
	
	
	@Before
	public void initialSetupTest() {
		exercisePointRepository.deleteAll();
		
		id1 = exercisePointRepository.save(new ExercisePoint(1, 1, 1, 1)).getId();
		id2 = exercisePointRepository.save(new ExercisePoint(2, 1, 3, 2)).getId();
		id3 = exercisePointRepository.save(new ExercisePoint(3, 2, 1, 3)).getId();
	}
	
	 @Test
	 public void postExercisePointRepositoryTest() {
		 ExercisePoint inputExercisePoint = new ExercisePoint(4, 2, 8, 3);
		 
		 ExercisePoint outputExercisePoint = exercisePointRepository.save(inputExercisePoint);
		 Assert.assertNotNull(outputExercisePoint);
	 }
	 
	 @Test
	 public void getExercisePointRepositoryTest(){
		 ExercisePoint outputExercisePoint = exercisePointRepository.findOne(id1);
		 
		 Assert.assertEquals(1, outputExercisePoint.getX(), 0.01);
		 Assert.assertEquals(1, outputExercisePoint.getY(), 0.01);
		 Assert.assertEquals(1, outputExercisePoint.getZ(), 0.01);
	 }
	 
	 @Test
	 public void putExercisePointRepositoryTest() {
		 ExercisePoint inputExercisePoint = new ExercisePoint(id2,4,2,1);
		 ExercisePoint outputExercisePoint = exercisePointRepository.save(inputExercisePoint);
		 
		 Assert.assertEquals(4, outputExercisePoint.getX(), 0.01);
		 Assert.assertEquals(2, outputExercisePoint.getY(), 0.01);
		 Assert.assertEquals(1, outputExercisePoint.getZ(), 0.01);
	 }
	 
	 @Test
	 public void deleteExercisePointRespositoryTest(){
		 exercisePointRepository.delete(id3);
		 ExercisePoint outputExercisePoint = exercisePointRepository.findOne(id3);
		 
		 Assert.assertTrue(outputExercisePoint == null);
	 }
}
