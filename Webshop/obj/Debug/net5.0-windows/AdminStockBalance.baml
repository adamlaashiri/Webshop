   M S B A M L   `   `   `  ����B  >Webshop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WebshopWebshop  5   	       Webshop.AdminStockBalance   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Webshop     5   	     � WindowStartupLocation$  CenterScreen=�5   	   $��18(�5       � Title$ Webshop��5	   	   $	��800��6   $	��800��6&   $��Segoe UI Light)�62   .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $	��250 �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $	��100 �6   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��40 �6   �� 5      $��20 �6   .+�5   
   �� -   5         ��Name$ 	TextTitle��5      $��1��6'   $��1��64   $��2��6D   $��36(�6Y   $��Segoe UI Light)�6g   $
��Bold"�6�   
Lagersaldo6�   �� 5   
   -   5        $ TextMessage��5      $��2��6)   $��2��66   $��0 0 0 0q�6F   $��2��6W   $��1��6h   $
��Bold"�6|   ���	#FFB70000$��Right=�6�   6�   �� 5!   
   $��3��6   $��1��6$   $
��auto=�65   .��5"      �� $��
10 0 10 10q�6   .+�5#      �� -   5         ��Name$ ListBoxProducts��5#      5$      5%      5&      �� 5)   
   $��3��6   $��2��6$   $
��auto=�65   .��5*      �� $��
10 0 10 10q�6   .+�5+      �� $��0 0 0 10q�6   	Kvantitet69   �� 5,      -   5         ��Name$ TextBoxQuantity��5,       �� 
IsReadOnly$
 True��63   .��6E   06H   ]� 5-      $��0 10 0 0q�6   .+�5.      �� -   5        $��Right=�5.      $��40��64   .��6T   -6W   �� 5/      -   5        $��Right=�5/      $��40��64   $��Right=�6?   $��0 0 10 0q�6[   .��6�   +6�   50      51      52      ]� 54   
   $��2��6   $��4��6$   $��	10 0 10 0q�61   .+�55      �� -   5         ��Name$ ButtonStockSave��55      $��Right=�6.   $	��100��6E   $��Right=�6Q   $��10 0 0 0q�6m   .��6�   Spara6�   56      �� 58   
   -   5        $ ButtonGoBack��58      $��1��6'   $��4��67   $��10 0 0 0q�6D   .��6q   
Tillbaka6{   5;      5<      