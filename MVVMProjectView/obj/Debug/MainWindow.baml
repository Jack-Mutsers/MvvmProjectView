   M S B A M L   `   `   `  ����J  FMVVMProjectView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MVVMProjectViewMVVMProjectView  5   	   G(clr-namespace:MVVMProjectView.ViewModelsMVVMProjectView.ViewModels  5   	   =#clr-namespace:MVVMProjectView.ViewsMVVMProjectView.Views  5   	        MVVMProjectView.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:MVVMProjectView     5   	   ?
viewmodels(clr-namespace:MVVMProjectView.ViewModels     5   	   5views#clr-namespace:MVVMProjectView.Views     5   	     � Title$  
MainWindow��5
   	   $	��500��6   $
��1135��6)   $
��1135��5   	   $	��500��5   	    � 	Resources 5       �� DataType2   ,MVVMProjectView.ViewModels.CategoryViewModel(   "MVVMProjectView.Views.CategoryView � DataContext/   )MVVMProjectView.ViewModels.LoginViewModel%   MVVMProjectView.Views.LoginView5   /MVVMProjectView.ViewModels.NewCategoryViewModel+   %MVVMProjectView.Views.NewCategoryView7   1MVVMProjectView.ViewModels.NewComponentsViewModel-   'MVVMProjectView.Views.NewComponentsView1	   +MVVMProjectView.ViewModels.NewUserViewModel#
   MVVMProjectView.Views.NewUser1   +MVVMProjectView.ViewModels.ProfileViewModel#   MVVMProjectView.Views.Profile0   *MVVMProjectView.ViewModels.StatusViewModel&    MVVMProjectView.Views.StatusView��%  (��       5   5   *, +)(�� Y     5   2   *, +)(�� �     5   8   *, +)(��     5   :   *, +)(�� i    5   4   *,	 +)(�� �    5   4   *, +)(��     5    3   *, +)�� 5   
   CategoryViewTemplate��"  65   .R�5         6!   �� 5      �� 5   
   LoginViewTemplate��"  62   .R�5         6   �� 5      �� 5   
   NewCategoryViewTemplate��"  68   .R�5         6$   �� 5      �� 5   
   NewComponentsViewTemplate��"  6:   .R�5         6&   �� 5      �� 5   
   NewUserViewTemplate��" 	 64   .R�5      
   6   �� 5      �� 5   
   ProfileViewTemplate��"  64   .R�5         6   �� 5      �� 5    
   StatusViewTemplate��"  63   .R�5!         6   �� 5"      5#      .��5$      �  � ColumnDefinitions 5%   
   �� 5&      $	��225 �6   �� 5'      �� 5(      �� 5)      �� 5*       � RowDefinitions 5,   
   �� 5-      �� 5.      �� 5/      �� 50      �� 51      .+�54   
   ]� 
�������$��0��6+   $��0��68   $��5��6H   .+�55      �� -   5         ��Name$
 menu��55      $
��Left=�6'   $��
10,10,10,0q�6B   $	��Top=�6V   .+�56      �� -   5        {�56      ��  �� Path$ LoggedIn� �� Mode$ OneWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�.@�57      �� 
 �� Orientation$
 
Horizontal=�6!   .+�58      �� $��50��6    $��50��6,   �� 59      $��Component List��6    $
��Bold"�69   $��Center=�6K   $��Center=�6h   5:      5;      �� 5=      $��7��6   $y�Hidden=�6'   �� 5?      -   5        {�5?      �� $ LoggedIn�$ OneWay=�$	 PropertyChanged=�.@�5@      �� $
 
Horizontal=�6!   .+�5A      �� $��50��6    $��50��6,   �� 5B      $��Category List��6    $
��Bold"�68   $��Center=�6J   $��Center=�6g   5C      5D      �� 5F      $��7��6   $y�Hidden=�6'   �� 5H      -   5        {�5H      �� $ LoggedIn�$ OneWay=�$	 PropertyChanged=�.@�5I      �� $
 
Horizontal=�6!   .+�5J      �� $��50��6    $��50��6,   �� 5K      $��Add User��6    $
��Bold"�63   $��Center=�6E   $��Center=�6b   5L      5M      �� 5O      $��7��6   $y�Hidden=�6'   �� 5Q      -   5        {�5Q      �� $ LoggedIn�$ OneWay=�$	 PropertyChanged=�.@�5R      �� $
 
Horizontal=�6!   .+�5S      �� $��50��6    $��50��6,   �� 5T      $��Profile Manager��6    $
��Bold"�6:   $��Center=�6L   $��Center=�6i   5U      5V      �� 5X      $��7��6   $y�Hidden=�6'   �� 5Z      -   5        {�5Z      �� $ LoggedIn�$ OneWay=�$	 PropertyChanged=�.@�5[      �� $
 
Horizontal=�6!   .+�5\      �� $��50��6    $��50��6,   �� 5]      $��Logout��6    $
��Bold"�61   $��Center=�6C   $��Center=�6`   5^      5_      �� 5a      $��7��6   $y�Hidden=�6'   5b      5c      �� 5e   
   $��1��6-   $��0��6=   $��5��6J   $��4��6[   ��6   �� 6[   5f      5g      