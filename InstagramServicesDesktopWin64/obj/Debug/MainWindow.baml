   M S B A M L   `   `   `  ����G  CUserControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:UserControls;assembly=UserControlsUserControls  5   	   X TInstagramServicesDesktopWin64, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:InstagramServicesDesktopWin64InstagramServicesDesktopWin64 5   	   .   (InstagramServicesDesktopWin64.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?US0clr-namespace:UserControls;assembly=UserControls     5   	   =local+clr-namespace:InstagramServicesDesktopWin64     5   	     � Title$  
MainWindow��5	   	   $	��815��6   $
��1255��6)   $	��830��66    � WindowStartupLocation$ CenterScreen=�6F   .��5
      �� .@�5   
   �� .��5      �  � ColumnDefinitions 5      �� 5      �� 5      $
��Auto �6'    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   .+�5      � $��0��6    5      �� 5      $��1* �6(   �� 5      $��1* �6(   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dgMain��5   *   $��5q�6      AutoGenerateColumns .     
IsReadOnly . $	��380��5   )      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 №��61   	   MaxWidth$	 35Q�6Z   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6<   �� *	RowNumber+6Z     5       $ 
Логин��61   
 6@   �� *Login+  5!      $ Статус��61   
 6A   �� *Status+  5"      $ Баланс��61   
 6A   �� *	Balance+  5#      $% Выполнено лайков��61   
 6K   �� *LikesRecieved+  5$      $" Выполнено подп.��61   
 6J   �� *SubscribeRecieved+  5%      $" Выполнено комм.��61   
 6J   �� *CommentsRecieved+  5&      $ Подписок��61   
 6C   �� *
Subscribes+  5'      $ Отписок��61   
 6B   �� *UnSubscribes+  5(      $ Комментарии��61   
 6F   �� *
Comments+  5)      $ Прокси��61   
 6A   �� *Proxy+  5*      $ Публикаций��61   
 6E   �� *Publications+  5+      $ Подписчиков��61   
 6F   �� *CurrentSubscribers+  5,      $ Аватар��61   
 6A   �� *Photo+  5-      $" Коэфф. качества��61   
 6J   �� *
Accuracy+5/      �� 50      $��1��6   $��0��6*   $��2q�6:   
�������$	��330��6a   $��	5,-38,0,5q�6q   ._�51      �� -   5         ��Name$ tbLogs��51   $   
�������$	��330��6L   $��0,0,0,0q�6\   52      53      �� 54      $��1��6   $��0��6-   .+�55      �� $��Управление��6   $��5q�63   .��56      �� $��5q�6%   .+�57      �� $��Запустить Like4u��6%   $��5q�6@   6N   �� 58      $!��Остановить Like4u��6%   $��5q�6A   6N   �� 59      $'��!Запустить отписку��6%   $��5q�6A   6N   �� 5:      $)��#Остановить отписку��6%   $��5q�6B   6O   �� 5;      $'��!Проверка аккаунта��6%   $��5q�6A   6N   �� 5<      -   5        $��Настройки��5<   %   $��5q�69   6\   �� 5=      $!��Выгрузить базу��6%   $��5q�6>   6K   �� 5>      -   5        $��Постинг��5>   %   $��5q�67   6Y   �� 5?      $(��"Открыть в браузере��6%   $��5q�6B   6O   5@      5A      �� 5B      $��5q�6!   .+�5C      �� $*��$Задержка в секундах��6#   .��5D      �� $��5q�6)   .+�5E   "   ��  �� Orientation$ 
Horizontal=�6-   $��5q�6F   .+�5F   &   �� $
��От��6,   6;       UserControls.NumericUpDown  5G   &   69   5H   #   �� 5I   "   $ 
Horizontal=�6-   $��5q�6F   .+�5J   &   �� $
��До��6,   6;     5K   &   69   5L   #   5M      5N      �� 5O      .��5P      �� .+�5Q   "   �� $��Общий баланс: ��6(   6C   �� 5R   "   $��В работе: ��6(   6?   �� 5S   "   $��Выделено: ��6(   6?   �� 5T   "   $��Всего лайков: ��6(   6C   �� 5U   "   $#��Всего подписок: ��6(   6E   �� 5V   "   $)��#Всего комментариев��6(   6G   5W      5X      �� 5Y      .��5Z      �� .+�5[   "   �� $ 
Horizontal=�6-   $��5q�6F   .+�5\   &   �� $��Смс: ��6,   6>     5]   &   $��11, 0, 0, 0q�67   6N   5^   #   �� 5_   "   $ 
Horizontal=�6-   $��5q�6F   .+�5`   &   �� $��Капча: ��6,   6@     5a   &   69   5b   #   5c      5d      �� 5e      .��5f      �� $��5q�6)   .+�5g   "   �� $)��#Загрузить аккаунты��6)   $��5q�6F   6S   �� 5h   "   $��Очистить лог��6)   $��5q�6@   6M   �� 5i   "   $*��$Сбросить все задачи��6)   $��5q�6G   6T   5j      5k      5l      5m      5n      5o      �� 5p   
   $#��Инстаграмм тест��6   .��5q      �� .+�5r      �� -   5         ��Name$ labelLog��5r   1   $��В залогинены: ��6   6E   �� 5s      $ 
Horizontal=�6   .+�5t      	� -   5         	�Name$ 	rbAndroid��5t   "   $��Android��65   	� 5u      -   5        $ 	rbBrowser��5u   "   $��Browser��65   5v      �� 5w      -   5         ��Name$ tbUsers��5w   [   $��23��6   $3��-Пyть к файлу с аккаунтами��6&    �� TextWrapping$
 Wrap=�6G   $��
5, 5, 5, 0q�6l   �� 5x      -	   5        $ tbProxy��5x   W   $��23��6   $,��&Путь к файлу с прокси��6&   $
 Wrap=�6C   $��
5, 0, 5, 0q�6h   �� 5y      -
   5        $��Start��5y      $��5, 0, 5, 10q�67   �� 5z      -   5        $ tbLike��5z   N   $��23��6   $
 Wrap=�6&   $��
5, 0, 5, 0q�6:   6N   �� 5{      -   5        $
��Like��5{      $��5, 0, 5, 10q�6;   �� 5|      -   5        $ 	tbComment��5|   N   $��23��6   $
 Wrap=�6&   $��
5, 0, 5, 0q�6:   6N   �� 5}      -   5        $��Comment��5}      $��5, 0, 5, 10q�6A   �� 5~      -   5        $ tbSubscribe��5~   N   $��23��6   $
 Wrap=�6&   $��
5, 0, 5, 0q�6:   6N   �� 5      -   5        $��	Subscribe��5      $��5, 0, 5, 10q�6E   5�      5�      5�      5�      