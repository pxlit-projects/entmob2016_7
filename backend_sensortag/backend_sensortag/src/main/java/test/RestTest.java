package test;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/hello")
public class RestTest {
	
	@RequestMapping(method = RequestMethod.GET)
	public String handleGet(){
		System.out.println("get");
		return "hello World";
	}

}