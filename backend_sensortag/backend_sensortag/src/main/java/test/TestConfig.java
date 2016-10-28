package test;

import javax.sql.DataSource;

import org.springframework.beans.factory.annotation.Autowired;
//import org.apache.tomcat.jdbc.pool.DataSource;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
/*import org.springframework.security.authentication.encoding.ShaPasswordEncoder;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;
import org.springframework.security.config.annotation.web.WebSecurityConfigurer;
import org.springframework.security.config.annotation.web.builders.WebSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;*/
import org.springframework.web.client.RestTemplate;

@EnableAutoConfiguration
@ComponentScan(basePackages={"be.pxl.groep7.models", "be.pxl.groep7.app", "be.pxl.groep7.rest"})
//@EnableGlobalMethodSecurity(prePostEnabled = true)
//@EnableWebSecurity
public class TestConfig  /*extends WebSecurityConfigurerAdapter */{
	@Bean
	public RestTemplate restTemplate() {
	    return new RestTemplate();
	}
	
	@Autowired
	private DataSource dataSource;
	
	/* @Override
	    protected void configure(AuthenticationManagerBuilder auth) throws Exception {
	        auth.jdbcAuthentication()
	                .dataSource(dataSource)
	                .usersByUsernameQuery("select username, password, enabled from users where username = ?")
	                .authoritiesByUsernameQuery("select username, role from users where username = ?")
	                .passwordEncoder(new BCryptPasswordEncoder())
	        ;
	    }*/
}
