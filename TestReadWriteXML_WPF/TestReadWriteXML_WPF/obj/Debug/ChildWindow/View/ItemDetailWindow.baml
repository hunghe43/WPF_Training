   M S B A M L   `   `   `  ����O  KTestReadWriteXML_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:TestReadWriteXML_WPF.ChildWindow.View%TestReadWriteXML_WPF.ChildWindow.View  5   	   g8clr-namespace:TestReadWriteXML_WPF.ChildWindow.ViewModel*TestReadWriteXML_WPF.ChildWindow.ViewModel  5   	   I)clr-namespace:TestReadWriteXML_WPF.CommonTestReadWriteXML_WPF.Common  5	   	   <    6TestReadWriteXML_WPF.ChildWindow.View.ItemDetailWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Elocal3clr-namespace:TestReadWriteXML_WPF.ChildWindow.View     5   	   N	viewmodel8clr-namespace:TestReadWriteXML_WPF.ChildWindow.ViewModel     5   	   EmultilParameter)clr-namespace:TestReadWriteXML_WPF.Common     5	   	   -   5        $��windowDetails��5   	     � Title$  ItemDetailWindow��5   	   $��1q�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   $��314.334��6.   $	��552��6?    � DataContext 5      D   >TestReadWriteXML_WPF.ChildWindow.ViewModel.DialogItemViewModel  5   
   6*    � 	Resources 5      6   0TestReadWriteXML_WPF.Common.PassThroughConverter   PassthroughConverter��%   &	          5   
   6N   5      .��5      � $��
49,10,16,0q�6   $	��Top=�6   $	��479��67   .+�5   
   � $��0,5,0,0q�6    � Orientation$ 
Horizontal=�6%   $	��Top=�6>   $	��476��6V   .+�5      �� -   5         ��Name$ 	textBlock��5      $
��Left=�6+   $
��Wrap=�6F   $
��Name��6Z   $	��Top=�6f   �� 5      -   5         ��Name$ textBox_Copy��5   6   $��Center=�6L    �� TextWrapping$
 Wrap=�6i   $��Center=�6}   $��76��6�   #��� ��6�   $��10,0,0,0q�6�   {�.  ��6   �� *ItemModel.Name+6�   �� 5      -   5        $ textBlock_Copy��5      $
��Left=�60   $
��Wrap=�6K   $
��Unit��6_   $	��Top=�6k   $��27,0,0,0q�6�   �� 5      -   5        $ textBox_Copy1��5   6   $��Center=�6M   $
 Wrap=�6j   $��Center=�6~   $��67��6�   #��� ��6�   $��10,0,0,0q�6�   {�.  ��6   �� *ItemModel.Unit+6   �� 5      -   5        $ textBlock_Copy1��5      $
��Left=�61   $
��Wrap=�6L   $��Create��6`   $	��Top=�6n   $��21,0,0,0q�6�   �� 5      -   5        $ textBox��5   <   $��Center=�6M   $
 Wrap=�6j   $��Center=�6~   $	��137��6�   #��� ��6�   $��10,0,0,0q�6�   {�.  ��6   �� *ItemModel.CreateDate+6  5      � 5   
   -   5        $��wrap_details��5      $��0,39,17,197q�6(   $��Center=�6=   .+�5       �� -	   5        $��textDetailsID��5       $��0��6m   $��0��6x   ��6-   �� *SelectedItem.Id+	 �� ElementName$	 dtg_listItemDetail��6�   �� 5!      $��Price��6   6'   �� 5"      -
   5        $��txtPrice��5"      $��66��6i   $��Center=�6t   $��17,0,0,0q�6�   ��6&   �� *SelectedItem.Price+$	 dtg_listItemDetail��6�   �� 5#      $��Quantity��6   $��14,0,0,0q�6(   6<   �� 5$      -   5        $��txtQuantity��5$      $��66��6p   $��Center=�6{   $��10,0,0,0q�6�   ��6*   �� *SelectedItem.Quantity+$	 dtg_listItemDetail��6�   �� 5%      $��Excute��6   $	��Top=�6&   $��59��6>   #��� ��6I   
�������$��Right=�6�   $��26,0,0,0q�5&      ��5%   �   Z� ��5&   '   �� *ExcuteDetail+��5'      `� 5(      
 `� 	Converter#
 [  6#   .1�5)      �� $	 wrap_details��6"   6?   �� 5*      $	 textDetailsID��6"   6@   5+      5-      �� 5.      $��Cancel��6   $	��Top=�6'   $��59��6?   #��� ��6J   
�������$��Right=�6�   $��0q�5/      ��5.   �   Z� 5/      50      �� 51   
   $��0,82,0,0q�6   $	��424��6'   $	��Top=�63   .+�52      �� $
��Left=�6   $
��Wrap=�63   $��List Details��6G   $	��Top=�6[   &   System.Windows.Controls.DataGrid  53      -   5          Name$ dtg_listItemDetail��53      $��1q�6g      CanUserAddRows .  $   HorizontalScrollBarVisibility$
 Auto=�55      "   VerticalScrollBarVisibility$
 Auto=�56         AutoGenerateColumns .  $	��142��57   -   $��0,0,1,0q�6:   ��53   3   �� *ListItemDetail+ �� Mode$ TwoWay=�   Columns 58      0  *System.Windows.Controls.DataGridTextColumn  59      ,  &System.Windows.Controls.DataGridColumn   Header$ No��6A      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *Id+6M     5:      $
 Name��6M    .  6)   �� *ItemModel.Name+6\     5;      $
 Unit��6L    .  6)   �� *ItemModel.Unit+6Z     5<      $ 
CreateDate��6*    . 6>     5=      $ Price��6D    6*   �� *Price+6D     5>      $ Quantity��6G    6*   �� *
Quantity+6G     5?      $ Amount��6*    .  6:   �� *Total+6T   4  .System.Windows.Controls.DataGridTemplateColumn  5@         CellTemplate 5A      �� 5B      .R�5C   "   �� .+�5D   &   �� $��X��6-   ��69   �� *DataContext.DeleteDetail+$	 dtg_listItemDetail��$ TwoWay=���5E   *   `� 5F   .   #
 [  6;   .1�5G   2   �� $	 windowDetails��6:   6X   �� 5H   2   $	 dtg_listItemDetail��6:   6]   5I   /   5K   '   5L   #   5M      5O      5Q      �� 5R       �� Orientation$ 
Horizontal=�6   .+�5S      �� -   5        $ textBlock_Copy3��5S      $
��Left=�65   $
��Wrap=�6P   $��Total: ��6d   $	��Top=�6s   �� 5T      $
��Left=�6   $
��Wrap=�67   $	��Top=�6x   $��10��6�   ��6K   �� *ItemModel.ItemDetails.Count+6�   �� 5U      $
��Left=�6   $
��Wrap=�67   $��records��6K   $	��Top=�6Z   5V      5W      5Z      5[      