   M S B A M L   `   `   `  ����F  BwithoutMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:withoutMVVMwithoutMVVM  5   	       withoutMVVM.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:withoutMVVM     5   	     � Title$  Without MVVM��5   	   $	��500��6   $	��800��6+    � 	Resources 5	      ��%    5      .��5      � .+�5   
   �� $	��350��6   $
��Left=�6!   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��
masterGrid��5      
����� �$	��430��6;      AutoGenerateColumns . 5      � 5       � ColumnDefinitions 5      �� 5      $
��299* �6'   �� 5      $	��51* �6'   .+�5      �� -   5        $��AddClientButton��5      $��
Add Client��60   
�������$	��100��6Y   $��20��6e   $��
10,10,0,10q�6q   $
��Left=�6�   5      �� 5      -   5        $��UpdateTableButton��5      $��Update tables��62   
�������$	��100��6^   $��20��6j   $��Center=�6v   $��110,10,64,10q�6�   6�   �� 5      -   5        $��DeleteClientButton��5      $��Delete Client��63   
�������$	��100��6_   $��20��6k   $��
0,10,10,10q�6w   $��Right=�6�   $��2��6�   5      5      5      �� 5    
   $��Right=�6   $	��450��62   .+�5!        -   5        $��
detailGrid��5!      
����+��$	��430��6A   � 5"      .+�5#      �� -   5        $��AddOrderButton��5#      
�������$��	Add Order��6C   $	��100��6W   $��20��6c   $��10,10q�6o   $
��Left=�6�   �� 5$      -   5        $��DeleteOrderButton��5$      
�������$��Delete Order��6F   $	��100��6]   $��20��6i   $��10,-10q�6u   $��Right=�6�   5%      5(      5)      5*      