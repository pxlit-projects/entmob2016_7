package be.pxl.groep7.repositorytests;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import be.pxl.groep7.AppConfig;
import be.pxl.groep7.dao.IUserRepository;
import be.pxl.groep7.models.User;
import be.pxl.groep7.test.config.TestConfig;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(classes = TestConfig.class)
@DirtiesContext
@SpringBootTest
public class UserRepositoryTest {


	@Autowired
	public IUserRepository userRepository;
	
	private int id1;
	private int id2;
	private int id3;
	
	
	@Before
	public void initialSetupTest() {
		userRepository.deleteAll();
		
		id1 = userRepository.save(new User(1, "Kim", "password", 169, 59)).getId();		
		id2 = userRepository.save(new User(2, "Stuart", "banana", 30, 1)).getId();
		id3 = userRepository.save(new User(3, "Ooglax", "bananaSplit", 30, 2)).getId();
	}
	
	 @Test
	 public void postUserRepositoryTest() {
		 User inputUser = new User(4, "Cloud Strife", "Nibelheim", 173, 61);
		 
		 User outputUser = userRepository.save(inputUser);
		 Assert.assertNotNull(outputUser);
	 }
	 
	 @Test
	 public void getUserRepositoryTest(){
		 User outputUser = userRepository.findOne(id1);
		 
		 Assert.assertEquals(169, outputUser.getHeight());
		 Assert.assertEquals(59, outputUser.getWeight());
		 Assert.assertEquals("Kim", outputUser.getName());
		 Assert.assertEquals("password", outputUser.getPassword());
	 }
	 
	 @Test
	 public void putUserRepositoryTest() {
		 User inputUser = new User(id3, "Geralt of Rivia", "Yennefer", 175, 67);
		 User outputUser = userRepository.save(inputUser);
		 
		 Assert.assertEquals(175, outputUser.getHeight());
		 Assert.assertEquals(67, outputUser.getWeight());
		 Assert.assertEquals("Geralt of Rivia", outputUser.getName());
		 Assert.assertEquals("Yennefer", outputUser.getPassword());
	 }
	 
	 @Test
	 public void deleteUserRespositoryTest(){
		 userRepository.delete(id3);
		 User outputUser = userRepository.findOne(id3);
		 
		 Assert.assertTrue(outputUser == null);
	 }
}
