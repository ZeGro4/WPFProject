   M S B A M L   `   `   `  ����I  EProjectTickets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ProjectTickets.ViewProjectTickets.View  5   	   $    ProjectTickets.View.OrdersList   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:ProjectTickets.View     5   	   ���#023047  � Icon$  ../Images/logo.ico��5       � Title$ 
OrdersList��5	   	   $	��450��6   $	��800��6)   .��5
      � .+�5   
   �� .+�5      � ���#14213d � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $
��Auto �6'   �� 5      $
��Auto �6'   .+�5      �� $��0��6   
�������$��16(�6@   $��Center=�6O   $��10q�6j   Корзина6�   �� 5      -   5         ��Name$ cBack��5         	bt_search#���   6(   $	��100��6`   $��
Назад��6l   $��1��6|   $��10q�6�   �� 5      -   5        $ btDelete��5      #���   6+   $	��100��6f   $��Удалить��6r   $��2��6�   $��10q�6�   5      � 5      ���	#FF4C618D 5      �� 5      $��* �6'   �� 5      $
��Auto �6'   �� 5      $
��Auto �6'   .+�5      �� -   5         ��Name$ 	pricetext��5      $��0��60   
�������$��16(�6S   $��Center=�6b   $��10q�6}   Сумма: 06�   �� 5       -   5        $ btBuy��5       #���   6(   $	��100��6`   $��Купить��6l   $��2��6}   $��10q�6�   5!      &   System.Windows.Controls.DataGrid  5#      -   5          Name$ dataGrid��5#         AutoGenerateColumns$ False��5$         
IsReadOnly$
 True��5%        StyledDataGrid#��[ 5&         Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn	   Header$	 NameFilm��6)   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6;   �� *
NameFilm+  5)      $	 Place��6)   
 68   �� *Place+  5*      $	 Price��6)   
 68   �� *	FilmPrice+5-      5.      50      51      