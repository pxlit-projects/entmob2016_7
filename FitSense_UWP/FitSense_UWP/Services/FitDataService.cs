using FitSense.DAL;
using FitSense.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense_UWP.Services
{
    class FitDataService : IFitDataService
    {
        SensorRepository<Distance> repository;

        public void DeleteRecord(Distance distance)
        {
            repository.DeleteRecord(distance);
        }

        public List<Distance> GetAllRecords()
        {
            //implementeren wanneer rest werkt!
            return DummyData.distances;
            //return repository.GetAllRecords();
        }

        public Distance GetRecordDetail(int id)
        {
            return DummyData.GetRecordDetail(id);
            //return repository.GetRecordDetail(id);
        }

        public void UpdateRecord(Distance distance)
        {
            DummyData.UpdateRecord(distance);
            //repository.UpdateRecord(distance);
        }
    }
}
