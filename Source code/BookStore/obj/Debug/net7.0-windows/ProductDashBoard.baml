   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BookStore	BookStore  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	        BookStore.ProductDashBoard   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:BookStore     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	     � Title$  ProductDashBoard��5	   	   $	��710��6"   $
��1200��6/    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      �� .+�5   
   #  LiveCharts.Wpf.CartesianChart  -   5        $��ProductChart��5      &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$	 Top=�5       �� Left$ 10��5      
 �� Top$ 81��6.   $	��236��6>   $
��1190��6K   $��Center=�6X   $	��Top=�6u      Series 5      �� *ColumnSeriesCollection+5        LiveCharts.Wpf.PieChart  5   
   -   5        $��PieChart��5      $ Right=�5         InnerRadius$ 80Q�5      $ 10��5      $	 367��6(   $	��307��69   $	��404��6F    J� RenderTransformOrigin$ 	0.4,1.116&�6R   $
��Left=�6t   $	��Top=�6�    5      �� *PieSeriesCollection+   ChartLegend 5      "  LiveCharts.Wpf.DefaultLegend  5      	   
BulletSize$	 25Q�6$   $��15(�64   5        5   
   -   5        $��BestSellerChart��5      $	 Top=�5!      $	 464��5"      $	 367��6/   $	��307��6@   $	��726��6M   $��Center=�6Y   $	��Top=�6v    5      �� *ColumnSeries2+5%      �� 5&   
   $��Doanh Số Sản Phẩm��6   
�������$��Center=�6?   
�����F�$
��1200��6z   $��Center=�6�   $��14(�6�   $
��Left=�6�   �� 5'   
   $��Top 3 Best Seller��6   
���   �$��Center=�6?   $
��1200��6d   $	��Top=�6q   $��15(�6�   $��Center=�6�   $	 333��6�   �� 5)   
   -   5        $��CBProductNames��5)      $ 10��6a   $ 34��6�   $	��137��6�   $ 0.328,-0.214&�6�   $
��Left=�6�   $��Center=�6�   ��6s   �� *ProductNames+5*      �� 5+   
   -   5        $	 152��5+      $ 34��6R   $	��137��6b   $ 0.328,-0.214&�6n   $
��Left=�6�   $��Center=�6�   .@�5,      �� $	��day��6   �� 5-      $
��week��6   �� 5.      $��month��6   �� 5/      $
��year��6   
 �� 
IsSelected$

 True��6*   51      �� 52   
   -   5        $��TitleProduct��52      $��Current Name Product��6$   $��18(�6D   $
��Bold"�6R   $	 505��6d   $ 34��6v   $
��Left=�6�   $��Center=�6�   �� 54   
   -   5        $��NameTop1��54   1   
�������$��11(�6#   $��NameTop1��6A   $	 320��6T   $	 475��6f   $
��Left=�6w   $��30��6�   $��Center=�6�   $	��140��6�   $ 1.218,0.268&�6�   �� 55   
   -   5        $��NameTop2��55   1   
�������$��11(�6#   $��NameTop2��6A   $	 320��6T   $	 505��6f   $��Center=�6w   $��30��6�   $	��Top=�6�   $	��140��6�   �� 56   
   -	   5        $��NameTop3��56   1   
�������$��11(�6#   $��NameTop3��6A   $	 320��6T   $	 535��6f   $��Center=�6w   $��30��6�   $	��Top=�6�   $	��140��6�   58      59      