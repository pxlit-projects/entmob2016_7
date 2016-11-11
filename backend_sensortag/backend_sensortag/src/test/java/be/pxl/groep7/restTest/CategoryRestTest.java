package be.pxl.groep7.restTest;

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
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.runners.MockitoJUnitRunner;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.MediaType;
import org.springframework.http.converter.HttpMessageConverter;
import org.springframework.http.converter.json.MappingJackson2HttpMessageConverter;
import org.springframework.mock.http.MockHttpOutputMessage;
import org.springframework.security.test.web.servlet.request.SecurityMockMvcRequestPostProcessors;
import org.springframework.security.test.web.servlet.setup.SecurityMockMvcConfigurers;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.setup.MockMvcBuilders;
import org.springframework.web.context.WebApplicationContext;

import be.pxl.groep7.dao.ICategoryRepository;
import be.pxl.groep7.models.Category;
import be.pxl.groep7.rest.CategoryRestController;
import be.pxl.groep7.services.ICategoryService;
import be.pxl.groep7.test.config.TestConfig;

@RunWith(SpringRunner.class)
@ContextConfiguration(classes = TestConfig.class)
@SpringBootTest
public class CategoryRestTest {

	private MockMvc mockMvc;
	
	private HttpMessageConverter mappingJackson2HttpMessageConverter;
	
	@Autowired
	private WebApplicationContext webAppContext;
	
	@Mock
	ICategoryService serviceMock;
	
	@Mock
	ICategoryRepository repMock;
	
	public CategoryRestController categoryController;
	
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
		categoryController = new CategoryRestController(serviceMock, repMock);
		mockMvc = MockMvcBuilders.standaloneSetup(new CategoryRestController(serviceMock, repMock))
				.build();
	}
	
	@Test
	public void getAllCategoriesTest() throws IOException, Exception {
		Category category1 = new Category(1, "Category 1");
		Category category2 = new Category(2, "Category 2");
		Category category3 = new Category(3, "Category 3");
		
		List<Category> categories = new ArrayList<>();
		categories.add(category1);
		categories.add(category2);
		categories.add(category3);
		
		Mockito.when(serviceMock.getAllCategories()).thenReturn(categories);
		Mockito.when(repMock.getAllCategories()).thenReturn(categories);
		
		mockMvc.perform(get(CategoryRestController.BASEURL+"/all")
		.with(user("user").password("123456")))
		.andExpect(status().isOk())
		.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
		.andExpect(content().json(asJson(asList(category1, category2, category3))));
	}
	
	@Test
	public void getExistingCategoryTest() throws IOException, Exception {
		Category category1 = new Category(1, "Category 1");
		
		Mockito.when(serviceMock.findCategoryById(1)).thenReturn(category1);
		Mockito.when(repMock.findOne(1)).thenReturn(category1);
		
		mockMvc.perform(get(CategoryRestController.BASEURL+"/getById/" + category1.getId())													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isOk())
				.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
				.andExpect(content().json(asJson(category1)));
	}
	
	@Test
	public void getNonExistingCategoryFailsTest() throws IOException, Exception {
		Category category1 = new Category(1, "Category 1");
		
		Mockito.when(serviceMock.findCategoryById(1)).thenReturn(null);
		Mockito.when(repMock.findOne(1)).thenReturn(null);
		
		mockMvc.perform(get(CategoryRestController.BASEURL+"/getById/" + category1.getId())													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
	}
	
	@Test
	public void postOneCategoryTest() throws IOException, Exception {
		Category category1 = new Category(1, "Category 1");
		
		Mockito.when(serviceMock.createOrUpdateCategory(category1)).thenReturn(category1);
		Mockito.when(serviceMock.doesCategoryExist(1)).thenReturn(false);
		Mockito.when(repMock.save(category1)).thenReturn(category1);
		
		 mockMvc.perform(post(CategoryRestController.BASEURL)
				 	.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456"))
	                .content(asJson(category1))
	                .contentType(MediaType.APPLICATION_JSON_UTF8))
	                .andExpect(status().isNoContent());
	}
	
	@Test
	public void postExistingCategoryFails() throws IOException, Exception {
		Category category1 = new Category(1, "Category 1");
		
		Mockito.when(serviceMock.createOrUpdateCategory(category1)).thenReturn(category1);
		Mockito.when(serviceMock.doesCategoryExist(1)).thenReturn(true);
		Mockito.when(repMock.save(category1)).thenReturn(category1);
		
		 mockMvc.perform(post(CategoryRestController.BASEURL)
				 	.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456"))
	                .content(asJson(category1))
	                .contentType(MediaType.APPLICATION_JSON_UTF8))
	                .andExpect(status().isConflict());
	}
	
	@Test
	public void putExistingCategory() throws IOException, Exception {
		Category category1 = new Category(1, "Category 1");
		
		Mockito.when(serviceMock.createOrUpdateCategory(category1)).thenReturn(category1);
		Mockito.when(serviceMock.doesCategoryExist(1)).thenReturn(true);
		Mockito.when(repMock.save(category1)).thenReturn(category1);
		
		mockMvc.perform(put(CategoryRestController.BASEURL + "/" + category1.getId())	
				.header("host", "localhost:8080")	
				.content(asJson(category1))
				.contentType(MediaType.APPLICATION_JSON_UTF8)
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNoContent())
				.andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
				.andExpect(content().json(asJson(category1)));
	}
	
	@Test
	public void putNonExistingCategoryFails() throws IOException, Exception {
		Category category1 = new Category(1, "Category 1");
		
		Mockito.when(serviceMock.createOrUpdateCategory(category1)).thenReturn(category1);
		Mockito.when(serviceMock.doesCategoryExist(1)).thenReturn(false);
		Mockito.when(repMock.save(category1)).thenReturn(category1);
		
		mockMvc.perform(put(CategoryRestController.BASEURL + "/" + category1.getId())	
				.header("host", "localhost:8080")	
				.content(asJson(category1))
				.contentType(MediaType.APPLICATION_JSON_UTF8)
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNotFound());
	}
	
	@Test
	public void deleteExistingCategory() throws Exception {
		Category category1 = new Category(1, "Category 1");
		
		Mockito.when(serviceMock.createOrUpdateCategory(category1)).thenReturn(category1);
		Mockito.when(serviceMock.doesCategoryExist(1)).thenReturn(true);
		Mockito.when(repMock.save(category1)).thenReturn(category1);
		
		mockMvc.perform(delete(CategoryRestController.BASEURL+"/" + category1.getId())	
				.header("host", "localhost:8080")													
				.with(SecurityMockMvcRequestPostProcessors.httpBasic("user", "123456")))
				.andExpect(status().isNoContent());
	}
	
	@Test
	public void deleteNonExistingCategoryFails() throws Exception {
		Category category1 = new Category(1, "Category 1");
		
		Mockito.when(serviceMock.createOrUpdateCategory(category1)).thenReturn(category1);
		Mockito.when(serviceMock.doesCategoryExist(1)).thenReturn(false);
		Mockito.when(repMock.save(category1)).thenReturn(category1);
		
		mockMvc.perform(delete(CategoryRestController.BASEURL+"/" + category1.getId())	
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
