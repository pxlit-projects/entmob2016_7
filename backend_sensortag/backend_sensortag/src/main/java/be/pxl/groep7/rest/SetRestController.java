package be.pxl.groep7.rest;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import be.pxl.groep7.dao.IExerciseRepository;
import be.pxl.groep7.dao.ISetRepository;
import be.pxl.groep7.models.Exercise;
import be.pxl.groep7.models.Set;

@RestController
@RequestMapping("/set")
public class SetRestController {

	@Autowired
	private ISetRepository dao;

	@RequestMapping(value="{id}", method = RequestMethod.GET, produces = "application/json")
	public Set getSetById(@PathVariable("id") int id){
		return dao.getSet(id);
	}
	
	@RequestMapping(method = RequestMethod.POST)
	public void addSet(@RequestBody Set set){
		dao.addSet(set);
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.PUT)
	public void editSet(@PathVariable("id") int id, @RequestBody Set set){
		dao.updateSet(set);
	}
	
	@RequestMapping(method = RequestMethod.DELETE)
	public void deleteSet(@RequestBody Set set) {
		dao.deleteSet(set);
	}
}
