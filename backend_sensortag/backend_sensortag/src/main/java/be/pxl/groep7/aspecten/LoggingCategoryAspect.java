package be.pxl.groep7.aspecten;

import java.util.List;

import org.aspectj.lang.ProceedingJoinPoint;
import org.aspectj.lang.annotation.AfterReturning;
import org.aspectj.lang.annotation.Around;
import org.aspectj.lang.annotation.Aspect;
import org.aspectj.lang.annotation.Before;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpEntity;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Component;

import be.pxl.groep7.jms.JMSMessageProducer;
import be.pxl.groep7.models.Category;

@Component
@Aspect
public class LoggingCategoryAspect {
	
	@Autowired
	private JMSMessageProducer producer;
	
	@Before("execution(* *.getCategoryById(int)) && args(id)")
	public void beforeGetCategoryById(int id) {
		producer.sendLog("getCategory triggered for id: " + id);
	}
	
	@AfterReturning(value="execution(* *.getCategoryById(int)) && args(id)", returning="responseEntity")
	public void afterGetCategoryById(int id, ResponseEntity<Category> responseEntity) {
		producer.sendLog("getCategory has been triggered: httpResponse: " + responseEntity.getStatusCodeValue() + " category id: " + id);
	}
	
	@Before("execution(* *.getAllCategories(..))")
	public void beforeGetCategories() {
		producer.sendLog("getAllCategories triggered");
	}
	
	@AfterReturning(value ="execution(* *.getAllCategories(..))", returning="responseEntity")
	public void afterGetAllCategories(ResponseEntity<List<Category>> responseEntity) {
		producer.sendLog("getAllCategories has been triggered: httpResponse: " + responseEntity.getStatusCodeValue());
	}
}
