﻿using Fitsense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense.DAL
{
    public interface ISetRepository
    {
        List<Set> GetSetsFromExercise(Exercise exercise);
    }
}
