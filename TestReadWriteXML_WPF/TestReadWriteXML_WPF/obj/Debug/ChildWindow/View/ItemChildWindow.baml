   M S B A M L   `   `   `  ����O  KTestReadWriteXML_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:TestReadWriteXML_WPF.ChildWindow.View%TestReadWriteXML_WPF.ChildWindow.View  5   	   g8clr-namespace:TestReadWriteXML_WPF.ChildWindow.ViewModel*TestReadWriteXML_WPF.ChildWindow.ViewModel  5   	   I)clr-namespace:TestReadWriteXML_WPF.CommonTestReadWriteXML_WPF.Common  5	   	   ;    5TestReadWriteXML_WPF.ChildWindow.View.ItemChildWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Elocal3clr-namespace:TestReadWriteXML_WPF.ChildWindow.View     5   	   N	viewmodel8clr-namespace:TestReadWriteXML_WPF.ChildWindow.ViewModel     5   	   EmultilParameter)clr-namespace:TestReadWriteXML_WPF.Common     5	   	   -   5        $��childWindowItem��5   	     � Title$  ItemDetailsWindow��5   	   $��176.833��6#   $	��300��64    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5      D   >TestReadWriteXML_WPF.ChildWindow.ViewModel.DialogItemViewModel  5   
   6*    � 	Resources 5      6   0TestReadWriteXML_WPF.Common.PassThroughConverter   PassthroughConverter��%   &	          5   
   6N   5      .��5      � .+�5   
   � -   5        $��wrapItem��5      $��0q�6$    � Orientation$ 
Horizontal=�6/   $��Center=�6H   .+�5      �� -   5        $��	txtItemID��5      $��0��6G   $��0��6Q   ��6)   �� *ItemModel.Id+6^   �� 5      -   5         ��Name$
 Unit��5      $
��Left=�6&   $
��Wrap=�6A   $
��Name��6U   $��Center=�6a   $��55��6|   $��0,8,0,0q�6�   �� 5      -   5         ��Name$ txtName��5      $
��Left=�6G   $��23��6b    �� TextWrapping$
 Wrap=�6n   $��Center=�6�   $	��171��6�   $��20,8,0,0q�6�   ��6'   �� *ItemModel.Name+6�   �� 5      -   5        $
 Name��5      $
��Left=�6&   $
��Wrap=�6A   $
��Unit��6U   $��Center=�6a   $��55��6|   $��0,8,0,0q�6�   �� 5      -   5        $ txtUnit��5      $
��Left=�6H   $��23��6c   $
 Wrap=�6o   $��Center=�6�   $	��171��6�   $��20,8,0,0q�6�   ��6(   �� *ItemModel.Unit+6�   �� 5      -   5        $ Create��5      $
��Left=�6(   $
��Wrap=�6C   $��Create��6W   $��Center=�6e   $��55��6�   $��0,8,0,0q�6�   (  "System.Windows.Controls.DatePicker  5      -	   5        	  Name$	 dtCreate��5      $
��Left=�6R   $��24��6m   $��Center=�6y   $	��171��6�   $��20,8,0,0q�6�   
   Text
 6,   �� *ItemModel.CreateDate+6�   �� 5      -
   5         ��Name$ button_Copy��5      $��Excute��6*   $��Center=�6;   $��	75,10,0,0q�6X   $	��Top=�6k   $��75��6�   #��� ��6�   
���������6�   Z� ��5      �� *
ExcuteItem+ �� Mode$ TwoWay=���5       `� 5!       `� 	Converter# [  6#   .1�5"      ��  �� ElementName$ childWindowItem��6"   6B   �� 5#      $ wrapItem��6"   6;   �� 5$      $ 	txtItemID��6"   6<   5%      5'      �� 5(      -   5        $ button_Copy1��5(      $��Cancel��6+   $��Center=�6<   $��	21,10,0,0q�6Y   $	��Top=�6l   $��75��6�   #��� ��6�   
���������6�   Z� 5*      5+      5,      