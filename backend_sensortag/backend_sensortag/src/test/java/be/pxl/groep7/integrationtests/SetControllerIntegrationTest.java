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
import be.pxl.groep7.dao.ISetRepository;
import be.pxl.groep7.models.ExercisePoint;
import be.pxl.groep7.models.Set;
import be.pxl.groep7.rest.ExercisePointRestController;
import be.pxl.groep7.rest.ExerciseRestController;
import be.pxl.groep7.rest.SetRestController;

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
public class SetControllerIntegrationTest {

	private MockMvc mockMvc;

	private HttpMessageConverter mappingJackson2HttpMessageConverter;

	@Autowired
	public ISetRepository setRepository;

	@Autowired
	private WebApplicationContext webAppContext;
	
	private Set set1;
	private Set set2;
	private Set set3;

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
		setRepository.deleteAll();
		mockMvc = MockMvcBuilders.webAppContextSetup(webAppContext)
				.apply(SecurityMockMvcConfigurers.springSecurity())
				.build();

		set1 = new Set();
		set1.setExerciseId(1);
		set1.setMaxTime(500);
		set1.setPoints(5);
		set1.setRepeats(20);
		set1 = setRepository.save(set1);

		set2 = new Set();
		set2.setExerciseId(2);
		set2.setMaxTime(100);
		set2.setPoints(15);
		set2.setRepeats(5);
		set2 = setRepository.save(set2);
		
		set3 = new Set();
		set3.setExerciseId(1);
		set3.setMaxTime(350);
		set3.setPoints(5);
		set3.setRepeats(5);
		set3 = setRepository.save(set3);
	}
	
	@Test
	public void getAllSetsByExerciseId() throws IOException, Exception {
		mockMvc.perform(get(SetRestController.BASEURL+"/setbyexercise/" + 1)
				.with(user("user").password("123456")))
		.andExpect(status().isOk())
		.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
		.andExpect(content().json(asJson(asList(set1, set3))));
	}

	@Test
	public void getSetById() throws IOException, Exception {
		mockMvc.perform(get(SetRestController.BASEURL+"/getById/" + set1.getId())	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isOk())
				.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
				.andExpect(content().json(asJson(set1)));
	}
	
	@Test
	public void postSetAndTestIfSetCouldBeFoundInDB() throws IOException, Exception {
		Set set4 = new Set();
		set4.setExerciseId(2);
		set4.setMaxTime(255);
		set4.setPoints(15);
		set4.setRepeats(25);
		
		 mockMvc.perform(post(SetRestController.BASEURL)
				 	.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456"))
	                .content(asJson(set4))
	                .contentType(MediaType.APPLICATION_JSON_UTF8))
	                .andExpect(status().isNoContent());
		 
		assertThat(setRepository.findOne(set3.getId()+1).getExerciseId() == set4.getExerciseId());
		assertThat(setRepository.findOne(set3.getId()+1).getMaxTime() == set4.getMaxTime());
		assertThat(setRepository.findOne(set3.getId()+1).getPoints() == set4.getPoints());
		assertThat(setRepository.findOne(set3.getId()+1).getRepeats() == set4.getRepeats());
	}
	
	@Test
	public void putSetAndTestIfEdited() throws IOException, Exception {
		set2.setMaxTime(44);
		
		mockMvc.perform(put(SetRestController.BASEURL + "/" + set2.getId())	
				.header("host", "localhost:8080")	
				.content(asJson(set2))
				.contentType(MediaType.APPLICATION_JSON_UTF8)
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNoContent())
				.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
				.andExpect(content().json(asJson(set2)));
	}
	
	@Test
	public void putSetWithoutGivingValidIdGeneratesNotFoundResponse() throws IOException, Exception {
		set3.setPoints(35);
		
		mockMvc.perform(put(SetRestController.BASEURL + "/" + set3.getId()+1)	
				.header("host", "localhost:8080")	
				.content(asJson(set3))
				.contentType(MediaType.APPLICATION_JSON_UTF8)
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
	}
	
	@Test
	public void deleteSetAndTestIfItIsNotFoundInDB() throws IOException, Exception {
		mockMvc.perform(delete(SetRestController.BASEURL+"/" + set1.getId())	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNoContent());
		
		assertThat(setRepository.exists(set1.getId()) == false);
	}
	
	@Test
	public void deleteSetThatDoesNotExistsAndTestIfNotFoundIsReturned() throws Exception {
		mockMvc.perform(delete(SetRestController.BASEURL+"/" + set3.getId()+1)	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
		
		assertThat(setRepository.exists(set3.getId()) == false);
	}
	
	@Test
	public void testIfGetByIdIsAuthorized() throws IOException, Exception {
		mockMvc.perform(get(SetRestController.BASEURL+"/getById/" + set1.getId())	
				.header("host", "localhost:8080"))													
				.andExpect(status().is(401));
	}

	protected String asJson(Object o) throws IOException {
		MockHttpOutputMessage mockHttpOutputMessage = new MockHttpOutputMessage();
		this.mappingJackson2HttpMessageConverter.write(o, MediaType.APPLICATION_JSON, mockHttpOutputMessage);
		return mockHttpOutputMessage.getBodyAsString();
	}
	
}
