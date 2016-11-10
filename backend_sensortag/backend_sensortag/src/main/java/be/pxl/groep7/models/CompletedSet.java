package be.pxl.groep7.models;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQuery;
import javax.persistence.Table;

@Entity
@Table(name="completed_set")
@NamedQuery(name="CompletedSet.getCompletedSetsBySetId"
				, query="select cs from CompletedSet cs where cs.setId=?1")
public class CompletedSet {
	
	@Id
	@Column(name="id")
	@GeneratedValue(strategy=GenerationType.AUTO)
	int id;
	
	@Column(name="set_id")
	int setId;
	
	@Column(name="time")
	long time;
	
	@Column(name="duration")
	int duration;
	
	@Column(name="user_id")
	int userId;
	
	public CompletedSet(int id, int setId, long time, int duration, int userId) {
		super();
		this.id = id;
		this.setId = setId;
		this.time = time;
		this.duration = duration;
		this.userId = userId;
	}
	
	public CompletedSet() {
		
	}
	
	public int getId() {
		return id;
	}
	
	public void setId(int id) {
		this.id = id;
	}
	
	public int getSetId() {
		return setId;
	}
	
	public void setSetId(int setId) {
		this.setId = setId;
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
	
	public int getUserId() {
		return userId;
	}
	
	public void setUser_id(int userId) {
		this.userId = userId;
	}
	
	

}
