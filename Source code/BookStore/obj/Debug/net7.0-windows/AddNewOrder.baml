   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BookStore	BookStore  5   	   /clr-namespace:BookStore.ViewBookStore.View  6/   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	       BookStore.AddNewOrder   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:BookStore     5   	   /local1clr-namespace:BookStore.View     6/   Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	     � WindowStartupLocation$  CenterScreen=�5	       � Title$ AddNewOrder��5
   	   $	��700��6   $
��1024��6*   ���	#FFD3FEFF � 	Resources 5      +   %BookStore.RelativeToAbsoluteConverter   absolute#  BookStore.View.PriceConverter  priceConverter��%:   &	        &	        5   
   6,     5   
   6    5      .��5      ]� ���	#FFD3FEFF$��15q�6'   .+�5   
   �� $��Add new transation��6   $	��Top=�6-   $��	10,10,0,0q�6B   $
��Left=�6U   $	��Top=�6p   $��20(�6�   $��Century Gothic)�6�   �� 5   
   $��Bottom=�6   $��39��6-   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5      �� -   5         ��Name$ cancelOrderBtn��5      $��Cancel��61   $
��Bold"�6_   $��0 0 30 0q�6q   $��15(�6�   $��36��6�   $��95��6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6.    �� 
StartPoint$ 0.5,0&�6?   .��5      �  � Color$ Black��6+    � Offset$ 0Q�69   � 5      $	 Red��6+   $ 0.087Q�67   5      5      �� 5      -   5        $ saveOrderBtn��5      $��Confirm��6/   $
��Bold"�6\   $��0 0 30 0q�6n   $��15(�6�   $��36��6�   $��95��6�   ���	#FF13FF175      5      5       �� 5!   
   .+�5"      A� 	 A� Columns$	 2��6   .+�5#      �� -   5        
 ��Name$
 nameTxt��5#      $��0 0 20 0q�6+    �� TextWrapping$
 Wrap=�6=   $��11(�6Q   
�������*  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Customer name��6r      UseFloatingWatermark$
 True��6�      ClearTextButton$
 True��6�   (  "System.Windows.Controls.DatePicker  5$      -   5          Name$ dateTxt��5$      $	��Top=�6/   $��20 0 0 0q�6G   $��11(�6Y   $ Purchase Date��6g   $
 True��6�   5&      �� 5'      $	��542��6   .+�5(      �� -   5        $��statusCombobox��5(   6   $
��Left=�6   $��	0 20 0 20q�6L   $	��116��6_   $ Status��6k   $
 True��6�   +  %MahApps.Metro.Controls.ComboBoxHelper   CharacterCasing$ Normal=�6�   ��5)      �� 5*      .R�5+      �� ��6$   �� *
statusName+5,      5.      � 5/      $��Center=�6   .+�50      �� $��Products��6   $	��Top=�6+   $��11(�6@   $��Century Gothic)�6N   $
��Bold"�6j   �� 51      -   5        $ AddProductButton��51      $��Right=�67      MahApps.Styles.Button.Circle#���  6S   
�������.��52      %  MahApps.Metro.Controls.FontIcon  -   5          Name$ AddButtonFontIcon��53   -   $��Segoe MDL2 Assets)�54   -   
��� � �   Glyph$	 ��56   -   57      58      �� 59      -   5         ��Name$ productsListView��59      $��1q�65   $	��350��6~    �� View 5:      �� 5;      .P�5<      �� $��ID��6Q    �� Width$ 50��6]    �� DisplayMemberBinding 6-   �� *ID+6]   �� 5=      $	 100��6-   $��Image��69    �� CellTemplate 5>   "   �� 5?   &   .R�5@   *   ��  �� BitmapScalingMode$ HighQuality=�60   $��
0, 0, 5, 0q�6^   $��20��6r   $��20��6}   ��6�   �� *Image+ �� 	Converter# [  5A   '   5C      �� 5D      $
��Name��6S   $	 200��6a    6-   �� *Name+6a   �� 5E      $��Publish��6V   $ 80��6g    6-   �� *	Publish+6g   �� 5F      $��Author��6U   $	 200��6e    6-   �� *Author+6e   �� 5G      $��
Unit Price��6~   $	 100��6�    6-   �� *Price+# [ 6�   �� 5H      $��Quantity��6-   $	 150��6?    5I   "   �� 5J   &   .R�5K   *   *  $MahApps.Metro.Controls.NumericUpDown    Name$ quantityUpDown��6<   -	   5           Minimum$ 0Q�5K   o      Maximum$	 100Q�6{      Value 6T   �� *
quantity+6�   5L   '   5N      �� 5O   "   $ 50��61   $��Delete��6<    5P   "   �� 5Q   &   .R�5R   *   �� $ EditProductsButton��61   -
   5        ��5T   -   �� .��5U   .     $ AddButtonFontIcon��5V   -   $��Segoe MDL2 Assets)�5W   -   
���  ��$	 ��5Y   -   5Z   +   5[   '   5]      5^      5`      �� 5a      -   5        $
 totalPriceTextBox��5a       �� 
IsReadOnly$
 True��65   $��Right=�6G   $	��116��6c   $��50��6o   $��17(�6{   
�������$ Total��6�   $
 True��6�   ��6�   �� *total+# [ 5c      5d      5e      5f      