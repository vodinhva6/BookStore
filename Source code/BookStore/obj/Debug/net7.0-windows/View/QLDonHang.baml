   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.ViewBookStore.View  5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	       BookStore.View.QLDonHang   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:BookStore.View     5      Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   $
��Auto��5	   H   $
��Auto��6U   ���	#FFD3FEFF  � 	Resources  5
      $   BookStore.View.StatusConverter   statusConverter#  BookStore.View.PriceConverter  priceConverter��%:   &	        &	        5   
   6      5   
   6   5      .��5      �� $��20q�6   .+�5   
   �� $��	OrderList��6   $	��Top=�6$   $
��Left=�69   $	��Top=�6T   $��20(�6l   $��Century Gothic)�6z    �� Left$ 19��6�   
 �� Top$	 114��6�   �� 5   
   -   5         ��Name$ ordersListView��5      $��1q�6+   $	��430��6?    �� View 5      �� 5      .P�5      �� $��ID��6I    �� Width$ 50��6U    �� DisplayMemberBinding 6%   �� *id+6U   �� 5      $
��Name��6O   $	 150��6]    6%   �� *
username+6]   �� 5      $��Price��6{   $	 100��6�    6%   �� *
totalPrice+ �� 	Converter# [ 6�   �� 5      $
��Date��6K   $	 100��6Y    6%   �� *date+6Y   �� 5      $��Status��6x   $	 100��6�    6%   �� *status+# [  6�   �� 5%      $ 50��6%   $��Delete��60    �� CellTemplate 5&      �� 5'      .R�5(   "   �� 	 ��Name$	 DeleteOrderButton��6)   -   5        ��5*   -   �� .��5+   &   %  MahApps.Metro.Controls.FontIcon  
  Name$
 AddButtonFontIcon��5,   -   $��Segoe MDL2 Assets)�5-   -   
���  ��   Glyph$	 ��5/   -   50   #   51      53      54      ��56      �� 57       �� 
TargetType" ��6   .�58      -   5        5:      5<      �� 5>   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   .+�5?      �� -   5        $	 previousPageButton��5?      .��5@        $��Segoe MDL2 Assets)�5B   -   $	 ��5C   -   5D      �� 5E      -   5        $��currentPageComboBox��5E   O   $��Center=�6j   $��Center=�6�   $	��103��6�   $��22��6�   ��5F      �� 5G      .R�5H      �� �� 5I      �6   �� *Item1+ �� Mode$ OneWay=� / �� 6G   �6K   �� *Item2+$ OneWay=�5J      5K      5M      �� 5N      -   5        $	 nextPageButton��5N      .��5O        $��Segoe MDL2 Assets)�5Q   -   $	 ��5R   -   5S      5T      5U      5V      