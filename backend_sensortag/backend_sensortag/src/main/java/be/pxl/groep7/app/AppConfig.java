package be.pxl.groep7.app;


import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;

@Configuration
@EnableAutoConfiguration
@ComponentScan(basePackages={"be.pxl.groep7.models", "be.pxl.groep7.app", "be.pxl.groep7.rest"})
@EnableJpaRepositories("be.pxl.groep7.dao")
public class AppConfig {

}
