package test;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class Test {

	@RequestMapping(method = RequestMethod.GET)
	public String bla(String[] args) {
		// TODO Auto-generated method stub
		System.out.println("test");
		return "";
	}

}
