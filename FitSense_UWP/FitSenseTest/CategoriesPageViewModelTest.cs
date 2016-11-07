﻿using Fitsense.Models;
using FitSense_UWP.Services;
using FitSense_UWP.ViewModel;
using FitSenseTest.mocks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSenseTest
{
    [TestClass]
    class CategoriesPageViewModelTest
    {
        private IFitDataService fitDataService;
        private INavigationService navigationService;

        private CategoriesPageViewModel GetViewModel()
        {
            return new CategoriesPageViewModel(this.fitDataService, this.navigationService);
        }

        [TestInitialize]
        public void Init()
        {
            fitDataService = new FitDataServiceMock();
            //dialogService = new MockDialogService();
        }

        [TestMethod]
        public void LoadAllCategories()
        {
            //Arrange
             ObservableCollection<Category> categories;
            var expectedCategories = fitDataService.GetAllCategories();

            //act
            var viewModel = GetViewModel();
            categories = viewModel.Categories;

            //assert
            CollectionAssert.AreEqual(expectedCategories, categories);
        }
    }
}