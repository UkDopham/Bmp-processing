   M S B A M L   `   `   `  ����O  KTraitement image Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Traitement_image_Wpf.ViewsTraitement_image_Wpf.Views  5   	   3    -Traitement_image_Wpf.Views.PixelisationWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:Traitement_image_Wpf.Views     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ Pixelisation��5	   	    � Icon$5 /pack://siteoforigin:,,,/Resources/minecraft.png��5
   	   $	��140��5   	   $	��200��5   	    � WindowStyle$
 None=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��4* �6   .+�5   
   � -   5        $��0��5      
������� � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��* �6#   .+�5      �� $�� Pixelisation��6      barreTextBlock#��[  5      $��0��5       �� 5#      -   5        
�������$��0q�5$      $��6��5%      ��5'      �� 5(       �� Orientation$ 
Horizontal=�6!   .+�5)      �� $��20��6    $2��,pack://siteoforigin:,,,/Resources/cancel.png��5*      �� 5+      $�� Fermer��6$   $��10(�5,   $   $��Center=�5-   $   5.      50      52      �� 54   
     
grisClaire#��[ 6   $��1��55      .+�56      �  57      �� 58      $��2* �6'   �� 59      $��* �6'   .+�5<      �� $�� Taille du pixel��6   
�������$��16(�5>      $��10q�5?      $��0��5@      �� 5B      -   5         ��Name$ pixelTextBlock��5B      
�������$��16(�5D      $��1��5E      $��10q�5F       �� Padding$
 10,0q�5G      ��5H      �� 	 �� ElementName$	 pixelSlider��
 �� Path$
 Value� �� UpdateSourceTrigger$ PropertyChanged=�5J      �� 5L      -   5         ��Name$ pixelSlider��5L      $
��10,0q�5M       � Maximum$ 50Q�5N       � Minimum$ 1Q�5O       �� TickFrequency$ 1Q�5P       �� IsSnapToTickEnabled . 5Q      �� 5S      -   5        $��OK��5S      
�������$��18(�5U      $��50,10q�5V      $��0q�5W      5X      5Y      5Z      5\      