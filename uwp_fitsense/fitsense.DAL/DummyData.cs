using fitsense.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitsense.DAL
{
    public class DummyData
    {
        public static List<Category> categories = new List<Category>()
        {
            new Category()
            {
                CategoryID = 0,
                Name = "Arms"
            },
            new Category()
            {
                CategoryID = 1,
                Name = "Chest"
            },
            new Category()
            {
                CategoryID = 2,
                Name = "Leg"
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

        public static List<Set> sets = new List<Set>()
        {
            new Set()
            {
                ExerciseID = 0,
                SetID = 0,
                MaxTime = 30,
                Points = 10,
                Reps = 5,
                ShowCompletedSets = false//Windows.UI.Xaml.Visibility.Collapsed
            },
            new Set()
            {
                ExerciseID = 0,
                SetID = 1,
                MaxTime = 60,
                Points = 30,
                Reps = 12,
                ShowCompletedSets = false//Windows.UI.Xaml.Visibility.Collapsed
            }
        };

        public static List<CompletedSet> completedSets = new List<CompletedSet>()
        {
            new CompletedSet()
            {
                CompletedSetID = 0,
                Duration = 15,
                SetID = 0,
                Time = 191016240000,
                UserID = 0
            },
            new CompletedSet()
            {
                CompletedSetID = 0,
                Duration = 12,
                SetID = 0,
                Time = 201016120000,
                UserID = 0
            },
            new CompletedSet()
            {
                CompletedSetID = 0,
                Duration = 11,
                SetID = 0,
                Time = 201016160000,
                UserID = 0
            },
            new CompletedSet()
            {
                CompletedSetID = 1,
                Duration = 11,
                SetID = 1,
                Time = 211016160000,
                UserID = 0
            },
            new CompletedSet()
            {
                CompletedSetID = 1,
                Duration = 12,
                SetID = 1,
                Time = 211016170000,
                UserID = 0
            }
        };
    }
}
