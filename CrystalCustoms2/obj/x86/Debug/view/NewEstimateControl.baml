   M S B A M L   `   `   `  ����J  FCrystalCustoms2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:CrystalCustoms2.viewCrystalCustoms2.view  5      -    'CrystalCustoms2.view.NewEstimateControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:CrystalCustoms2.view     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   �� $��견적 입력��6   $��15(�6    $
��Bold"�6.   $��0��6@   $��0��6P   �� 5   
   $��0��6   $��1��6%    �� Orientation$ 
Horizontal=�62   .+�5      �� -   5        $��견적등록��5      $	��100��6$   $��30��60   6<   5      �� 5   
   $��0��6   $��2��6'   .��5      � -   5         �Name$ 
settleForm��5        5      �� 5      $��40 �6$   �� 5      $��40 �6$   �� 5      $��40 �6$   �� 5      $��40 �6$   �� 5       $��40 �6$   �� 5!      $��40 �6$   �� 5"      $��40 �6$   �� 5#      $��40 �6$   �� 5$      $��40 �6$   �� 5%      $��40 �6$   �� 5&      $��40 �6$   �� 5'      $��40 �6$   �� 5(      $��40 �6$   �� 5)      $��40 �6$   �� 5*      $��40 �6$   �� 5+      $��40 �6$   �� 5,      $	��200 �6$   �� 5-      $��40 �6$   �� 5.      $��* �6$    50      �� 51      $��* �6'   �� 52      $��* �6'   .+�55      �� $��견적 수신인 정보��6   $��15(�6,   $
��Bold"�6:   $��0��6L   $��0��6\   $��2��6i   �� 56      $��0��6   $��1��6-   $ 
Horizontal=�6:   .+�57      �� $��회사이름��6   $��Center=�6+   $	��120��6F   �� 58      -   5        $��txtReptName��58      $��한국세*기술원��61   $��Center=�6@   $	��200��6[   59      �� 5:      $��0��6   $��2��6-   $ 
Horizontal=�6:   .+�5;      �� $��전화��6   $��Center=�6)   $	��120��6D   �� 5<      -   5        $��
txtReptTel��5<      $��055-792-2773��60   $��Center=�6D   $	��200��6_   5=      �� 5>      $��0��6   $��3��6-   $ 
Horizontal=�6:   .+�5?      �� $��팩스��6   $��Center=�6)   $	��120��6D   �� 5@      -   5        $��
txtReptFax��5@      $��055-792-2797��60   $��Center=�6D   $	��200��6_   5A      �� 5B      $��0��6   $��4��6-   $ 
Horizontal=�6:   .+�5C      �� $��	담당자��6   $��Center=�6*   $	��120��6E   �� 5D      -   5        $��
txtReptOwn��5D      $��한국세*기술원��60   $��Center=�6?   $	��200��6Z   5E      �� 5F      $��1��6   $��1��6-   $ 
Horizontal=�6:   .+�5G      �� $��주소��6   $��Center=�6)   $	��120��6D   �� 5H      -   5        $��txtReptAddress��5H      $*��$경상남도 진수시 소호로 101��64   $��Center=�6L   $	��240��6g   5I      �� 5J      $��1��6   $��2��6-   $ 
Horizontal=�6:   .+�5K      �� $��날짜��6   $��Center=�6)   $	��120��6D   �� 5L      -   5        $��txtReptDate��5L      $��
2016-11-16��61   $��Center=�6C   $	��200��6^   5M      �� 5N      $��1��6   $��3��6-   $ 
Horizontal=�6:   .+�5O      �� $��견적서번호��6   $��Center=�6,   $	��120��6G   �� 5P      -	   5        $��	txtReptNo��5P      $��161161��6/   $��Center=�6=   $	��200��6X   5Q      �� 5S      $��견적 발신인 정보��6   $��15(�6,   $
��Bold"�6:   $��0��6L   $��5��6\   $��2��6i   $��Center=�6}   �� 5T      $��0��6   $��6��6-   $ 
Horizontal=�6:   .+�5U      �� $��회사이름��6   $��Center=�6+   $	��120��6F   �� 5V      -
   5        $��txtSendName��5V      $#��주식회사 *코퍼레이션��61   $��Center=�6D   $	��200��6_   5W      �� 5X      $��1��6   $��6��6-   $ 
Horizontal=�6:   .+�5Y      �� $��주소��6   $��Center=�6)   $	��120��6D   �� 5Z      -   5        $��txtSendAddress��5Z      $-��'경기도 화성시 동탄반석로 160��64   $��Center=�6M   $	��240��6h   5[      �� 5\      $��0��6   $��7��6-   $ 
Horizontal=�6:   .+�5]      �� $��전화��6   $��Center=�6)   $	��120��6D   �� 5^      -   5        $��
txtSendTel��5^      $��070-5022-5750��60   $��Center=�6E   $	��200��6`   5_      �� 5`      $��0��6   $��8��6-   $ 
Horizontal=�6:   .+�5a      �� $��팩스��6   $��Center=�6)   $	��120��6D   �� 5b      -   5        $��
txtSendFax��5b      $��070-8200-5750��60   $��Center=�6E   $	��200��6`   5c      �� 5d      $��1��6   $��7��6-   $ 
Horizontal=�6:   .+�5e      �� $��견적서 유효기간��6   $��Center=�6/   $	��120��6J   �� 5f      -   5        $��txtSendDeadline��5f      $��
2016-12-16��65   $��Center=�6G   $	��200��6b   5g      �� 5h      $��1��6   $��8��6-   $ 
Horizontal=�6:   .+�5i      �� $��	작성자��6   $��Center=�6*   $	��120��6E   �� 5j      -   5        $��
txtSendOwn��5j      $
��조*��60   $��Center=�6:   $	��200��6U   5k      �� 5m      $��견적상세��6   $��15(�6'   $
��Bold"�65   $��0��6G   $��9��6W   $��2��6d   $��Center=�6x   �� 5n      $��0��6   $��10��6-   $ 
Horizontal=�6;   .+�5o      �� $��영업담당자��6   $��Center=�6,   $	��120��6G   �� 5p      -   5        $��txtSalesOwn��5p      $
��조*��61   $��Center=�6;   $	��200��6V   5q      �� 5r      $��1��6   $��10��6-   $ 
Horizontal=�6;   .+�5s      �� $��	납품일��6   $��Center=�6*   $	��120��6E   �� 5t      -   5        $��txtShipDate��5t      $��
2016-11-24��61   $��Center=�6C   $	��200��6^   5u      �� 5v      $��0��6   $��11��6-   $ 
Horizontal=�6;   .+�5w      �� $��운송수단��6   $��Center=�6+   $	��120��6F   �� 5x      -   5        $��txtShipType��5x      $��택배��61   $��Center=�6;   $	��200��6V   5y      �� 5z      $��1��6   $��11��6-   $ 
Horizontal=�6;   .+�5{      �� $��인도지점��6   $��Center=�6+   $	��120��6F   �� 5|      -   5        $��txtDeliveryPoint��5|      $��귀원자재창고��66   $��Center=�6D   $	��200��6_   5}      �� 5~      $��0��6   $��12��6-   $ 
Horizontal=�6;   .+�5      �� $��조건��6   $��Center=�6)   $	��120��6D   �� 5�      -   5        $��
txtPayCond��5�      $��귀원결제조건��60   $��Center=�6>   $	��200��6Y   5�      �� 5�      $��금액정보��6   $��15(�6'   $
��Bold"�65   $��0��6G   $��13��6W   $��2��6e   $��Center=�6y   �� 5�      $��0��6   $��14��6-   $ 
Horizontal=�6;   .+�5�      �� $��세율��6   $��Center=�6)   $	��120��6D   �� 5�      -   5        $��
txtTaxRate��5�      $��세율��60   $��Center=�6:   $	��200��6U   5�      �� 5�      $��1��6   $��14��6-   $ 
Horizontal=�6;   .+�5�      �� $��합계��6   $��Center=�6)   $	��120��6D   �� 5�      -   5        $��	txtAmount��5�      $��합계��6/   $��Center=�69   $	��200��6T   5�      �� 5�      $��견적품목��6   $��15(�6'   $
��Bold"�65   $��0��6G   $��16��6W   $��2��6e   $��Center=�6y   $��10,10,-10,160q�6�   &   System.Windows.Controls.DataGrid  5�      -   5          Name$ estDataGrid��5�      $��0��60   $��16��6@   $��2��6N      Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ 번호��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   ��  �� Path$ ID�  5�      $ 내역��6-    69   �� $ ITEMNAME�  5�      $ 수량��6-    69   �� $	 QTY�  5�      $ 단가��6-    69   �� $ UPRICE�  5�      $ 금액��6-    69   �� $ AMOUNT�5�      �� 5�      $��0��6   $��17��6-   $��2��6;   $ 
Horizontal=�6O   $��Right=�6h   .+�5�      �� -   5        $��추가��5�      $	��100��6*   $��30��66   6B   �� 5�      -   5        $��삭제��5�      $	��100��6*   $��30��66   6B   5�      5�      5�      5�      5�      