package be.pxl.groep7;


import org.apache.tomcat.jdbc.pool.DataSource;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.security.SecurityAutoConfiguration;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.EnableAspectJAutoProxy;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;
import org.springframework.jdbc.datasource.DriverManagerDataSource;
import org.springframework.security.authentication.encoding.ShaPasswordEncoder;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.web.client.RestTemplate;
import org.springframework.web.servlet.config.annotation.EnableWebMvc;

@Configuration
@EnableAutoConfiguration
@ComponentScan(basePackages={"be.pxl.groep7.models", "be.pxl.groep7.app", "be.pxl.groep7.rest", "be.pxl.groep7.aspecten"})
@EnableJpaRepositories("be.pxl.groep7.dao")
@EnableGlobalMethodSecurity(securedEnabled = true)
@EnableAspectJAutoProxy
//@EnableWebSecurity
@EnableWebMvc
public class AppConfig extends WebSecurityConfigurerAdapter {

	@Bean
	public RestTemplate restTemplate() {
	    return new RestTemplate();
	}
	
	@Autowired
	private DataSource dataSource;
	
	@Autowired
	public void configAuthentication(AuthenticationManagerBuilder auth) throws Exception {

	  auth.jdbcAuthentication().dataSource(dataSource)
		.usersByUsernameQuery(
			"select username,password, enabled from users where username=?")
		.authoritiesByUsernameQuery(
			"select username, role from user_roles where username=?");
	}
	
	/*@Override
	protected void configure(HttpSecurity http) throws Exception {

	  http.authorizeRequests()
		.antMatchers("/sensortagapi/category").access("hasRole('ROLE_USER')")
		.and()
		  .formLogin().loginPage("/login").failureUrl("/login?error")
		  .usernameParameter("username").passwordParameter("password")
		.and()
		  .logout().logoutSuccessUrl("/login?logout")
		.and()
		  .exceptionHandling().accessDeniedPage("/403")
		.and()
		  .csrf();
	}*/

	
	/*public void configureSecurity (AuthenticationManagerBuilder auth, DataSource ds) throws Exception {
		auth.jdbcAuthentication().passwordEncoder(new ShaPasswordEncoder(256))
			 .dataSource(ds)
			 .usersByUsernameQuery("SELECT name, password, enabled from user where name = ?")
			 .authoritiesByUsernameQuery("SELECT name, role from user where name = ?");
	}*/
}
