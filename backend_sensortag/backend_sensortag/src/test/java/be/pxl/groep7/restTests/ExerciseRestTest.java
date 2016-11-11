package be.pxl.groep7.restTests;

import static java.util.Arrays.asList;
import static org.assertj.core.api.Assertions.assertThat;
import static org.springframework.security.test.web.servlet.request.SecurityMockMvcRequestPostProcessors.user;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.delete;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.put;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.content;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.MediaType;
import org.springframework.http.converter.HttpMessageConverter;
import org.springframework.http.converter.json.MappingJackson2HttpMessageConverter;
import org.springframework.mock.http.MockHttpOutputMessage;
import org.springframework.security.test.web.servlet.request.SecurityMockMvcRequestPostProcessors;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.setup.MockMvcBuilders;
import org.springframework.web.context.WebApplicationContext;

import be.pxl.groep7.dao.IExerciseRepository;
import be.pxl.groep7.models.Exercise;
import be.pxl.groep7.rest.ExerciseRestController;
import be.pxl.groep7.services.IExerciseService;
import be.pxl.groep7.test.config.TestConfig;

@RunWith(SpringRunner.class)
@ContextConfiguration(classes = TestConfig.class)
@SpringBootTest
public class ExerciseRestTest {

private MockMvc mockMvc;
	
	private HttpMessageConverter mappingJackson2HttpMessageConverter;
	
	@Autowired
	private WebApplicationContext webAppContext;
	
	@Mock
	IExerciseService serviceMock;
	
	@Mock
	IExerciseRepository repMock;
	
