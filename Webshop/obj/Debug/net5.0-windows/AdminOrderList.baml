   M S B A M L   `   `   `  ����B  >Webshop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WebshopWebshop  5   	       Webshop.AdminOrderList   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Webshop     5   	     � WindowStartupLocation$  CenterScreen=�5   	   $��18(�5       � Title$ Webshop��5	   	   $	��800��6   $	��800��6&   $��Segoe UI Light)�62   .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $	��250 �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $	��100 �6   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��40 �6   �� 5      $��20 �6   .+�5   
   �� -   5         ��Name$ 	TextTitle��5      $��1��6'   $��1��64   $��2��6D   $��36(�6Y   $��Segoe UI Light)�6g   $
��Bold"�6�   Alla ordrar6�   �� 5   
   -   5        $ TextMessage��5      $��2��6)   $��2��66   $��0 0 0 0q�6F   $��2��6W   $��1��6h   $
��Bold"�6|   ���	#FFB70000$��Right=�6�   6�   �� 5!   
   $��3��6   $��1��6$   $
��auto=�65   .��5"      �� $��
10 0 10 10q�6   .+�5#      �� -   5         ��Name$ ListBoxOrders��5#      5$      5%      5&      �� 5)   
   $��3��6   $��2��6$   $
��auto=�65   .��5*      �� .+�5+      �� -   5        $ TextBlocDate��5+      $
��Bold"�62   $��Segoe UI)�6D   Datum:6c   �� 5,      -   5        $ TextBlockName��5,      Namn:6;   �� 5-      -   5        $ TextBlockAdress��5-      
Address:6@   �� 5.      -   5        $ TextTelephone��5.      
Telefon:6>   �� 5/      -   5        $ TextMail��5/      Mail:66   �� 50      -	   5        $ TextSex��50      Kön:63   �� 51      -
   5        $ TextShippmentMethod��51      Fraktmetod:6G   �� 52      $
��Bold"�6   $��Segoe UI)�6.   	Beställt6O   �� 53      -   5         ��Name$ StackPanelOrdered��53      6:   54      55      �� 57   
   -   5         ��Name$ ButtonGoBack��57      $��1��6'   $��4��67   $��10 0 0 0q�6D   .��6q   
Tillbaka6{   5:      5;      