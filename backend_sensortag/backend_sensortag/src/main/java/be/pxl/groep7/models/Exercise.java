package be.pxl.groep7.models;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.NamedQuery;
import javax.persistence.Table;

@Entity
@Table(name="exercise")
@NamedQuery(name="Exercise.getExerciseByCategoryId"
				, query="select ex from Exercise ex where ex.category_id=?1")
public class Exercise {
	
	@Id
	@Column(name="id")
	int id;
	
	@Column(name="name")
	String name;
	
	@Column(name="description")
	String description;
	
	@Column(name="category_id")
	int category_id;
	
	public Exercise() {
		
	}
		
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
