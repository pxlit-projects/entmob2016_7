package test;

import java.nio.charset.Charset;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.Base64;

import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.FixMethodOrder;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.junit.runners.MethodSorters;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.boot.test.WebIntegrationTest;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.test.context.SpringBootTest.WebEnvironment;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpMethod;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
//import org.springframework.security.crypto.codec.Hex;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.springframework.test.context.web.WebAppConfiguration;
import org.springframework.web.client.RestClientException;
import org.springframework.web.client.RestTemplate;

import be.pxl.groep7.models.Category;

//Test methods first on one class -> junit randomizes :( a better way (framework) wanted
//Problem: The code generates 404 with get after delete -> but this is good :(
@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(classes = TestConfig.class)
@WebAppConfiguration
@DirtiesContext
@SpringBootTest
public class CategoryRestIT {

	//@Value("http://localhost:8080/sensortagapi/category")
	@Value("http://http://84.195.1.59/sensorTag/category")
	private String baseURL;
	
	private String username = "user";
	private String password = "user";
	
	@Autowired
	private RestTemplate template;
	
<<<<<<< HEAD
	private int id = 1;
=======
	private int id = 2;
>>>>>>> 82c5ceea70470d5c14fd51e6d574664b0d78d0bf
	
	@Test
	public void postCategory() throws RestClientException, NoSuchAlgorithmException{
		Category category = new Category();
		category.setName("Category 4");
		
		//--------------------------------------POST-----------------------------------------------------//
<<<<<<< HEAD
		//System.out.println("Post about to happen");
		//ResponseEntity<String> response =  template.postForEntity(baseURL, category, String.class, MediaType.APPLICATION_JSON);
		//System.out.println("post");
		//Assert.assertTrue(response.getStatusCode() == HttpStatus.NO_CONTENT);
=======
		System.out.println("Post about to happen");
		ResponseEntity<String> response = template.exchange
		 (baseURL, HttpMethod.POST, new HttpEntity<String>(securityHeader()), String.class);
		//ResponseEntity<String> response =  template.postForEntity(baseURL, category, String.class, MediaType.APPLICATION_JSON);
		System.out.println("post");
		Assert.assertTrue(response.getStatusCode() == HttpStatus.NO_CONTENT);
>>>>>>> 82c5ceea70470d5c14fd51e6d574664b0d78d0bf
		//-----------------------------------------------------------------------------------------------//
		//--------------------------------------GET------------------------------------------------------//
		//ResponseEntity<Category> response2 = template.getForEntity(baseURL + "/{0}", Category.class, id);
		//System.out.println("get");
		//Assert.assertTrue(response2.getStatusCode() == HttpStatus.OK);
		//---------------------------------------------------------------------------------------------//
		//-----------------------------------------PUT-------------------------------------------------//
		//category.setName("Category 5");
		//category.setId(id);
		//System.out.println("put");
		//template.put(baseURL, category);
		//----------------------------------------------------------------------------------------------//
		//-----------------------------------------GET--------------------------------------------------//
		//ResponseEntity<Category> response3 = template.getForEntity(baseURL + "/{0}", Category.class, id);
		//System.out.println(response3.getBody().getName());
		//Assert.assertTrue(response3.getBody().getName().equals("Category 5"));
		//----------------------------------------------------------------------------------------------//
		//----------------------------------------DELETE------------------------------------------------//
		//System.out.println("delete");
		//template.delete(baseURL +"/{0}", id);
		//----------------------------------------------------------------------------------------------//
		//System.out.println("Get getting get");
		//ResponseEntity<Category> response4 = template.getForEntity(baseURL + "/{0}", Category.class, id);
		//System.out.println("get");
		//Assert.assertTrue(response4.getStatusCode() == HttpStatus.NOT_FOUND);				//Generates exception 404 -> not founnd -> but this is exactly what we want!
	}
	
	public String securityHeader() throws NoSuchAlgorithmException{
		HttpHeaders headers = createAuthenticationHeader();
		ResponseEntity<String> response = template.exchange(baseURL, HttpMethod.GET, new HttpEntity<String>(headers), String.class);
		return response.getBody();
	}
	
	private HttpHeaders createAuthenticationHeader() throws NoSuchAlgorithmException{
		//MessageDigest digest = MessageDigest.getInstance("SHA-256"); 
		//digest.update(password.getBytes());
		//byte[] bytes = digest.digest();
		
		/*System.out.println("Nu komt de hash!");
		
		for (byte b : bytes) {
			System.out.print(b);
		}
		System.out.println();*/
		
		String auth = username + ":" + password;
		System.out.println(auth);
		String encodedAuth = Base64.getEncoder().encodeToString(auth.getBytes(Charset.forName("UTF-8")));
		String authHeader = "Basic " + encodedAuth;
		HttpHeaders headers = new HttpHeaders();
		headers.set("Authorization", authHeader);
		
		return headers;
	}
	
	//@Test
	public void getCategory() {
		ResponseEntity<Category> response = template.getForEntity(baseURL + "/{0}", Category.class, id);
		
		Assert.assertTrue(response.getStatusCode() == HttpStatus.OK);
	}
	
	//@Test
	public void updateCategory() {
		Category category = new Category();
		category.setName("Category 5");
		category.setId(id);
		template.put(baseURL, category);
		
		ResponseEntity<Category> response = template.getForEntity(baseURL + "/{0}", Category.class, id);
		
		Assert.assertTrue(response.getBody().getName().equals("Category 5"));
	}
	
	//@Test
	public void deleteCategory(){
		template.delete(baseURL +"/{0}", id);
		
		ResponseEntity<Category> response = template.getForEntity(baseURL + "/{0}", Category.class, id);
		Assert.assertTrue(response.getStatusCode() == HttpStatus.NOT_FOUND);
	}
	
}
