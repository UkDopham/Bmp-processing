   M S B A M L   `   `   `  ����O  KTraitement image Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Traitement_image_Wpf.ViewsTraitement_image_Wpf.Views  5   	   2    ,Traitement_image_Wpf.Views.RedimensionWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:Traitement_image_Wpf.Views     5   	     � Title$  Redimension��5   	    � 
ResizeMode$ NoResize=�5	   	   $	��150��5
   	   $	��200��5   	    � WindowStyle$
 None=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��8* �6   .+�5   
   � -   5        $��0��5      
������� � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��* �6#   .+�5      �� $�� Redimension��6      barreTextBlock#��[  5      $��0��5      �� 5!      -   5        
�������$��0q�5"      $��6��5#      ��5%      �� 5&       �� Orientation$ 
Horizontal=�6!   .+�5'      �� $��20��6    $2��,pack://siteoforigin:,,,/Resources/cancel.png��5(      �� 5)      $�� Fermer��6$   $��10(�5*   $   5+      5-      5/      �� 51   
     
grisClaire#��[ 6   $��1��52      .+�53      �  54      �� 55      $��2* �6'   �� 56      $��* �6'   .+�59      �� $��0��6   $ 
Horizontal=�6-   .+�5;      �� $2��,pack://siteoforigin:,,,/Resources/height.png��6     imageBarreDeTache#��[ 5<      $	��5,0q�5=      �� 5?      $�� Hauteur��6    #��[  5@      $��10q�5A      5B      �� 5D      -   5         ��Name$ HauteurTextBox��5D      
�������$��12(�5F      $��1��5G      $��10q�5H      $
��10,0q�5I      $��0��5J      5L      � 5N       5O      �� 5P      $��2* �6'   �� 5Q      $��* �6'   .+�5T      �� $��0��6   $ 
Horizontal=�5U      .+�5V      �� $1��+pack://siteoforigin:,,,/Resources/width.png��6   #��[ 5W      $	��5,0q�5X      �� 5Z      $�� Largeur��6    #��[  5[      $��10q�5\      5]      �� 5_      -   5        $ LargeurTextBox��5_      
�������$��12(�5a      $��1��5b      $��10q�5c      $
��10,0q�5d      $��0��5e      5g      �� 5i      -   5        $��OK��5i      
�������$��18(�5k      $��50,10q�5l      $��0q�5m      5n      5o      5p      5q      