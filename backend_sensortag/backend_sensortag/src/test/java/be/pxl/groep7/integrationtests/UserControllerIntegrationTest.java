package be.pxl.groep7.integrationtests;

import java.io.IOException;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.MediaType;
import org.springframework.http.converter.HttpMessageConverter;
import org.springframework.http.converter.json.MappingJackson2HttpMessageConverter;
import org.springframework.mock.http.MockHttpOutputMessage;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.setup.MockMvcBuilders;
import org.springframework.web.context.WebApplicationContext;
import org.springframework.security.test.web.servlet.setup.SecurityMockMvcConfigurers;
import org.springframework.security.test.web.servlet.request.SecurityMockMvcRequestPostProcessors;

import be.pxl.groep7.AppConfig;
import be.pxl.groep7.dao.IUserRepository;
import be.pxl.groep7.models.User;
import be.pxl.groep7.rest.UserRestController;

import static org.assertj.core.api.Assertions.assertThat;
import static java.util.Arrays.asList;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.put;
import static org.springframework.security.test.web.servlet.request.SecurityMockMvcRequestPostProcessors.user;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.delete;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.content;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.context.web.WebAppConfiguration;

@RunWith(SpringRunner.class)
@SpringBootTest
@ContextConfiguration(classes = AppConfig.class)
@WebAppConfiguration
public class UserControllerIntegrationTest {
	
	private MockMvc mockMvc;

	private HttpMessageConverter mappingJackson2HttpMessageConverter;

	@Autowired
	public IUserRepository userRepository;

	@Autowired
	private WebApplicationContext webAppContext;
	
	private User user1;
	private User user2;
	private User user3;

	@Autowired
	void setConverters(HttpMessageConverter<?>[] converters){
		mappingJackson2HttpMessageConverter = asList(converters)
				.stream()
				.filter(hmc -> hmc instanceof MappingJackson2HttpMessageConverter)
				.findAny()
				.get();

		assertThat(mappingJackson2HttpMessageConverter)
		.isNotNull()
		.describedAs("the JSON message converter must not be null");
	}

	@Before
	public void setUp() throws Exception {
		userRepository.deleteAll();
		mockMvc = MockMvcBuilders.webAppContextSetup(webAppContext)
				.apply(SecurityMockMvcConfigurers.springSecurity())
				.build();

		user1 = new User();
		user1.setHeight(169);
		user1.setName("Kim");
		user1.setPassword("password");
		user1.setWeight(59);
		user1 = userRepository.save(user1);

		user2 = new User();
		user2.setHeight(30);
		user2.setName("Stuart");
		user2.setPassword("banana");
		user2.setWeight(1);
		user2 = userRepository.save(user2);
		
		user3 = new User();
		user3.setHeight(45);
		user3.setName("Tim");
		user3.setPassword("gelato");
		user3.setWeight(1);
		user3 = userRepository.save(user3);
	}

	@Test
	public void getUserById() throws IOException, Exception {
		mockMvc.perform(get(UserRestController.BASEURL+"/getById/" + user1.getId())	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isOk())
				.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
				.andExpect(content().json(asJson(user1)));
	}
	
	@Test
	public void postUserAndTestIfSetCouldBeFoundInDB() throws IOException, Exception {
		User user4 = new User();
		user4.setHeight(45);
		user4.setName("Purple Minion");
		user4.setPassword("gru");
		user4.setWeight(2);
		
		 mockMvc.perform(post(UserRestController.BASEURL)
				 	.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456"))
	                .content(asJson(user4))
	                .contentType(MediaType.APPLICATION_JSON_UTF8))
	                .andExpect(status().isNoContent());
		 
		assertThat(userRepository.findOne(user3.getId()+1).getHeight() == user4.getHeight());
		assertThat(userRepository.findOne(user3.getId()+1).getName().equals(user4.getName()));
		assertThat(userRepository.findOne(user3.getId()+1).getPassword().equals(user4.getPassword()));
		assertThat(userRepository.findOne(user3.getId()+1).getWeight() == user4.getWeight());
	}
	
	@Test
	public void putUserAndTestIfEdited() throws IOException, Exception {
		user2.setHeight(144);
		
		mockMvc.perform(put(UserRestController.BASEURL + "/" + user2.getId())	
				.header("host", "localhost:8080")	
				.content(asJson(user2))
				.contentType(MediaType.APPLICATION_JSON_UTF8)
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNoContent())
				.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
				.andExpect(content().json(asJson(user2)));
	}
	
	@Test
	public void putSetWithoutGivingValidIdGeneratesNotFoundResponse() throws IOException, Exception {
		user3.setHeight(135);
		
		mockMvc.perform(put(UserRestController.BASEURL + "/" + 0)	
				.header("host", "localhost:8080")	
				.content(asJson(user3))
				.contentType(MediaType.APPLICATION_JSON_UTF8)
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
	}
	
	@Test
	public void deleteUserAndTestIfItIsNotFoundInDB() throws IOException, Exception {
		mockMvc.perform(delete(UserRestController.BASEURL+"/" + user1.getId())	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNoContent());
		
		assertThat(userRepository.exists(user1.getId()) == false);
	}
	
	@Test
	public void deleteUserThatDoesNotExistsAndTestIfNotFoundIsReturned() throws Exception {
		mockMvc.perform(delete(UserRestController.BASEURL+"/" + user3.getId()+1)	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
		
		assertThat(userRepository.exists(user3.getId()) == false);
	}
	
	@Test
	public void testIfGetByIdIsAuthorized() throws IOException, Exception {
		mockMvc.perform(get(UserRestController.BASEURL+"/getById/" + user1.getId())	
				.header("host", "localhost:8080"))													
				.andExpect(status().is(401));
	}

	protected String asJson(Object o) throws IOException {
		MockHttpOutputMessage mockHttpOutputMessage = new MockHttpOutputMessage();
		this.mappingJackson2HttpMessageConverter.write(o, MediaType.APPLICATION_JSON, mockHttpOutputMessage);
		return mockHttpOutputMessage.getBodyAsString();
	}
}
