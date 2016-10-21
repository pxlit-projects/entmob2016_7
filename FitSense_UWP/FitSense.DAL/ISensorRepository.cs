using FitSense.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense.DAL
{
    interface ISensorRepository<T> where T : SensorModel
    {
        void DeleteRecord(T record);
        //TODO generisch maken
        List<T> GetAllRecords();
        T GetRecordDetail(int id);
        void UpdateRecord(T record);
    }
}
