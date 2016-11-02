package be.pxl.groep7.rest;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import be.pxl.groep7.dao.IUserRepository;
import be.pxl.groep7.models.User;
import be.pxl.groep7.services.IUserService;

@RestController
@RequestMapping("/user")
public class UserRestController {
	
	@Autowired
	private IUserService service;

	@RequestMapping(value="{id}", method = RequestMethod.GET, produces = "application/json")
	public ResponseEntity<User> getUserById(@PathVariable("id") int id) {
		HttpStatus status = HttpStatus.OK;
		User user = service.findUserById(id);
		
		if (user == null){
			status = HttpStatus.NOT_FOUND;
		}
		
		return new ResponseEntity<>(user, status);
	}
	
	@RequestMapping(method = RequestMethod.POST, consumes= "application/json", produces= "application/json")
	public ResponseEntity<User> addUser(@RequestBody User user) {
		HttpStatus status = HttpStatus.NO_CONTENT;
		User newUser = null;
		
		if (!service.doesUserExist(user.getId())){
			newUser = service.createOrUpdateUser(user);
		} else {
			status = HttpStatus.CONFLICT;
		}
		
		return new ResponseEntity<>(newUser, status);	
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.PUT, consumes= "application/json", produces= "application/json")
	public ResponseEntity<User> editUser(@PathVariable("id") int id, @RequestBody User user){
		HttpStatus status = HttpStatus.NO_CONTENT;
		User newUser = null;
		
		if (service.doesUserExist(user.getId())){
			newUser = service.createOrUpdateUser(user);
		} else {
			status = HttpStatus.NOT_FOUND;
		}
		
		return new ResponseEntity<>(newUser, status);	
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.DELETE)
	public ResponseEntity<String> deleteUser(@PathVariable int id) {
		HttpStatus status = HttpStatus.NO_CONTENT;
		
		if (service.doesUserExist(id)){
			service.deleteUserById(id);
		} else {
			status = HttpStatus.NOT_FOUND;
		}
		return new ResponseEntity<>(status);	
	}
}
