   M S B A M L   `   `   `  ����?  ;Cars, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CarsCars  5   	       Cars.Add   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Cars     5   	     � Title$  AddCarDialog��5   	   $	��350��6   $	��350��6+   .��5	      � .+�5
   
   �� $��20q�6   .+�5      � $��	0 20 0 20q�6   .+�5      �� $��Make model:��6   $	��100��6.   $
��Left=�6:   �� 5      -   5        $��	modelText��5   H   $��	100 0 0 0q�6Y   5      � 5      .+�5      �� $��Engine Size:��6   $	��100��6/   $
��Left=�6;   �� 5      -   5        $��sizeText��5      $��	100 0 0 0q�6,   5      �� 5      -   5        $��slEngine��5       � SmallChange$	 0.1Q�6%    � Maximum$ 20Q�67    � Minimum$ 0Q�6D    �� IsSnapToTickEnabled .  �� TickPlacement$
 None=�5   	    �� TickFrequency$	 0.1Q�6   $��	5 20 5 20q�62   6E   � 5      .+�5      �� $��
Fuel type:��6   $��70��6-   $
��Left=�68   �� 5      -   5        $
��fuel��5      $��70 0 0 0q�6'   .@�5      ��  �� 
IsSelected . .��65   
Gasoline6?   �� 5      .��6#   Diesel6+   �� 5      .��6#   Hybrid6+   �� 5      .��6#   
Electric6-   �� 5      .��6#   Other6*   5      5      � 5      $��	0 30 0 20q�6   .+�5       �� -   5        $��bnCancel��5       $	��100��6@   $
��Left=�6L   $��	20 0 50 0q�6g   .��6z   Cancel6�   �� 5!      -   5        $��bnSave��5!      $	��100��6<   $
��Left=�6H   $��	170 0 0 0q�6c   .��6v   Save6|   5"      5#      5$      5%      