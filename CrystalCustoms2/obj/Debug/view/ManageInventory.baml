   M S B A M L   `   `   `  ����J  FCrystalCustoms2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:CrystalCustoms2.viewCrystalCustoms2.view  5      *    $CrystalCustoms2.view.ManageInventory   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:CrystalCustoms2.view     5      .��5	      � .+�5
   
   �   � ColumnDefinitions  5      �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��40 �6    �� 5      $��40 �6    �� 5      $��* �6    .+�5      �� $��재고관리��6   $��15(�6#   $
��Bold"�61   $��0��6C   $��0��6S   �� 5      $��0��6   $��1��6)    �� Orientation$ 
Horizontal=�66   .+�5      �� -   5         ��Name$ btnSave��5      $��신규��6*   $��75��67   $��30��6B   6N   �� 5      -   5        $ 	btnDelete��5      $��삭제��6,   $��75��69   $��30��6D   6P   �� 5      -   5        $ btnEdit��5      $��수정��6*   $��75��67   $��30��6B   6N   �� 5      -   5        $ btnPrev��5      $��이전��6*   $��75��67   $��30��6B   6N   �� 5      -   5        $ btnNext��5      $��다음��6*   $��75��67   $��30��6B   6N   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ invDataGrid��5      $��0��6,   $��2��6<    � 	Resources 5      )  #System.Windows.Controls.DataGridRow �� 
TargetType��%E   '        �� 5       "  6   .�5!      -   5        5"      5#         Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ 번호��6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 65   �� 
 �� Path$
 Id�  5&      $ 	제품명��6)   	 66   �� $

 Name�  5'      $ 
Master B/L��6)   	 6=   �� $
 Mblno�  5(      $ 	House B/L��6)   	 6<   �� $
 Hblno�  5)      $ 수량��6)   	 65   �� $	
 Qty�  5*      $ 단가��6)   	 65   �� $
 	Unitprice�  5+      $ 규격��6)   	 65   �� $
 Standard�5-      5.      5/      50      