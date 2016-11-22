using fitsense.DAL.dependencies;
using fitsense.models;
using FitSense.Dependencies;
using FitSense.Services;
using FitSense.ViewModels;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.fitsense.mocks;
using test.fitsense.mocks.Repository;

namespace test.fitsense.Tests.Services
{
    [TestClass]
    public class DataServiceTest
    {
        private UserRepositoryMock userRepository;
        private CategoryRepositoryMock categoryRepository;
        private ExerciseRepositoryMock exerciseRepository;
        private SetRepositoryMock setRepository;
        private CompletedSetRepositoryMock completedSetRepository;

        [TestInitialize]
        public void Init()
        {
            userRepository = new UserRepositoryMock();
            categoryRepository = new CategoryRepositoryMock();
            exerciseRepository = new ExerciseRepositoryMock();
            setRepository = new SetRepositoryMock();
            completedSetRepository = new CompletedSetRepositoryMock();
        }

        [TestMethod]
        public void LoginTest()
        {
            IDataService dataService = new DataService(userRepository,
                                                        categoryRepository,
                                                        exerciseRepository,
                                                        setRepository,
                                                        completedSetRepository);
            Task task = dataService.LoginAsync("Daniel", "Password");
            task.Wait();

            Assert.IsNotNull(dataService.LoggedInUser);
            Assert.AreEqual("Daniel", dataService.LoggedInUser.Name);
        }

        [TestMethod]
        public void searchUserTest()
        {
            IDataService dataService = new DataService(userRepository,
                                                        categoryRepository,
                                                        exerciseRepository,
                                                        setRepository,
                                                        completedSetRepository);
            var user = dataService.SearchUser("Daniel");
            Assert.AreEqual("Daniel", user.Name);
        }

        [TestMethod]
        public void GetAllCategoriesAsyncTest()
        {
            var categories = new List<Category>()
            {
                new Category
                {
                    Name = "Arms"
                }
            };
            categoryRepository.Categories = categories;
            IDataService dataService = new DataService(userRepository,
                                                        categoryRepository,
                                                        exerciseRepository,
                                                        setRepository,
                                                        completedSetRepository);

            Task<List<Category>> task = dataService.GetAllCategoriesAsync();
            var result = task.Result;

            Assert.AreEqual(categories[0].Name, result[0].Name);
        }

        [TestMethod]
        public void GetExercisesFromCategoryAsyncTest()
        {
            var categories = new List<Category>()
            {
                new Category
                {
                    CategoryID = 1,
                    Name = "Arms"
                }
            };
            var exercises = new List<Exercise>()
            {
                new Exercise
                {
                    CategoryID = 1,
                    Name = "Lift"
                },
                new Exercise
                {
                    CategoryID = 2,
                    Name = "Not Lift"
                }
            };
            categoryRepository.Categories = categories;
            exerciseRepository.Exercises = exercises;
            IDataService dataService = new DataService(userRepository,
                                                        categoryRepository,
                                                        exerciseRepository,
                                                        setRepository,
                                                        completedSetRepository);
            Task<List<Exercise>> task = dataService.GetExercisesFromCategoryAsync(categories[0]);
            var result = task.Result;

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(exercises[0].Name, result[0].Name);
        }

        [TestMethod]
        public void GetSetsFromExerciseAsyncTest()
        {
            var exercises = new List<Exercise>()
            {
                new Exercise
                {
                    CategoryID = 1,
                    ExerciseID = 1,
                    Name = "Lift"
                },
                new Exercise
                {
                    CategoryID = 2,
                    ExerciseID = 2,
                    Name = "Not Lift"
                }
            };

            var sets = new List<Set>()
            {
                new Set
                {
                    ExerciseID = 1,
                    SetID = 1
                },
                new Set
                {
                    ExerciseID = 2,
                    SetID = 1
                }
            };

            exerciseRepository.Exercises = exercises;
            setRepository.Sets = sets;
            IDataService dataService = new DataService(userRepository,
                                                        categoryRepository,
                                                        exerciseRepository,
                                                        setRepository,
                                                        completedSetRepository);

            Task<List<Set>> task = dataService.GetSetsFromExerciseAsync(exercises[0]);
            var result = task.Result;

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(sets[0].SetID, result[0].SetID);
        }

        [TestMethod]
        public void GetSetViewModelsFromExerciseAsyncTest()
        {
            var exercises = new List<Exercise>()
            {
                new Exercise
                {
                    CategoryID = 1,
                    ExerciseID = 1,
                    Name = "Lift"
                },
                new Exercise
                {
                    CategoryID = 2,
                    ExerciseID = 2,
                    Name = "Not Lift"
                }
            };

            var sets = new List<Set>()
            {
                new Set
                {
                    ExerciseID = 1,
                    SetID = 1
                },
                new Set
                {
                    ExerciseID = 2,
                    SetID = 1
                }
            };

            exerciseRepository.Exercises = exercises;
            setRepository.Sets = sets;
            IDataService dataService = new DataService(userRepository,
                                                        categoryRepository,
                                                        exerciseRepository,
                                                        setRepository,
                                                        completedSetRepository);

            Task<List<SetViewModel>> task = dataService.GetSetViewModelsFromExerciseAsync(exercises[0],
                new NavigationServiceMock());
            var result = task.Result;

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(sets[0].SetID, result[0].Set.SetID);
            Assert.AreEqual(exercises[0].ExerciseID, result[0].Exercise.ExerciseID);
        }

    }
}
