   M S B A M L   `   `   `  ����@  <Laba4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Laba4Laba4  5          Laba4.UserControl3   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:Laba4     5        � 	Resources  5	         HoverButtonStyle �� 
TargetType �� Property �� Value  ForegroundColor  BackgroundColor  String46��%�  &	        �� 5
   
   " ��6)   .�5      ��  � ��$ 40��6'   �� 5       � ��$	 300��6&   �� 5       � ��# �  6+   �� 5       � ��# �  6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ Center=�64   �� 5       � ��# �  6(   �� 5       � ��$ 60,0,0,0q�6'   �� 5       � �� �#DD571C6,   �� 5       � ��$ 16(�6)   5      5      .��5      � .+�5   
   �� -   5         ��Name$ NumberTextBox��5      $
��Left=�6)   $	��Top=�6D   $��52��6\   $��
416,10,0,0q�6g   $��26��6{   ��5   
   �� *CurrentTicketsAmount+ �� RelativeSource ��  �� AncestorType UserControl �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   	 �� Orientation$	 
Horizontal=�6   $
��Left=�6.   $	��Top=�6I   $��20��6a   $��83��6m   $��
486,13,0,0q�6x   .+�5      �� -   5        
 ��Name$
 ticket_amount_up_btn��5      $��+��63   $��30��6?   �� 5      -   5        $
 ticket_amount_down_btn��5      $��-��65   $��30��6A   $��20,0,0,0q�6L   5      �� 5   
   $��0��6   $��Center=�6%   $��267,60,0,319q�6@   .+�5       �� -   5        $
 
mainButton��5       #��[  6*   $	��300��6T   $
��Left=�6`   .��5!      �� $&�� ПЕРЕЙТИ К КОРЗИНЕ��6   $
��Wrap=�65   $	��175��6I   ��6U   Z� 5"      5#      �� 5$   
   $
��Left=�6   $��
280,15,0,0q�6/   $
��Wrap=�6C   $)��#Количество билетов��6W   $	��Top=�6q   
���   �6�   �� 5%   
   -   5        $ eventTextBox��5%      $
��Left=�6(   $��326,138,0,0q�6C    �� TextWrapping$
 Wrap=�6X   $	��Top=�6l   $	��300��6�   $	��144��6�   ��6�   Z�  �� SelectionBrush 6�   Z�  �� SelectionTextBrush 6�   Z� ��6�   Z� 6�   5&      5'      