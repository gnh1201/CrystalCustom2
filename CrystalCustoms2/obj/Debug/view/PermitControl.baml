   M S B A M L   `   `   `  ����J  FCrystalCustoms2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:CrystalCustoms2.viewCrystalCustoms2.view  5      (    "CrystalCustoms2.view.PermitControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:CrystalCustoms2.view     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��40 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��60 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   �� $��수입면장 입력��6   $��15(�6"   $
��Bold"�60   $��0��6B   $��0��6R   �� 5   
   $��0��6   $��1��6%    �� Orientation$ 
Horizontal=�62   .+�5      �� $��면장유형��6   $��Center=�6#   $��70��6>   �� 5      -   5         ��Name$ selBlNo��5      $��Center=�6(   $	��200��6C   .@�5      �� 
 � Tag$ hblNo��6    �� 
IsSelected . .��6=   하우스 B/L (HBL)6L   �� 5      $ mblNo��6   .��6+   마스터 B/L (MBL)6:   �� 5      $ cargMtNo��6   .��6.   화물번호64   5      5       �� 5"   
   $��0��6   $��2��6%   $ 
Horizontal=�62   .+�5#      �� $��
B/L 번호��6   $��Center=�6%   $��70��6@   �� 5$      -   5        $��txtBlNo��5$      $��AW15CY16JR1106��6'   $��Center=�6=   $	��200��6X   5%      �� 5'   
   $��0��6   $��3��6%   $ 
Horizontal=�62   .+�5(      �� $��귀속연도��6   $��Center=�6#   $��70��6>   �� 5)      -   5        $��selBlYy��5)      $��Center=�6&   $	��200��6A   5*      �� 5,   
   $��0��6   $��4��6%   $ 
Horizontal=�62   .+�5-      �� $��화물번호��6   $��Center=�6#   $��70��6>   �� 5.      -   5        $��txtCargMtNo��5.      $�� ��6)   $��Center=�61   $	��200��6L   5/      �� 51   
   $��0��6   $��5��6%   $ 
Horizontal=�62   $��Bottom=�6K   .+�52      �� -   5         ��Name$ btnOk��52      $��입력��6$   $��75��61   $��30��6<   6H   53      54      55      