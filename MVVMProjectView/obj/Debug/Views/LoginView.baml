   M S B A M L   `   `   `  ����J  FMVVMProjectView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MVVMProjectView.ViewsMVVMProjectView.Views  5      E'clr-namespace:MVVMProjectView.ResourcesMVVMProjectView.Resources  5      %    MVVMProjectView.Views.LoginView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:MVVMProjectView.Views     5      =	Resources'clr-namespace:MVVMProjectView.Resources     5      .��5      � .+�5   
   � $��	54,0,54,0q�6   $	��785��6"   $	��Top=�6.   .+�5      �� $��Login��6   $
��Left=�6$   $	��Top=�6?   $��61��6W   $��36(�6c   �� 5      -   5          ��Name$  lblMessages��5      
���  ��$
��Bold"�6�   $
��Left=�6�   $��	16,80,0,0q�6�   $	��Top=�6�   $��16(�6�   ��6)   ��  �� Path$ LoginMessage� �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      -   5        $��
DelMessage��5      $
��Left=�6{   $��	16,80,0,0q�6�   $	��Top=�6�   $��14(�6�   
��� � �$
��Bold"�6�   ��6&   �� *DeleteMessage+$ PropertyChanged=�$ OneWay=�6�   �� 5      -   5        $��lblNotification��5      $
��Left=�6~   $��	16,80,0,0q�6�   $	��Top=�6�   $��14(�6�   
����  �$
��Bold"�6�   ��6+   �� *NoteMessage+$ PropertyChanged=�$ OneWay=�6�   �� 5      $��	username:��6   $
��Left=�6(   $��
15,111,0,0q�6C   $	��Top=�6W   �� 5      $
��Left=�6=   $��23��6X   $��
90,115,0,0q�6d    �� TextWrapping$
 Wrap=�6x   $	��Top=�6�   $	��120��6�   ��6   �� *
username+$ TwoWay=�6�   �� 5      $��	password:��6   $
��Left=�6(   $��
16,156,0,0q�6C   $	��Top=�6W   G� 5      -   5         G�Name$ pwBox��5      $
��Left=�6)   $��
90,159,0,0q�6D   $	��Top=�6X   $	��120��6p   $��23��6|   6�   �� 5      -   5        $��Button��5      $
��Left=�6&   $��109,199,0,0q�6A   $	��Top=�6V   $��75��6n   6y   5      5      5      