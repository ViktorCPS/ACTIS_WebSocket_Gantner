   M S B A M L   `   `   `  ����N  JGAT.GT7.Client.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GAT.GT7.Client.CoreGAT.GT7.Client.Core  5   	   $    GAT.GT7.Client.Core.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:GAT.GT7.Client.Core     5   	   ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   $��10q�65    � DataContext 5
      '   !GAT.GT7.Client.Core.MainViewModel  5   
    � 	Resources 5      1   +GAT.GT7.Client.Core.InverseBooleanConverter   	BoolToVis+   %GAT.GT7.Client.Core.EnumNameConverter  EnumNameConverter �� 
TargetType �� Property �� Value%  Xceed.Wpf.Toolkit.IntegerUpDown&   System.Windows.Controls.DataGrid��%�  &	        &	      '�� &     '  �     '��     '�� Y    '  �    '��       5   
   6(     5   
   6"   �� 5   
   " ��6   .�5      ��  � ��$ 200px��6)   �� 5       � ��$ 0,0,0,5q�6'   5      �� 5   
   "  6   .�5      ��  � ��$ 200px��6)   �� 5       � ��$ 0,0,0,5q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 100px��6)   5      �� 5   
   " ��6   .�5      ��  � ��$ 10,0,0,0q�6'   �� 5       � ��$ 	10 0 10 0q�6(   5      �� 5    
   "  6   .�5!      ��  � ��$ 0,0,0,5q�6'   5"      �� 5#   
   " ��6   .�5$      ��  � ��$ 2,5,2,5q�6'   5%      5'      .��5(      � $��5q�6    � ColumnDefinitions 5)   
   �� 5*      $
��auto �6   �� 5+      $
��auto �6   �� 5,      $��* �6   �� 5-      $
��auto �6   �� 5.      $
��auto �6    � RowDefinitions 51   
   �� 52      $
��auto �6   �� 53      $
��auto �6   �� 54      $
��auto �6   �� 55      $��* �6   �� 56      $
��auto �6   .+�59   
   �� $��0��6   $��0��6    $
��Host��6-   �� 5:   
   -   5        $
��Host��5:   /   $��1��6   $��0��6"   ��6;   �� *Host+{�6Q   �� *	IsStarted+ �� 	Converter# [  �� 5<   
   $��0��6   $��1��6    $��Username��6.   �� 5=   
   -   5        $��Username��5=   /   $��1��6   $��1��6"   ��6?   �� *User+{�6U   �� *	IsStarted+# [  �� 5?   
   $��0��6   $��2��6    $��Password��6-   �� 5@   
   -   5        $��Password��5@   /   $��1��6   $��2��6"   ��6?   �� *
Password+{�6Y   �� *	IsStarted+# [  �� 5B   
   $��3��6   $��0��6!   $��Start��6.   ��6>   �� *StartDeviceCommand+�� 5C   
   $��4��6   $��0��6!   $
��Stop��6.   ��6=   �� *StopDeviceCommand+�� 5E   
   $��2��6   $��4��6    $��	Connected��6R   ${�False��6f   	 d� 	IsChecked	 60   �� *IsConnected+6f     5I   
   $��3��6   $��99��6    
   
IsReadOnly$

 True��5J         AutoGenerateColumns$ False��6%      ClipboardCopyMode$ ExcludeHeader=�6A   ��5I   5   �� *
LogEntries+*   $GAT.GT7.Client.Core.DataGridBehavior   
Autoscroll 5K      �� *
AutoScroll+   	CellStyle 5L      �� 5M      *  $System.Windows.Controls.DataGridCell"  6   .�5N      ��  � ��$ 0q�68   5O       5R        textBlockStyle��%_   &	       �� 5T      " ��6   .�5U      ��  �@��Padding$ 5,2,5,2q�60   5V      5W         Columns 5X      0  *System.Windows.Controls.DataGridTextColumn  5Y      ,	  &System.Windows.Controls.DataGridColumn 	  Header$
 Date��6%   1
  +System.Windows.Controls.DataGridBoundColumn 
  ElementStyle# [ 6L    
  Binding 63   �� *Date+6L   4  .System.Windows.Controls.DataGridTemplateColumn  5\      $
 Type��6)      CellTemplate 5]      �� 5^      .R�5_      �� $
��None=�6$   ��5`   "   �� 5a   &   " ��6,    �� Triggers 5b   *   �� 5c   .   *   $GAT.GT7.Client.Core.LogEntryTypeEnum   	Connected �� Value# Z 6S    �� Binding 6:   �� *Type+.a�5d   2   ��  � ��$B </GAT.GT7.Client.Core;component/Resources/connected_16x16.png��6K   5e   /   �� 5f   .      Disconnected# Z 6S    6:   �� *Type+.a�5g   2   ��  � ��$E ?/GAT.GT7.Client.Core;component/Resources/disconnected_16x16.png��6K   5h   /   �� 5i   .      DataReceived# Z 6S    6:   �� *Type+.a�5j   2   ��  � ��$A ;/GAT.GT7.Client.Core;component/Resources/received_16x16.png��6K   5k   /   �� 5l   .      DataSent# Z 6S    6:   �� *Type+.a�5m   2   ��  � ��$= 7/GAT.GT7.Client.Core;component/Resources/sent_16x16.png��6K   5n   /   �� 5o   .      Message# Z 6S    6:   �� *Type+.a�5p   2   ��  � ��$@ :/GAT.GT7.Client.Core;component/Resources/message_16x16.png��6K   5q   /   5s   '   5u      5v      5x        5z      $ Message��6)    	  Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6:    	  ClipboardContentBinding 6D   �� *	Message+ 5{      �� 5|      .R�5}      �� #��[ 6f   ��6(   �� *	Message+ � ToolTip 6A   �� *MessageFormatted+6f   5~      5�      5�      � 5�   
   $��4��6   $��0��6   $��99��6,    5�      �� 5�      $
��auto �6#   �� 5�      $
��auto �6#   �� 5�      $��* �6#   �� 5�      $
��auto �6#   �� 5�      $
��auto �6#    5�      �� 5�      $
��auto �6    �� 5�      $
��auto �6    .+�5�      �� $��1��6   $��0��6$   $��Allow Access��6V   	 64   �� *AllowAccess+6V   �� 5�      $��3��6   $��
Autoscroll��6H   $��Center=�6]   	 6'   �� *
AutoScroll+6]   �� 5�      $��4��6   $��Clear��6&   ��66   �� *ClearCommunicationCommand+�� 5�      $��0��6   $��
Delay [ms]��6$     5�      -   5        $��Delay��5�   2   $��1��6"   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   	Increment 1006   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]    Minimum  06�   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase!   Text! 6?   �� " �� Path$" Delay�# �� UpdateSourceTrigger$# PropertyChanged=�6�   5�      5�      5�      