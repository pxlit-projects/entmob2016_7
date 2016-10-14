﻿using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FitSenseApp.Pages
{
    public partial class CharacteristicList : ContentPage
    {
        IAdapter adapter;
        IDevice device;
        IService service;

        ObservableCollection<ICharacteristic> characteristics;

        public CharacteristicList(IAdapter adapter, IDevice device, IService service)
        {
            InitializeComponent();
            this.adapter = adapter;
            this.device = device;
            this.service = service;
            this.characteristics = new ObservableCollection<ICharacteristic>();

            listView.ItemsSource = characteristics;

            // when characteristics are discovered
            service.CharacteristicsDiscovered += (object sender, EventArgs e) => {
                Debug.WriteLine("service.CharacteristicsDiscovered");
                if (characteristics.Count == 0)
                    Device.BeginInvokeOnMainThread(() => {
                        foreach (var characteristic in service.Characteristics)
                        {
                            characteristics.Add(characteristic);
                        }
                    });
            };

            // start looking for characteristics
            service.DiscoverCharacteristics();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (characteristics.Count == 0)
            {
                Debug.WriteLine("No characteristics, attempting to find some");
                // start looking for the device
                adapter.ConnectToDevice(device);
            }
        }
        /// <summary>
        /// Display a Characteristics Page
        /// </summary>
        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (((ListView)sender).SelectedItem == null)
            {
                return;
            }

            var characteristic = e.SelectedItem as ICharacteristic;
            ContentPage characteristicsPage = null;

            if (characteristic.Name.Contains("On/Off"))
            {
                characteristicsPage = new CharacteristicDetail_TISwitch(adapter, device, service, characteristic);
            }
            else if (true)
            {
                characteristicsPage = new CharacteristicDetail_TISensor(adapter, device, service, characteristic);
            }
            else
            {
                //characteristicsPage = new CharacteristicDetail(adapter, device, service, characteristic);
            }

            Navigation.PushAsync(characteristicsPage);

            ((ListView)sender).SelectedItem = null; // clear selection
        }
    }
}
