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

import be.pxl.groep7.dao.ICompletedSetRepository;
import be.pxl.groep7.models.CompletedSet;
import be.pxl.groep7.rest.CategoryRestController;
import be.pxl.groep7.rest.CompletedSetRestController;
import be.pxl.groep7.services.ICompletedSetService;
import be.pxl.groep7.services.ICompletedSetService;
import be.pxl.groep7.test.config.TestConfig;

@RunWith(SpringRunner.class)
@ContextConfiguration(classes = TestConfig.class)
@SpringBootTest
public class CompletedSetRestTest {

	private MockMvc mockMvc;
	
	private HttpMessageConverter mappingJackson2HttpMessageConverter;
	
	@Autowired
	private WebApplicationContext webAppContext;
	
	@Mock
	ICompletedSetService serviceMock;
	
	@Mock
	ICompletedSetRepository repMock;
	
	public CompletedSetRestController completedSetController;
	
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
		completedSetController = new CompletedSetRestController(serviceMock, repMock);
		mockMvc = MockMvcBuilders.standaloneSetup(completedSetController)
				.build();
	}
	
	@Test
	public void getAllCompletedSetsBySetIdTest() throws IOException, Exception {
		CompletedSet completedSet1 = new CompletedSet(1, 1, 10, 210, 1);
		CompletedSet completedSet2 = new CompletedSet(2, 1, 15, 200, 2);
		CompletedSet completedSet3 = new CompletedSet(3, 1, 5, 200, 1);
		
		List<CompletedSet> completedSets = new ArrayList<>();
		completedSets.add(completedSet1);
		completedSets.add(completedSet2);
		completedSets.add(completedSet3);
		
		Mockito.when(serviceMock.getAllCompletedSetsBySetId(1)).thenReturn(completedSets);
		Mockito.when(repMock.getCompletedSetsBySetId(1)).thenReturn(completedSets);
		
		mockMvc.perform(get(CompletedSetRestController.BASEURL+"/sets/" + 1)
		.with(user("user").password("123456")))
		.andExpect(status().isOk())
		.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
		.andExpect(content().json(asJson(asList(completedSet1, completedSet2, completedSet3))));
	}
	
	@Test
	public void getExistingCompletedSetTest() throws IOException, Exception {
		CompletedSet completedSet1 = new CompletedSet(1, 1, 10, 210, 1);
		
		Mockito.when(serviceMock.findCompletedSetById(1)).thenReturn(completedSet1);
		Mockito.when(repMock.findOne(1)).thenReturn(completedSet1);
		
		mockMvc.perform(get(CompletedSetRestController.BASEURL+"/getById/" + completedSet1.getId())													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isOk())
				.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
				.andExpect(content().json(asJson(completedSet1)));
	}
	
	@Test
	public void getNonExistingCompletedSetFailsTest() throws IOException, Exception {
		CompletedSet completedSet1 = new CompletedSet(1, 1, 10, 210, 1);
		
		Mockito.when(serviceMock.findCompletedSetById(1)).thenReturn(null);
		Mockito.when(repMock.findOne(1)).thenReturn(null);
		
		mockMvc.perform(get(CompletedSetRestController.BASEURL+"/getById/" + completedSet1.getId())													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
	}
	
	@Test
	public void postOneCompletedSetTest() throws IOException, Exception {
		CompletedSet completedSet1 = new CompletedSet(1, 1, 10, 210, 1);
		
		Mockito.when(serviceMock.createOrUpdateCompletedSet(completedSet1)).thenReturn(completedSet1);
		Mockito.when(serviceMock.doesCompletedSetExist(1)).thenReturn(false);
		Mockito.when(repMock.save(completedSet1)).thenReturn(completedSet1);
		
		 mockMvc.perform(post(CompletedSetRestController.BASEURL)
				 	.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456"))
	                .content(asJson(completedSet1))
	                .contentType(MediaType.APPLICATION_JSON_UTF8))
	                .andExpect(status().isNoContent());
	}
	
	@Test
	public void postExistingCompletedSetFails() throws IOException, Exception {
		CompletedSet completedSet1 = new CompletedSet(1, 1, 10, 210, 1);
		
		Mockito.when(serviceMock.createOrUpdateCompletedSet(completedSet1)).thenReturn(completedSet1);
		Mockito.when(serviceMock.doesCompletedSetExist(1)).thenReturn(true);
		Mockito.when(repMock.save(completedSet1)).thenReturn(completedSet1);
		
		 mockMvc.perform(post(CompletedSetRestController.BASEURL)
				 	.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456"))
	                .content(asJson(completedSet1))
	                .contentType(MediaType.APPLICATION_JSON_UTF8))
	                .andExpect(status().isConflict());
	}
	
	@Test
	public void putExistingCompletedSet() throws IOException, Exception {
		CompletedSet completedSet1 = new CompletedSet(1, 1, 10, 210, 1);
		
		Mockito.when(serviceMock.doesCompletedSetExist(1)).thenReturn(true);
		Mockito.when(serviceMock.createOrUpdateCompletedSet(completedSet1)).thenReturn(completedSet1);
		Mockito.when(repMock.save(completedSet1)).thenReturn(completedSet1);
		
		mockMvc.perform(put(CompletedSetRestController.BASEURL + "/" + completedSet1.getId())	
				.header("host", "localhost:8080")	
				.content(asJson(completedSet1))
				.contentType(MediaType.APPLICATION_JSON_UTF8)
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNoContent())
				.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
				.andExpect(content().json(asJson(completedSet1)));
	}
	
	@Test
	public void putNonExistingCompletedSetFails() throws IOException, Exception {
		CompletedSet completedSet1 = new CompletedSet(1, 1, 10, 210, 1);
		
		Mockito.when(serviceMock.createOrUpdateCompletedSet(completedSet1)).thenReturn(completedSet1);
		Mockito.when(serviceMock.doesCompletedSetExist(1)).thenReturn(false);
		Mockito.when(repMock.save(completedSet1)).thenReturn(completedSet1);
		
		mockMvc.perform(put(CompletedSetRestController.BASEURL + "/" + completedSet1.getId())	
				.header("host", "localhost:8080")	
				.content(asJson(completedSet1))
				.contentType(MediaType.APPLICATION_JSON_UTF8)
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
	}
	
	@Test
	public void deleteExistingCompletedSet() throws Exception {
		CompletedSet completedSet1 = new CompletedSet(1, 1, 10, 210, 1);
		
		Mockito.when(serviceMock.createOrUpdateCompletedSet(completedSet1)).thenReturn(completedSet1);
		Mockito.when(serviceMock.doesCompletedSetExist(1)).thenReturn(true);
		Mockito.when(repMock.save(completedSet1)).thenReturn(completedSet1);
		
		mockMvc.perform(delete(CompletedSetRestController.BASEURL+"/" + completedSet1.getId())	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNoContent());
	}
	
	@Test
	public void deleteNonExistingCompletedSetFails() throws Exception {
		CompletedSet completedSet1 = new CompletedSet(1, 1, 10, 210, 1);
		
		Mockito.when(serviceMock.createOrUpdateCompletedSet(completedSet1)).thenReturn(completedSet1);
		Mockito.when(serviceMock.doesCompletedSetExist(1)).thenReturn(false);
		Mockito.when(repMock.save(completedSet1)).thenReturn(completedSet1);
		
		mockMvc.perform(delete(CompletedSetRestController.BASEURL+"/" + completedSet1.getId())														
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
	}
	
	protected String asJson(Object o) throws IOException {
		MockHttpOutputMessage mockHttpOutputMessage = new MockHttpOutputMessage();
		this.mappingJackson2HttpMessageConverter.write(o, MediaType.APPLICATION_JSON, mockHttpOutputMessage);
		return mockHttpOutputMessage.getBodyAsString();
	}
}
