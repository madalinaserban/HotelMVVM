   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfApp1.ViewWpfApp1.View  5   	   7 clr-namespace:WpfApp1.ViewModelsWpfApp1.ViewModels  5   	       WpfApp1.View.WithAccount   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WpfApp1.View     5   	   0ctx clr-namespace:WpfApp1.ViewModels     5   	   $	��650��5      $	��450��6'     � WindowStartupLocation$  CenterScreen=�63    � DataContext 5	      -  'WpfApp1.ViewModels.WithAccountViewModel  5
   
    � 	Resources 5         RoundedBorder �� 
TargetType �� Property �� Value  RoundedButtonStyle �� 
TargetType �� CornerRadius ��Name	 �� Triggers
 P� Property P� Value��%�  &	        &	 T     7   �� 5   
   " ��6&   .�5      ��  �@��CornerRadius$ 5��6-   5      �� 5   
   " ��6+   .�5      ��  � ��
 �����6+   �� 5       � ��
 �   �6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 10,10,10,10��6!   #��z��6<   8��  ._�5      �� $ contentPresenter��6/   #��z��6I   #��z��6}   #��z��6�   #��z��6�   #��z��6	  5      5      5      	 5      P� 5      
 �@J�IsMouseOver . . �5      ��  � ��
 ��ح�63   �� 5       � ��
 �   �63   5       P� 5!      
 � {� .  . �5"      ��  � ��
 ��ح�63   �� 5#       � ��
 �   �63   5$      5&      5'      ��5(      �� 5)   
    �� ImageSource$ 6.jpg��6   .��5+      �  � RowDefinitions 5,   
   �� 5-      $	��97* �6   �� 5.      $��56 �6   .+�50   
   �� $��0��6    �� Orientation$ Vertical=�6"   $��0,0,0.333,55.667q�69   $��2��6S   .+�51      �� #��[ 6   $��35��6A   $��10,100,10,0q�6M   $��Gaseste-ti vacanta��6b   $��Sitka Display)�52      $��25(�60   ��6>   �� *SeeMenuCommand+�� 53      #��[ 6   $��35��6A   $��
10,50,10,0q�6M   $��Rezervari active��6a   $��Sitka Display)�54      $��25(�61   �� 55      #��[ 6   $��35��6A   $��
10,50,10,0q�6M   $��Istoric rezervari��6a   $��Sitka Display)�56      $��25(�60   58      �� 59   
   $��1��6   $��0��6   $��70��6.   $
��Left=�69   $��10,9.333,0,12.667q�6T   #��[ 5:      $��20(�6=   ��6K   �� *BackCommand+.��5;      �� $��  Back��6   $��25(�6&   $��Sitka Display)�64   $��80��6O   $��48��6Z   5<      5=      5>      