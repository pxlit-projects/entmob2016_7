package be.pxl.groep7.models;

public interface DistanceRepository {
	public Distance2 getDistanceById(int id);
	public void addDistance(Distance2 distance);		//public void addDistance(SensorModel distance);	
}
