package be.pxl.groep7.models;




import java.util.Date;

import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import org.springframework.stereotype.Component;

@Component
@Entity
@Table(name="distance")
public class Distance2 {
	
	@Id
	private int id;
	
	
	private long time;
	private int amountOfSteps;
	private int height;
	
	
	public Distance2(){
		
	}
	
	public Distance2(int id, long time, int amountOfSteps, int height) {
		//super();
		this.id = id;
		this.time = time;
		this.amountOfSteps = amountOfSteps;
		this.height = height;
	}
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public long getTime() {
		return time;
	}
	public void setTime(long time) {
		this.time = time;
	}
	public int getAmountOfSteps() {
		return amountOfSteps;
	}
	public void setAmountOfSteps(int amountOfSteps) {
		this.amountOfSteps = amountOfSteps;
	}
	public int getHeight() {
		return height;
	}
	public void setHeight(int height) {
		this.height = height;
	}
	
	

}
