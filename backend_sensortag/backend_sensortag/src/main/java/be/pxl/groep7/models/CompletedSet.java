package be.pxl.groep7.models;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.NamedQuery;
import javax.persistence.Table;

@Entity
@Table(name="completed_set")
@NamedQuery(name="CompletedSet.getCompletedSetBySetId"
				, query="select cs from CompletedSet cs where cs.exercise_id=?1")
public class CompletedSet {
	
	@Id
	@Column(name="id")
	int id;
	
	@Column(name="exercise_id")
	int exerciseId;
	
	@Column(name="time")
	long time;
	
	@Column(name="duration")
	int duration;
	
	@Column(name="user_id")
	int user_id;
	
	public CompletedSet(int id, int exerciseId, long time, int duration, int user_id) {
		super();
		this.id = id;
		this.exerciseId = exerciseId;
		this.time = time;
		this.duration = duration;
		this.user_id = user_id;
	}
	
	public int getId() {
		return id;
	}
	
	public void setId(int id) {
		this.id = id;
	}
	
	public int getExerciseId() {
		return exerciseId;
	}
	
	public void setExerciseId(int exerciseId) {
		this.exerciseId = exerciseId;
	}
	
	public long getTime() {
		return time;
	}
	
	public void setTime(long time) {
		this.time = time;
	}
	
	public int getDuration() {
		return duration;
	}
	
	public void setDuration(int duration) {
		this.duration = duration;
	}
	
	public int getUser_id() {
		return user_id;
	}
	
	public void setUser_id(int user_id) {
		this.user_id = user_id;
	}
	
	

}
