   M S B A M L   `   `   `  ����O  KTraitement image Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Traitement_image_Wpf.ViewsTraitement_image_Wpf.Views  5   	   1    +Traitement_image_Wpf.Views.HistoriqueWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:Traitement_image_Wpf.Views     5   	     � Title$  HistoriqueWindow��5   	   $	��300��5	   	   $	��300��5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	   .��5      �    
grisClaire#��[  6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��8* �6   .+�5   
   � -   5        $��0��5      
������� � ColumnDefinitions 5      �� 5      $��3* �6#   �� 5      $��* �6#   .+�5      �� $�� Historique��6     barreTextBlock#��[ 5      $��0��5      �� 5       -   5        
�������$��0q�5!      $��6��5"      ��5$      �� 5%       �� Orientation$ 
Horizontal=�6!   .+�5&      �� $��20��6    $2��,pack://siteoforigin:,,,/Resources/cancel.png��5'      �� 5(      $�� Fermer��6$   #��[ 5)   (   5*      5,      5.      �� 50   
   -   5         ��Name$ HistoriqueListBox��50      $��1��51      53      55      56      