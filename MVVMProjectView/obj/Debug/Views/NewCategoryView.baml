   M S B A M L   `   `   `  ����J  FMVVMProjectView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MVVMProjectView.ViewsMVVMProjectView.Views  5      +    %MVVMProjectView.Views.NewCategoryView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:MVVMProjectView.Views     5      .��5	      � .+�5
   
   � $��	54,0,54,0q�6   $	��785��6"   $	��Top=�6.   .+�5      �� -   5        $��lblTitle��5      $
��Left=�6|   $	��Top=�6�   $	��372��6�   $��36(�6�   ��6$   �� *newCategoryHeader+  �� UpdateSourceTrigger$  PropertyChanged=� �� Mode$ TwoWay=�6�   �� 5      $��Category name:��6   $
��Left=�6-   $��
45,110,0,0q�6H   $	��Top=�6\   �� 5      -   5         ��Name$ tbNewCat��5      $
��Left=�6y   $��23��6�   $��143,110,0,0q�6�   $	��Top=�6�   $	��150��6�   ��6(   �� *category.name+$  PropertyChanged=�$ TwoWay=�6�   �� 5      $��Category Icon:��6   $
��Left=�6-   $��
45,145,0,0q�6H   $	��Top=�6\   �� 5      -   5        $��upload��5      $��40��6&   $��60��62   $��143,138,582,40q�6=   6U   �� 5      -   5         ��Name$ imgIcon��5      $��50��6%   $��50��60   $
��Left=�6<   $	��Top=�6W   $��235,138,0,0q�6�   ��6o   �� *ConvertedImage+$ TwoWay=�$  PropertyChanged=�6�   �� 5      -   5         ��Name$ btnSet��5      $
��Left=�6|   $��143,198,0,0q�6�   $	��Top=�6�   $��75��6�   ��6%   �� *updateCreateName+$  PropertyChanged=�$ TwoWay=�6�   �� 5      -   5        $��CatError��5      $
��Left=�6w   $��
143,76,0,0q�6�   $	��Top=�6�   $��12(�6�   
���  ��$
��Bold"�6�   ��6$   �� *NewCatError+$  PropertyChanged=�$ OneWay=�6�   �� 5      -   5        $��
CatMessage��5      $
��Left=�6{   $��
143,76,0,0q�6�   $	��Top=�6�   $��12(�6�   
��� � �$
��Bold"�6�   ��6&   �� *NewCatMessage+$  PropertyChanged=�$ OneWay=�6�   5      5      5      