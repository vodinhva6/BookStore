   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BookStore	BookStore  5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	       BookStore.AddProduct   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:BookStore     5   	   Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	     � Title$  Add Product��5	   	   $	��660��6   $	��300��6*   ���	#FFD3FEFF � 	Resources 5
      +   %BookStore.RelativeToAbsoluteConverter   absolute��%   &	          5   
   6,   5      .��5      � -   5        $��productDataAddWindow��5       � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��3* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   .+�5      �� $��Add New Product��6   $��Center=�6.   $	��Top=�6K   $
��Bold"�6c   $��15(�6u   $��Century Gothic)�6�   5      �� 5   
   $��1��6   $��Center=�6"   $��Center=�6=   .+�5      �� -   5        $��productImage��5      $��Images/0.jpg��6(   $	��130��6>   $	��130��6K    �� BitmapScalingMode$ HighQuality=�6W   �� 5      -   5        $��30��5   <   $��30��6G   $��0q�6S   
������ .��5       �� $��Assets/Icon/browse.png��6   $ HighQuality=�68   5!      5"      ]� 5#   
   $��2��6   .+�5$      �� $	��Top=�6   $��5 0 0 0q�6)   $
��Name��6:   $
��Left=�6I   $	��Top=�6d   $��14(�6|   $��Century)�6�   �� 5%      $��Bottom=�6,   $��	10 0 10 0q�6D   *  $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton$
 True��6W      	Watermark$ A Court of Mist and Fury��6�   ��6   �� *Name+6�   5&      ]� 5'   
   $��3��6   .+�5(      �� $	��Top=�6   $��5 0 0 0q�6)   $��Author��6:   $
��Left=�6K   $	��Top=�6f   $��14(�6~   $��Century)�6�   �� 5)      $��Bottom=�6.   $��	10 0 10 0q�6F   $
 True��6Y   $ Sarah J. Maas��6�   ��6   �� *Author+6�   5*      ]� 5+   
   $��4��6   .+�5,      �� $	��Top=�6   $��5 0 0 0q�6)   $��Publish��6:   $
��Left=�6L   $	��Top=�6g   $��14(�6   $��Century)�6�   �� 5-      $��Bottom=�6/   $��	10 0 10 0q�6G   $
 True��6Z   $
 2023��6�   ��6   �� *	Publish+6�   5.      ]� 5/   
   $��5��6   .+�50      �� $	��Top=�6   $��5 0 0 0q�6)   $��Category��6:   $
��Left=�6M   $	��Top=�6h   $��14(�6�   $��Century)�6�   �� 51      -   5        $��productCategoryCombobox��51      $��Bottom=�66   $��	10 0 10 0q�6N   +  %MahApps.Metro.Controls.ComboBoxHelper   CharacterCasing$ Normal=�6a   ��52      �� 53      .R�54      �� ��6$   �� *CategoryName+55      57      58      ]� 59   
   $��6��6   .+�5:      �� $	��Top=�6   $��5 0 0 0q�6)   $��Price��6:   $
��Left=�6J   $	��Top=�6e   $��14(�6}   $��Century)�6�   �� 5;      $��Bottom=�6-   $��	10 0 10 0q�6E   $
 True��6X   $ 100000��6�   ��6   �� *Price+6�   5<      ]� 5=   
   $��7��6   .+�5>      �� $	��Top=�6   $��5 0 0 0q�6)   $��	Raw Price��6:   $
��Left=�6N   $	��Top=�6i   $��14(�6�   $��Century)�6�   �� 5?      $��Bottom=�60   $��	10 0 10 0q�6H   $
 True��6[   $ 100000��6�   ��6   �� *
RawPrice+6�   5@      ]� 5A   
   $��8��6   .+�5B      �� $	��Top=�6   $��5 0 0 0q�6)   $��Quantity��6:   $
��Left=�6M   $	��Top=�6h   $��14(�6�   $��Century)�6�   �� 5C      $��Bottom=�60   $��	10 0 10 0q�6H   $
 True��6[   $	 500��6�   ��6   �� *
Quantity+6�   5D      � 5E   
   $��9��6    � ColumnDefinitions 5F      �� 5G      $��* �6#   �� 5H      $��* �6#   �� 5I      $��* �6#   �� 5J      $��* �6#   .+�5L      �� -   5         �� 	IsDefault$
 True��5L      $��2��6D   $��45��6T   $��45��6_   $��Center=�6k   
������ $��0q�6�      MahApps.Styles.Button.Circle#���  6�   .��5M      �� $��Assets/Icon/check.png��6   $ HighQuality=�67   5N      �� 5O      	 �� IsCancel$
	 True��6   $��3��6%   $��45��65   $��45��6@   $��Center=�6L   
������ $��0q�6�   #���  6�   .��5P      �� $��Assets/Icon/uncheck.png��6   $ HighQuality=�69   5Q      5R      5S      5T      