   M S B A M L   `   `   `  ����C  ?PollSber, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PollSber.ViewsPollSber.Views  5      9!clr-namespace:PollSber.ConvertersPollSber.Converters  5          PollSber.Views.ResultView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:PollSber.Views     5      8
converters!clr-namespace:PollSber.Converters     5         SUserControl#��[  5
        � 	Resources  5      3   -PollSber.Converters.BoolToVisibilityConverter  BoolToVisibilityConverter��%   &	         5   
   6/   5      .��5      (�  (� Stretch$ Uniform=�6   .��5   
   � -   5         �Name$ MainGrid��5      $
��1920��6!   $
��1080��6/   
������ .+�5      �� $"��/Assets/Images/ImageLogo.png��6   $��33��6:   $��60q�6F   $
��Left=�6R   $	��Top=�6m   �� 5      $
��Auto��6   $��Center=�6'   $	��796��6B   .+�5      �� $��0 0 0 72q�6   .+�5      ��   TextTitleBig#��[ 6    $	��170��5       $��0 0 0 40q�5       ��5       �� *Result.Title+5       �� 5      $��0 0 0 40q�6!   .+�5      ��   TextBodyMedium#��[ 6$   $��0 0 0 16q�5   $   ��5   $   �� *Result.Text1+5   $   �� 5      #��[ 6$   ��5   $   �� *Result.Text2+5       �� 5!      .+�5"      �� #��[ 6$   $��0 0 0 32q�5$   $   ��5#   $   �� *Result.Text3+5$   $   �� 5%      .+�5&      ��   TextTitleMedium#��[ 6(   $��0 0 0 16q�5(   (   ��5'   (   �� *Result.Text4+5(   (   �� 5)        TextBodySmall#��[ 6(   ��5*   (   �� *Result.Text5+5+      �� 5,      $
��0 24q�6%   .+�5-      �� #��[ 6(   $��0 0 0 16q�5/   (   ��5.   (   �� *Result.Text6+5/   (   �� 50      #��[ 6(   ��51   (   �� *Result.Text7+52      �� 53      .+�54      �� #��[ 6(   $��0 0 0 16q�56   (   ��55   (   �� *Result.Text8+56   (   �� 57      #��[ 6(   ��58   (   �� *Result.Text9+59      5:      5;      �� 5<      .+�5=      �� #��[ 6      ResultViewMessageOn#��[ 5>       $	��674��5?       $
��Left=�6,   �� 5@      $
��0 32q�6!   .+�5A      ��   InputEmailStyle#��[ 6"   ��5B   "   �� *	UserEmail+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5C       �� Orientation$ 
Horizontal=�6%   $��50��6>   $��0 16 0 0q�6J   .+�5D      ��   CheckBoxStyle#��[ 6'   $��32��5E   '   $��32��62   $
��Left=�5F   '   $	��Top=�5G   '   $��0 0 16 0q�5H   '    d� 	IsChecked 5I   '   �� *
IsAgreed+$ TwoWay=��� 5J      #��[ 6(   $	��625��6O   Я ознакомлен с �� 5L   "    	 HyperlinkStyle#��[	 6,    �� Command 6T   �� *OpenPrivacyPolicyCommand+.�6�   53Политикой СберУниверситета6�   #! и даю согласие на �� 5N   "   #��[	 6,    6T   �� *OpenPersonalDataCommand+.�6�   :8обработку персональных данных6�   5O      5P      5Q      �� 5R      $ 
Horizontal=�6!   $��Center=�6:   $
��0 32q�6W   .+�5S      ��  
 
ButtonBack#��[
 6!   $	��382��5T   !   $��94��6-     ResultViewButtonComplete#��[ 5U   !   $��24(�5V   !     
SBSansText#��[ 6/   $��0 0 32 0q�5W   !   ��5X   !   �� *FinishCommand+�� 5Y        ButtonAccept#��[ 6!   $	��382��5Z   !   $��94��6-     ResultViewButtonTakeResult#��[ 5[   !   $��24(�5\   !   #��[ 6/   ��5]   !   �� *SendEmailCommand+5^      5_      5`      �� 5c      ���	#80000000 K� ZIndex$ 10��5e      y�5d      �� *IsAnyPopupOpen+	 �� 	Converter#	 [ 5e      � 5h      $��Center=�5i      
 � 	StaysOpen$
 False��5k       � AllowsTransparency$
 True��5l      ��5h      �� *IsPrivacyPolicyPopupOpen+ � PlacementTarget 5j      ��  �� ElementName$ MainGrid��.��5m      '   !PollSber.Views.PopupPrivacePolicy   � DataContext 6+   �� 5n      � 5p      $��Center=�5q      $
 False��5s      $
 True��5t      ��5p      �� *IsPersonalDataPopupOpen+ 5r      �� $ MainGrid��.��5u      &    PollSber.Views.PopupPersonalData   6*   �� 5v      � 5x      $��Center=�5y      $
 False��5{      $
 True��5|      ��5x      �� *IsEmailErrorPopupOpen+ 5z      �� $ MainGrid��.��5}      $   PollSber.Views.PopupEmailError   6(   �� 5~      5      5�      5�      