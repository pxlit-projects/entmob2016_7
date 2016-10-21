package be.pxl.groep7.app;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.ConfigurableApplicationContext;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.format.datetime.joda.LocalDateParser;

//import be.pxl.groep7.dao.IDistanceRepository;
//import be.pxl.groep7.models.Distance;
import be.pxl.groep7.models.Distance2;
import be.pxl.groep7.models.DistanceAppConfig;
//import be.pxl.groep7.models.SensorModel;

import java.sql.Timestamp;
import java.time.LocalDate;
import java.util.Date;

@SpringBootApplication
@ComponentScan({"be.pxl.groep7.rest", "be.pxl.groep7.dao", "be.pxl.groep7.models"})
public class Main {

	public static void main(String[] args) {
		SpringApplication.run(Main.class, args);
	}

}
