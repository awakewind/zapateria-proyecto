   M S B A M L   `   `   `  ���� N  JZapateria.interfazb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Zapateria.interfazbZapateria.interfazb  ,    &Zapateria.interfazb.VentanaExistencias   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:Zapateria.interfazb     -     � WindowStartupLocation$  CenterScreen=� � 
ResizeMode$ CanMinimize=� � Title$ VentanaExistencias��$��318.321��$��761.832��.��� .+�&   System.Windows.Controls.DataGrid  -     Name$ 
dtgZapatos��   AutoGenerateColumns .  $
��Left=�$��0,62,0,0q�$	��Top=�$	��225��$	��754��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	ID zapato��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
Id_zapatos+     Width5  /System.Windows.Controls.DataGridLengthConverter$ * $ Nombre gama�� �� *NomGaZapato1+  $ * $ Estilos�� �� *	Estilos+  $ * $ Marcas�� �� *Marcas+  $ * $ Tallas disponibles�� �� *TallasDisponibles1+  $ * $ Cantidad Disponible�� �� *CantidadDisponible1+  $ * $ Colores disponibles�� �� *ColoresGama1+  $ * $ Distribuidor�� �� *
Viajeros+�� -   	 ��Name$	 	btnBuscar��$��Buscar��$
��Left=�$��
283,24,0,0q�$	��Top=�$��75���� -   
 ��Name$
 label��$��Buscar producto:��$
��Left=�$��	10,18,0,0q�$	��Top=��� -    ��Name$ cmbProducto��$
��Left=�$��
118,24,0,0q�$	��Top=�$	��120��