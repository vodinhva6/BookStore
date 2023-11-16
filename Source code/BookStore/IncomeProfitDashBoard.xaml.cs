using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Microsoft.Identity.Client;

namespace BookStore
{
    /// <summary>
    /// Interaction logic for IncomeProfitDashBoard.xaml
    /// </summary>
    /// 
    public partial class IncomeProfitDashBoard : Window
    {

        Random Random = new Random();
        public Double randomInRange(Double min, Double max)
        {
            return Random.Next() % (max - min) + min;
        }
        RevenueProfitDAO RPDAO = new RevenueProfitDAO();
        ChartValues<ObservableValue> ColumnUIRevenues = new ChartValues<ObservableValue>() {
            new ObservableValue(0.7)
        };
        ChartValues<ObservableValue> ColumnUIProfits = new ChartValues<ObservableValue>(){
            new ObservableValue(0.3)
        };
        public async void GetAll(string preiod)
        {
            try
            {

                ObservableCollection<RevenueProfit> data = await Task.Run(() => RPDAO.GetAll(preiod));
                ColumnUIRevenues.Clear();
                ColumnUIProfits.Clear();
                IPChart.AxisX.Clear();
                List<string> TitleAxisX = new List<string>();
                foreach (RevenueProfit p in data)
                {

                    ColumnUIRevenues.Add(new ObservableValue(p.Revenue));
                    ColumnUIProfits.Add(new ObservableValue(p.Profit));
                    TitleAxisX.Add(p.Preiod);


                }
                IPChart.AxisX.Add(new LiveCharts.Wpf.Axis
                {
                    Title = "Datetime",
                    Labels = TitleAxisX,
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }


        string currentPreiod = "year";
        public String ShowParseLabelRevenue(ChartPoint label)
        {
            Double yRevenue = label.Y;

            Double yProfit = ColumnUIProfits[Convert.ToInt32(label.X)].Value;


            Double MaxRevenue = ColumnUIRevenues.Max(o => o.Value);
            Double MinRevenue = ColumnUIRevenues.Min(o => o.Value);

            Double MaxProfit = ColumnUIProfits.Max(o => o.Value);
            Double MinProfit = ColumnUIProfits.Min(o => o.Value);

            if (yRevenue == MaxRevenue || yRevenue == MinRevenue ||
                yProfit == MaxProfit || yProfit == MinProfit)
            {
                return $"{yRevenue:F2}";
            };
            return "";
        }
        public String ShowParseLabelProfit(ChartPoint label)
        {
            Double yProfit = label.Y;

            Double yRevenue = ColumnUIRevenues[Convert.ToInt32(label.X)].Value;

            Double MaxRevenue = ColumnUIRevenues.Max(o => o.Value);
            Double MinRevenue = ColumnUIRevenues.Min(o => o.Value);

            Double MaxProfit = ColumnUIProfits.Max(o => o.Value);
            Double MinProfit = ColumnUIProfits.Min(o => o.Value);

            if (yRevenue == MaxRevenue || yRevenue == MinRevenue ||
                yProfit == MaxProfit || yProfit == MinProfit)
            {
                return $"{yProfit:F2}";
            };
            return "";
        }

        public SeriesCollection ColumnSeriesCollection => new SeriesCollection
        {
            new ColumnSeries
            {
                Title = "Revenues",
                Values = ColumnUIRevenues,
                Fill = Brushes.DeepSkyBlue,
                LabelPoint=ShowParseLabelRevenue,
                DataLabels=true
            },
             new ColumnSeries
            {
                Title = "Profit",
                Values = ColumnUIProfits,
                Fill = Brushes.LightSeaGreen,
                LabelPoint=ShowParseLabelProfit,
                DataLabels=true

            }
        };




        public ObservableValue CostUI = new ObservableValue(0.3);
        public ObservableValue ProfitUI = new ObservableValue(0.7);

        public SeriesCollection PieSeriesCollection => new SeriesCollection
        {
            new PieSeries
            {
                Title = "Cost",
                Values = new ChartValues<ObservableValue> { CostUI  },
                Fill = Brushes.OrangeRed,
                DataLabels = true,
                LabelPoint = label => $"{label.Participation:P}"
            },
             new PieSeries
            {
                Title = "Profit",
                Values = new ChartValues<ObservableValue> { ProfitUI },
                Fill = Brushes.LightSeaGreen,
                DataLabels = true,
                LabelPoint = label => $"{label.Participation:P}"
            }
        };
        // todo load DAO
        private void ColumnSeries_OnDataClick(object sender, ChartPoint chartPoint)
        {

            try
            {
                var Revenue = ColumnUIRevenues[chartPoint.Key].Value;
                var Profit = ColumnUIProfits[chartPoint.Key].Value;
                var Costpc = (Revenue - Profit) * 1.0 / Profit;
                var Profitpc = Profit * 1.0 / Revenue;
                CostUI.Value = Costpc;
                ProfitUI.Value = Profitpc;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }

        }
        public IncomeProfitDashBoard()
        {
            InitializeComponent();

            IPChart.DataClick += ColumnSeries_OnDataClick;
            GetAll(currentPreiod);
            DataContext = this;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            string selectedOption = selectedItem.Content.ToString();
            if (selectedOption == currentPreiod) return;
            currentPreiod = selectedOption;
            GetAll(currentPreiod);
        }
    }
}
