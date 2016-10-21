package be.pxl.groep7.models;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name="exercise_point")
public class ExercisePoint {
	
	@Id
	@Column(name="id")
	int id;
	
	@Column(name="x")
	double x;
	
	@Column(name="y")
	double y;
	
	@Column(name="z")
	double z;
	
	public ExercisePoint(int id, double x, double y, double z) {
		super();
		this.id = id;
		this.x = x;
		this.y = y;
		this.z = z;
	}

	public int getId() {
		return id;
	}
	
	public void setId(int id) {
		this.id = id;
	}
	
	public double getX() {
		return x;
	}
	
	public void setX(double x) {
		this.x = x;
	}
	
	public double getY() {
		return y;
	}
	
	public void setY(double y) {
		this.y = y;
	}
	
	public double getZ() {
		return z;
	}
	
	public void setZ(double z) {
		this.z = z;
	}
	
	

}
