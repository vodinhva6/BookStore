   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.ViewBookStore.View  5          BookStore.View.QLHangHoa   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:BookStore.View     5      -   5        $
��Auto��5   7   $
��Auto��6D     � 	Resources  5	      0   *BookStore.View.RelativeToAbsoluteConverter   absolute&   BookStore.View.CategoryConverter  category#  BookStore.View.PriceConverter 	 price��%W   &	        &	      &	 &       5
   
   6,     5   
   6"     5   
   6   5      .��5      �  � RowDefinitions 5   
   �� 5      $��9* �6   �� 5      $��* �6   .+�5   
   �� -   5        $��productListView��5       $��0��6   $��Disabled=�67   ��5      �� 5      .R�5      ��  �� Orientation$ Vertical=�6!   $	��250��68   $	��248��6E   $��22q�6Q   .+�5      ��  �� BitmapScalingMode$ HighQuality=�6    $	��100��6N   $	��200��6Z   ��6g   �� *Image+ �� 	Converter# [  �� 5      $
��Wrap=�6$   $��Center=�68   �� 5      $
��Bold"�68   
����  ��6"   �� *Name+6J   5      �� 5      $
��Wrap=�6$   $��Center=�68   �� 5      $
��Bold"�6c   �6"   �� *
CategoryID+# [ 6c    - �� 5      $
��Bold"�6:   
���  ���6"   �� *Author+6L    - �� 5       $
��Bold"�6;   �6"   �� *	Publish+6;   5!      �� 5"      $
��Wrap=�6$   $��Center=�68   �� 5#      $��Italic$�6Z   
���OO/��6"   �� *Price+# [ 6m   5$      5%      5&      ��5(      �� 5)      .R�5*      � 5+        5-        productsContextMenu m� Icon��%�  &	       �� 5.      .@�5/      m� -   5        $��Delete��5/      $	��120��6P   $��30��6\    50      �� 51      $ HighQuality=�6$   $��../Assets/Icon/delete.png��6R   53      m� 54      -   5        $��Update��54      $	��120��6P   $��30��6\    55      �� 56      $ HighQuality=�6$   $��../Assets/Icon/update.png��6R   58      59      5:      ��5;      �� 5<       �� 
TargetType" ��6   .�5=      ��  �� Property �@�ContextMenu �� Value# [ 5>   !   -   5        5A      5C      �� 5D   
   $��1��6   $ 
Horizontal=�6"   $��Center=�6;   $��Center=�6V   .+�5E      �� -   5        $��30��5E      $��30��6       MahApps.Styles.Button.Circle#���  6M   $��Center=�6�   $��Center=�6�   .��5F      �� $!��../Assets/Icon/previous.png��6   $ HighQuality=�6=   5G      �� 5H      -   5        $ ��currentProductPageComboBox��5H   V   $��Center=�6x   $��Center=�6�   $��75��6�   $��5 0 5 0q�6�   ��5I      �� 5J      .R�5K      �� �� 5L      �6   �� *Item1+	 �� Mode$	 OneWay=� / �� 6G   �6K   �� *Item2+$	 OneWay=�5M      5N      5P      �� 5Q      -   5        $��30��5Q      $��30��6    #���  6I   $��Center=�6�   $��Center=�6�   .��5R      �� $��../Assets/Icon/next.png��6   $ HighQuality=�69   5S      5T      5U      5V      