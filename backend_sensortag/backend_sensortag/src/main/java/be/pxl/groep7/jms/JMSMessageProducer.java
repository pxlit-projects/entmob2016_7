package be.pxl.groep7.jms;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jms.core.JmsTemplate;
import org.springframework.stereotype.Component;

@Component
public class JMSMessageProducer {

	@Autowired
	private JmsTemplate jmsTemplate;
	
    public void sendLog(String text){
    	jmsTemplate.send("LoggingQueue", s -> s.createTextMessage(text));
    }
}
