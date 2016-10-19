package app;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.ConfigurableApplicationContext;
import org.springframework.format.datetime.joda.LocalDateParser;

import be.pxl.groep7.dao.IDistanceRepository;
//import be.pxl.groep7.models.Distance;
import be.pxl.groep7.models.Distance2;
import be.pxl.groep7.models.DistanceAppConfig;
import be.pxl.groep7.models.SensorModel;

import java.sql.Timestamp;
import java.time.LocalDate;
import java.util.Date;

@SpringBootApplication
public class Main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		ConfigurableApplicationContext ctx = SpringApplication.run(DistanceAppConfig.class, args);
		
		IDistanceRepository dr = ctx.getBean("distanceRepository", IDistanceRepository.class);
		
		
		//SensorModel dist = new Distance(1, LocalDate.now(), 5, 1500);
		
		//Distance2 dist = new Distance2(1, 25L, 5, 1500);
		//dr.addDistance(dist);
			
		
		Distance2 dis = dr.getDistanceById(1);
		System.out.println(dis);
		//SpringApplication.run(Test.class, args);
	}

}
