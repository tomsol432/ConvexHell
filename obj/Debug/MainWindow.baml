   M S B A M L   `   `   `  ����E  AConvexHell, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ConvexHell
ConvexHell  5   	       ConvexHell.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ConvexHell     5   	   -   5          �Name$  
WindowMain��5   	    � Title$ Convex Hell��5   	   $	��900��6   $
��1600��6*   ���	#FF1D1D1D.��5	      �  � ColumnDefinitions 5
   
   �� 5      $��1407* �6   �� 5      $
��185* �6   .+�5   
   � -   5         �Name$ GridCanvasHolder��5      $��
10,10,1,10q�6)   .+�5      �� -   5         ��Name$ 	CanvasMap��5      5      �� 5   
   -   5         ��Name$ ButtonGenerateDataset��5      $��Generate dataset��60   $��	3,10,10,0q�6K   $	��Top=�6^   $��1��6v   $��20��6�   6�   �� 5   
   -   5         ��Name$ SliderPointAmount��5      $��	3,35,10,0q�6,   $	��Top=�6?    � Minimum$ 5Q�6W    � Maximum$	 200Q�6c   	 � SmallChange$	 1Q�6q   
 �� Interval$
 1��6�    �� IsSnapToTickEnabled . $��1��6�   $��18��6�   �� 5   
   -   5         ��Name$ LabelPCounter��5      $�� ��6'   $��	3,58,10,0q�62   $	��Top=�6E   
�������$��Center=�6p   $��Center=�6�   $��1��6�   $��26��6�   5      5      