   M S B A M L   `   `   `  ����I  EProjectTickets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ProjectTickets.ViewProjectTickets.View  5   	   !    ProjectTickets.View.Profile   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:ProjectTickets.View     5   	     � Title$  Profile��5   	   $	��450��6   $	��800��6&   .��5	      �� .+�5
   
   � ���#14213d � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� $��0��6   
�������$��16(�6;   $��Center=�6I   $��10q�6d   Профиль6y   �� 5      -   5         ��Name$ cBack��5         	bt_search#���   6$   $	��100��6\   $��
Назад��6h   $��1��6x   $��10q�6�   �� 5      -   5        $ ProfileButton��5      $��70��6G   $��50��6R   
������ 
������ $��5q�6�   $��2��6�   .��5      �� $��70��6   $��50��6#   $��../Images/basket.png��6/   5      �� 5      -   5        $ 
ExitButton��5      $��70��6B   $��50��6M   
������ 
������ $��5q�6�   $��3��6�   .��5      �� $��70��6   $��50��6#   $��../Images/exit.png��6/   5      5      � 5   
    5      �� 5      $��1* �6#   �� 5       $��2* �6#   .+�5#      �� $��1��6   $��10q�6)   .+�5$      �� $��Name:��6   $
��Bold"�6)   �� 5%      -   5         �� 
IsReadOnly$
 True��5%   4   $��30��6F   $��0,0,0,20q�6R   ��6   �� *
NameUser+6d   �� 5'      $��Email:��6   $
��Bold"�6*   �� 5(      $
 True��61   $��30��6C   $��0,0,0,10q�6O   ��6   �� *Email+6O   �� 5*      $
��Age:��6   $
��Bold"�6(   �� 5+      $
 True��6/   $��30��6A   $��0,0,0,20q�6M   ��6   �� *Age+6M   5,      �� 5.      $��0��6   $��../Images/no_photo.png��6$   $��Uniform=�6D   $��10q�6V   5/      �� 51   
   $	��250��6   .��53      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��53         AutoGenerateColumns$ False��54         
IsReadOnly$
 True��55        StyledDataGrid#��[ 56         Columns 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn   Header$ NameFilm��6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6;   �� *
NameFilm+  59      $ Place��6)   	 68   �� *Place+  5:      $ Price��6)   	 68   �� *Price+5<      5=      5>      5?      