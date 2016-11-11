package be.pxl.groep7.integrationTests;

import java.nio.charset.Charset;
import java.security.NoSuchAlgorithmException;
import java.util.Base64;

import org.junit.Assert;
import org.junit.Ignore;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpMethod;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.springframework.web.client.RestClientException;
import org.springframework.web.client.RestTemplate;

import be.pxl.groep7.AppConfig;
import be.pxl.groep7.models.Category;
import be.pxl.groep7.test.config.TestConfig;

/*@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(classes = TestConfig.class)
@SpringBootTest
public class CategoryIntegrationTest {

	@Value("http://localhost:8080/sensortagapi/category")
	private String baseURL;
	
	private String nameCategory = "You Shall Work!";
	private String newName = "You should still be working!";
	
	private String username = "user";
	private String password = "123456";
	
	@Autowired
	private RestTemplate template;
	
	@Deprecated
	public void ScenarioIntegrationTest() throws RestClientException, NoSuchAlgorithmException{
		Category category = new Category();
		category.setName(nameCategory); 
		System.out.println("POST integration test");
		HttpEntity<Category> request = new HttpEntity<Category>(category, createAuthenticationHeader(1));		
		ResponseEntity<String> response = template.postForEntity(baseURL, request, String.class);
		
		Assert.assertTrue(response.getStatusCode() == HttpStatus.NO_CONTENT);
		//-------------------------------------------------------------------------------------------------------------//
		System.out.println("GET integration test");
		HttpEntity<String> request2 = new HttpEntity<String>(createAuthenticationHeader(0));		
		ResponseEntity<Category> response2 = template.exchange(baseURL +"/1", HttpMethod.GET, request2, Category.class);
		
		Assert.assertTrue(response2.getStatusCode() == HttpStatus.OK);
		//--------------------------------------------------------------------------------------------------------------//
		category.setId(1);
		category.setName(newName);
		
		System.out.println("PUT integration test");
		HttpEntity<Category> request3 = new HttpEntity<Category>(category, createAuthenticationHeader(1));		
		ResponseEntity<String> response3 = template.exchange(baseURL, HttpMethod.PUT, request3, String.class);
		
		Assert.assertTrue(response3.getStatusCode() == HttpStatus.NO_CONTENT);
		//--------------------------------------------------------------------------------------------------------------//
		System.out.println("second GET integration test");
		HttpEntity<String> request4 = new HttpEntity<String>(createAuthenticationHeader(0));		
		ResponseEntity<Category> response4 = template.exchange(baseURL +"/1", HttpMethod.GET, request4, Category.class);
		
		Assert.assertTrue(response4.getBody().getName().equals(newName));
		//-----------------------------------------------------------------------------------------------------------------//
		System.out.println("DELETE integration test");
		HttpEntity<String> request5 = new HttpEntity<String>(createAuthenticationHeader(0));		
		ResponseEntity<String> response5 = template.exchange(baseURL +"/1", HttpMethod.DELETE, request5, String.class);
		
		Assert.assertTrue(response5.getStatusCode() == HttpStatus.NO_CONTENT);
	}
	
	public HttpHeaders createAuthenticationHeader(int status) throws NoSuchAlgorithmException{
		String auth = username + ":" + password;
		String encodedAuth = Base64.getEncoder().encodeToString(auth.getBytes(Charset.forName("UTF-8")));
		String authHeader = "Basic " + encodedAuth;
		HttpHeaders headers = new HttpHeaders();
		headers.set("Authorization", authHeader);
		
		if (status == 1){
			headers.setContentType(MediaType.APPLICATION_JSON);
		}
		
		return headers;
	}
}*/
