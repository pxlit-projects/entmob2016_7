package be.pxl.groep7.models;

import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.domain.EntityScan;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;

@SpringBootApplication
//@EnableJpaRepositories("be.pxl.groep7.dao")			//This does not work, but it should work
@ComponentScan("be.pxl.groep7.dao")
public class DistanceAppConfig {

}
