package be.pxl.groep7.serviceTests;

import org.junit.Assert;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.runners.MockitoJUnitRunner;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.ContextConfiguration;

import be.pxl.groep7.dao.IExercisePointRepository;
import be.pxl.groep7.models.ExercisePoint;
import be.pxl.groep7.serviceImpl.ExercisePointServiceImpl;
import be.pxl.groep7.test.config.TestConfigLite;

@RunWith(MockitoJUnitRunner.class)
@ContextConfiguration(classes = TestConfigLite.class)
@SpringBootTest
public class ExercisePointServiceTest {

	@Mock
	IExercisePointRepository repMock;
	
	@InjectMocks
	public ExercisePointServiceImpl exercisePointService;
	
	@Test
	public void createOrUpdateExercisePointTest() {
		ExercisePoint exercisePoint = new ExercisePoint(1, 2.0, 1.0, 1.4);
		Mockito.when(repMock.save(exercisePoint)).thenReturn(exercisePoint);
		
		ExercisePoint exercisePoint2 = exercisePointService.createOrUpdateExercisePoint(exercisePoint);
		
		Assert.assertEquals(exercisePoint, exercisePoint2);
	}
	
	@Test
	public void findExercisePointByIdTest() {
		ExercisePoint exercisePoint = new ExercisePoint(1, 2.0, 1.0, 1.4);
		Mockito.when(repMock.findOne(1)).thenReturn(exercisePoint);
		
		ExercisePoint exercisePoint2 = exercisePointService.findExercisePointById(1);
		
		Assert.assertEquals(exercisePoint, exercisePoint2);
	}
	
	
	@Test(expected=Exception.class)
	public void deleteExercisePointTest() {
		Mockito.doThrow(Exception.class).when(repMock).delete(1);
		exercisePointService.deleteExercisePointById(1);
	}
	
	@Test
	public void doesExercisePointExistTest() {
		Mockito.when(repMock.exists(1)).thenReturn(true);
		boolean exists = exercisePointService.doesExercisePointExist(1);
		
		Assert.assertTrue(exists);
	}
}
