   M S B A M L   `   `   `  ����@  <Laba4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Laba4Laba4  5   	       Laba4.ProdPage   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Laba4     5   	   !ucLaba4.UserControl1     5   )   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  6G     � Cursor$g  aC:\\Users\\KROU4\\YandexDisk\\Уник\\ООП Панченко\\Лаба 4-7\\Fonts\\UpArrow.cur��5   ,   $	��550��5       � Title$ 
TicketsPro��5   	    � WindowState$ 	Maximized=�6    � Icon$z tC:\\Users\\KROU4\\YandexDisk\\Уник\\ООП Панченко\\Лаба 4-7\\Fonts\\tickets-ticket-svgrepo-com.png��64    � 	Resources 5	         Laba4.MinValueConverter   MinValueConverter   Laba4.MaxValueConverter  MaxValueConverter  OrangeTextBoxStyle �� 
TargetType �� Property �� Value  ForegroundColor��%�   &	        &	      &	 &       5   
   6"     5   
   6"   �� 5   
   " ��6+   .�5      ��  � ��$ 28(�6)   �� 5       � ��# �  6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$
 Wrap=�6-   5      5      .��5      �� .��5   
   � $��	20 0 60 0q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� -   5        	 ��Name$	 infoStackPanel��5   )   $��0��6   
 �� Orientation$
 Vertical=�6A   .+�5      �� -   5         ��Name$ 
backButton��5   q   $h��bC:\Users\KROU4\YandexDisk\Уник\ООП Панченко\Лаба 4-7\Photo\back-svgrepo-com.png��6   $��50��6�   $��50��6�   $	��Top=�6�   $
��Left=�6�   �� 5!      -   5         ��Name$ mainName��5!      #��[ 6`   ��6.   �� *Name+ �� StringFormat$ Спектакль {0}��6`   � 5#       � Orientation$ 
Horizontal=�6   .+�5$      �� $
 
Horizontal=�6!   .+�5%      �� $q��kC:\Users\KROU4\YandexDisk\Уник\ООП Панченко\Лаба 4-7\Photo\calendar-days-svgrepo-com.png��6    $��37��6�   $��45��6�   $
��Left=�6�   �� 5&      $��18(�6W   $
��Bold"�6e   $��Center=�6w   $��5 0 5 0q�6�   ��6$   �� *
dateTime+$ 
dd.MM.yyyy��6�   �� 5'      $��18(�6:   $
��Bold"�6H   $��Center=�6Z   $��5 0 5 0q�6u   ��6$   �� *Time+6u   5(      �� 5)      $
 
Horizontal=�6!   .+�5*      �� $p��jC:\Users\KROU4\YandexDisk\Уник\ООП Панченко\Лаба 4-7\Photo\location-pin-svgrepo-com.png��6    $��37��6�   $��45��6�   $
��Left=�6�   �� 5+      $
��Bold"�6>   $��18(�6Q   $��Center=�6_   $��5 0 10 0q�6z   ��6$   �� *
Location+6z   5,      �� 5-      $
 
Horizontal=�6!   .+�5.      �� $k��eC:\Users\KROU4\YandexDisk\Уник\ООП Панченко\Лаба 4-7\Photo\tickets-svgrepo-com.png��6    $��37��6|   $��45��6�   $
��Left=�6�   �� 5/      $��18(�6j   $
��Left=�6x   $��Center=�6�   $��5 0 5 0q�6�   $
��Bold"�6�   ��6$   �� *Price+ �� 	Converter# [  6�   �� 50      $��18(�6j   $
��Left=�6x   $��Center=�6�   $
��Bold"�6�   ��6$   �� *Price+# [ 6�   51      52      �� 54      $��18(�6:   $
��Left=�6H   $��0,10,0,0q�6c   $
��Wrap=�6u    �� TextAlignment$ Justify=�6�   ��6   �� *Description+6�   �� 55      $��0 10 0 0q�6_   $��18(�6r   ��6   �� *TicketCount+$* $Билетов осталось: {0}��6r   �� 56      $��0 10 0 0q�6U   $��18(�6h   ��6   �� *
Category+$ Категория: {0}��6h   �� 58      #��[ 6     String47#���  6H   � 59      -   5         �Name$ wraForImages��59      5:      �� 5;      #��[ 6     String49#���  6H      Laba4.UserControl1  5<         Laba4.UserControl1   CommentSubmitted$% CommentControl_CommentSubmitted��6%   5>      �� 5@      -   5        $	 	mainPanel��5@   )   $��1��6   $
 Vertical=�6<   .+�5B      �� -   5        $ 	mainImage��5B      $��Right=�6L   $	��450��6h   $
��Auto��6t   $��60,0,0,0q�6�   ��6+   �� *ImageFilePath+6�   5C      5D      5E      5G      