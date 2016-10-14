package be.pxl.groep7.rest;

import org.springframework.ui.ModelMap;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import be.pxl.groep7.models.Distance;
import be.pxl.groep7.models.SensorModel;

@RestController
@RequestMapping("/sensor")
public class SensorREST {
	
	@RequestMapping(method = RequestMethod.GET)
	public String handleGet(){
		System.out.println("get");
		return "hello";
	}
	
	/*@RequestMapping(value = "/addStudent", method = RequestMethod.POST)
	   public String addDistance(@ModelAttribute("SpringWeb")SensorModel distance, 
	   ModelMap model) {
		try{
			Distance d = (Distance) distance;
			  model.addAttribute("id", d.getId());
		      model.addAttribute("height", d.getHeight());
		      model.addAttribute("id", d.getTime());
		} catch (Exception e) {
			System.out.println("EXCEPTION! " + e.getMessage());
		}
	    
	      return "result";
	   }*/

}
