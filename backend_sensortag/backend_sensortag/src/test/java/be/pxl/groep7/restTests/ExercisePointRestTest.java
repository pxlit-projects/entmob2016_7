package be.pxl.groep7.restTests;

import static java.util.Arrays.asList;
import static org.assertj.core.api.Assertions.assertThat;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.delete;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.put;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.content;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

import java.io.IOException;

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

import be.pxl.groep7.dao.IExercisePointRepository;
import be.pxl.groep7.models.ExercisePoint;
import be.pxl.groep7.rest.ExercisePointRestController;
import be.pxl.groep7.services.IExercisePointService;
import be.pxl.groep7.test.config.TestConfig;

@RunWith(SpringRunner.class)
@ContextConfiguration(classes = TestConfig.class)
@SpringBootTest
public class ExercisePointRestTest {


	private MockMvc mockMvc;
	
	private HttpMessageConverter mappingJackson2HttpMessageConverter;
	
	@Autowired
	private WebApplicationContext webAppContext;
	
	@Mock
	IExercisePointService serviceMock;
	
	@Mock
	IExercisePointRepository repMock;
	
	public ExercisePointRestController exercisePointController;
	
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
		exercisePointController = new ExercisePointRestController(serviceMock, repMock);
		mockMvc = MockMvcBuilders.standaloneSetup(new ExercisePointRestController(serviceMock, repMock))
				.build();
	}
	
	
	@Test
	public void getExistingExercisePointTest() throws IOException, Exception {
		ExercisePoint exercisePoint1 = new ExercisePoint(1, 1.0, 2.3, 1.5);
		
		Mockito.when(serviceMock.findExercisePointById(1)).thenReturn(exercisePoint1);
		Mockito.when(repMock.findOne(1)).thenReturn(exercisePoint1);
		
		mockMvc.perform(get(ExercisePointRestController.BASEURL+"/getById/" + exercisePoint1.getId())													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isOk())
				.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
				.andExpect(content().json(asJson(exercisePoint1)));
	}
	
	@Test
	public void getNonExistingExercisePointFailsTest() throws IOException, Exception {
		ExercisePoint exercisePoint1 = new ExercisePoint(1, 1.0, 2.3, 1.5);
		
		Mockito.when(serviceMock.findExercisePointById(1)).thenReturn(null);
		Mockito.when(repMock.findOne(1)).thenReturn(null);
		
		mockMvc.perform(get(ExercisePointRestController.BASEURL+"/getById/" + exercisePoint1.getId())													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
	}
	
	@Test
	public void postOneExercisePointTest() throws IOException, Exception {
		ExercisePoint exercisePoint1 = new ExercisePoint(1, 1.0, 2.3, 1.5);
		
		Mockito.when(serviceMock.createOrUpdateExercisePoint(exercisePoint1)).thenReturn(exercisePoint1);
		Mockito.when(serviceMock.doesExercisePointExist(1)).thenReturn(false);
		Mockito.when(repMock.save(exercisePoint1)).thenReturn(exercisePoint1);
		
		 mockMvc.perform(post(ExercisePointRestController.BASEURL)
				 	.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456"))
	                .content(asJson(exercisePoint1))
	                .contentType(MediaType.APPLICATION_JSON_UTF8))
	                .andExpect(status().isNoContent());
	}
	
	@Test
	public void postExistingExercisePointFails() throws IOException, Exception {
		ExercisePoint exercisePoint1 = new ExercisePoint(1, 1.0, 2.3, 1.5);
		
		Mockito.when(serviceMock.createOrUpdateExercisePoint(exercisePoint1)).thenReturn(exercisePoint1);
		Mockito.when(serviceMock.doesExercisePointExist(1)).thenReturn(true);
		Mockito.when(repMock.save(exercisePoint1)).thenReturn(exercisePoint1);
		
		 mockMvc.perform(post(ExercisePointRestController.BASEURL)
				 	.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456"))
	                .content(asJson(exercisePoint1))
	                .contentType(MediaType.APPLICATION_JSON_UTF8))
	                .andExpect(status().isConflict());
	}
	
	@Test
	public void putExistingExercisePoint() throws IOException, Exception {
		ExercisePoint exercisePoint1 = new ExercisePoint(1, 1.0, 2.3, 1.5);
		
		Mockito.when(serviceMock.createOrUpdateExercisePoint(exercisePoint1)).thenReturn(exercisePoint1);
		Mockito.when(serviceMock.doesExercisePointExist(1)).thenReturn(true);
		Mockito.when(repMock.save(exercisePoint1)).thenReturn(exercisePoint1);
		
		mockMvc.perform(put(ExercisePointRestController.BASEURL + "/" + exercisePoint1.getId())	
				.header("host", "localhost:8080")	
				.content(asJson(exercisePoint1))
				.contentType(MediaType.APPLICATION_JSON_UTF8)
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNoContent())
				.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
				.andExpect(content().json(asJson(exercisePoint1)));
	}
	
	@Test
	public void putNonExistingExercisePointFails() throws IOException, Exception {
		ExercisePoint exercisePoint1 = new ExercisePoint(1, 1.0, 2.3, 1.5);
		
		Mockito.when(serviceMock.createOrUpdateExercisePoint(exercisePoint1)).thenReturn(exercisePoint1);
		Mockito.when(serviceMock.doesExercisePointExist(1)).thenReturn(false);
		Mockito.when(repMock.save(exercisePoint1)).thenReturn(exercisePoint1);
		
		mockMvc.perform(put(ExercisePointRestController.BASEURL + "/" + exercisePoint1.getId())	
				.header("host", "localhost:8080")	
				.content(asJson(exercisePoint1))
				.contentType(MediaType.APPLICATION_JSON_UTF8)
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
	}
	
	@Test
	public void deleteExistingExercisePoint() throws Exception {
		ExercisePoint exercisePoint1 = new ExercisePoint(1, 1.0, 2.3, 1.5);
		
		Mockito.when(serviceMock.createOrUpdateExercisePoint(exercisePoint1)).thenReturn(exercisePoint1);
		Mockito.when(serviceMock.doesExercisePointExist(1)).thenReturn(true);
		Mockito.when(repMock.save(exercisePoint1)).thenReturn(exercisePoint1);
		
		mockMvc.perform(delete(ExercisePointRestController.BASEURL+"/" + exercisePoint1.getId())	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNoContent());
	}
	
	@Test
	public void deleteNonExistingExercisePointFails() throws Exception {
		ExercisePoint exercisePoint1 = new ExercisePoint(1, 1.0, 2.3, 1.5);
		
		Mockito.when(serviceMock.createOrUpdateExercisePoint(exercisePoint1)).thenReturn(exercisePoint1);
		Mockito.when(serviceMock.doesExercisePointExist(1)).thenReturn(false);
		Mockito.when(repMock.save(exercisePoint1)).thenReturn(exercisePoint1);
		
		mockMvc.perform(delete(ExercisePointRestController.BASEURL+"/" + exercisePoint1.getId())	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
	}
	
	protected String asJson(Object o) throws IOException {
		MockHttpOutputMessage mockHttpOutputMessage = new MockHttpOutputMessage();
		this.mappingJackson2HttpMessageConverter.write(o, MediaType.APPLICATION_JSON, mockHttpOutputMessage);
		return mockHttpOutputMessage.getBodyAsString();
	}
	
}
