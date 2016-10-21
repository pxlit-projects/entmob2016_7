package be.pxl.groep7.app;

import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;

@Configuration
@EnableAutoConfiguration
@ComponentScan(basePackages={"be.pxl.groep7.models", "be.pxl.groep7.app", "be.pxl.groep7.dao", "be.pxl.groep7.rest"})
public class AppConfig {

}
