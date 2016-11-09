﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitsense.Models
{
    public class Category : SensorModel
    {
        public string Name { get; set; }
        //dit is NIET voor de db, maar voor de JSON!
        [JsonIgnore]
        public List<Exercise> Exercises { get; set; }
    }
}
