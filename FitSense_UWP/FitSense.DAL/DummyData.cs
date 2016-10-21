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
                ID = 0,
                CategoryID = 0,
                Name = "Halter Lift",
                Description = "Raise your arm while holding the halter"
            },
            new Exercise()
            {
                ID = 1,
                CategoryID = 0,
                Name = "Halter Stretch",
                Description = "Hold the halters in front of you, stretch your arms and move them to the side of your shoulders"
            },
            new Exercise()
            {
                ID = 2,
                CategoryID = 1,
                Name = "Sit Up",
                Description = "Lay down on your back, feet stretched towards you. Now move your face towards your knees"
            }
        };

        public static List<Set> sets = new List<Set>()
        {
            new Set()
            {
                ExerciseID = 0,
                ID = 0,
                MaxTime = 30,
                Points = 10,
                Reps = 5
            },
            new Set()
            {
                ExerciseID = 0,
                ID = 1,
                MaxTime = 60,
                Points = 30,
                Reps = 12
            }
        };

        List<CompletedSet> completedSets = new List<CompletedSet>()
        {
            new CompletedSet()
            {
                CompletedSetID = 0,
                Duration = 10,
                SetID = 0,

            }
        };

        
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
