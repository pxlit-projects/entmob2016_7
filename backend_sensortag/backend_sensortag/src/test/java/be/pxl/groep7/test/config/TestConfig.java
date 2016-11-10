package be.pxl.groep7.test.config;

import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.Import;

import be.pxl.groep7.ComponentScanConfig;
import be.pxl.groep7.SecurityConfig;

@Configuration
@EnableAutoConfiguration
@Import(value={SecurityConfig.class, ComponentScanConfig.class})
public class TestConfig {

}
