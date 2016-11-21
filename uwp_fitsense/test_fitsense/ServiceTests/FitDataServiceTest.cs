using fitsense.DAL.dependencies;
using fitsense.models;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.fitsense.dal;
using test.fitsense.dal.mocks;
using uwp_fitsense.dependencies;
using uwp_fitsense.services;

namespace test_fitsense.ServiceTests
{
    [TestClass]
    public class FitDataServiceTest
    {
        private IFitDataService fitDataService;

        private ICategoryRepository categoryRepository;
        private IExerciseRepository exerciseRepository;
        private ISetRepository setRepository;
        private ICompletedSetRepository completedSetRepository;

        [TestInitialize]
        public void Init()
        {
            categoryRepository = new MockCategoryRepository();
            exerciseRepository = new MockExerciseRepository();
            setRepository = new MockSetRepository();
            completedSetRepository = new MockCompletedSetRepository();

            fitDataService = new FitDataService(categoryRepository, exerciseRepository, setRepository, completedSetRepository);
        }

        [TestMethod]
        public void LoadAllCategoriesFromService()
        {
            var categories = fitDataService.GetAllCategoriesAsync().Result;
            var categoriesReal = TestData.categories;

            CollectionAssert.AreEqual(categories, categoriesReal);
        }

        [TestMethod]
        public void AddOneCategoryAndTestIfListIsBigger()
        {
            fitDataService.AddCategoryAsync(new Category { CategoryID = 3, Name = "Category 3" });
            var categories = fitDataService.GetAllCategoriesAsync().Result;

            var categoriesReal = TestData.categories;
            CollectionAssert.AreEqual(categories, categoriesReal);
        }

        [TestMethod]
        public void LoadAllExercisesWithCategoryID1FromService()
        {
            var exercises = fitDataService.GetExercisesFromCategoryAsync(new Category() { CategoryID = 1 }).Result;
            var exercisesReal = TestData.exercises.Where(e => e.CategoryID == 1).ToList();

            CollectionAssert.AreEqual(exercises, exercisesReal);
        }

        [TestMethod]
        public void LoadAllExercisesWithoutCategoryReturnsNull()
        {
            var exercises = fitDataService.GetExercisesFromCategoryAsync(null).Result;

            CollectionAssert.AreEqual(exercises, null);
        }

        [TestMethod]
        public void LoadAllSetsWithExerciseIDFromService()
        {
            var sets = fitDataService.GetSetsFromExerciseAsync(new Exercise() { ExerciseID = 1 }).Result;
            var setsReal = TestData.sets.Where(s => s.ExerciseID == 1).ToList();

            CollectionAssert.AreEqual(sets, setsReal);
            
        }

        [TestMethod]
        public void LoadAllCompletedSetsWithSetID1FromService()
        {
            var completedSets = fitDataService.GetCompletedSetsFromSetAsync(new Set() { SetID = 1}).Result;
            var completedSetsReal = TestData.completedSets.Where(cs => cs.SetID == 1).ToList();

            CollectionAssert.AreEqual(completedSets, completedSetsReal);
        }

        [TestMethod]
        public void ToggleSetVisibility()
        {
            var set = fitDataService.ToggleSelectedSetVisibility(new Set() { ShowCompletedSets = false });

            Assert.AreEqual(set.ShowCompletedSets, true); 
        }

    }
}
