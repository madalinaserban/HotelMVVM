   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfApp1.ViewWpfApp1.View  5   	   7 clr-namespace:WpfApp1.ViewModelsWpfApp1.ViewModels  5   	        WpfApp1.View.NotLoggedView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WpfApp1.View     5   	   0ctx clr-namespace:WpfApp1.ViewModels     5   	   $	��650��5      $	��500��6'     � WindowStartupLocation$  CenterScreen=�63    � DataContext 5	      -  'WpfApp1.ViewModels.NotLoggedInViewModel  5
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
    �� ImageSource$ 6.jpg��6   .��5+      �  � ColumnDefinitions 5,   
   �� 5-      $��5* �6   �� 5.      $	��24* �6    � RowDefinitions 50   
   �� 51      $
��102* �6   �� 52      $
��317* �6   �� 53      $��50 �6   .+�55   
   �� $��1��6   #��[ 6   $��Gaseste-ti
  vacanta��56      $ ��35,152.333,123.333,121.667q�65   $��38(�6Y   $��Sitka Display)�6g   $��Center=�6�   $��Center=�57      $��1��6P   ��63   �� *
ViewMenu+59      �� 5:   
   $��0��6   $��2��6!   $��60��6.   $
��Left=�69   $��10,2.333,0,4.667q�6T   #��[ 5;      $��20(�6=   ��6K   �� *BackCommand+.��5<      �� $
��Back��6   $��Sitka Display)�6$   6A   5=      5>      5?      