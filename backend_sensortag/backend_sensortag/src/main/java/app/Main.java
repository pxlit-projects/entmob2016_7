package app;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.ConfigurableApplicationContext;
import org.springframework.format.datetime.joda.LocalDateParser;

//import be.pxl.groep7.models.Distance;
import be.pxl.groep7.models.Distance2;
import be.pxl.groep7.models.DistanceAppConfig;

import java.sql.Timestamp;
import java.time.LocalDate;
import java.util.Date;

@SpringBootApplication
public class Main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		ConfigurableApplicationContext ctx = SpringApplication.run(DistanceAppConfig.class, args);
	}

}
