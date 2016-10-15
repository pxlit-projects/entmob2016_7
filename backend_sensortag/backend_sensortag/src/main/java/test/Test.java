package test;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.ConfigurableApplicationContext;
import org.springframework.format.datetime.joda.LocalDateParser;

import be.pxl.groep7.models.Distance;
import be.pxl.groep7.models.SensorModel;
import be.pxl.groep7.repository.DistanceAppConfig;
import be.pxl.groep7.repository.DistanceRepository;

import java.time.LocalDate;
import java.util.Date;

@SpringBootApplication
public class Test {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		ConfigurableApplicationContext ctx = SpringApplication.run(DistanceAppConfig.class, args);
		
		DistanceRepository dr = ctx.getBean("distanceRepository", DistanceRepository.class);
		
		
		SensorModel dist = new Distance(1, LocalDate.now(), 5, 1500);
		dr.addDistance(dist);
			
		
		Distance dis = dr.getDistanceById(1);
		System.out.println(dis);
		//SpringApplication.run(Test.class, args);
	}

}
