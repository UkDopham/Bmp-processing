   M S B A M L   `   `   `  ����O  KTraitement image Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Traitement_image_Wpf.ViewsTraitement_image_Wpf.Views  5   	   .    (Traitement_image_Wpf.Views.MessageWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:Traitement_image_Wpf.Views     5   	     � Title$  Message��5   	   $	��120��5	   	   $	��250��5
   	    � Icon$0 *pack://siteoforigin:,,,/Resources/text.png��5   	    � 
ResizeMode$ NoResize=�5   	   $��Segoe UI Light)�5   	    � WindowStyle$
 None=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��5* �6   .+�5   
   � -   5        $��0��5      
������� � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��* �6#   .+�5      �� $�� Message��6      barreTextBlock#��[  5       $��0��5!      �� 5$      -   5        
�������$��0q�5%      $��6��5&      ��5(      �� 5)       �� Orientation$ 
Horizontal=�6!   .+�5*      �� $��20��6    $2��,pack://siteoforigin:,,,/Resources/cancel.png��5+      �� 5,      $�� Fermer��6$   $��10(�5-   $   $��Center=�5.   $   5/      51      53      �� 54   
   
�������$��1��55      .+�57      �� $��1��6   $+��%   Quel message voulez vous écrire ?��58      
�������59      �� 5;      $��2q�6   $��
20,10,20,0q�5<      $��0q�5=      
����������#3399ff��5>      �� *MessageCode+5@      � 5A       5B      �� 5C      $��3* �6'   �� 5D      $��2* �6'   �� 5E      $��3* �6'   .+�5I      �� -   5        $��20,10,20,10q�5I      ���#3399ff$��0q�5K      $��Couleur��5M      
�������$��0��5O      �� 5Q      $��1��6   .+�5R      �� $��Taille de la police��6   
�������$��8(�5T      $��0q�5U      
���   �5V      �� 5W      -   5         ��Name$ tailleComboBox��5W      .@�5X      �� $��10��6'    �� 
IsSelected . 5Y   #   �� 5Z      $��12��6'   �� 5[      $��14��6'   �� 5\      $��16��6'   �� 5]      $��18��6'   �� 5^      $��20��6'   �� 5_      $��22��6'   �� 5`      $��24��6'   �� 5a      $��26��6'   �� 5b      $��28��6'   �� 5c      $��30��6'   �� 5d      $��32��6'   �� 5e      $��34��6'   5f      5g      �� 5j      -   5        $��20,10,20,10q�5j      ���#3399ff$��0q�5l      $��OK��5n      
�������$��2��5p      5q      5s      5t      5u      5w      