   M S B A M L   `   `   `  ����J  FMVVMProjectView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MVVMProjectView.ViewsMVVMProjectView.Views  5      -    'MVVMProjectView.Views.NewComponentsView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:MVVMProjectView.Views     5      .��5	      � .+�5
   
   � $
��62,0q�6   $	��785��6   $	��Top=�6)   $	��251��6A   .+�5      �� -   5        $��lblTitle��5      $
��Left=�6}   $	��Top=�6�   $	��372��6�   $��36(�6�   ��6$   �� *newComponentHeader+  �� UpdateSourceTrigger$  PropertyChanged=� �� Mode$ TwoWay=�6�   �� 5      $��Component name:��6   $
��Left=�6.   $��
27,110,0,0q�6I   $	��Top=�6]   �� 5      -   5         ��Name$ 	tbNewComp��5      $
��Left=�6{   $��23��6�   $��143,110,0,0q�6�   $	��Top=�6�   $	��150��6�   ��6)   �� *component.name+$  PropertyChanged=�$ TwoWay=�6�   �� 5      $��
categorie:��6   $
��Left=�6)   $��
73,145,0,0q�6D   $	��Top=�6X   �� 5      -   5         ��Name$ 
cbCategory��5       �� DisplayMemberPath$
 name��6+   $��26��6D   $	��150��6P   $��143,145,492,80q�6\   �� 5      -   5        $��btnSet��5      $
��Left=�6z   $��143,221,0,0q�6�   $	��Top=�6�   $��75��6�   ��6#   �� *updateCreateName+$  PropertyChanged=�$ TwoWay=�6�   �� 5      -   5        $��btnDel��5      $��Delete��6�   $
��Left=�6�   $��233,221,0,0q�6�   $	��Top=�6�   $��75��6�   y�6#   �� *deleteButtonVisibility+$  PropertyChanged=�$ TwoWay=�6�   �� 5      -   5        $��	CompError��5      $
��Left=�6y   $��
143,76,0,0q�6�   $	��Top=�6�   $��12(�6�   
���  ��$
��Bold"�6�   ��6%   �� *NewCompError+$  PropertyChanged=�$ OneWay=�6�   �� 5      -   5        $��CompMessage��5      $
��Left=�6}   $��
143,76,0,0q�6�   $	��Top=�6�   $��12(�6�   
��� � �$
��Bold"�6�   ��6'   �� *NewCompMessage+$  PropertyChanged=�$ OneWay=�6�   �� 5      $��Arduino IP Adress:��6   $
��Left=�61   $��
27,184,0,0q�6L   $	��Top=�6`   �� 5      -   5        $ tbNewCompIp��5      $
��Left=�6�   $��23��6�   $��143,184,0,0q�6�   $	��Top=�6�   $	��150��6�   ��6+   �� *component.ip_adress+$  PropertyChanged=�$ TwoWay=�6�   5      5      5      