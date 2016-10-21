using FitSense.Model;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using FitSense.DAL;

namespace FitSense.DAL
{
    public class SensorRepository<T> : ISensorRepository<T> where T : SensorModel
    {
        // voorlopig: 1 model (negeer het generische deel)
        // het generische verhaal gaat maar werken eenmaal we een rest service hebben
        // Dan kunnen we /call/classname/actie doen en de service gaat de data zo verwerken
        // statische lijsten kunnen deze calls niet verwerken


        //private DummyData d = new DummyData<Distance>();

        public List<T> records = new List<T>();

        public SensorRepository()
        {
            //distances.Add(DummyData.d);
        }

        public List<T> GetAllRecords()
        {
            return records;
        }

        public T GetRecordDetail(int id)
        {
            return records.Where(r => r.ID == id).FirstOrDefault();
        }

        public void UpdateRecord(T sensorModel)
        {
            //nogmaals, werkt vooropig enkel op distance (later bij rest volledig implementeren)
            T recordToUpdate = records.Where(r => r.ID == sensorModel.ID).FirstOrDefault();
            recordToUpdate = sensorModel;
        }

        public void DeleteRecord(T record)
        {
            records.Remove(record);
        }
    }
}

