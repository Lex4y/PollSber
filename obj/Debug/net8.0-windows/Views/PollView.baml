   M S B A M L   `   `   `  ����C  ?PollSber, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PollSber.ViewsPollSber.Views  5          PollSber.Views.PollView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:PollSber.Views     5         SUserControl#��[  5	      .��5
      (�   (� Stretch$  Uniform=�6   .��5   
   � $
��1920��6   $
��1080��6   .+�5      �� $"��/Assets/Images/ImageLogo.png��6   $��33��6:   $��60q�6F   $
��Left=�6R   $	��Top=�6m   �� 5        ButtonBackSmall#��[ 6     
SBSansText#��[ 5      $��24(�5      $	��223��5      $��62��5      $��
Назад��5      $��60q�5      $��Right=�5      $	��Top=�5      ��5      �� *BackCommand+�� 5      $	��960��6   $
��1644��6%   .+�5      ��   TextTitleBig#��[ 6   $
��Left=�5        	PollTitle#��[ 5      �� 5      $	��960��6   $	��166��6)   $
��0 42q�66   .+�5      ��   TextBodyMedium#��[ 6      PollTextPart1#��[ 5   !   $��0 0 0 16q�5   !   �� 5       #��[ 6      PollTextPart2#��[ 5!   !   5"      �� 5$      $	��960��6   $
��1158��6%   ���	#20FFFFFF$��0 0 0 42q�6J    �� Padding$ 40q�6\    �� CornerRadius$ 36��6i   ._�5%      �� ��6#   �� *	Questions+��5&      �� 5'      .R�5(   "   �� $��0,0,0,72q�6-   .+�5)   &   ��   TextTitleSmall#��[ 60   ��5*   0   �� *QuestionText+�� 5,   &    	 SliderPollStyle#��[	 5-   )   $��0 24 0 8q�5.   )    � Value 5,   -   �� *CurrentValue+ �� Mode$ TwoWay=� � Minimum 5/   )   �� *
MinValue+ � Maximum 50   )   �� *
MaxValue+� 53   &    � ColumnDefinitions 54   *   �� 55   .   $��* �6?   �� 57   .   $��* �6?   �� 59   .   $��* �6?   .+�5>   *   �� $��0��64    
 TextBodySmall#��[
 5?   5   $
��Left=�5@   5    �� TextAlignment$
 Left=�5A   5   $��CharacterEllipsis=�5C   5   $	��308��5D   5   ��5B   5   �� *ValueTexts[0]+5D   5   �� 5G   *   $��1��64   #��[
 5H   5   $��Center=�5I   5   $ Center=�5J   4   $��CharacterEllipsis=�5L   5   $	��308��5M   5   ��5K   5   �� *ValueTexts[1]+5M   5   �� 5P   *   $��2��64   #��[
 5Q   1   $��Right=�5R   1   $ Right=�5S   1   $��CharacterEllipsis=�5U   1   $	��308��5V   1   ��5T   1   �� *ValueTexts[2]+5V   1   5W   '   5X   #   5Y      5[      5\      �� 5]        ButtonAccept#��[ 6   $	��445��5^      $	��109��5_      $
��Left=�5`        PollButtonNext#��[ 5a      #��[ 5b      ��5c      �� *NextCommand+5d      5e      5f      5g      