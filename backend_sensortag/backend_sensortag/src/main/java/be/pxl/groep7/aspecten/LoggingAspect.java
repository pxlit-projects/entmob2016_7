package be.pxl.groep7.aspecten;

import org.aspectj.lang.annotation.Aspect;
import org.aspectj.lang.annotation.Before;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import be.pxl.groep7.jms.JMSMessageProducer;

@Component
@Aspect
public class LoggingAspect {

	private static int counter;
	
	@Autowired
	private JMSMessageProducer producer;
	
	@Before("execution(* *.getCategoryById(int))")
	public void before(){
		counter++;
		producer.sendLog("getCategory triggered" + counter);
		System.out.println("aspect triggered " + counter);
	}
}
