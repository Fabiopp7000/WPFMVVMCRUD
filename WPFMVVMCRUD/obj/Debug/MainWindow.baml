   M S B A M L   `   `   `  ����F  BWPFMVVMCRUD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPFMVVMCRUDWPFMVVMCRUD  5   	       WPFMVVMCRUD.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WPFMVVMCRUD     5   	     � Title$  Lista de Funcionários��5   	   $	��350��5	   	   $	��525��6    � DataContext 5
   	   ��  �� Path$ Funcionarios�   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��9* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��3q�6   $��3q�5      $
��Novo��5      ��5      �� ��5      �� *Novo+5      �� 5      $��3q�6   $��3q�5      $��Editar��5      ��5      �� ��5      �� *Editar+5      �� 5      $��3q�6   $��3q�5      $��Deletar��5      ��5      �� ��5      �� *	Deletar+5      5       �� 5!   
   $��1��6   $��Visible=�5"      $��Hidden=�5#      .��5$      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .     
IsReadOnly . ��6   �� *Funcionarios+ �� SelectedItem 5'      �� *FuncionarioSelecionado+	   Columns	 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Id+  5*      $

 Nome��6)    67   �� *Nome+  5+      $
 	Sobrenome��6)    6<   �� *	Sobrenome+  5,      $
 Data Nascimento��6)    6B   �� *DataNascimento+ �� StringFormat$ {0:d}��  5-      $

 Sexo��6)    67   �� *Sexo+  5.      $
 Estado Civil��6)    6?   �� *EstadoCivil+  5/      $
 Data Admissão��6)    6@   �� *DataAdmissao+$ {0:d}��51      52      53      54      