   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BookStore	BookStore  5   	   /clr-namespace:BookStore.ViewBookStore.View  6/       BookStore.BookList   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:BookStore     5   	   /local1clr-namespace:BookStore.View     6/   -   5          � Title$  Choose product��5   
   $	��450��6!   $	��800��6.    � 	Resources 5	      0   *BookStore.View.RelativeToAbsoluteConverter   absolute&   BookStore.View.CategoryConverter  category#  BookStore.View.PriceConverter 	 price��%W   &	        &	      &	 &       5
   
   6-     5   
   6#     5   
   6    5      .��5      ]� $
��True��6   .+�5   
   �� $��Choose product to add��6   $��13(�61   $	��Top=�6?   �� 5   
   -   5        $��booksListView��5   *   $��10, 10, 0, 0q�6   $	��794��6?   $	��384��6K   $��Disabled=�6X   ��5      �� 5      .R�5      ��  �� Orientation$ Vertical=�6!   $	��250��68   $	��248��6E   $��22q�6Q   .+�5      ��  �� BitmapScalingMode$ HighQuality=�6    $	��100��6N   $	��200��6Z   ��6g   �� *Image+ �� 	Converter# [  �� 5      $
��Wrap=�6$   $��Center=�68   �� 5      $
��Bold"�64   
����  ��6   �� *Name+6F   5      �� 5      $
��Wrap=�6$   $��Center=�68   �� 5      $
��Bold"�6_   �6   �� *
CategoryID+# [ 6_    - �� 5      $
��Bold"�66   
���  ���6   �� *Author+6H    - �� 5      $
��Bold"�67   �6   �� *	Publish+67   5      �� 5      $
��Wrap=�6$   $��Center=�68   �� 5       $��Italic$�6V   
���OO/��6   �� *Price+# [ 6i   5!      5"      5#      ��5%      �� 5&      .R�5'      � 5(      ��5*      �� 5+       �� 
TargetType" ��6   .�5,      -   5        5.      50      51      52      