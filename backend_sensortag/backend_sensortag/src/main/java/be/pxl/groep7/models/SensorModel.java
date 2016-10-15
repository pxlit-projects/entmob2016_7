package be.pxl.groep7.models;

import javax.persistence.Column;
import javax.persistence.Id;

public abstract class SensorModel {

	@Id	
	private int id;
	
	public SensorModel(int id){
		this.id = id;
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}
	
	
}
