   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BookStore	BookStore  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	   %    BookStore.IncomeProfitDashBoard   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:BookStore     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ IncomeProfitDashBoard��5
   	   $	��700��6'   $
��1200��64   .��5      �� .+�5   
   #  LiveCharts.Wpf.CartesianChart  -   5        $��IPChart��5      &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$	 Top=�5       �� Left$ 10��5      
 �� Top$ 81��6.   $	��236��6>   $
��1190��6K   $��Center=�6X   $	��Top=�6u      Series 5      �� *ColumnSeriesCollection+5        LiveCharts.Wpf.PieChart  5   
   -   5        $��PieChart��5      $ Right=�5         InnerRadius$ 80Q�5      $	 396��5      $	 342��6)   $	��307��6:   $	��404��6G    J� RenderTransformOrigin$ 	0.4,1.116&�6S    5      �� *PieSeriesCollection+   ChartLegend 5      "  LiveCharts.Wpf.DefaultLegend  5      	   
BulletSize$	 25Q�6$   $��15(�64   5      �� 5   
   $��Doanh Số Bán Hàng��6   
�������$��Center=�6?   
�����F�$
��1200��6z   $��Center=�6�   $��14(�6�   $
��Left=�6�   �� 5   
   -   5        $ 10��5      $ 34��6Q   $	��120��6a   $ 0.328,-0.214&�6m   .@�5      �� $	��day��6   �� 5       $
��week��6   �� 5!      $��month��6   �� 5"      $
��year��6   
 �� 
IsSelected$

 True��6*   5$      5%      5&      