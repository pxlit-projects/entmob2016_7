package be.pxl.groep7.rest;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/sensor")
public class SensorREST {
	
	@RequestMapping(method = RequestMethod.GET)
	public String handleGet(){
		System.out.println("get");
		return "hello";
	}

}
