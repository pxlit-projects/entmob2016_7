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

        public List<T> distances = new List<T>();

        private static List<T> records;

        public SensorRepository()
        {
            //distances.Add(DummyData.d);
        }

        public void DeleteRecord(T sensorModel)
        {
            // TODO
        }

        public List<T> GetAllRecords()
        {
            return distances;
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

    }
}

