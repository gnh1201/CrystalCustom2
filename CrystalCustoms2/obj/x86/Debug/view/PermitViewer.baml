   M S B A M L   `   `   `  ����J  FCrystalCustoms2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:CrystalCustoms2.viewCrystalCustoms2.view  5      '    !CrystalCustoms2.view.PermitViewer   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:CrystalCustoms2.view     5      .��5      �   � RowDefinitions  5	   
   �� 5
      $��30 �6   �� 5      $��50 �6   �� 5      $��40 �6   �� 5      $��3* �6   �� 5      $��50 �6   �� 5      $��2* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   �� $��수입면장 작업선택��6   $��15(�6$   $
��Bold"�62   $��0��6D   $��0��6T   �� 5   
   $��0��6   $��1��6%    �� Orientation$ 
Horizontal=�62   .+�5      �� -   5         ��Name$ 	btnSettle��5      $ ��통관/운송정보 등록��6(   $	��150��6=   $��30��6I   6U   5      �� 5   
   $��수입면장 기본정보��6   $��15(�6$   $
��Bold"�62   $��0��6D   $��2��6T   �� 5   
   $��3��6   ��. $
��Auto=�6<   .��5      � -   5         �Name$ permitSummaries��5       5       �� 5!      $��* �6'   �� 5"      $��2* �6'   �� 5#      $��1* �6'   �� 5$      $��2* �6'   5&      5'      �� 5)   
   $��면장 상세정보��6   $��15(�6"   $
��Bold"�60   $��0��6B   $��4��6R   $��Bottom=�6_   &   System.Windows.Controls.DataGrid  5*   
   -   5          Name$ permitSubDataGrid��5*      $��5��6.   $
��Left=�6;   $	��Top=�6V      
IsReadOnly .    SelectionMode$ Single=�6�      Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn	   Header$	 장치장명��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 63   ��  �� Path$ shedNm�  5-      $	 처리일시��6%   
 63   �� $ prcsDttm�  5.      $	 신고번호��6%   
 63   �� $ dclrNo�  5/      $	 반출입일시��6%   
 64   �� $ rlbrDttm�  50      $	 중량��6%   
 61   �� $
 wght�  51      $	 반출입근거번호��6%   
 66   �� $ 	rlbrBssNo�  52      $	 사전안내내용��6%   
 65   �� $ 
bfhnGdncCn�  53      $	 중량단위��6%   
 63   �� $ wghtUt�  54      $	 포장개수��6%   
 63   �� $ pckGcnt�  55      $	 처리구분��6%   
 63   �� $ cargTrcnRelaBsopTpcd�  56      $	 포장단위��6%   
 63   �� $ pckUt�  57      $	 반출입내용��6%   
 64   �� $ rlbrCn�  58      $	 장치장부호��6%   
 64   �� $ shedSgn�5:      5;      5<      