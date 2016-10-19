package be.pxl.groep7.models;

public class Temperature {
	
	int id;
	long time;
	int temperature;
	int user_id;	
	
	public Temperature(int id, long time, int temperature, int user_id) {
		this.id = id;
		this.time = time;
		this.temperature = temperature;
		this.user_id = user_id;
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
	
	public int getTemperature() {
		return temperature;
	}
	
	public void setTemperature(int temperature) {
		this.temperature = temperature;
	}
	
	public int getUser_id() {
		return user_id;
	}
	
	public void setUser_id(int user_id) {
		this.user_id = user_id;
	}

}
