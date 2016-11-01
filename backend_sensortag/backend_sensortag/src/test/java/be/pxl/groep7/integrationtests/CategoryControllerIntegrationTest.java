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
import be.pxl.groep7.dao.ICategoryRepository;
import be.pxl.groep7.models.Category;
import be.pxl.groep7.rest.CategoryRestController;

import static org.assertj.core.api.Assertions.assertThat;
import static java.util.Arrays.asList;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.security.test.web.servlet.request.SecurityMockMvcRequestPostProcessors.user;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.content;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.context.web.WebAppConfiguration;

@RunWith(SpringRunner.class)
@SpringBootTest
@ContextConfiguration(classes = AppConfig.class)
@WebAppConfiguration
public class CategoryControllerIntegrationTest {

	private MockMvc mockMvc;

	private HttpMessageConverter mappingJackson2HttpMessageConverter;

	@Autowired
	public ICategoryRepository categoryRepository;

	@Autowired
	private WebApplicationContext webAppContext;

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
		categoryRepository.deleteAll();
		mockMvc = MockMvcBuilders.webAppContextSetup(webAppContext)
				.apply(SecurityMockMvcConfigurers.springSecurity())
				.build();

	}

	@Test
	public void postTwoCategoriesAndReturnAsList() throws IOException, Exception {
		Category c = new Category();
		c.setName("Category 1");
		categoryRepository.save(c);

		Category c2 = new Category();
		c2.setName("Category 2");
		categoryRepository.save(c2);

		mockMvc.perform(get(CategoryRestController.BASEURL+"/all")
				.with(user("user").password("123456")))
		.andExpect(status().isOk())
		.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
		.andExpect(content().json(asJson(asList(c, c2))));
	}

	@Test
	public void postOneCategoryAndReturnOne() throws IOException, Exception {
		Category c = new Category();
		c.setName("Category 1");
		int id = categoryRepository.save(c).getId();

		mockMvc.perform(get(CategoryRestController.BASEURL+"/getById/" + id)	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isOk())
				.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
				.andExpect(content().json(asJson(c)));
	}
	
	@Test
	public void postOneCategoryEditOneAndReturnEditedCategory() throws IOException, Exception {
		Category c = new Category();
		c.setName("Category 1");
		int id = categoryRepository.save(c).getId();
		c.setId(id);
		c.setName("Category 2");
		
		categoryRepository.save(c);
		
		mockMvc.perform(get(CategoryRestController.BASEURL+"/getById/" + id)	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isOk())
				.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
				.andExpect(content().json(asJson(c)));
	}
	
	@Test
	public void postOneCategoryDeleteAndCheckIfNotFound() throws IOException, Exception {
		Category c = new Category();
		c.setName("Category 1");
		int id = categoryRepository.save(c).getId();
		
		categoryRepository.delete(c);
		
		mockMvc.perform(get(CategoryRestController.BASEURL+"/getById/" + id)	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
	}
	
	@Test
	public void postThreeCategoriesDeleteOneAndTestIfTwoReturn() throws IOException, Exception {
		Category c = new Category();
		c.setName("Category 1");
		categoryRepository.save(c);

		Category c2 = new Category();
		c2.setName("Category 2");
		int id = categoryRepository.save(c2).getId();
		c2.setId(id);
		
		Category c3 = new Category();
		c3.setName("Category 3");
		categoryRepository.save(c3);
		
		categoryRepository.delete(c2);
		
		mockMvc.perform(get(CategoryRestController.BASEURL+"/all")
				.with(user("user").password("123456")))
		.andExpect(status().isOk())
		.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
		.andExpect(content().json(asJson(asList(c, c3))));
	}

	protected String asJson(Object o) throws IOException {
		MockHttpOutputMessage mockHttpOutputMessage = new MockHttpOutputMessage();
		this.mappingJackson2HttpMessageConverter.write(o, MediaType.APPLICATION_JSON, mockHttpOutputMessage);
		return mockHttpOutputMessage.getBodyAsString();
	}

}
