using FitSense.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense_UWP.Services
{
    public interface IFitDataService
    {
        void DeleteRecord(Distance distance);
        //TODO generisch maken
        List<Distance> GetAllRecords();
        Distance GetRecordDetail(int id);
        void UpdateRecord(Distance distance);
    }
}
