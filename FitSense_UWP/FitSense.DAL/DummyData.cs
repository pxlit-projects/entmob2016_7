﻿using FitSense.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense.DAL
{
    public class DummyData
    {
        public static List<Category> categories = new List<Category>()
        {
            new Category()
            {
                ID = 0,
                Name = "Arms"
            },
            new Category()
            {
                ID = 1,
                Name = "Chest"
            }
        };

        public static List<Exercise> exercises = new List<Exercise>()
        {
            new Exercise()
            {
                ExerciseID = 0,
                CategoryID = 0,
                Name = "Halter Lift",
                Description = "Raise your arm while holding the halter"
            },
            new Exercise()
            {
                ExerciseID = 1,
                CategoryID = 0,
                Name = "Halter Stretch",
                Description = "Hold the halters in front of you, stretch your arms and move them to the side of your shoulders"
            },
            new Exercise()
            {
                ExerciseID = 2,
                CategoryID = 1,
                Name = "Sit Up",
                Description = "Lay down on your back, feet stretched towards you. Now move your face towards your knees"
            }
        };

        /*List<Set>

        List<CompletedSet> completedSets = new List<CompletedSet>()
        {
            new CompletedSet()
            {
                CompletedSetID = 0,
                Duration = 10,
                SetID = 0,

            }
        }*/

        
        public static void Remove(Category record)
        {
            categories.Remove(record);
        }

        public static Category GetCategoryDetail(int id)
        {
            return categories.Where(r => r.ID == id).FirstOrDefault();
        }

        public static void UpdateCategory(Category dist)
        {
            //nogmaals, werkt vooropig enkel op distance (later bij rest volledig implementeren)
            Category recordToUpdate = categories.Where(r => r.ID == dist.ID).FirstOrDefault();
            recordToUpdate = dist;
        }

    }
}
