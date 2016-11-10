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
import be.pxl.groep7.dao.IExerciseRepository;
import be.pxl.groep7.models.Exercise;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(classes = AppConfig.class)
@WebAppConfiguration
@DirtiesContext
@SpringBootTest
public class ExerciseRepositoryTest {

	@Autowired
	public IExerciseRepository exerciseRepository;
	
	private int id1;
	private int id2;
	private int id3;
	
	
	@Before
	public void initialSetupTest() {
		exerciseRepository.deleteAll();
		
		id1 = exerciseRepository.save(new Exercise(1, "Oefening 1", "Dit is een oefening", 1)).getId();
		id2 = exerciseRepository.save(new Exercise(2, "Oefening 2", "Dit is ook een oefening", 2)).getId();
		id3 = exerciseRepository.save(new Exercise(3, "Oefening 3", "Dit is nog een andere oefening", 1)).getId();
	}
	
	 @Test
	 public void postExerciseRepositoryTest() {
		 Exercise inputExercise = new Exercise(4, "Oefening 4", "Dit is ook nog een oefening", 2);
		 
		 Exercise outputExercise = exerciseRepository.save(inputExercise);
		 Assert.assertNotNull(outputExercise);
	 }
	 
	 @Test
	 public void getExerciseRepositoryTest(){
		 Exercise outputExercise = exerciseRepository.findOne(id1);
		 
		 Assert.assertEquals("Oefening 1", outputExercise.getName());
		 Assert.assertEquals("Dit is een oefening", outputExercise.getDescription());
		 Assert.assertEquals(1, outputExercise.getCategoryId());
	 }
	 
	 @Test
	 public void putExerciseRepositoryTest() {
		 Exercise inputExercise = new Exercise(id3, "Oefening 3", "Dit is een nieuwe oefening", 2);
		 Exercise outputExercise = exerciseRepository.save(inputExercise);
		 
		 Assert.assertEquals("Oefening 3", outputExercise.getName());
		 Assert.assertEquals("Dit is een nieuwe oefening", outputExercise.getDescription());
		 Assert.assertEquals(2, outputExercise.getCategoryId());
		 Assert.assertEquals(id3, outputExercise.getId());
	 }
	 
	 @Test
	 public void deleteExerciseRespositoryTest(){
		 exerciseRepository.delete(id3);
		 Exercise outputExercise = exerciseRepository.findOne(id3);
		 
		 Assert.assertTrue(outputExercise == null);
	 }
	 
	 @Test
	 public void getListOfExercisesByCategoryIdTest() {
		 List<Exercise> exercises = exerciseRepository.getExercisesByCategoryId(2);
		 
		 Assert.assertTrue(exercises.size() == 1);
	 }
}
