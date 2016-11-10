package be.pxl.groep7;

import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.EnableAspectJAutoProxy;
import org.springframework.context.annotation.Import;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;
import org.springframework.web.servlet.config.annotation.EnableWebMvc;

@Configuration
@EnableAutoConfiguration
@EnableGlobalMethodSecurity(securedEnabled = true)
@EnableAspectJAutoProxy
@EnableWebMvc				//For the REST controller: @RequestBody/@ResponseBody 
@Import({SecurityConfig.class, ComponentScanConfig.class})
public class AppConfig  {
	
	
}
