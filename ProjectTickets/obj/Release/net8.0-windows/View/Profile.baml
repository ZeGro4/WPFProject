   M S B A M L   `   `   `  ���� I  EProjectTickets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ProjectTickets.ViewProjectTickets.View  !    ProjectTickets.View.Profile   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:ProjectTickets.View       � Title$  Profile��$	��450��$	��800��.���� .+�� ���#14213d � ColumnDefinitions �� $��* ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��
�������$��16(�$��Center=�$��10q�Профиль�� -    ��Name$ cBack��   	bt_search#���   $	��100��$��
Назад��$��1��$��10q��� -   $ ProfileButton��$��70��$��50��
������ 
������ $��5q�$��2��.���� $��70��$��50��$��../Images/basket.png���� -   $ 
ExitButton��$��70��$��50��
������ 
������ $��5q�$��3��.���� $��70��$��50��$��../Images/exit.png���  �� $��1* ��� $��2* �.+��� $��1��$��10q�.+��� $��Name:��$
��Bold"��� -    �� 
IsReadOnly$
 True��$��30��$��0,0,0,20q����� *
NameUser+�� $��Email:��$
��Bold"��� $
 True��$��30��$��0,0,0,10q����� *Email+�� $
��Age:��$
��Bold"��� $
 True��$��30��$��0,0,0,20q����� *Age+�� $��0��$��../Images/no_photo.png��$��Uniform=�$��10q��� $	��250��.��&   System.Windows.Controls.DataGrid  -     Name$ dataGrid��   AutoGenerateColumns$ False��   
IsReadOnly$
 True��  StyledDataGrid#��[    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ NameFilm��1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *
NameFilm+  $ Place��	 �� *Place+  $ Price��	 �� *Price+