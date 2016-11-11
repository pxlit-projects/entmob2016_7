package be.pxl.groep7.jms;

import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.TextMessage;

//import org.apache.logging.log4j.LogManager;
//import org.apache.logging.log4j.Logger;
import org.springframework.jms.annotation.JmsListener;
import org.springframework.stereotype.Component;


@Component
public class JMSMessageConsumer {
	
	final static org.apache.log4j.Logger logger = org.apache.log4j.LogManager.getLogger(JMSMessageConsumer.class);

    @JmsListener(destination = "LoggingQueue")
    public void onMessage(Message message) {
    	try {
			if (message instanceof TextMessage) {
				String text = ((TextMessage) message).getText();
				if (text.contains("httpResponse: 404")) {
					logger.warn(text);
				} else {
					logger.info(text);
				}
			}
		} catch (JMSException e) {
			e.printStackTrace();
			System.out.println("FUCKED Up!");
		}
	}
}
