package be.pxl.groep7.models;

public class Serie {
	
	int id;
	int repeats;
	int exercise_id;
	int points;
	int maxTime;
	
	public Serie(int id, int repeats, int exercise_id, int points, int maxTime) {
		this.id = id;
		this.repeats = repeats;
		this.exercise_id = exercise_id;
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
	
	public int getExercise_id() {
		return exercise_id;
	}
	
	public void setExercise_id(int exercise_id) {
		this.exercise_id = exercise_id;
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
