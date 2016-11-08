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
import be.pxl.groep7.dao.ICompletedSetRepository;
import be.pxl.groep7.models.CompletedSet;
import be.pxl.groep7.rest.CompletedSetRestController;

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
public class CompletedSetControllerIntegrationTest {

	private MockMvc mockMvc;

	private HttpMessageConverter mappingJackson2HttpMessageConverter;

	@Autowired
	public ICompletedSetRepository completedSetRepository;

	@Autowired
	private WebApplicationContext webAppContext;
	
	private CompletedSet completedSet1;
	private CompletedSet completedSet2;
	private CompletedSet completedSet3;
	private CompletedSet completedSet4;

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
		completedSetRepository.deleteAll();
		mockMvc = MockMvcBuilders.webAppContextSetup(webAppContext)
				.apply(SecurityMockMvcConfigurers.springSecurity())
				.build();

		completedSet1 = new CompletedSet();
		completedSet1.setDuration(10);				//duration in what? miliseconds, seconds, minutes, hours? -> minutes?
		completedSet1.setExerciseId(1);
		completedSet1.setTime(1500L); 				//difference with duration?
		completedSet1.setUser_id(1);
		completedSet1 = completedSetRepository.save(completedSet1);

		completedSet2 = new CompletedSet();
		completedSet2.setDuration(10);				//duration in what? miliseconds, seconds, minutes, hours? -> minutes?
		completedSet2.setExerciseId(2);
		completedSet2.setTime(1500L); 				//difference with duration?
		completedSet2.setUser_id(1);
		completedSet2 = completedSetRepository.save(completedSet2);
		
		completedSet3 = new CompletedSet();
		completedSet3.setDuration(10);				//duration in what? miliseconds, seconds, minutes, hours? -> minutes?
		completedSet3.setExerciseId(1);
		completedSet3.setTime(1500L); 				//difference with duration?
		completedSet3.setUser_id(2);
		completedSet3 = completedSetRepository.save(completedSet3);
		
		completedSet4 = new CompletedSet();
		completedSet4.setDuration(10);				//duration in what? miliseconds, seconds, minutes, hours? -> minutes?
		completedSet4.setExerciseId(2);
		completedSet4.setTime(1500L); 				//difference with duration?
		completedSet4.setUser_id(2);
		completedSet4 = completedSetRepository.save(completedSet4);
	}

	@Test
	public void getAllCompletedSetsByExerciseId() throws IOException, Exception {
		mockMvc.perform(get(CompletedSetRestController.BASEURL+"/sets/" + 1)
				.with(user("user").password("123456")))
		.andExpect(status().isOk())
		.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
		.andExpect(content().json(asJson(asList(completedSet1, completedSet3))));
	}

	@Test
	public void getCompletedSetById() throws IOException, Exception {
		mockMvc.perform(get(CompletedSetRestController.BASEURL+"/getById/" + completedSet1.getId())	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isOk())
				.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
				.andExpect(content().json(asJson(completedSet1)));
	}
	
	@Test
	public void postCompletedSetAndTestIfCompletedSetCouldBeFoundInDB() throws IOException, Exception {
		CompletedSet completedSet5 = new CompletedSet();
		completedSet5.setDuration(20);
		completedSet5.setExerciseId(2);
		completedSet5.setTime(50L);
		completedSet5.setUser_id(1);
		
		 mockMvc.perform(post(CompletedSetRestController.BASEURL)
				 	.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456"))
	                .content(asJson(completedSet5))
	                .contentType(MediaType.APPLICATION_JSON_UTF8))
	                .andExpect(status().isNoContent());
		 
		assertThat(completedSetRepository.findOne(completedSet4.getId()+1).getDuration() == completedSet5.getDuration());
		assertThat(completedSetRepository.findOne(completedSet4.getId()+1).getExerciseId() == completedSet5.getExerciseId());
		assertThat(completedSetRepository.findOne(completedSet4.getId()+1).getTime() == completedSet5.getTime());
		assertThat(completedSetRepository.findOne(completedSet4.getId()+1).getUserId() == completedSet5.getUserId());
	}
	
	@Test
	public void putCompletedSetAndTestIfEdited() throws IOException, Exception {
		completedSet2.setDuration(78);
		
		mockMvc.perform(put(CompletedSetRestController.BASEURL + "/" + completedSet2.getId())	
				.header("host", "localhost:8080")	
				.content(asJson(completedSet2))
				.contentType(MediaType.APPLICATION_JSON_UTF8)
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNoContent())
				.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
				.andExpect(content().json(asJson(completedSet2)));
	}
	
	@Test
	public void putCompletedSetWithoutGivingValidIdGeneratesNotFoundResponse() throws IOException, Exception {
		completedSet3.setDuration(55);
		
		mockMvc.perform(put(CompletedSetRestController.BASEURL + "/" + 0)	
				.header("host", "localhost:8080")	
				.content(asJson(completedSet3))
				.contentType(MediaType.APPLICATION_JSON_UTF8)
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
	}
	
	@Test
	public void deleteCompletedSetAndTestIfItIsNotFoundInDB() throws IOException, Exception {
		mockMvc.perform(delete(CompletedSetRestController.BASEURL+"/" + completedSet1.getId())	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNoContent());
		
		assertThat(completedSetRepository.exists(completedSet1.getId()) == false);
	}
	
	@Test
	public void deleteCompletedSetThatDoesNotExistsAndTestIfNotFoundIsReturned() throws Exception {
		mockMvc.perform(delete(CompletedSetRestController.BASEURL+"/" + completedSet3.getId()+1)	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
		
		assertThat(completedSetRepository.exists(completedSet3.getId()) == false);
	}
	
	@Test
	public void testIfGetByIdIsAuthorized() throws IOException, Exception {
		mockMvc.perform(get(CompletedSetRestController.BASEURL+"/getById/" + completedSet1.getId())	
				.header("host", "localhost:8080"))													
				.andExpect(status().is(401));
	}

	protected String asJson(Object o) throws IOException {
		MockHttpOutputMessage mockHttpOutputMessage = new MockHttpOutputMessage();
		this.mappingJackson2HttpMessageConverter.write(o, MediaType.APPLICATION_JSON, mockHttpOutputMessage);
		return mockHttpOutputMessage.getBodyAsString();
	}
}