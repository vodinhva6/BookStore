   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.ViewBookStore.View  5          BookStore.View.TrangChu   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:BookStore.View     5      -   5          � 	Resources  5      0   *BookStore.View.RelativeToAbsoluteConverter   absolute&   BookStore.View.CategoryConverter  category#  BookStore.View.PriceConverter 	 price��%W   &	        &	      &	 &       5   
   6,     5   
   6"     5   
   6   5      .��5      � ���#FFFFFF � ColumnDefinitions 5   
   �� 5      $	��325 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6"    �� Orientation$ Vertical=�5      $��	10,30,0,0q�5      .+�5      �� $)��#Tổng số sản phẩm đang bán��6   $��15(�5       �� TextAlignment$ Center=�5      �� 5      -   5         ��Name$ totalProduct��5      $��0,5,0,0q�62   $��25(�5      $��0��5       $ Center=�6%   �� 5"      $��0,50,0,0q�6   $��Center=�5#      .+�5$      �� $��15(�6   $+��%Tổng đơn hàng mới trong tuần��6*   �� 5%      -   5        $ weekProduct��5%      $��0,5,0,0q�61   $��25(�5&      $��0��6#   $ Center=�6,   5'      �� 5(      $��0,50,0,0q�6   $��Center=�5)      .+�5*      �� $��15(�6   $+��%Tổng đơn hàng mới trong tháng��6*   �� 5+      -   5        $ monthProduct��5+      $��0,5,0,0q�62   $��25(�5,      $��0��6#   $ Center=�6,   5-      5.      �� 51   
   $��0��6   $��1��6"   $ Vertical=�52      $��	10,10,0,0q�53      .+�55      �� $)��#Các sản phẩm sắp hết hàng��6   $��15(�56      $ Center=�57      �� 58      -   5        $��productListViewTrangChu��58      $��Disabled=�66   ��59      �� 5:      .R�5;      �� $ Vertical=�6%   $	��300��6<   $	��248��6I   .+�5<      ��  �� BitmapScalingMode$ HighQuality=�6$   $	��100��6R   $	��200��6^   ��6k   �� *Image+ �� 	Converter# [  �� 5=      $
��Wrap=�6(   $��Center=�6<   �� 5>      $
��Bold"�64   
����  ��6   �� *Name+6F   5?      �� 5@      $
��Wrap=�6(   $��Center=�6<   �� 5A      $
��Bold"�6Y   �6   �� *Type+# [ 6Y    - �� 5C      $
��Bold"�66   
���  ���6   �� *Author+6H    - �� 5E      $
��Bold"�67   �6   �� *	Publish+67   5F      �� 5G      $
��Wrap=�6(   $��Center=�6<   �� 5H      $��Italic$�6V   
���OO/��6   �� *Price+# [ 6i   5I      �� 5K      $
��Wrap=�6(   $��Center=�6<   �� 5L      $�Số lượng còn lại ��6   $
��Bold"�68    �� 5M      $
��Bold"�69   �6   �� *
Quantity+69   5O      5P      5Q      ��5S      �� 5T      .R�5U      � 5V        5X        productsContextMenu m� Icon��%$  &	       �� 5Y      .@�5Z      m� $��Delete��6#    5[      �� 5\   "   $ HighQuality=�6(   $��../Assets/Icon/delete.png��6V   5^      m� 5_      $��Update��6#    5`      �� 5a   "   $ HighQuality=�6(   $��../Assets/Icon/update.png��6V   5c      5d      5e      ��5f      �� 5g       �� 
TargetType" ��6   .�5h      �� 	 �� Property	 �@�ContextMenu
 �� Value#
 [ 5i      5j      5l      5m      5n      5o      