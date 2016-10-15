package be.pxl.groep7.repository;

import be.pxl.groep7.models.Distance;
import be.pxl.groep7.models.SensorModel;

public interface DistanceRepository {
	public Distance getDistanceById(int id);
	public void addDistance(SensorModel distance);
}
