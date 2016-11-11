package be.pxl.groep7.integrationTests;

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
import org.springframework.test.annotation.DirtiesContext;
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
import be.pxl.groep7.test.config.TestConfig;

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
@ContextConfiguration(classes = TestConfig.class)
@DirtiesContext
public class CategoryControllerIntegrationTest {

	private MockMvc mockMvc;

	private HttpMessageConverter mappingJackson2HttpMessageConverter;

	@Autowired
	public ICategoryRepository categoryRepository;

	@Autowired
	private WebApplicationContext webAppContext;
	
	private Category category1;
	private Category category2;
	private Category category3;

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

		category1 = new Category();
		category1.setName("Category 1");
		category1 = categoryRepository.save(category1);

		category2 = new Category();
		category2.setName("Category 2");
		category2 = categoryRepository.save(category2);
		
		category3 = new Category();
		category3.setName("Category 3");
		category3 = categoryRepository.save(category3);
	}

	@Test
	public void getCategoriesAsList() throws IOException, Exception {
		mockMvc.perform(get(CategoryRestController.BASEURL+"/all")
				.with(user("user").password("123456")))
		.andExpect(status().isOk())
		.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
		.andExpect(content().json(asJson(asList(category1, category2, category3))));
	}

	@Test
	public void getCategoryById() throws IOException, Exception {
		mockMvc.perform(get(CategoryRestController.BASEURL+"/getById/" + category1.getId())	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isOk())
				.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
				.andExpect(content().json(asJson(category1)));
	}
	
	@Test
	public void postCategoryAndTestIfCategoryCouldBeFoundInDB() throws IOException, Exception {
		Category category4 = new Category();
		category4.setName("Category 4");
		
		System.out.println("Real post json: " + asJson(category4));
		
		 mockMvc.perform(post(CategoryRestController.BASEURL)
				 	.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456"))
	                .content(asJson(category4))
	                .contentType(MediaType.APPLICATION_JSON_UTF8))
	                .andExpect(status().isNoContent());
		 
		assertThat(categoryRepository.findOne(category3.getId()+1).getName().equals(category4.getName()));
	}
	
	@Test
	public void postCategoryLikeDotNETAndTestIfCategoryCouldInserted() throws IOException, Exception {
		String json = "{\"CategoryID\": 0, \"Name\": \"Naam\"}";
		System.out.println(json);
		
		 mockMvc.perform(post(CategoryRestController.BASEURL)
				 	.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456"))
	                .content(json)
	                .contentType(MediaType.APPLICATION_JSON_UTF8))
	                .andExpect(status().isNoContent());
	}
	
	@Test
	public void putCategoryAndTestIfEdited() throws IOException, Exception {
		category2.setName("Nieuwe category");
		
		mockMvc.perform(put(CategoryRestController.BASEURL + "/" + category2.getId())	
				.header("host", "localhost:8080")	
				.content(asJson(category2))
				.contentType(MediaType.APPLICATION_JSON_UTF8)
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNoContent())
				.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
				.andExpect(content().json(asJson(category2)));
	}
	
	@Test
	public void putCategoryWithoutGivingValidIdGeneratesNotFoundResponse() throws IOException, Exception {
		category3.setName("Nieuwe category");
		
		mockMvc.perform(put(CategoryRestController.BASEURL + "/" + 0)	
				.header("host", "localhost:8080")	
				.content(asJson(category3))
				.contentType(MediaType.APPLICATION_JSON_UTF8)
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
	}
	
	@Test
	public void deleteCategoryAndTestIfItIsNotFoundInDB() throws IOException, Exception {
		mockMvc.perform(delete(CategoryRestController.BASEURL+"/" + category1.getId())	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNoContent());
		
		assertThat(categoryRepository.exists(category1.getId()) == false);
	}
	
	@Test
	public void deleteCategoryThatDoesNotExistsAndTestIfNotFoundIsReturned() throws Exception {
		mockMvc.perform(delete(CategoryRestController.BASEURL+"/" + category3.getId()+1)	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
		
		assertThat(categoryRepository.exists(category1.getId()) == false);
	}
	
	@Test
	public void testIfGetByIdIsAuthorized() throws IOException, Exception {
		mockMvc.perform(get(CategoryRestController.BASEURL+"/getById/" + category1.getId())	
				.header("host", "localhost:8080"))													
				.andExpect(status().is(401));
	}

	protected String asJson(Object o) throws IOException {
		MockHttpOutputMessage mockHttpOutputMessage = new MockHttpOutputMessage();
		this.mappingJackson2HttpMessageConverter.write(o, MediaType.APPLICATION_JSON, mockHttpOutputMessage);
		return mockHttpOutputMessage.getBodyAsString();
	}
}
