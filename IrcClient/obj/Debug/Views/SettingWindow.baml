   M S B A M L   `   `   `  ����D  @IrcClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:IrcClient.ViewsIrcClient.Views  5   	   #    IrcClient.Views.SettingWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:IrcClient.Views     5   	     � Title$  Настройки��5   	   $	��150��6   $	��300��6(   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,   .+�5   
   �� $��Настройки��6   $��Center=�6%   $��Center=�6B   $��15(�6]   6m   � 5   
   $��1��6   $��Center=�6    5      �� 5      $
��auto �6    60   �� 5      $
��auto �6    61   �� 5      $
��auto �6    60    � ColumnDefinitions 5      �� 5      6%   �� 5      6%   .+�5      �� $��0��6   $��0��6!   $��Имя сервера��61   $��Center=�6G   6f   �� 5      $��0��6   $��1��6%   $*��$Введите имя сервера��65   $��Center=�6P   6p   �� 5      $��1��6   $��Порт��6!   $��Center=�60   6O   �� 5      $��1��6   $��1��6%   $�� Введите порт��65   $��Center=�6J   6k   �� 5      $��2��6   $��0��6!   $��Никнейм��61   $��Center=�6C   6b   �� 5      $��2��6   $��1��6%   $#��Введите никнейм��65   $��Center=�6M   6m   5       �� 5!   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5"      �� $��Сохранить ��6   $
��Left=�6*   $
��Auto��6E   6V   �� 5#      $��Отмета ��6   $��Right=�6'   6E   5$      5%      5&      