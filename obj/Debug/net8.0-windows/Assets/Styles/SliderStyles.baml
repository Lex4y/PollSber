   M S B A M L   `   `   `  ����C  ?PollSber, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PollSber.ConvertersPollSber.Converters  5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891    +PollSber.Converters.SliderProgressConverter   SliderProgressConverter  SliderThumbStyle  �� 
TargetType �� Property �� Value �� 
TargetType �� BitmapScalingMode  CustomSliderTemplate ��Name �� RadiusX �� RadiusY `� 	Converter	 �� Path
 �� RelativeSource ]� Thumb �� Triggers P� Property P� Value �� 
TargetName  SliderPollStyle�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      +local!clr-namespace:PollSber.Converters  5      %�  &	        &	      &	 1    7   7  &	 t    7     5      6$   �� 5      "  n�6%   .�5   
   ��  � ��$ -10 -4 -10 0q�6#   �� 5   
    � �� 5	      �� 5
      " n�6"   .R�5      �� $)��#/Assets/Images/ImagePointSlider.png��6   $��70��5      $��70��5      $ HighQuality=�5      5      5      5      �� 5      " ��63   .R�5   
   � .+�5      �� $ TrackBackground��6   $��32��5      ���	#40FFFFFF$��Center=�5      $ 16��5      $ 16��6$   �� 5      $��ProgressBar��6   $��32��5      ���#FFFFFF$��Center=�5      $
��Left=�5      $ 16��5       $ 16��6$   ��5!      `� 5"      8   .1�5#      �� $	 Value�6T   
 6"   �� *TemplatedParent+6T   �� 5$      $	 Maximum�6T   
 6"   �� *TemplatedParent+6T   �� 5%      $	 ActualWidth�6T   
 6"   �� *TemplatedParent+6T   5&      5(      ]� 5)      $��
PART_Track��6    5*      n� 5+      8�� 6   5-      5.       5/   
   P� 50       �@J�IsMouseOver$
 True��6-   . �51      �� $ TrackBackground��6    � �� �	#60FFFFFF6F   52      54      �� 56      "  ��6$   .�57   
   ��  � ��8   6%   �� 58   
    � ��$	 880��6"   �� 59   
    � ��$ 51��6#   �� 5:   
    �@�Minimum$ 0Q�6$   �� 5;   
    �@�Maximum$ 2Q�6$   �� 5<   
    �@��TickFrequency$ 1Q�6*   �� 5=   
    �@��IsSnapToTickEnabled$
 True��60   5>      5?      