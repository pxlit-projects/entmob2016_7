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
import be.pxl.groep7.dao.IExercisePointRepository;
import be.pxl.groep7.models.ExercisePoint;
import be.pxl.groep7.rest.ExercisePointRestController;
import be.pxl.groep7.test.config.TestConfig;

import static org.assertj.core.api.Assertions.assertThat;
import static java.util.Arrays.asList;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.put;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.delete;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.content;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.context.web.WebAppConfiguration;

@RunWith(SpringRunner.class)
@SpringBootTest
@ContextConfiguration(classes = TestConfig.class)
@WebAppConfiguration
public class ExercisePointControllerIntegrationTest {

	private MockMvc mockMvc;

	private HttpMessageConverter mappingJackson2HttpMessageConverter;

	@Autowired
	public IExercisePointRepository exercisePointRepository;

	@Autowired
	private WebApplicationContext webAppContext;
	
	private ExercisePoint exercisePoint1;
	private ExercisePoint exercisePoint2;
	private ExercisePoint exercisePoint3;

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
		exercisePointRepository.deleteAll();
		mockMvc = MockMvcBuilders.webAppContextSetup(webAppContext)
				.apply(SecurityMockMvcConfigurers.springSecurity())
				.build();

		exercisePoint1 = new ExercisePoint();
		exercisePoint1.setX(1.14);
		exercisePoint1.setY(2.04);
		exercisePoint1.setZ(0.25);
		exercisePoint1 = exercisePointRepository.save(exercisePoint1);

		exercisePoint2 = new ExercisePoint();
		exercisePoint2.setX(1.78);
		exercisePoint2.setY(1.04);
		exercisePoint2.setZ(3.25);
		exercisePoint2 = exercisePointRepository.save(exercisePoint2);
		
		exercisePoint3 = new ExercisePoint();
		exercisePoint3.setX(3.08);
		exercisePoint3.setY(1.35);
		exercisePoint3.setZ(2.29);
		exercisePoint3 = exercisePointRepository.save(exercisePoint3);
	}

	@Test
	public void getExercisePointById() throws IOException, Exception {
		mockMvc.perform(get(ExercisePointRestController.BASEURL+"/getById/" + exercisePoint1.getId())	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isOk())
				.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
				.andExpect(content().json(asJson(exercisePoint1)));
	}
	
	@Test
	public void postExercisePointAndTestIfExercisePointCouldBeFoundInDB() throws IOException, Exception {
		ExercisePoint exercisePoint4 = new ExercisePoint();
		exercisePoint4.setX(0.54);
		exercisePoint4.setY(3.18);
		exercisePoint4.setZ(1.66);
		
		 mockMvc.perform(post(ExercisePointRestController.BASEURL)
				 	.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456"))
	                .content(asJson(exercisePoint4))
	                .contentType(MediaType.APPLICATION_JSON_UTF8))
	                .andExpect(status().isNoContent());
		 
		assertThat(exercisePointRepository.findOne(exercisePoint3.getId()+1).getX() == exercisePoint4.getX());
		assertThat(exercisePointRepository.findOne(exercisePoint3.getId()+1).getY() == exercisePoint4.getY());
		assertThat(exercisePointRepository.findOne(exercisePoint3.getId()+1).getZ() == exercisePoint4.getZ());
	}
	
	@Test
	public void putExercisePointAndTestIfEdited() throws IOException, Exception {
		exercisePoint2.setX(2.37);
		
		mockMvc.perform(put(ExercisePointRestController.BASEURL + "/" + exercisePoint2.getId())	
				.header("host", "localhost:8080")	
				.content(asJson(exercisePoint2))
				.contentType(MediaType.APPLICATION_JSON_UTF8)
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNoContent())
				.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
				.andExpect(content().json(asJson(exercisePoint2)));
	}
	
	@Test
	public void putExercisePointWithoutGivingValidIdGeneratesNotFoundResponse() throws IOException, Exception {
		exercisePoint3.setZ(4.0);
		
		mockMvc.perform(put(ExercisePointRestController.BASEURL + "/" + 0)	
				.header("host", "localhost:8080")	
				.content(asJson(exercisePoint3))
				.contentType(MediaType.APPLICATION_JSON_UTF8)
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
	}
	
	@Test
	public void deleteExercisePointAndTestIfItIsNotFoundInDB() throws IOException, Exception {
		mockMvc.perform(delete(ExercisePointRestController.BASEURL+"/" + exercisePoint1.getId())	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNoContent());
		
		assertThat(exercisePointRepository.exists(exercisePoint1.getId()) == false);
	}
	
	@Test
	public void deleteExercisePointThatDoesNotExistsAndTestIfNotFoundIsReturned() throws Exception {
		mockMvc.perform(delete(ExercisePointRestController.BASEURL+"/" + exercisePoint3.getId()+1)	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
		
		assertThat(exercisePointRepository.exists(exercisePoint3.getId()) == false);
	}
	
	@Test
	public void testIfGetByIdIsAuthorized() throws IOException, Exception {
		mockMvc.perform(get(ExercisePointRestController.BASEURL+"/getById/" + exercisePoint1.getId())	
				.header("host", "localhost:8080"))													
				.andExpect(status().is(401));
	}

	protected String asJson(Object o) throws IOException {
		MockHttpOutputMessage mockHttpOutputMessage = new MockHttpOutputMessage();
		this.mappingJackson2HttpMessageConverter.write(o, MediaType.APPLICATION_JSON, mockHttpOutputMessage);
		return mockHttpOutputMessage.getBodyAsString();
	}
	
}
