   M S B A M L   `   `   `  ����O  KTestReadWriteXML_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:TestReadWriteXML_WPFTestReadWriteXML_WPF  5   	   O,clr-namespace:TestReadWriteXML_WPF.ViewModelTestReadWriteXML_WPF.ViewModel  5   	   I)clr-namespace:TestReadWriteXML_WPF.CommonTestReadWriteXML_WPF.Common  5	   	   %    TestReadWriteXML_WPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:TestReadWriteXML_WPF     5   	   B	viewModel,clr-namespace:TestReadWriteXML_WPF.ViewModel     5   	   EmultilParameter)clr-namespace:TestReadWriteXML_WPF.Common     5	   	   -   5        $��MainwindowName��5   	     � Title$  
MainWindow��5   	   $	��525��6   $	��275��6(   $��1q�5   
    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5      2   ,TestReadWriteXML_WPF.ViewModel.ItemViewModel  5   
   6$    � 	Resources 5      6   0TestReadWriteXML_WPF.Common.PassThroughConverter   PassthroughConverter��%   &	          5   
   6N   5      .��5      � .+�5   
   � $��0,10,0,0q�6    � RowDefinitions 5      �� 5      6"   �� 5      6"   5      �� 5   
   $��0��6   $��0,5,0,0q�6"    �� Orientation$ 
Horizontal=�63   $	��Top=�6L   $��Center=�6d   .+�5      �� -   5         ��Name$ button��5      $	��Add��6%   $��Center=�63   $	��Top=�6P   $��75��6h   #��� ��6s   
���������6�   Z� ��5      �� *
ShowDialog+ �� Mode$ TwoWay=��� 5      -   5        $ button_Copy��5      $
��Edit��6*   $��Center=�69   $��0q�6V   $	��Top=�6a   $��75��6y   #��� ��6�   
���������6�   Z� ��5       �� *
ShowDialog+$ TwoWay=���5!      �� *SelectedValue+	 �� ElementName$	 dtg_listItem���� 5"      -   5        $ button_Copy1��5"      $��Delete��6+   $��Center=�6<   $��0q�6Y   $	��Top=�6d   $��75��6|   #��� ��6�   
���������6�   Z� ��5#      �� *
DeleteItem+��5$      `� 5%      
 `� 	Converter#
 [  6#   .1�5&      �� $	 MainwindowName��6"   6A   �� 5'      $	 dtg_listItem��6"   6?   5(      5*      �� 5,      -   5         ��Name$ 	txtSearch��5,      $��Center=�6)   $��0q�6F    �� TextWrapping$
 Wrap=�6Q   $��Center=�6e   $	��120��6�   #��� ��6�   .��6�   5.      �� 5/      -   5        $ button_Copy2��5/      $
��Find��6+   $��0q�6:   $	��Top=�6E   $��75��6]   #��� ��6h   
�������$��Right=�6�   ��6�   Z� ��50      �� *
SearchItem+��51      `� 52      #
 [  6#   .1�53      �� $	 MainwindowName��6"   6A   �� 54      $	 	txtSearch��6"   6<   55      57      59      �� 5:   
   $��0,35,0,0q�6   .+�5;      �� $��List of items��6   $
��Left=�6-   $��Center=�6H   $��50,0,0,0q�6c   &   System.Windows.Controls.DataGrid  5<      -   5          Name$ dtg_listItem��5<      $��1q�6[      CanUserAddRows .  $   HorizontalScrollBarVisibility$
 Auto=�5>      "   VerticalScrollBarVisibility$
 Auto=�5?      $��0,8,0,0q�5@         AutoGenerateColumns .  $	��419��6H   $	��142��6T   $��Center=�6a   ��5<   -   �� *
ListItem+$ TwoWay=�   Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6@      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *Id+6N     5C      $	 Uni��6C    .  6*   �� *Name+6P     5D      $ Create��6C    .  6*   �� *Unit+6S   4  .System.Windows.Controls.DataGridTemplateColumn  5E         CellTemplate 5F      �� 5G      .R�5H   "   �� .+�5I   &   �� $ button��6-   $��Details��6=   $��Center=�6O   $	��Top=�6l   $��75��6�   #��� ��6�   
���������6�   Z� ��5J   -   �� *DataContext.ViewDetails+$	 dtg_listItem��$ TwoWay=���5K   -   �� 5M   #   5N      5P      5S      �� 5T      $ 
Horizontal=�6   $��49,5,0,0q�62   .+�5U      �� -   5         ��Name$ textBlock_Copy3��5U      $
��Left=�65   $
��Wrap=�6P   $��Total: ��6d   $	��Top=�6s   �� 5V      $
��Left=�6   $
��Wrap=�67   $	��Top=�6k   $��10��6�   ��6K   �� *ListItem.Count+6�   �� 5W      $
��Left=�6   $
��Wrap=�67   $��records��6K   $	��Top=�6Z   5X      5Z      5[      5]      