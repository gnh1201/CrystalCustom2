   M S B A M L   `   `   `  ����J  FCrystalCustoms2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:CrystalCustoms2.viewCrystalCustoms2.view  5      ,    &CrystalCustoms2.view.ManageAddressBook   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:CrystalCustoms2.view     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   .+�5   
   �� $��주소록 관리��6   $��15(�6!   $
��Bold"�6/   $��0��6A   $��0��6Q   $��2��6^   �� 5   
   $��0��6   $��1��6%    �� Orientation$ 
Horizontal=�62   .+�5      �� $��분류��6   $��Center=�6!   $	��120��6<   �� 5      -   5        $��	txtAddrId��5      $��1��6'   $��Center=�60   $	��120��6K    �� 
IsReadOnly . 6W   5      �� 5    
   $��0��6   $��2��6%   $ 
Horizontal=�62   .+�5!      �� $��이름��6   $��Center=�6!   $	��120��6<   �� 5"      -   5        $��
txtKeyType��5"      $��unipass��6(   $��Center=�67   $	��240��6R   5#      �� 5%   
   $��0��6   $��3��6%   $ 
Horizontal=�62   .+�5&      �� $��우편번호1��6   $��Center=�6$   $	��120��6?   �� 5'      -   5        $��
txtKeyName��5'      $��retrieveCargCsclPrgsInfo��6(   $��Center=�6H   $	��240��6c   5(      �� 5*   
   $��0��6   $��4��6%   $ 
Horizontal=�62   .+�5+      �� $��우편번호2��6   $��Center=�6$   $	��120��6?   �� 5,      -   5        $��
txtKeyDesc��5,      $��화물통관진행번호��6(   $��Center=�68   $	��240��6S   5-      �� 5/   
   $��0��6   $��5��6%   $ 
Horizontal=�62   .+�50      �� $��인증키 코드��6   $��Center=�6%   $	��120��6@   �� 51      -   5        $��
txtKeycode��51      $��0000000000000000000��6*   $��Center=�6E   $	��240��6`   52      �� 54   
   $��0��6   $��6��6%   $ 
Horizontal=�62   .+�55      �� $��인증키 등록시간��6   $��Center=�6'   $	��120��6B   �� 56      -   5        $��txtKeyDatetime��56      $��0000000000000000000��6.   $��Center=�6I   $	��240��6d   57      59      5:      