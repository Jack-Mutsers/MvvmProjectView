   M S B A M L   `   `   `  ����J  FMVVMProjectView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MVVMProjectView.ViewsMVVMProjectView.Views  5      #    MVVMProjectView.Views.NewUser   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:MVVMProjectView.Views     5      .��5	      � .+�5
   
   � $��	54,0,54,0q�6   $	��785��6"   $	��Top=�6.   .+�5      �� $��Add new user��6   $
��Left=�6+   $	��Top=�6F   $��61��6^   $��36(�6j   �� 5      $��	Username:��6   $
��Left=�6(   $��	48,80,0,0q�6C   $	��Top=�6V   �� 5      -   5          ��Name$  tbBox��5      $
��Left=�6L   $��23��6g   $��
119,83,0,0q�6s    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6%   �� *
username+ �� Mode$ TwoWay=�6�   �� 5      $��	Password:��6   $
��Left=�6(   $��
52,123,0,0q�6C   $	��Top=�6W   G� 5      -   5         G�Name$ pwBox��5      $
��Left=�6W   $��119,126,0,0q�6r   $	��Top=�6�   $	��120��6�   $��23��6�   �� 5      -   5        $��Create��5      $
��Left=�6&   $	��Top=�6A   $��75��6Y   $��137,167,0,0q�6d   6y   �� 5      -   5        $��	UserError��5      $
��Left=�6y   $��261,126,0,0q�6�   $	��Top=�6�   $��12(�6�   
���  ��$
��Bold"�6�   ��6%   �� *NewUserError+ �� UpdateSourceTrigger$ PropertyChanged=�$ OneWay=�6�   �� 5      -   5        $��UserMessage��5      $
��Left=�6}   $��261,126,0,0q�6�   $	��Top=�6�   $��12(�6�   
��� � �$
��Bold"�6�   ��6'   �� *NewUserMessage+$ PropertyChanged=�$ OneWay=�6�   5      5      5      