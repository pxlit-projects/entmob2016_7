using Fitsense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense.DAL
{
    interface ISensorRepository
    {
        void RemoveCategory(Category record);
        Category GetCategoryDetail(int id);
        void UpdateCategory(Category dist);
    }
}
