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
import be.pxl.groep7.dao.IExerciseRepository;
import be.pxl.groep7.models.Exercise;
import be.pxl.groep7.rest.ExerciseRestController;

import static org.assertj.core.api.Assertions.assertThat;
import static java.util.Arrays.asList;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.put;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.delete;
import static org.springframework.security.test.web.servlet.request.SecurityMockMvcRequestPostProcessors.user;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.content;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.context.web.WebAppConfiguration;

@RunWith(SpringRunner.class)
@SpringBootTest
@ContextConfiguration(classes = AppConfig.class)
@WebAppConfiguration
public class ExerciseControllerIntegrationTest {

	private MockMvc mockMvc;

	private HttpMessageConverter mappingJackson2HttpMessageConverter;

	@Autowired
	public IExerciseRepository exerciseRepository;

	@Autowired
	private WebApplicationContext webAppContext;
	
	private Exercise exercise1;
	private Exercise exercise2;
	private Exercise exercise3;

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
		exerciseRepository.deleteAll();
		mockMvc = MockMvcBuilders.webAppContextSetup(webAppContext)
				.apply(SecurityMockMvcConfigurers.springSecurity())
				.build();

		exercise1 = new Exercise();
		exercise1.setCategoryId(1);		
		exercise1.setDescription("Dit is oefening 1");
		exercise1.setName("Oefening 1");
		exercise1 = exerciseRepository.save(exercise1);

		exercise2 = new Exercise();
		exercise2.setCategoryId(2);		
		exercise2.setDescription("Dit is oefening 2");
		exercise2.setName("Oefening 2");
		exercise2 = exerciseRepository.save(exercise2);
		
		exercise3 = new Exercise();
		exercise3.setCategoryId(1);		
		exercise3.setDescription("Dit is oefening 3");
		exercise3.setName("Oefening 3");
		exercise3 = exerciseRepository.save(exercise3);
	}

	@Test
	public void getAllExercisesByCategoryId() throws IOException, Exception {
		mockMvc.perform(get(ExerciseRestController.BASEURL+"/bycategory/" + 1)
				.with(user("user").password("123456")))
		.andExpect(status().isOk())
		.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
		.andExpect(content().json(asJson(asList(exercise1, exercise3))));
	}

	@Test
	public void getExerciseById() throws IOException, Exception {
		mockMvc.perform(get(ExerciseRestController.BASEURL+"/getById/" + exercise1.getId())	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isOk())
				.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
				.andExpect(content().json(asJson(exercise1)));
	}
	
	@Test
	public void postExerciseAndTestIfExerciseCouldBeFoundInDB() throws IOException, Exception {
		Exercise exercise4 = new Exercise();
		exercise4.setCategoryId(2);		
		exercise4.setDescription("Dit is oefening 4");
		exercise4.setName("Oefening 4");
		
		 mockMvc.perform(post(ExerciseRestController.BASEURL)
				 	.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456"))
	                .content(asJson(exercise4))
	                .contentType(MediaType.APPLICATION_JSON_UTF8))
	                .andExpect(status().isNoContent());
		 
		assertThat(exerciseRepository.findOne(exercise3.getId()+1).getCategoryId() == exercise4.getCategoryId());
		assertThat(exerciseRepository.findOne(exercise3.getId()+1).getDescription().equals(exercise4.getDescription()));
		assertThat(exerciseRepository.findOne(exercise3.getId()+1).getName().equals(exercise4.getName()));
	}
	
	@Test
	public void putExerciseAndTestIfEdited() throws IOException, Exception {
		exercise2.setName("New Name");
		
		mockMvc.perform(put(ExerciseRestController.BASEURL + "/" + exercise2.getId())	
				.header("host", "localhost:8080")	
				.content(asJson(exercise2))
				.contentType(MediaType.APPLICATION_JSON_UTF8)
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNoContent())
				.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
				.andExpect(content().json(asJson(exercise2)));
	}
	
	@Test
	public void putExerciseWithoutGivingValidIdGeneratesNotFoundResponse() throws IOException, Exception {
		exercise3.setCategoryId(3);
		
		mockMvc.perform(put(ExerciseRestController.BASEURL + "/" + 0)	
				.header("host", "localhost:8080")	
				.content(asJson(exercise3))
				.contentType(MediaType.APPLICATION_JSON_UTF8)
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
	}
	
	@Test
	public void deleteExerciseAndTestIfItIsNotFoundInDB() throws IOException, Exception {
		mockMvc.perform(delete(ExerciseRestController.BASEURL+"/" + exercise1.getId())	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNoContent());
		
		assertThat(exerciseRepository.exists(exercise1.getId()) == false);
	}
	
	@Test
	public void deleteExerciseThatDoesNotExistsAndTestIfNotFoundIsReturned() throws Exception {
		mockMvc.perform(delete(ExerciseRestController.BASEURL+"/" + exercise3.getId()+1)	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
		
		assertThat(exerciseRepository.exists(exercise3.getId()) == false);
	}
	
	@Test
	public void testIfGetByIdIsAuthorized() throws IOException, Exception {
		mockMvc.perform(get(ExerciseRestController.BASEURL+"/getById/" + exercise1.getId())	
				.header("host", "localhost:8080"))													
				.andExpect(status().is(401));
	}

	protected String asJson(Object o) throws IOException {
		MockHttpOutputMessage mockHttpOutputMessage = new MockHttpOutputMessage();
		this.mappingJackson2HttpMessageConverter.write(o, MediaType.APPLICATION_JSON, mockHttpOutputMessage);
		return mockHttpOutputMessage.getBodyAsString();
	}
}
