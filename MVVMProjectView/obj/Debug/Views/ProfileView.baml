   M S B A M L   `   `   `  ����J  FMVVMProjectView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MVVMProjectViewMVVMProjectView  5      #    MVVMProjectView.Views.Profile   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9mvvmprojectviewclr-namespace:MVVMProjectView     5      $	��910��5   #   .��5	      � .+�5
   
   � $��	54,0,54,0q�6   $	��785��6"   $	��Top=�6.   .+�5      �� $��Account management��6   $
��Left=�61   $	��Top=�6M   $	��372��6e   $��36(�6q   �� 5      $��Change password��6   $
��Left=�6.   $��	48,74,0,0q�6I   $	��Top=�6\   $��22(�6t   $
��Bold"�6�   �� 5      $��new password:��6   $
��Left=�6,   $��
34,118,0,0q�6G   $	��Top=�6[   G� 5      -   5        $��
tbPassword��5      $
��Left=�6P   $��23��6k   $��127,121,0,0q�6w   $	��Top=�6�   $	��120��6�   �� 5      $��repeat password:��6   $
��Left=�6/   $��
22,156,0,0q�6J   $	��Top=�6^   G� 5      -   5        $��tbPasswordConf��5      $
��Left=�6`   $��23��6{   $��127,159,0,0q�6�   $	��Top=�6�   $	��120��6�   6�   �� 5      -   5        $��lblError��5      $
��Left=�6w   $��262,156,0,0q�6�   $	��Top=�6�   $��14(�6�   
���  ��$
��Bold"�6�   ��6$   �� *UpdateError+  �� UpdateSourceTrigger$  PropertyChanged=� �� Mode$ OneWay=�6�   �� 5      -   5        $��
lblMessage��5      $
��Left=�6{   $��262,156,0,0q�6�   $	��Top=�6�   $��14(�6�   
��� � �$
��Bold"�6�   ��6&   �� *UpdateMessage+$  PropertyChanged=�$ OneWay=�6�   '   !MVVMProjectView.PasswordValidator  5         Box1 5      ��  �� ElementName$ 
tbPassword��   Box2 5      �� $ tbPasswordConf���� 5      -   5        $��update��5      $
��Left=�6&   $��
76,200,0,0q�6A   $	��Top=�6U   $	��103��6m   $��28��6y   6�   �� 5      $��Remove Account��6   $
��Left=�6-   $��
48,250,0,0q�6H   $	��Top=�6\   $��22(�6t   $
��Bold"�6�   �� 5      $+��%Note: admin account cannot be deleted��6   $
��Left=�6E   $��
46,284,0,0q�6`   $	��Top=�6t   
����  �$
��Bold"�6�   $��10(�6�   �� 5       -   5        $��delete account��5       $
��Left=�6.   $��
62,316,0,0q�6I   $	��Top=�6]   $	��143��6u   $��34��6�   6�   �� 5!      -   5        $��DelError��5!      $
��Left=�6w   $��
62,345,0,0q�6�   $	��Top=�6�   $��14(�6�   
���  ��$
��Bold"�6�   ��6$   �� *DeleteError+$  PropertyChanged=�$ OneWay=�6�   5"      5#      5$      