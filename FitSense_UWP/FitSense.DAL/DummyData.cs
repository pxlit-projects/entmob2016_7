using FitSense.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense.DAL
{
    public class DummyData
    {
        public static List<Distance> distances = new List<Distance>()
            {
                new Distance()
                {
                    AmountOfSteps = 100,
                    ID = 0
                },
                new Distance()
                {
                    AmountOfSteps = 200,
                    ID = 1
                },
                new Distance()
                {
                    AmountOfSteps = 150,
                    ID = 2
                },
                new Distance()
                {
                    AmountOfSteps = 180,
                    ID = 3
                },
                new Distance()
                {
                    AmountOfSteps = 120,
                    ID = 4
                },
                new Distance()
                {
                    AmountOfSteps = 100,
                    ID = 5
                }
            };

        public static void Remove(Distance record)
        {
            distances.Remove(record);
        }

        public static Distance GetRecordDetail(int id)
        {
            return distances.Where(r => r.ID == id).FirstOrDefault();
        }

        public static void UpdateRecord(Distance dist)
        {
            //nogmaals, werkt vooropig enkel op distance (later bij rest volledig implementeren)
            Distance recordToUpdate = distances.Where(r => r.ID == dist.ID).FirstOrDefault();
            recordToUpdate = dist;
        }

    }
}
