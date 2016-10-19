package app;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.ConfigurableApplicationContext;
import be.pxl.groep7.models.DistanceAppConfig;


@SpringBootApplication
public class Main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		ConfigurableApplicationContext ctx = SpringApplication.run(DistanceAppConfig.class, args);
	}

}
