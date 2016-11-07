package be.pxl.groep7.jms;

import javax.jms.Message;

import org.springframework.jms.annotation.JmsListener;
import org.springframework.stereotype.Component;

@Component
public class JMSMessageConsumer {

    @JmsListener(destination = "messageQue")
    public void onMessage(Message message) {
        System.out.println("Hi, I'm JMSMessageConsumer and I got "+message);
    }
}
