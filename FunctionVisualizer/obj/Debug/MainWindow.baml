   M S B A M L   `   `   `  ����M  IFunctionVisualizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:FunctionVisualizerFunctionVisualizer  5   	   #    FunctionVisualizer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:FunctionVisualizer     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��0.1* �6   6,   �� 5      $
��0.1* �6   6,   �� 5      $
��0.1* �6   6,   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $
��0.1* �6   6.   �� 5      $��* �6   6+   �� 5      $
��0.2* �6   6.   .+�5   
   � $��1��6   $��2��6    5      �� 5      $
��0.6* �6#   62   �� 5      $��* �6#   6/   �� 5      $
��0.6* �6#   62   �� 5      $��* �6#   6/   .+�5      �� $��0��6   $��Center=�6(   $��13(�6C   " Начало интервала:5      �� 5      -   5         ��Name$ StartIntervalTBox��5      $��1��62   6E   �� 5       $��2��6   $��Center=�6(   $��13(�6C    Конец интервала:5"      �� 5#      -   5        $ EndIntervalTBox��5#      $��3��6/   6B   5$      �� 5%   
   $��1��6   $��0��6"   $��20(�62   $��Center=�6@   F(X) =6g   �� 5&   
   -   5        $ FunctionTBox��5&      $��1��6(   $��1��65   �� 5'   
   -   5         ��Name$ Button1��5'      $��Нарисовать��6"   $��1��67   $��2��5(      69   �� 5)   
   -   5         ��Name$ OutputTB��5)      $��3��6&   $��1��63   5*      5+      