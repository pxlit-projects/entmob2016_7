package be.pxl.groep7.models;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQuery;
import javax.persistence.Table;

import com.fasterxml.jackson.annotation.JsonProperty;

@Entity
@Table(name="completed_set")
@NamedQuery(name="CompletedSet.getCompletedSetsBySetId"
				, query="select cs from CompletedSet cs where cs.setId=?1")
public class CompletedSet {
	
	@Id
	@Column(name="id")
	@GeneratedValue(strategy=GenerationType.AUTO)
	@JsonProperty(value="CompletedSetID")
	int id;

	@Column(name="set_id")
	@JsonProperty(value="SetID")
	int setId;
	
	@Column(name="time")
	@JsonProperty(value="Time")
	long time;
	
	@Column(name="duration")
	@JsonProperty(value="Duration")
	int duration;
	
	@Column(name="user_id")
	@JsonProperty(value="UserID")
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
	
	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + id;
		return result;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		CompletedSet other = (CompletedSet) obj;
		if (id != other.id)
			return false;
		return true;
	}

}
