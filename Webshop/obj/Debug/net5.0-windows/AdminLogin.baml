   M S B A M L   `   `   `  ����B  >Webshop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WebshopWebshop  5   	       Webshop.AdminLogin   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Webshop     5   	     � WindowStartupLocation$  CenterScreen=�5   	   $��18(�5       � Title$ Webshop��5	   	   $	��500��6   $	��800��6&   $��Segoe UI Light)�62   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $	��100 �6   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��40 �6   �� 5      $��20 �6   .+�5   
   �� $��1��6   $��1��6!   $��2��61   $��36(�6E   $��Segoe UI Light)�6S   $
��Bold"�6o   Logga in som Administratör6�   �� 5   
   -   5         ��Name$ 	TextError��5      $��2��6'   $��3��64   $��2��6D   $��1��6U   $
��Bold"�6i   ���	#FFB700006�   �� 5   
   $��3��6   $��1��6"   $��3��62   .+�5       �� $��0 0 0 5q�6   $
��Bold"�6*   Användarnamn6J   �� 5!      -   5         ��Name$ InputUsername��5!      $��0 0 0 10q�6-   $
��Bold"�6?   6S   �� 5#      $��0 0 0 5q�6   $
��Bold"�6)   	Lösenord6E   G� 5$      -   5         G�Name$ InputPassword��5$      63   5%      �� 5'   
   -   5         ��Name$ ButtonLogin��5'      $��3��6&   $��4��66   $��5q�6C   #��� ��6h   .��6�   
Logga in6�   5*      5+      