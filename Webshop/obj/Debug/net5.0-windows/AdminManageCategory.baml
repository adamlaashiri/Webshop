   M S B A M L   `   `   `  ����B  >Webshop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WebshopWebshop  5   	   !    Webshop.AdminManageCategory   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Webshop     5   	     � WindowStartupLocation$  CenterScreen=�5   	   $��18(�5       � Title$ Webshop��5	   	   $	��500��6   $	��800��6&   $��Segoe UI Light)�62   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $	��100 �6   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $��40 �6   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $��40 �6   �� 5       $��* �6   �� 5"      $��40 �6   �� 5$      $��20 �6   .+�5'   
   �� -   5         ��Name$ 	TextTitle��5'      $��1��6'   $��1��64   $��2��6D   $��36(�6Y   $��Segoe UI Light)�6g   $
��Bold"�6�   Lägg till Kategori6�   �� 5)   
   -   5        $ TextMessage��5)      $��2��6)   $��3��66   $��0 0 0 0q�6F   $��2��6W   $��1��6h   $
��Bold"�6|   ���	#FFB700006�   �� 5+   
   $��3��6   $��1��6!   $��10 0 0 0q�61   Namn6I   �� 5,   
   -   5         ��Name$ 	InputName��5,      $��4��6%   $��1��62   $��3��6B   $��	10 10 0 0q�6V   $
��Bold"�6i   6}   �� 5.   
   $��6��6   $��1��6!   $��10 0 0 0q�61   Beskrivning (Valfritt)6[   �� 5/   
   -   5        $ InputDescription��5/      $��7��6,   $��1��69   $��3��6I   $��	10 10 0 0q�6]   $
��Bold"�6p   6�   �� 51   
   -   5         ��Name$ ButtonCreateCategory��51      $��1��6/   $��9��6?   $��10 0 0 0q�6L   .��6�   Skapa Kategori6�   �� 52   
   -   5        $ ButtonGoBack��52      $��3��6'   $��9��67   $��10 0 0 0q�6D   .��6r   
Tillbaka6|   55      56      