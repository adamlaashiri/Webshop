   M S B A M L   `   `   `  ����B  >Webshop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WebshopWebshop  5   	       Webshop.Shop   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Webshop     5   	     � WindowStartupLocation$  CenterScreen=�5   	   $��18(�5       � Title$ Webshop��5	   	   $	��700��6   $
��1000��6&   $��Segoe UI Light)�63   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��50 �6   �� 5      $
��auto �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��* �6   �� 5"      $��40 �6   �� 5$      $��20 �6   .+�5(   
   �� $��6��6   $��2��6"    �� Orientation$ 
Horizontal=�62   $��Center=�6K   $��Center=�6h   .+�5)      �� $��Segoe UI)�6   $
��Bold"�6.   
Varukorg6J   �� 5*      -   5         ��Name$ TextBlockCartItems��5*      $��10 0 0 0q�64   06I   5+      �� 5-   
   -   5        $ 	TextTitle��5-      $��1��6'   $��1��64   $��2��6D   $��36(�6X   $��Segoe UI Light)�6f   $
��Bold"�6�   Utvada produkter6�   �� 5.   
   -   5        $ 
TextTitle2��5.      $��3��6(   $��1��65   $��2��6E   $��28(�6Y   $��Segoe UI)�6g   $��Normal"�6}   $��Italic$�6�   ���	#FF777777#!Sök efter produkt eller kategori6�   �� 51   
   $��2��6   $��1��6"   $��3��62   $��	0 10 0 10q�6F   .+�52      �� -   5         ��Name$ ListFeaturedproducts��52      $��3��6Y   ��69   �� *	Product+��53      �� 54      .R�55      ��  ��Name$ BorderFeatured��6!   $��0 5 10 5q�69    �� CornerRadius$ 5��6K   ���	#FF5A48D3._�56      �� $��	10 0 10 0q�6)   $	��300��6<   .+�57   "   �� $
��Left=�6C   ��6-   �� *Name+6C   �� 58   "   ��6-   �� *Description+�� 59   "   $
��Bold"�6,   $��Segoe UI)�6>   ��6U   �� *Price+	 �� StringFormat$	 {0:C}���� 5:   "   -   5        #��� ��5:   C   

 � Tag
 6)   �� *	ProductId+.��6�   
Lägg till6�   5;      5<      5=      ��5?      �� 5@      .R�5A      � 5B      5D      5E      �� 5G   
   -   5         ��Name$ TextBoxSearch��5G      $��4��6)   $��1��66   $��3��6F   $��	0 10 0 0 q�6Z   6�   �� 5J   
   $
��Auto=�6   $��5��6:   $��1��6G   $��3��6W   .��5K      �� -   5        $ ��StackPanelSearchedProducts��5K      $��	0 10 0 10q�6;   5M      5N      �� 5Q   
   -   5         ��Name$ ButtonGoBack��5Q      $��1��6'   $��6��67   $��5q�6D   #��� ��6O   .��6�   
Tillbaka5R      �� 5V   
   -	   5        $ ButtonGoToCart��5V      $��3��6)   $��6��69   $��5q�6F   #��� ��6Q   .��6�   
Kundkorg5W      5Y      5Z      