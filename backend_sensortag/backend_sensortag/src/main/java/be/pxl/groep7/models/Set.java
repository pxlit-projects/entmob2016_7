package be.pxl.groep7.models;
// !! DB TABLE: set_table !!

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.NamedQuery;
import javax.persistence.Table;

import org.springframework.boot.autoconfigure.SpringBootApplication;

@Entity
@Table(name="set_table")								// why set_table? "set" is a reserved keyword for mysql
@NamedQuery(name="Set.getSetsByExerciseId" 
					, query="select s from Set s where s.exerciseId=?1")
public class Set {
	
	@Id
	@Column(name="id")
	int id;
	
	@Column(name="repeats")
	int repeats;
	
	@Column(name="exercise_id")
	int exerciseId;
	
	@Column(name="points")
	int points;
	
	@Column(name="max_time")
	int maxTime;
	
	public Set() {
		
	}
	
	public Set(int id, int repeats, int exerciseId, int points, int maxTime) {
		this.id = id;
		this.repeats = repeats;
		this.exerciseId = exerciseId;
		this.points = points;
		this.maxTime = maxTime;
	}

	public int getId() {
		return id;
	}
	
	public void setId(int id) {
		this.id = id;
	}
	
	public int getRepeats() {
		return repeats;
	}
	
	public void setRepeats(int repeats) {
		this.repeats = repeats;
	}
	
	public int getExerciseId() {
		return exerciseId;
	}
	
	public void setExercise_id(int exerciseId) {
		this.exerciseId = exerciseId;
	}
	
	public int getPoints() {
		return points;
	}
	
	public void setPoints(int points) {
		this.points = points;
	}
	
	public int getMaxTime() {
		return maxTime;
	}
	
	public void setMaxTime(int maxTime) {
		this.maxTime = maxTime;
	}
	
	

}
