   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BookStore	BookStore  5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	       BookStore.ChangePassword   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:BookStore     5   	   Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   -   5          � Title$  Add Product��5	   	   $	��450��5      $	��300��6   ���	#FFD3FEFF.��5      � -   5        $��ChangePasswordWindow��5       � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��70 �6   �� 5      $��70 �6   �� 5      $��60 �6   �� 5      $��70 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   .+�5      �� $��Thay đổi mật khẩu��6   $��Center=�60   $	��Top=�6M   $
��Bold"�6e   $��15(�6w   $��Century Gothic)�6�   5      �� 5   
   $��1��6   .+�5      �� $��5 0 0 0q�6   $��Tài khoản��5      $
��Left=�5      $	��Top=�6/   $��14(�6G   $��Century)�6U   �� 5      -   5        $��currentUsername��5      $��	10 0 10 0q�5      $��30��5       *  $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton$
 True��5!         	Watermark$ Tài khoản của bạn��6?   6q   5"      �� 5$   
   $��2��6   .+�5%      �� $��5 0 0 0q�6   $��Mật khẩu cũ��6%   $
��Left=�6;   $	��Top=�6V   $��14(�6n   $��Century)�6|   G� 5&      -   5        $��oldPassword��5&      $��	10 0 10 0q�5'      $��30��5(      $
 True��5)      $ Mật khẩu hiện tại��6?   6q   5*      �� 5,   
   $��3��6   .+�5-      �� -   5         �� 	IsDefault$
 True��5.      $��0,5,0,0q�5/      
��� ���$��2��52      $��55��6%   $��45��60   $��Center=�6<   $��0q�6X    !  MahApps.Styles.Button.Dialogs#���   6l   .��54      �� $��Xác thực��6   55      56      �� 58   
   $��4��6   .+�59      �� $��5 0 0 0q�5:      $��Mật khẩu mới��6%   $
��Left=�6<   $	��Top=�6W   $��14(�6o   $��Century)�6}   G� 5;      -   5        $��newPassword��5;      $��	10 0 10 0q�5<      $
 True��5=      $ Mật khẩu mới��6C   6p   5>      �� 5?   
   $��5��6   .+�5@      �� $��5 0 0 0q�5A      $��Xác nhận mật khẩu��6%   $
��Left=�6A   $	��Top=�6\   $��14(�6t   $��Century)�6�   G� 5B      -   5        $��confirmPassword��5B      $��	10 0 10 0q�5C      $
 True��6%   $ Xác nhận mật khẩu��6N   6�   5D      � 5F   
   $��9��6    � ColumnDefinitions 5G      �� 5H      $��* �6#   �� 5I      $��* �6#   �� 5J      $��* �6#   �� 5K      $��* �6#   .+�5M      �� -   5        $��OKButton��5M   &   $
 True��6   $��0,55,0,0q�5N      $��2��5P      $��45��6%   $��45��60   $��Center=�6<   
������ $��0q�6p      MahApps.Styles.Button.Circle#���  6�   .��5Q      �� $��Assets/Icon/check.png��6    �� BitmapScalingMode$ HighQuality=�67   5R      �� 5S       �� IsCancel$
 True��6   $��0,55,0,0q�5T      $��3��5U      $��45��6%   $��45��60   $��Center=�6<   
������ $��0q�6p   #���  6�   .��5V      �� $��Assets/Icon/uncheck.png��6   $ HighQuality=�69   5W      5X      5Y      5Z      