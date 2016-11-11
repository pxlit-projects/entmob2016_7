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

import be.pxl.groep7.dao.IUserRepository;
import be.pxl.groep7.models.User;
import be.pxl.groep7.serviceImpl.UserServiceImpl;
import be.pxl.groep7.test.config.TestConfigLite;

@RunWith(MockitoJUnitRunner.class)
@ContextConfiguration(classes = TestConfigLite.class)
@SpringBootTest
public class UserServiceTest {

	@Mock
	IUserRepository repMock;
	
	@InjectMocks
	public UserServiceImpl userService;
	
	@Test
	public void createOrUpdateUserTest() {
		User user = new User(1, "Kim", "banana", 169, 59);
		Mockito.when(repMock.save(user)).thenReturn(user);
		
		User user2 = userService.createOrUpdateUser(user);
		
		Assert.assertEquals(user, user2);
	}
	
	@Test
	public void findUserByIdTest() {
		User user =  new User(1, "Kim", "banana", 169, 59);
		Mockito.when(repMock.findOne(1)).thenReturn(user);
		
		User user2 = userService.findUserById(1);
		
		Assert.assertEquals(user, user2);
	}
	
	@Test(expected=Exception.class)
	public void deleteUserTest() {
		Mockito.doThrow(Exception.class).when(repMock).delete(1);
		userService.deleteUserById(1);
	}
	
	@Test
	public void doesUserExistTest() {
		Mockito.when(repMock.exists(1)).thenReturn(true);
		boolean exists = userService.doesUserExist(1);
		
		Assert.assertTrue(exists);
	}
}
