   M S B A M L   `   `   `  ����D  @IrcClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:IrcClient	IrcClient  5   	   1clr-namespace:IrcClient.ViewsIrcClient.Views  5   	       IrcClient.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:IrcClient     5   	   /viewsclr-namespace:IrcClient.Views     5   	     � Title$  
Irc Client��5	   	   $	��420��6   $	��700��6)   .��5
      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $��5* �6   6+   �� 5      $
��auto �6   6,    � ColumnDefinitions 5   
   �� 5      $��1* �6   6,   �� 5      $��5* �6   6,   .+�5   
   �� $��0��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $��Right=�6K   $	��Top=�6g   .+�5      �� $	��100��6   ��6"   �� *ChannelName+6A   �� 5      $��Connect Channel��64   ��6   �� *
AddChannel+6Q   �� 5      $��Connect��6   ��6'   �� *ConnectCommand+6L   5      �� 5   
   $��1��6   $��0��6   ��6/   �� *ChannelsList+ �� SelectedItem 6T   �� *ChannelName+ �� Mode$ OneWayToSource=���5      �� 5      .R�5      �� 
���������6    ��  J� InputBindings 5      d� 5       d� MouseAction$ LeftDoubleClicke�6�    �� Command 6+   �� *DataContext.AddChannel+	 �� RelativeSource	 �� 
 �� Mode$
 FindAncestor=� �� AncestorType" �6�   5       5!      5#      $   IrcClient.Views.MessageBoxView  5$   
   $��1��6   $��1��6,   6>   � 5%   
   $��2��6   $��1��6   .+�5&      �� $��Stretch=�6   ��63   �� *MessageInput+.��6R    5'      �� 5(      
 �� Key$ Return��6A    6!   �� *SendMessage+6P   .��5)   )   5*      �� 5+      $��Отправить��6   $��Right=�6K   ��6+   �� *SendMessage+6K   5,      5-      5.      