	public ExerciseRestController exerciseController;
	
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
		exerciseController = new ExerciseRestController(serviceMock, repMock);
		mockMvc = MockMvcBuilders.standaloneSetup(exerciseController)
				.build();
	}
	
	@Test
	public void getAllExercisesByCategoryIdTest() throws IOException, Exception {
		Exercise exercise1 = new Exercise(1, "Oefening 1", "Dit is een oefening", 1);
		Exercise exercise2 = new Exercise(2, "Oefening 2", "Dit is nog een oefening", 1);
		Exercise exercise3 = new Exercise(1, "Oefening 3", "Dit is ook een oefening", 1);
		
		List<Exercise> exercises = new ArrayList<>();
		exercises.add(exercise1);
		exercises.add(exercise2);
		exercises.add(exercise3);
		
		Mockito.when(serviceMock.getAllExercisesByCategoryId(1)).thenReturn(exercises);
		Mockito.when(repMock.getExercisesByCategoryId(1)).thenReturn(exercises);
		
		mockMvc.perform(get(ExerciseRestController.BASEURL+"/bycategory/" + 1)
		.with(user("user").password("123456")))
		.andExpect(status().isOk())
		.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
		.andExpect(content().json(asJson(asList(exercise1, exercise2, exercise3))));
	}
	
	@Test
	public void getExistingExerciseTest() throws IOException, Exception {
		Exercise exercise1 = new Exercise(1, "Oefening 1", "Dit is een oefening", 1);
		
		Mockito.when(serviceMock.findExerciseById(1)).thenReturn(exercise1);
		Mockito.when(repMock.findOne(1)).thenReturn(exercise1);
		
		mockMvc.perform(get(ExerciseRestController.BASEURL+"/getById/" + exercise1.getId())													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isOk())
				.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
				.andExpect(content().json(asJson(exercise1)));
	}
	
	@Test
	public void getNonExistingExerciseFailsTest() throws IOException, Exception {
		Exercise exercise1 = new Exercise(1, "Oefening 1", "Dit is een oefening", 1);
		
		Mockito.when(serviceMock.findExerciseById(1)).thenReturn(null);
		Mockito.when(repMock.findOne(1)).thenReturn(null);
		
		mockMvc.perform(get(ExerciseRestController.BASEURL+"/getById/" + exercise1.getId())													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
	}
	
	@Test
	public void postOneExerciseTest() throws IOException, Exception {
		Exercise exercise1 = new Exercise(1, "Oefening 1", "Dit is een oefening", 1);
		
		Mockito.when(serviceMock.createOrUpdateExercise(exercise1)).thenReturn(exercise1);
		Mockito.when(serviceMock.doesExerciseExist(1)).thenReturn(false);
		Mockito.when(repMock.save(exercise1)).thenReturn(exercise1);
		
		 mockMvc.perform(post(ExerciseRestController.BASEURL)
				 	.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456"))
	                .content(asJson(exercise1))
	                .contentType(MediaType.APPLICATION_JSON_UTF8))
	                .andExpect(status().isNoContent());
	}
	
	@Test
	public void postExistingExerciseFails() throws IOException, Exception {
		Exercise exercise1 = new Exercise(1, "Oefening 1", "Dit is een oefening", 1);
		
		Mockito.when(serviceMock.createOrUpdateExercise(exercise1)).thenReturn(exercise1);
		Mockito.when(serviceMock.doesExerciseExist(1)).thenReturn(true);
		Mockito.when(repMock.save(exercise1)).thenReturn(exercise1);
		
		 mockMvc.perform(post(ExerciseRestController.BASEURL)
				 	.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456"))
	                .content(asJson(exercise1))
	                .contentType(MediaType.APPLICATION_JSON_UTF8))
	                .andExpect(status().isConflict());
	}
	
	@Test
	public void putExistingExercise() throws IOException, Exception {
		Exercise exercise1 = new Exercise(1, "Oefening 1", "Dit is een oefening", 1);
		
		Mockito.when(serviceMock.doesExerciseExist(1)).thenReturn(true);
		Mockito.when(serviceMock.createOrUpdateExercise(exercise1)).thenReturn(exercise1);
		Mockito.when(repMock.save(exercise1)).thenReturn(exercise1);
		
		mockMvc.perform(put(ExerciseRestController.BASEURL + "/" + exercise1.getId())	
				.header("host", "localhost:8080")	
				.content(asJson(exercise1))
				.contentType(MediaType.APPLICATION_JSON_UTF8)
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNoContent())
				.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
				.andExpect(content().json(asJson(exercise1)));
	}
	
	@Test
	public void putNonExistingExerciseFails() throws IOException, Exception {
		Exercise exercise1 = new Exercise(1, "Oefening 1", "Dit is een oefening", 1);
		
		Mockito.when(serviceMock.createOrUpdateExercise(exercise1)).thenReturn(exercise1);
		Mockito.when(serviceMock.doesExerciseExist(1)).thenReturn(false);
		Mockito.when(repMock.save(exercise1)).thenReturn(exercise1);
		
		mockMvc.perform(put(ExerciseRestController.BASEURL + "/" + exercise1.getId())	
				.header("host", "localhost:8080")	
				.content(asJson(exercise1))
				.contentType(MediaType.APPLICATION_JSON_UTF8)
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
	}
	
	@Test
	public void deleteExistingExercise() throws Exception {
		Exercise exercise1 = new Exercise(1, "Oefening 1", "Dit is een oefening", 1);
		
		Mockito.when(serviceMock.createOrUpdateExercise(exercise1)).thenReturn(exercise1);
		Mockito.when(serviceMock.doesExerciseExist(1)).thenReturn(true);
		Mockito.when(repMock.save(exercise1)).thenReturn(exercise1);
		
		mockMvc.perform(delete(ExerciseRestController.BASEURL+"/" + exercise1.getId())	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNoContent());
	}
	
	@Test
	public void deleteNonExistingExerciseFails() throws Exception {
		Exercise exercise1 = new Exercise(1, "Oefening 1", "Dit is een oefening", 1);
		
		Mockito.when(serviceMock.createOrUpdateExercise(exercise1)).thenReturn(exercise1);
		Mockito.when(serviceMock.doesExerciseExist(1)).thenReturn(false);
		Mockito.when(repMock.save(exercise1)).thenReturn(exercise1);
		
		mockMvc.perform(delete(ExerciseRestController.BASEURL+"/" + exercise1.getId())														
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
	}
	
	protected String asJson(Object o) throws IOException {
		MockHttpOutputMessage mockHttpOutputMessage = new MockHttpOutputMessage();
		this.mappingJackson2HttpMessageConverter.write(o, MediaType.APPLICATION_JSON, mockHttpOutputMessage);
		return mockHttpOutputMessage.getBodyAsString();
	}
}
