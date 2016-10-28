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
	public ResponseEntity<String> addUser(@RequestBody User user) {
		HttpStatus status = HttpStatus.NO_CONTENT;
		
		if (!dao.exists(user.getId())){
			dao.save(user);
		} else {
			status = HttpStatus.CONFLICT;
		}
		
		return new ResponseEntity<>(status);	
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.PUT, consumes= "application/json")
	public ResponseEntity<String> editUser(@PathVariable("id") int id, @RequestBody User user){
		HttpStatus status = HttpStatus.NO_CONTENT;
		
		if (dao.exists(user.getId())){
			dao.save(user);
		} else {
			status = HttpStatus.CONFLICT;
		}
		
		return new ResponseEntity<>(status);	
	}
	
	@RequestMapping(value="{id}", method = RequestMethod.DELETE)
	public ResponseEntity<String> deleteUser(@PathVariable int id) {
		HttpStatus status = HttpStatus.NO_CONTENT;
		
		if (dao.exists(id)){
			dao.delete(id);
		} else {
			status = HttpStatus.CONFLICT;
		}
		return new ResponseEntity<>(status);	
	}
}
