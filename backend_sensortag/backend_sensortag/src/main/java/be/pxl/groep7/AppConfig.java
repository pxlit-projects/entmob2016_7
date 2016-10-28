package be.pxl.groep7;


import org.apache.tomcat.jdbc.pool.DataSource;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.security.SecurityAutoConfiguration;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.EnableAspectJAutoProxy;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;
//import org.springframework.security.authentication.encoding.ShaPasswordEncoder;
//import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
//import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;

@Configuration
@EnableAutoConfiguration
@ComponentScan(basePackages={"be.pxl.groep7.models", "be.pxl.groep7.app", "be.pxl.groep7.rest", "be.pxl.groep7.aspecten"})
@EnableJpaRepositories("be.pxl.groep7.dao")
//@EnableGlobalMethodSecurity(securedEnabled = true)
@EnableAspectJAutoProxy
public class AppConfig {

	/*public void configureSecurity (AuthenticationManagerBuilder auth, DataSource ds) throws Exception {
		auth.jdbcAuthentication().passwordEncoder(new ShaPasswordEncoder(256))
			 .dataSource(ds)
			 .usersByUsernameQuery("SELECT name, password, enabled from user where name = ?")
			 .authoritiesByUsernameQuery("SELECT name, role from user where name = ?");
	}*/
}
