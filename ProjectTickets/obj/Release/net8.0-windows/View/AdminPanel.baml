   M S B A M L   `   `   `  ���� I  EProjectTickets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ProjectTickets.ViewProjectTickets.View  $    ProjectTickets.View.AdminPanel   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:ProjectTickets.View       � Icon$  ../Images/logo.ico�� � Title$ 
AdminPanel�����#023047$	��450��$	��800�� � 	Resources    listTemplate �� Path��%  &	        �� .R��� $��5q�$��350px��.+��� $	��300��$	��200������ $ 	PathImage��� $��20(�
�������$
��Bold"�$��Center=����� $ NameFilm�� .+��� $��16(�
�������$��Year:��$��Center=��� $��16(�
�������$��Center=����� $ DateFilm�� .+��� $��16(�
�������$��Time:��$��Center=��� $��16(�
�������$��Center=����� $ TimeFilm�� .+��� $��16(�
�������$��Price:��$��Center=��� $��16(�
�������$��Center=����� $ Price�.��� .+��� .���� .+�� ���#14213d � RowDefinitions �� $
��Auto � � ColumnDefinitions �� $��2* ��� $��1* ��� $��1* ��� $
��Auto �.+��� -    ��Name$ 	searchbox��$	��320��  txtbox_search#���  $��0��$��0���� -    ��Name$ btSearch��  	bt_search#���  $��
Поиск��$��1��$��0���� -   $ 	btCinemas��#���  $��Кинотеатры��$	��120��$��2��$��0���� -   $ 
ExitButton��$��70��$��50��
������ 
������ $��3q�$��8��$��0��.���� $��70��$��50��$��../Images/exit.png���  �� $��* � �� $
��Auto ��� $��2* �.+��� $	��210��$	��400��$��0�����#14213d.+��� -   $ bt_add��#���  $	��170��$��5q�$��Добавить���� -   $ bt_edit��#���  $	��170��$��5q�$��Изменить���� -   $ 	bt_delete��#���  $	��170��$��5q�$��Удалить���� -    ��Name$ 	filmsList��$��1��$��0��#��[  $��Disabled=����#023047
������ ���� .R�� 