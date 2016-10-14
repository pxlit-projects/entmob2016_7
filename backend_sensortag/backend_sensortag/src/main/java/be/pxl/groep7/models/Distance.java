package be.pxl.groep7.models;

import java.time.LocalDate;
import java.util.Date;

import org.springframework.stereotype.Component;

@Component
public class Distance extends SensorModel {

	private LocalDate time;
	private int amountOfSteps;
	private int height;
	
}
