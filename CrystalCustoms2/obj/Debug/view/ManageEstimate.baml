   M S B A M L   `   `   `  ����J  FCrystalCustoms2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:CrystalCustoms2.viewCrystalCustoms2.view  5      )    #CrystalCustoms2.view.ManageEstimate   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:CrystalCustoms2.view     5      -   5        .��5
      �   � RowDefinitions  5   
   �� 5      $��40 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��50 �6   �� 5      $��* �6   .+�5   
   �� $��견적서 관리��6   $��15(�6!   $
��Bold"�6/   $��0��6A   $��0��6Q   �� 5   
   $��0��6   $��1��6%    �� Orientation$ 
Horizontal=�62   .+�5      �� $��견적서 번호��6   $��Center=�6%   $	��120��6@   �� 5      -   5        $��txtKeyId��5      $�� ��6&   $��Center=�6.   $	��120��6I    �� 
IsReadOnly . 6U   5      �� 5   
   $��0��6   $��2��6%   $ 
Horizontal=�62   .+�5      �� $��견적서 생성일자��6   $��Center=�6'   $	��120��6B   �� 5      -   5        $��
txtKeyType��5      $�� ��6(   $��Center=�60   $	��240��6K   5      �� 5   
   $��0��6   $��3��6%   $ 
Horizontal=�62   .+�5      �� -   5         ��Name$ btnSave��5      $��견적서 신규생성��6&   $	��140��69   $��30��6E   6Q   �� 5       -   5        $ 	btnDelete��5       $��삭제��6(   $��75��65   $��30��6@   6L   �� 5!      -   5        $ btnEdit��5!      $��수정��6&   $��75��63   $��30��6>   6J   �� 5"      -   5        $ 	btnExport��5"      $��PDF 내보내기��6(   $	��120��6;   $��30��6G   6S   �� 5#      -   5        $ btnComplete��5#      $��판매완료��6*   $��80��69   $��30��6D   6P   5$      �� 5&   
   $��0��6   $��8��6%   .+�5'      &   System.Windows.Controls.DataGrid  -	   5          Name$ estDataGrid��5'         
IsReadOnly .    SelectionMode$ Single=�6>      AutoGenerateColumns .  $��Stretch=�6q      Columns 5(      5+      5,      5.      5/      