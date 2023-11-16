using LiveCharts.Defaults;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Collections.ObjectModel;
using LiveCharts.Wpf;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Wordprocessing;

namespace BookStore
{
    /// <summary>
    /// Interaction logic for ProductDashBoard.xaml
    /// </summary>
    public partial class ProductDashBoard : Window
    {
        ProductDAOKhoi productDAOKhoi =new ProductDAOKhoi();
        List<string> productNames = new List<string>();
        ChartValues<ObservableValue> ColumnUIQuantities = new ChartValues<ObservableValue>() {
            new ObservableValue(7)
        };

        ChartValues<ObservableValue> ColumnUITop1 = new ChartValues<ObservableValue>() {
            new ObservableValue(7)
        };
        ChartValues<ObservableValue> ColumnUITop2 = new ChartValues<ObservableValue>() {
            new ObservableValue(7)
        };
        ChartValues<ObservableValue> ColumnUITop3 = new ChartValues<ObservableValue>() {
            new ObservableValue(7)
        };

        List<string> LabelTop3 = new List<string>();


        string CurrentNameProduct = "A Court of Mist and Fury";
        string CurrentTime = "year";

        public async void GetAll(string name,string preiod)
        {
            try
            {

                ObservableCollection<Product> data = await Task.Run(() => productDAOKhoi.GetAll(name,preiod));
                ColumnUIQuantities.Clear();
                ProductChart.AxisX.Clear();
               
                List<string> TitleAxisX = new List<string>();
                foreach (Product p in data)
                {

                    ColumnUIQuantities.Add(new ObservableValue(p.Quantities));
                    //MessageBox.Show(p.Quantities.ToString());
                    TitleAxisX.Add(p.Preiod);


                }
                ProductChart.AxisX.Add(new LiveCharts.Wpf.Axis
                {
                    Title = "Datetime",
                    Labels = TitleAxisX,
                });
                getTop3(preiod);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        public async void setNameComboBox()
        {
            try
            {

                productNames = await Task.Run(() => productDAOKhoi.getProductName());

                CBProductNames.ItemsSource = productNames.Select(p => new ComboBoxItem { Content = p }).ToList();

                CurrentNameProduct = productNames[0];
                CurrentTime = "year";
                GetAll(CurrentNameProduct, CurrentTime);
                CBProductNames.SelectedIndex = 0;
                TitleProduct.Content = productNames[0];



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        public async void getTop3(string preiod)
        {
            try
            {

                var top3 =  await Task.Run(() => productDAOKhoi.GetTop3(preiod));
                List<string> TitleAxisX = new List<string>();
                ColumnUITop1.Clear();
                ColumnUITop2.Clear();
                ColumnUITop3.Clear();
                LabelTop3.Clear();
                BestSellerChart.AxisX.Clear();
                var cnt = 0;
                foreach (Product p in top3)
                {

                    if (cnt%3==0) ColumnUITop1.Add(new ObservableValue(p.Quantities));
                    if (cnt % 3 == 1) ColumnUITop2.Add(new ObservableValue(p.Quantities));
                    if (cnt % 3 == 2) ColumnUITop3.Add(new ObservableValue(p.Quantities));
                    //MessageBox.Show(p.Quantities.ToString());
                    LabelTop3.Add(p.Name);
                    if (cnt % 3 == 0)
                    {
                        TitleAxisX.Add(p.Preiod);
                    } 
                    
                    cnt++;
                }
                NameTop1.Content = LabelTop3[0 * 3];
                NameTop2.Content = LabelTop3[0 * 3 + 1];
                NameTop3.Content = LabelTop3[0 * 3 + 2];
                BestSellerChart.AxisX.Add(new LiveCharts.Wpf.Axis
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

        public ObservableValue QuantitiesTop1 = new ObservableValue(0.3);
        public ObservableValue QuantitiesTop2 = new ObservableValue(0.3);
        public ObservableValue QuantitiesTop3 = new ObservableValue(0.3);

        public SeriesCollection PieSeriesCollection => new SeriesCollection
        {
            new PieSeries
            {
                Title = "1                  .",
                Values = new ChartValues<ObservableValue> { QuantitiesTop1  },
                Fill = Brushes.LightSeaGreen,
                DataLabels = true,
                LabelPoint = label => $"{label.Participation:P}"
            },
             new PieSeries
            {
                Title = "1                  .",
                Values = new ChartValues<ObservableValue> { QuantitiesTop2 },
                Fill = Brushes.GreenYellow,
                DataLabels = true,
                LabelPoint = label => $"{label.Participation:P}"
            },
             new PieSeries
            {
                Title = "1                  .",
                Values = new ChartValues<ObservableValue> { QuantitiesTop3 },
                Fill = Brushes.Orange,
                DataLabels = true,
                LabelPoint = label => $"{label.Participation:P}"
            }
        };
        public String ShowParseLabelRevenue(ChartPoint label)
        {
            Double yRevenue = label.Y;


            Double MaxRevenue = ColumnUITop1.Max(o => o.Value);
            Double MinRevenue = ColumnUITop1.Min(o => o.Value);

            MaxRevenue = Math.Max(MaxRevenue, ColumnUITop2.Max(o => o.Value));
            MinRevenue = Math.Min(MinRevenue, ColumnUITop2.Min(o => o.Value));


            MaxRevenue = Math.Max(MaxRevenue, ColumnUITop3.Max(o => o.Value));
            MinRevenue = Math.Min(MinRevenue, ColumnUITop3.Min(o => o.Value));         

            if (yRevenue == MaxRevenue || yRevenue == MinRevenue)
      
            {
                return $"{yRevenue:F0}";
            };
            return "";
        }
        public SeriesCollection ColumnSeries2 => new SeriesCollection
        {
            new ColumnSeries
            {
                Title = "ProductTop1",
                Values = ColumnUITop1,
                Fill = Brushes.LightSeaGreen,
                LabelPoint=ShowParseLabelRevenue,
                DataLabels=true
            },
             new ColumnSeries
            {
                Title = "ProductTop2",
                Values = ColumnUITop2,
                Fill = Brushes.GreenYellow,
                LabelPoint=ShowParseLabelRevenue,
                DataLabels=true

            },
            new ColumnSeries
            {
                Title = "ProductTop3",
                Values = ColumnUITop3,
                Fill = Brushes.Orange,
                LabelPoint=ShowParseLabelRevenue,
                DataLabels=true

            }
        };
        public String ShowParseLabelQuantity(ChartPoint label)
        {
            Double yRevenue = label.Y;



            Double MaxRevenue = ColumnUIQuantities.Max(o => o.Value);
            Double MinRevenue = ColumnUIQuantities.Min(o => o.Value);

            if (yRevenue == MaxRevenue || yRevenue == MinRevenue)
            {
                return $"{yRevenue:F0}";
            };
            return "";
        }
        public SeriesCollection ColumnSeriesCollection => new SeriesCollection
        {
            new ColumnSeries
            {
                Title = "Quantities",
                Values = ColumnUIQuantities,
                Fill = Brushes.DeepSkyBlue,
                LabelPoint=ShowParseLabelQuantity,
                DataLabels=true
            },
        };
        public ProductDashBoard()
        {
            InitializeComponent();
            setNameComboBox();
            this.DataContext = this;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            string selectedOption = selectedItem.Content.ToString();
            if (selectedOption == CurrentTime) return;
            CurrentTime = selectedOption;
            GetAll(CurrentNameProduct, CurrentTime);
        }

        private void ComboBox_SelectionChangedNameProduct(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            string selectedOption = selectedItem.Content.ToString();
            if (selectedOption == CurrentNameProduct) return;
            CurrentNameProduct = selectedOption;
            TitleProduct.Content = selectedOption;

            GetAll(CurrentNameProduct, CurrentTime);
        }

        private void ChangePieChart(object sender, ChartPoint chartPoint)
        {
            try
            {
                var index = chartPoint.Key;
                var Top1 = ColumnUITop1[index].Value;
                var Top2 = ColumnUITop2[index].Value;
                var Top3 = ColumnUITop3[index].Value;
                var Sum = Top1 + Top2 + Top3;
                QuantitiesTop1.Value = Top1 * 1.0 / Sum;
                QuantitiesTop2.Value = Top2 * 1.0 / Sum;
                QuantitiesTop3.Value = Top3 * 1.0 / Sum;

               
                NameTop1.Content = LabelTop3[index*3];
                NameTop2.Content = LabelTop3[index * 3+1];
                NameTop3.Content = LabelTop3[index * 3+2];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        
    }
}
