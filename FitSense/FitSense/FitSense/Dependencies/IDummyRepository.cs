﻿using fitsense.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense.Dependencies
{
    public interface IDummyRepository
    {
        IEnumerable<Category> GetAllCategories();
    }
}
