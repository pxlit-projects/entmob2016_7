package be.pxl.groep7.rest;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/user")
public class UserRestController {

	
	@RequestMapping(method = RequestMethod.GET)
	public String handleGet(){
		
		
		return "user";
	}
}
