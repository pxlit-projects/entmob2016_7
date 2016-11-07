package be.pxl.groep7.aspecten;

import org.aspectj.lang.annotation.Aspect;
import org.aspectj.lang.annotation.Before;
import org.springframework.stereotype.Component;

@Component
@Aspect
public class LoggingAspect {

	private static int counter;
	
	@Before("execution(* *.getCategoryById(int))")
	public void before(){
		counter++;
		System.out.println("aspect triggered " + counter);
	}
}
