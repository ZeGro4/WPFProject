   M S B A M L   `   `   `  ���� I  EProjectTickets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ProjectTickets.ViewProjectTickets.View  $    ProjectTickets.View.CinemaPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:ProjectTickets.View       � Icon$  ../Images/logo.ico�� � Title$ 
CinemaPage�����#023047$	��450��$	��800�� � 	Resources    listTemplate �� Path��%  &	        �� .R��� $��5q�$��350px��.+��� $	��300��$	��200������ $ 	PathImage��� $��20(�
�������$
��Bold"�$��Center=����� $ NameFilm�� .+��� $��16(�
�������$��Year:��$��Center=��� $��16(�
�������$��Center=����� $ DateFilm�� .+��� $��16(�
�������$��Time:��$��Center=��� $��16(�
�������$��Center=����� $ TimeFilm�� .+��� $��16(�
�������$��Price:��$��Center=��� $��16(�
�������$��Center=����� $ Price�.���� $
��Auto=�.���� .+�� ���#14213d � RowDefinitions �� $
��Auto � � ColumnDefinitions �� $��2* ��� $
��Auto ��� $
��Auto ��� $
��0.5* ��� $
��Auto ��� $
��0.5* ��� $
��Auto ��� $��1* ��� $
��0.5* ��� $
��0.5* ��� $
��0.5* ��� $
��0.5* �.+��� 
�������$��16(�$��0��$��0��$
��0 25q�.��Название:�� -    ��Name$ 	searchbox��  txtbox_search#���  $��0��$��0���� 
�������$��16(�$��1��$��0��$
��0 25q�.��	Цена:�� $
��от��$��18(�
�������$
��5 27q�$��2��$��0���� -   $ minprice��  txtbox_price#���  $��3��$��0���� $
��до��$��18(�
�������$
��5 27q�$��4��$��0���� -   $ maxprice��$��65��$��35��#���  $��5��$��0���� 
�������$��16(�$��6��$��0��$
��0 25q�.��	Дата:(  "System.Windows.Controls.DatePicker  -     Name$ datepick��$	��150��  datepicker_style#���  $��7��$��0���� -    ��Name$ btSearch��  	bt_search#���  $��
Поиск��$��8��$��0���� -   $ ProfileButton��$��70��$��50��
������ 
������ $��5q�$��9��$��0��.���� $��70��$��50��$��../Images/basket.png���� -   $ 
ExitButton��$��70��$��50��
������ 
������ $��5q�$��11��$��1��.���� $��70��$��50��$��../Images/exit.png���� -   $ ProfilButton��$��70��$��50��
������ 
������ $��5q�$��10��$��1��.���� $��70��$��50��$ ��../Images/user-profile.png���� -	   	 ��Name$	 	filmsList��#��[  $��Disabled=����#023047
������ ���� .R�� 