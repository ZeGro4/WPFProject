   M S B A M L   `   `   `  ���� I  EProjectTickets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ProjectTickets.ViewProjectTickets.View  $    ProjectTickets.View.LIstCinema   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:ProjectTickets.View       � Icon$  ../Images/logo.ico�� � Title$ 
LIstCinema��$	��450��$	��800�����#023047 � 	Resources    listTemplate �� Path��%�  &	        �� .R��� $��5q�$��350px��$	��400��.+��� $	��300��$	��200������ $ 	PathImage��� $��20(�
�������$
��Bold"�$��Center=����� $ 
NameCinema�� .+��� $��16(�$	��0 5q�
�������$��Address:��$��Center=��� $��16(�$	��0 5q�
�������$��Center=����� $ Addres�� .+��� $��16(�
�������$��Owner:��$��Center=��� $��16(�
�������$��Center=����� $ OwnerCinema�.��� .+��� .���� .+�� ���#14213d � RowDefinitions �� $
��Auto � � ColumnDefinitions �� $��2* ��� $��1* ��� $��1* �.+��� -    ��Name$ 	searchbox��$	��350��  txtbox_search#���  $��0��$��0���� -    ��Name$ btSearch��  	bt_search#���  $��
Поиск��$��1��$��0���� -   $ 	btCinemas��#���  $��Фильмы��$��2��$��0���  �� $��* � �� $
��Auto ��� $��2* �.+��� $	��400��$	��210��$��0�����#14213d.+��� -   $ bt_add��#���  $	��170��$��5q�$��Добавить���� -   $ 	bt_delete��#���  $	��170��$��5q�$��Удалить���� -    ��Name$ 
cinemaList��$��1��$��0��#��[  $��Disabled=����#023047
������ ���� .R�� 