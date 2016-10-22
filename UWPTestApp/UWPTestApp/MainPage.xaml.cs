using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPTestApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<ISeries> serieList;
        List<ISeries> SerieList
        {
            get
            {
                return serieList;
            }
            set
            {
                serieList = value;
            }
        }
        public class Records
        {
            public string Name
            {
                get;
                set;
            }
            public int Amount
            {
                get;
                set;
            }
        }

        public MainPage()
        {
            this.InitializeComponent();

            LoadChartContents();

            serieList = new List<ISeries>();
            ISeries serie = new ISeries()
            {

            };

        
            
        }

        class testclass : ISeries


        private void LoadChartContents()
        {
            Random rand = new Random();
            List<Records> records = new List<Records>();
            records.Add(new Records()
            {
                Name = "Suresh",
                Amount = rand.Next(0, 200)
            });
            records.Add(new Records()
            {
                Name = "C# Corner",
                Amount = rand.Next(0, 200)
            });
            records.Add(new Records()
            {
                Name = "Sam",
                Amount = rand.Next(0, 200)
            });
            records.Add(new Records()
            {
                Name = "Sri",
                Amount = rand.Next(0, 200)
            });
            (PieChart.Series[0] as PieSeries).ItemsSource = records;
            (ColumnChart.Series[0] as ColumnSeries).ItemsSource = records;
            
            (lineChart.Series[0] as LineSeries).ItemsSource = records;
            (BubbleChart.Series[0] as BubbleSeries).ItemsSource = records;
            (ScatterChart.Series[0] as ScatterSeries).ItemsSource = records;
            (AreaChart.Series[0] as AreaSeries).ItemsSource = records;

        }
    }
}
