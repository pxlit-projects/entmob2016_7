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

import be.pxl.groep7.dao.IExerciseRepository;
import be.pxl.groep7.models.Exercise;
import be.pxl.groep7.models.Exercise;
import be.pxl.groep7.serviceImpl.ExerciseServiceImpl;
import be.pxl.groep7.test.config.TestConfigLite;

@RunWith(MockitoJUnitRunner.class)
@ContextConfiguration(classes = TestConfigLite.class)
@SpringBootTest
public class ExerciseServiceTest {

	@Mock
	IExerciseRepository repMock;
	
	@InjectMocks
	public ExerciseServiceImpl exerciseService;
	
	@Test
	public void createOrUpdateExerciseTest() {
		Exercise exercise = new Exercise(1, "Oefening 1", "Dit is een oefening", 1);
		Mockito.when(repMock.save(exercise)).thenReturn(exercise);
		
		Exercise exercise2 = exerciseService.createOrUpdateExercise(exercise);
		
		Assert.assertEquals(exercise, exercise2);
	}
	
	@Test
	public void findExerciseByIdTest() {
		Exercise exercise = new Exercise(1, "Oefening 1", "Dit is een oefening", 1);
		Mockito.when(repMock.findOne(1)).thenReturn(exercise);
		
		Exercise exercise2 = exerciseService.findExerciseById(1);
		
		Assert.assertEquals(exercise, exercise2);
	}
	
	@Test
	public void getAllExercisesByCategoryIdTest() {
		List<Exercise> exercises = new ArrayList<>();
		exercises.add(new Exercise(1, "Oefening 1", "Dit is een oefening", 1));
		exercises.add(new Exercise(2, "Oefening 2", "Dit is ook een oefening", 1));
		
		Mockito.when(repMock.getExercisesByCategoryId(1)).thenReturn(exercises);
		
		List<Exercise> exercises2 = exerciseService.getAllExercisesByCategoryId(1);
		
		Assert.assertEquals(exercises.size(), exercises2.size());
		
		for (int i=0; i<exercises.size(); i++){
			Assert.assertEquals(exercises.get(i).getDescription(), exercises2.get(i).getDescription());
			Assert.assertEquals(exercises.get(i).getName(), exercises2.get(i).getName());
			Assert.assertEquals(exercises.get(i).getId(), exercises2.get(i).getId());
			Assert.assertEquals(exercises.get(i).getCategoryId(), exercises2.get(i).getCategoryId());
		}
	}
	
	
	@Test(expected=Exception.class)
	public void deleteExerciseTest() {
		Mockito.doThrow(Exception.class).when(repMock).delete(1);
		exerciseService.deleteExerciseById(1);
	}
	
	@Test
	public void doesExerciseExistTest() {
		Mockito.when(repMock.exists(1)).thenReturn(true);
		boolean exists = exerciseService.doesExerciseExist(1);
		
		Assert.assertTrue(exists);
	}
	
}
