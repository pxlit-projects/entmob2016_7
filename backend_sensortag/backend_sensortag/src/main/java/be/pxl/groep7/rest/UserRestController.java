package be.pxl.groep7.rest;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import be.pxl.groep7.dao.ISetRepository;
import be.pxl.groep7.dao.IUserRepository;
import be.pxl.groep7.models.Set;
import be.pxl.groep7.models.User;

@RestController
@RequestMapping("/user")
public class UserRestController {
	
	@Autowired
	private IUserRepository dao;

	@RequestMapping(value="{id}", method = RequestMethod.GET, produces = "application/json")
	public ResponseEntity<User> getUserById(@PathVariable("id") int id) {
		HttpStatus status = HttpStatus.OK;
		User user = dao.findOne(id);
		
		if (user == null){
			status = HttpStatus.NOT_FOUND;
		}
		
		return new ResponseEntity<>(user, status);
	}
	
	@RequestMapping(method = RequestMethod.POST, consumes= "application/json")
	public void addUser(@RequestBody User user) {
		dao.save(user);
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.PUT, consumes= "application/json")
	public void editUser(@PathVariable("id") int id, @RequestBody User user){
		dao.save(user);
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.DELETE)
	public void deleteUser(@PathVariable int id) {
		dao.delete(id);
	}
}
