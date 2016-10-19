package be.pxl.groep7.models;

public class Exercise {
	
	int id;
	String name;
	String description;
	int category_id;
		
	public Exercise(int id, String name, String description, int category_id) {
		this.id = id;
		this.name = name;
		this.description = description;
		this.category_id = category_id;
	}

	public int getId() {
		return id;
	}
	
	public void setId(int id) {
		this.id = id;
	}
	
	public String getName() {
		return name;
	}
	
	public void setName(String name) {
		this.name = name;
	}
	
	public String getDescription() {
		return description;
	}
	
	public void setDescription(String description) {
		this.description = description;
	}
	
	public int getCategory_id() {
		return category_id;
	}
	
	public void setCategory_id(int category_id) {
		this.category_id = category_id;
	}
}
