using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

namespace Zapateria.interfazb
{

    /// <summary>
    /// Lógica de interacción para VentanaAdministración.xaml
    /// </summary>
    public partial class VentanaAdministración : Window
    {
        ServicioZapateriaReferenciab.zapateriawsSoapClient ws = new ServicioZapateriaReferenciab.zapateriawsSoapClient();


        public VentanaAdministración()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            dtgEmpleados.ItemsSource = ws.getAllEmpleados();
            dtgCargos.ItemsSource = ws.getAllcargos();
            dtgZapatos.ItemsSource = ws.getAllZapato();
            dtgEstilos.ItemsSource = ws.getAllEstilos();
            dtgMarcas.ItemsSource = ws.getAllMarcas();
            dtgPRoveedores .ItemsSource = ws.getAllProveedores ();
            dtgViajeros.ItemsSource = ws.getAllViajeros();
            dtgComisiones.ItemsSource = ws.getAllComisiones();
            dtgPrestamos.ItemsSource = ws.getAllPrestamos();
            dtgdetavent.ItemsSource = ws.getAllDetavent();
            dtgClientes.ItemsSource = ws.getAllClientes();

            var cargos = ws.getAllcargos();
            cmbCargo.ItemsSource = cargos;
            cmbCargo.DisplayMemberPath = "NomCargo1";
            cmbCargo.SelectedValuePath = "Id_cargo";

            var estilos = ws.getAllEstilos();
            cmbEstilos.ItemsSource = estilos;
            cmbEstilos.DisplayMemberPath = "NomEstilo1";
            cmbEstilos.SelectedValuePath = "Id_estilo";

            var marcas = ws.getAllMarcas();
            cmbMarcas.ItemsSource = marcas;
            cmbMarcas.DisplayMemberPath = "NomMarca1";
            cmbMarcas.SelectedValuePath = "Id_marcas";

            var viajero = ws.getAllViajeros();
            cmbViajeros.ItemsSource = viajero;
            cmbViajeros.DisplayMemberPath = "NomViajero1";
            cmbViajeros.SelectedValuePath = "Id_viajero";

            var proveedores = ws.getAllProveedores();
            cmbproveedoresviajero.ItemsSource = proveedores;
            cmbproveedoresviajero.DisplayMemberPath = "NomEmpresa1";
            cmbproveedoresviajero.SelectedValuePath = "Id_proveedor";

            var ventas = ws.getAllVentas();
            cmbVenta.ItemsSource = ventas;
            cmbVenta.DisplayMemberPath = "Id_venta";
            cmbVenta.SelectedValuePath = "Id_venta";

            var empleado = ws.getAllEmpleados();
            cmbEmpleado.ItemsSource = empleado;
            cmbEmpleado.DisplayMemberPath = "Nomempleado";
            cmbEmpleado.SelectedValuePath = "Id_empleado";

            cmbVentaprestamo .ItemsSource = ventas;
            cmbVentaprestamo.DisplayMemberPath = "Id_venta";
            cmbVentaprestamo.SelectedValuePath = "Id_venta";

            cmbventadetavent.ItemsSource = ventas;
            cmbventadetavent.DisplayMemberPath = "Id_venta";
            cmbventadetavent.SelectedValuePath = "Id_venta";

            var zapato = ws.getAllZapato();
            cmbproductodetavent.ItemsSource = zapato;
            cmbproductodetavent.DisplayMemberPath = "NomGaZapato1";
            cmbproductodetavent.SelectedValuePath = "Id_zapatos";

            cmbempleadodetavent .ItemsSource = empleado;
            cmbempleadodetavent.DisplayMemberPath = "Nomempleado";
            cmbempleadodetavent.SelectedValuePath = "Id_empleado";

        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            String nomempleado;
            String apeempleado;
            String numtelempleado;
            String direccionempleado;
            Int32 cargoempleado;
            DateTime fechanacempleado;
            String duiempleado;
            String nitempleado;

            nomempleado = TxtNombre.Text;
            apeempleado = TxtApellido.Text;
            numtelempleado = TxtTelefono.Text;
            direccionempleado = TxtDireccion.Text;
            cargoempleado = Convert.ToInt32(cmbCargo.SelectedValue);
            fechanacempleado = dtpFecha.SelectedDate.Value;
            duiempleado = TxtDui.Text;
            nitempleado = TxtNit.Text;

            if (ws.agregarEmpleado(nomempleado, apeempleado, numtelempleado, direccionempleado, cargoempleado, fechanacempleado, duiempleado, nitempleado) == 1)
            {

                MessageBox.Show("Nuevo empleado agregado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudo agregar el empleado", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgEmpleados.ItemsSource = ws.getAllEmpleados();
            limpiar();
            nuevo();
        }

        

        private void dtgEmpleados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var empleado = (ServicioZapateriaReferenciab.empleados)dtgEmpleados.SelectedItem;

            if (empleado != null)
            {
                this.txtId.Text = "" + empleado.Id_empleado;
                this.TxtNombre.Text = empleado.Nomempleado;
                this.TxtApellido.Text = empleado.Apeempleado;
                this.TxtTelefono.Text = empleado.Numtellempleado;
                this.TxtDireccion.Text = empleado.Direcempleado;
                this.TxtDui.Text = empleado.Duiempleado;
                this.TxtNit.Text = empleado.Nitempleado;
                this.dtpFecha.SelectedDate = empleado.Fechanacempleado;
                this.cmbCargo.SelectedValue = empleado.Cargos;

                BtnEliminar.IsEnabled = true;
                BtnEditar.IsEnabled = true;
                btnAceptar.IsEnabled = false;
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {

            int id = Convert.ToInt32(this.txtId.Text);
            if (ws.deleteEmpleado(id) == 1)
            {
                MessageBox.Show("Datos eliminados", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudieron realizar los cambios", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            limpiar();
            nuevo();
            dtgEmpleados.ItemsSource = ws.getAllEmpleados();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            String nomempleado;
            String apeempleado;
            String numtelempleado;
            String direccionempleado;
            Int32 cargoempleado;
            DateTime fechanacempleado;
            String duiempleado;
            String nitempleado;

            nomempleado = TxtNombre.Text;
            apeempleado = TxtApellido.Text;
            numtelempleado = TxtTelefono.Text;
            direccionempleado = TxtDireccion.Text;
            cargoempleado = Convert.ToInt32(cmbCargo.SelectedValue);
            fechanacempleado = dtpFecha.SelectedDate.Value;
            duiempleado = TxtDui.Text;
            nitempleado = TxtNit.Text;
            int id = Convert.ToInt32(this.txtId.Text);

            if (ws.updateEmpleado(id, nomempleado, apeempleado, numtelempleado, direccionempleado, cargoempleado, fechanacempleado, duiempleado, nitempleado) == 1)
            {

                MessageBox.Show("Datos actualizados", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudieron realizar los cambios", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            dtgEmpleados.ItemsSource = ws.getAllEmpleados();
            limpiar();
            nuevo();

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
            nuevo();
        }

        private void limpiar()
        {
            this.txtId.Clear();
            this.TxtNombre.Clear();
            this.TxtApellido.Clear();
            this.TxtTelefono.Clear();
            this.TxtDireccion.Clear();
            this.TxtDui.Clear();
            this.TxtNit.Clear();
            this.dtpFecha.SelectedDate = DateTime.Today;
            this.cmbCargo.SelectedIndex = -1;
        }

        private void nuevo()
        {
            BtnEliminar.IsEnabled = false;
            BtnEditar.IsEnabled = false;
            btnAceptar.IsEnabled = true;
        }

        private void dtgCargos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cargo = (ServicioZapateriaReferenciab.cargos)dtgCargos.SelectedItem;

            if (cargo != null)
            {
                this.txtIdCargo.Text = "" + cargo.Id_cargo;
                this.txtNomCargo.Text = cargo.NomCargo1;
                this.txtSalario.Text = "" + cargo.Salario1;
                this.txtDescripcionCargo.Text = cargo.DescripcionCargo1;

                btnEliminarCargo.IsEnabled = true;
                btnEditarCargo.IsEnabled = true;
                btnGuardarCargo.IsEnabled = false;
            }
        }

        private void btnGuardarCargo_Click(object sender, RoutedEventArgs e)
        {

            String nombrecargo = txtNomCargo.Text;
            String descripcióncargo = txtDescripcionCargo.Text;
            Decimal salariocargo = Convert.ToDecimal(txtSalario.Text);

            if (ws.agregarCargo(nombrecargo, descripcióncargo, salariocargo) == 1)
            {

                MessageBox.Show("Nuevo cargo agregado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudo agregar el cargo", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgCargos.ItemsSource = ws.getAllcargos();
            limpiarcargos();
            nuevocargo();
        }

        private void btnEditarCargo_Click(object sender, RoutedEventArgs e)
        {
            Int32 idcargo = Convert.ToInt32(txtIdCargo.Text);
            String nombrecargo = txtNomCargo.Text;
            String descripcióncargo = txtDescripcionCargo.Text;
            Decimal salariocargo = Convert.ToDecimal(txtSalario.Text);

            if (ws.updateCargos(idcargo, nombrecargo, descripcióncargo, salariocargo) == 1)
            {

                MessageBox.Show("Se modificó el cargo", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudo mofificar el cargo", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgCargos.ItemsSource = ws.getAllcargos();
            limpiarcargos();
            nuevocargo();
        }

        private void btnEliminarCargo_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(this.txtIdCargo.Text);
            if (ws.deleteCargos(id) == 1)
            {
                MessageBox.Show("Datos eliminados", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudieron realizar los cambios", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            dtgCargos.ItemsSource = ws.getAllcargos();
            limpiarcargos();
            nuevocargo();

        }

        private void btnCancelarCargo_Click(object sender, RoutedEventArgs e)
        {
            limpiarcargos();
            nuevocargo();
        }

        private void limpiarcargos()
        {
            this.txtIdCargo.Clear();
            this.txtNomCargo.Clear();
            this.txtDescripcionCargo.Clear();
            this.txtSalario.Clear();

        }

        private void nuevocargo()
        {
            btnEliminarCargo .IsEnabled = false;
            btnEditarCargo .IsEnabled = false;
            btnGuardarCargo .IsEnabled = true;
        }

        private void dtgZapatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var zapato  = (ServicioZapateriaReferenciab.zapatos )dtgZapatos .SelectedItem;

            if (zapato != null)
            {
                this.txtIdZapato .Text = "" + zapato.Id_zapatos ;
                this.txtNombreZapato .Text = zapato.NomGaZapato1 ;
                this.cmbEstilos .SelectedValue  = zapato.Estilos ;
                this.cmbMarcas .SelectedValue  = zapato.Marcas ;
                this.txtTallas.Text = zapato.TallasDisponibles1;
                this.txtCantidad .Text = "" + zapato.CantidadDisponible1;
                this.txtColoresGanma .Text  = zapato.ColoresGama1 ;
                this.cmbViajeros .SelectedValue = zapato.Viajeros ;

                btnEliminarZapato.IsEnabled = true;
                btnEditarZapato.IsEnabled = true;
                btnGuardarZapato.IsEnabled = false;
            }
        }

        private void btnGuardarZapato_Click(object sender, RoutedEventArgs e)
        {
            String nombrezapato  = txtNombreZapato .Text;
            Int32 estilo  = Convert.ToInt32 (cmbEstilos .SelectedValue );
            Int32 marca  = Convert.ToInt32(cmbMarcas .SelectedValue);
            String tallas = txtTallas.Text;
            Int32 cantdisp  = Convert.ToInt32(txtCantidad.Text);
            String coloresgama = txtColoresGanma.Text;
            Int32 viajeros  = Convert.ToInt32(cmbViajeros .SelectedValue);

            if (ws.agregarZapato (nombrezapato ,estilo ,marca ,tallas ,cantdisp ,coloresgama ,viajeros ) == 1)
            {

                MessageBox.Show("Nuevo producto agregado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudo agregar el producto", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgZapatos.ItemsSource = ws.getAllZapato();
            limpiarzapatos();
            nuevozapatos();
        }

        private void btnEditarZapato_Click(object sender, RoutedEventArgs e)
        {
            Int32 idzapato  = Convert.ToInt32(txtIdZapato .Text);
            String nombrezapato = txtNombreZapato.Text;
            Int32 estilo = Convert.ToInt32(cmbEstilos.SelectedValue);
            Int32 marca = Convert.ToInt32(cmbMarcas.SelectedValue);
            String tallas = txtTallas.Text;
            Int32 cantdisp = Convert.ToInt32(txtCantidad.Text);
            String coloresgama = txtColoresGanma.Text;
            Int32 viajeros = Convert.ToInt32(cmbViajeros.SelectedValue);

            if (ws.updateZapato ( idzapato ,nombrezapato, estilo, marca, tallas, cantdisp, coloresgama, viajeros) == 1)
            {

                MessageBox.Show("Producto modificado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudo modificar el producto", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgZapatos.ItemsSource = ws.getAllZapato();
            limpiarzapatos();
            nuevozapatos();
        }

        private void btnEliminarZapato_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(this.txtIdZapato .Text);
            if (ws.deleteZapato (id) == 1)
            {
                MessageBox.Show("Datos eliminados", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudieron realizar los cambios", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            dtgZapatos.ItemsSource = ws.getAllZapato();
            limpiarzapatos();
            nuevozapatos();

        }

        private void btnCancelarZapato_Click(object sender, RoutedEventArgs e)
        {
            limpiarzapatos();
            nuevozapatos();
        }

        private void limpiarzapatos ()
        {
            txtIdZapato.Clear();
            txtNombreZapato.Clear();
            cmbEstilos.SelectedIndex = -1;
            cmbMarcas.SelectedIndex = -1;
            txtTallas.Clear();
            txtCantidad.Clear();
            txtColoresGanma.Clear();
            cmbViajeros.SelectedIndex = -1;

        }

        private void nuevozapatos ()
        {
            btnEliminarZapato .IsEnabled = false;
            btnEditarZapato .IsEnabled = false;
            btnGuardarZapato .IsEnabled = true;
        }

        private void dtgEstilos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var estilos  = (ServicioZapateriaReferenciab.estilos )dtgEstilos .SelectedItem;

            if (estilos  != null)
            {
                this.txtIdEstilo .Text = "" + estilos .Id_estilo ;
                this.txtEstilo .Text = estilos .NomEstilo1 ;
                this.txtGenero.Text = estilos.GeneroEstilo1;
                this.txtDescripciónEstilo.Text = estilos .Descripcíon1 ;
                

                btnEliminarEstilo .IsEnabled = true;
                btnEditarEstilo .IsEnabled = true;
                btnGuardarEstilo .IsEnabled = false;
            }
        }

        private void btnEditarEstilo_Click(object sender, RoutedEventArgs e)
        {
            Int32 idEstilo = Convert.ToInt32(txtIdEstilo .Text); 
            String estilo = txtEstilo.Text;
            String genero = txtGenero.Text;
            String descripción = txtDescripciónEstilo.Text;


            if (ws.updateEstilos (idEstilo , estilo, descripción, genero) == 1)
            {

                MessageBox.Show("Se modificó el estilo", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudo modificar el Estilo", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgEstilos.ItemsSource = ws.getAllEstilos();
            limpiarEstilo();
            nuevoEstilo();
        }

        private void btnGuardarEstilo_Click(object sender, RoutedEventArgs e)
        {
            String estilo = txtEstilo.Text;
            String genero = txtGenero.Text;
            String descripción = txtDescripciónEstilo.Text;


            if (ws.agregarEstilo(estilo, descripción, genero) == 1)
            {

                MessageBox.Show("Nuevo Estilo agregado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudo agregar el Estilo", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgEstilos.ItemsSource = ws.getAllEstilos();
            limpiarEstilo();
            nuevoEstilo();
        }

        private void btnEliminarEstilo_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(this.txtIdEstilo .Text);
            if (ws.deleteEstilos (id) == 1)
            {
                MessageBox.Show("Datos eliminados", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudieron realizar los cambios", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            dtgEstilos.ItemsSource = ws.getAllEstilos();
            limpiarEstilo();
            nuevoEstilo();
        }

        private void btnCancelarEstilo_Click(object sender, RoutedEventArgs e)
        {
            limpiarEstilo();
            nuevoEstilo();
        }

        private void limpiarEstilo ()
        {
            this.txtIdEstilo  .Clear();
            this.txtEstilo  .Clear();
            this.txtGenero .Clear();
            this.txtDescripciónEstilo .Clear();

        }

        private void nuevoEstilo ()
        {
            btnEliminarEstilo.IsEnabled = false ;
            btnEditarEstilo.IsEnabled = false ;
            btnGuardarEstilo.IsEnabled = true ;
        }

        private void dtgMarcas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var marca  = (ServicioZapateriaReferenciab.marcas )dtgMarcas .SelectedItem;

            if (marca != null)
            {
                this.txtIdMarca .Text = "" + marca .Id_marcas;
                this.txtMarca .Text = marca .NomMarca1 ;
                

                btnEliminarMarca .IsEnabled = true;
                btnEditarMarca .IsEnabled = true;
                btnGuardarMarca .IsEnabled = false;
            }
        }

        private void btnGuardarMarca_Click(object sender, RoutedEventArgs e)
        {
            String marca  = txtMarca .Text;
            

            if (ws.agregarMarca (marca ) == 1)
            {

                MessageBox.Show("Nueva marca agregada", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudo agregar la marca", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgMarcas.ItemsSource = ws.getAllMarcas();
            limpiarmarca();
            nuevomarca();
        }

        private void btnEditarMarca_Click(object sender, RoutedEventArgs e)
        {
            Int32 idmarca = Convert.ToInt32(txtIdMarca.Text);
            String marca = txtMarca.Text;


            if (ws.updateMarcas (idmarca , marca) == 1)
            {

                MessageBox.Show("Nueva marca agregada", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudo agregar la marca", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgMarcas.ItemsSource = ws.getAllMarcas();
            limpiarmarca();
            nuevomarca();
        }

        private void btnEliminarMarca_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(this.txtIdMarca .Text);
            if (ws.deleteMarcas (id) == 1)
            {
                MessageBox.Show("Datos eliminados", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudieron realizar los cambios", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            dtgMarcas.ItemsSource = ws.getAllMarcas();
            limpiarmarca();
            nuevomarca();
        }

        private void btnCancelarMarca_Click(object sender, RoutedEventArgs e)
        {
            limpiarmarca();
            nuevomarca();


        }

        private void limpiarmarca ()
        {
            this.txtIdMarca.Clear();
            this.txtMarca.Clear();

        }

        private void nuevomarca ()
        {
            btnEliminarMarca.IsEnabled = false ;
            btnEditarMarca.IsEnabled = false ;
            btnGuardarMarca.IsEnabled = true ;
        }

        private void dtgPRoveedores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proveedor  = (ServicioZapateriaReferenciab.proveedores )dtgPRoveedores .SelectedItem;

            if (proveedor  != null)
            {
                this.txtidproveedor .Text = "" + proveedor .Id_proveedor ;
                this.txtproveedor .Text = proveedor .NomEmpresa1 ;
                this.txttelefonoproveedor.Text = proveedor.TelefonoEmpresa1;
                this.txtcorreoproveedor.Text = proveedor.CorreoEmpresa1;


                btneliminarproveedores .IsEnabled = true;
                btneditarproveedores .IsEnabled = true;
                btnguardarproveedores .IsEnabled = false;
            }
        }

        private void btnguardarproveedores_Click(object sender, RoutedEventArgs e)
        {
            String nombreempresa  = txtproveedor .Text;
            String telefonoempresa  = txttelefonoproveedor .Text;
            String correoempresa  = txtcorreoproveedor .Text;


            if (ws.agregarProveedor (nombreempresa,telefonoempresa ,correoempresa ) == 1)
            {

                MessageBox.Show("Nuevo proveedor agregado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudo agregar el proveedor", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgPRoveedores.ItemsSource = ws.getAllProveedores();
            limpiarproveedor();
            nuevoproveedor();

        }

        private void btneditarproveedores_Click(object sender, RoutedEventArgs e)
        {
            Int32 idempresa = Convert.ToInt32(txtidproveedor.Text);
            String nombreempresa = txtproveedor.Text;
            String telefonoempresa = txttelefonoproveedor.Text;
            String correoempresa = txtcorreoproveedor.Text;


            if (ws.updateProveedores (idempresa ,nombreempresa, telefonoempresa, correoempresa) == 1)
            {

                MessageBox.Show("Datos modificados", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudieron modificar los datos", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgPRoveedores.ItemsSource = ws.getAllProveedores();
            limpiarproveedor();
            nuevoproveedor();
        }

        private void btneliminarproveedores_Click(object sender, RoutedEventArgs e)
        {
            Int32 idempresa = Convert.ToInt32(txtidproveedor.Text);
            


            if (ws.deleteProveedores (idempresa) == 1)
            {

                MessageBox.Show("Datos eliminados", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudieron eliminar los datos", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgPRoveedores.ItemsSource = ws.getAllProveedores();
            limpiarproveedor();
            nuevoproveedor();
        }

        private void btncancelarproveedores_Click(object sender, RoutedEventArgs e)
        {
            limpiarproveedor();
            nuevoproveedor();
        }

        private void limpiarproveedor ()
        {
            this.txtidproveedor.Clear();
            this.txtproveedor.Clear();
            this.txttelefonoproveedor.Clear();
            this.txtcorreoproveedor.Clear();

        }

        private void nuevoproveedor ()
        {
            btneliminarproveedores.IsEnabled = false ;
            btneditarproveedores.IsEnabled = false ;
            btnguardarproveedores.IsEnabled = true ;
        }

        private void dtgViajeros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var viajero  = (ServicioZapateriaReferenciab.viajeros )dtgViajeros .SelectedItem;

            if (viajero  != null)
            {
                this.txtidviajero .Text = "" + viajero.Id_viajero ;
                this.txtnombreviajero .Text = viajero.NomViajero1 ;
                this.txtapellidoviajero .Text = viajero.ApeViajero1 ;
                this.txttelefonoviajero .Text = viajero.TelefonoViajero1 ;
                this.txtcorreoviajero .Text = viajero.CorreoViajero1 ;
                this.cmbproveedoresviajero  .SelectedValue = viajero .Proveedores ;

                btneliminarviajero .IsEnabled = true;
                btneditarviajero .IsEnabled = true;
                btnguardarviajero.IsEnabled = false;
            }
        }

        private void btnguardarviajero_Click(object sender, RoutedEventArgs e)
        {
            String nombre  = txtnombreviajero .Text;
            String apellido  = txtapellidoviajero .Text ;
            String telefono  = txttelefonoviajero .Text ;
            String correo  = txtcorreoviajero .Text;
            Int32 proveedor  = Convert.ToInt32(cmbproveedoresviajero .SelectedValue);


            if (ws.agregarViajero (nombre,apellido ,telefono ,proveedor ,correo ) == 1)
            {

                MessageBox.Show("Nuevo viajero agregado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudo agregar el viajero", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgViajeros.ItemsSource = ws.getAllViajeros();
            limpiarviajero();
            nuevoviajero();
        }

        private void btneditarviajero_Click(object sender, RoutedEventArgs e)
        {
            Int32 idviajero = Convert.ToInt32(txtidviajero.Text);
            String nombre = txtnombreviajero.Text;
            String apellido = txtapellidoviajero.Text;
            String telefono = txttelefonoviajero.Text;
            String correo = txtcorreoviajero.Text;
            Int32 proveedor = Convert.ToInt32(cmbproveedoresviajero.SelectedValue);


            if (ws.updateViajeros ( idviajero ,nombre, apellido, telefono, proveedor, correo) == 1)
            {

                MessageBox.Show("Se modificaron los datos", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudieron modificar los  datos", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgViajeros.ItemsSource = ws.getAllViajeros();
            limpiarviajero();
            nuevoviajero();
        }

        private void btneliminarviajero_Click(object sender, RoutedEventArgs e)
        {
            Int32 idviajero = Convert.ToInt32(txtidviajero.Text);
           

            if (ws.deleteViajeros (idviajero) == 1)
            {

                MessageBox.Show("Se eliminaron los datos", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudieron eliminar los  datos", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgViajeros.ItemsSource = ws.getAllViajeros();
            limpiarviajero();
            nuevoviajero();
        }

        private void btncancelarviajero_Click(object sender, RoutedEventArgs e)
        {
            limpiarviajero();
            nuevoviajero();
        }

        private void limpiarviajero ()
        {
            txtidviajero.Clear();
            txtnombreviajero.Clear();
            txtapellidoviajero.Clear();
            txttelefonoviajero.Clear();
            txtcorreoviajero.Clear();
            cmbproveedoresviajero.SelectedIndex = -1;

        }

        private void nuevoviajero ()
        {
            btneliminarviajero.IsEnabled = false ;
            btneditarviajero.IsEnabled = false ;
            btnguardarviajero.IsEnabled = true  ;
        }

        private void dtgComisiones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comisiones = (ServicioZapateriaReferenciab.comisiones )dtgComisiones.SelectedItem;

            if (comisiones != null)
            {
                this.txtidComision .Text = "" + comisiones.Id_comision ;
                this.cmbEmpleado .SelectedValue  = comisiones.Empleados ;
                this.txtvalorcomision .Text = "" + comisiones.ValorComision1 ;
                this.cmbVenta .SelectedValue = comisiones.Ventas ;

                btnEliminarComision .IsEnabled = true;
                btnEditarComision .IsEnabled = true;
                btnGuardarComision .IsEnabled = false;
            }
        }

        private void btnGuardarComision_Click(object sender, RoutedEventArgs e)
        {
            Int32 empleado = Convert.ToInt32(cmbEmpleado.SelectedValue);
            Decimal  valor = Convert .ToDecimal ( txtvalorcomision .Text);
            Int32 venta  = Convert.ToInt32(cmbVenta .SelectedValue);


            if (ws.agregarComision (empleado ,valor ,venta ) == 1)
            {

                MessageBox.Show("Nueva comisión agregada", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudo agregar la comisión", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgComisiones.ItemsSource = ws.getAllComisiones();
            limpiarcomision();
            nuevocomision();

        }

        private void btnEditarComision_Click(object sender, RoutedEventArgs e)
        {
            Int32 idcomision = Convert.ToInt32(txtidComision.Text);
            Int32 empleado = Convert.ToInt32(cmbEmpleado.SelectedValue);
            Decimal valor = Convert.ToDecimal(txtvalorcomision.Text);
            Int32 venta = Convert.ToInt32(cmbVenta.SelectedValue);


            if (ws.updateComisiones (idcomision ,empleado, valor, venta) == 1)
            {

                MessageBox.Show("Se modificaron los datos", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudieron modificar los datos", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgComisiones.ItemsSource = ws.getAllComisiones();
            limpiarcomision();
            nuevocomision();

        }

        private void btnEliminarComision_Click(object sender, RoutedEventArgs e)
        {
            Int32 idcomision = Convert.ToInt32(txtidComision.Text);


            if (ws.deleteComisiones (idcomision) == 1)
            {

                MessageBox.Show("Se eliminaron los datos", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudieron eliminar los datos", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgComisiones.ItemsSource = ws.getAllComisiones();
            limpiarcomision();
            nuevocomision();

        }

        private void btnCancelarComision_Click(object sender, RoutedEventArgs e)
        {
            limpiarcomision();
            nuevocomision();

        }

        private void limpiarcomision ()
        {
            txtidComision.Clear();
            cmbEmpleado.SelectedIndex = -1;
            txtvalorcomision.Clear();
            cmbVenta.SelectedIndex = -1;

        }

        private void nuevocomision ()
        {
            btnEliminarComision.IsEnabled = false ;
            btnEditarComision.IsEnabled = false ;
            btnGuardarComision.IsEnabled = true ;
        }

        private void dtgPrestamos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var prestamos = (ServicioZapateriaReferenciab.prestamos )dtgPrestamos .SelectedItem;

            if (prestamos  != null)
            {
                this.txtidprestamo .Text = "" + prestamos.Id_prestamo ;
                this.cmbVentaprestamo .SelectedValue = prestamos.Ventas ;
                this.txtAbonoDeuda .Text = "" + prestamos.AbonoDeuda1 ;
                this.txtSaldoPendiente .Text = "" + prestamos.SaldoPendiente1 ;

                btnEliminarPrestamos .IsEnabled = true;
                btnEditarPrestamos .IsEnabled = true;
                btnGuardarPrestamos.IsEnabled = false;
            }
        }

        private void btnGuardarPrestamos_Click(object sender, RoutedEventArgs e)
        {
            Int32 ventas  = Convert.ToInt32(cmbVentaprestamo .SelectedValue);
            Decimal abonodeuda = Convert.ToDecimal(txtAbonoDeuda .Text);
            Decimal saldopendiente  = Convert.ToDecimal(txtSaldoPendiente .Text);


            if (ws.agregarPrestamos (ventas,abonodeuda ,saldopendiente ) == 1)
            {

                MessageBox.Show("Nuevo prestamo agregado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudo agregar el prestamo", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgPrestamos.ItemsSource = ws.getAllPrestamos();
            limpiarprestamo();
            nuevoprestamo();
        }

        private void btnEditarPrestamos_Click(object sender, RoutedEventArgs e)
        {
            Int32 idprestamo = Convert.ToInt32(txtidprestamo.Text);
            Int32 ventas = Convert.ToInt32(cmbVentaprestamo.SelectedValue);
            Decimal abonodeuda = Convert.ToDecimal(txtAbonoDeuda.Text);
            Decimal saldopendiente = Convert.ToDecimal(txtSaldoPendiente.Text);


            if (ws.updatePrestamos (idprestamo ,ventas, abonodeuda, saldopendiente) == 1)
            {

                MessageBox.Show("Datos Actualizados", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudieron actualizar los datos", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgPrestamos.ItemsSource = ws.getAllPrestamos();
            limpiarprestamo();
            nuevoprestamo();
        }

        private void btnEliminarPrestamos_Click(object sender, RoutedEventArgs e)
        {
            Int32 idprestamo = Convert.ToInt32(txtidprestamo.Text);
            

            if (ws.deletePrestamos (idprestamo) == 1)
            {

                MessageBox.Show("Datos eliminados", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudieron eliminar los datos", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgPrestamos.ItemsSource = ws.getAllPrestamos();
            limpiarprestamo();
            nuevoprestamo();
        }

        private void btnCancelarPRestamos_Click(object sender, RoutedEventArgs e)
        {
            limpiarprestamo();
            nuevoprestamo();
        }

        private void limpiarprestamo ()
        {
            txtidprestamo.Clear();
            cmbVentaprestamo.SelectedIndex = -1;
            txtAbonoDeuda.Clear();
            txtSaldoPendiente.Clear();

        }

        private void nuevoprestamo ()
        {
            btnEliminarPrestamos.IsEnabled = false;
            btnEditarPrestamos.IsEnabled = false;
            btnGuardarPrestamos.IsEnabled = true;
        }

        private void dtgdetavent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var detavent  = (ServicioZapateriaReferenciab.detalles_de_venta)dtgdetavent .SelectedItem;

            if (detavent != null)
            {
                this.txtiddetavent.Text = "" + detavent.Id_detalleVenta ;
                this.cmbventadetavent .SelectedValue = detavent.Ventas;
                this.cmbproductodetavent .SelectedValue = detavent.Zapatos ;
                this.cmbempleadodetavent .SelectedValue = detavent.Empleados ;
                this.txttotalpagardetavent .Text = "" + detavent.TotalPagar1 ;
                this.txtcantidadproductodetanvet .Text = "" + detavent.CantidadProducto1;

                btneliminardetavent .IsEnabled = true;
                btneditardetavent .IsEnabled = true;
                btnguardardetavent .IsEnabled = false;
            }
        }

        private void btnguardardetavent_Click(object sender, RoutedEventArgs e)
        {
            Int32 ventas = Convert.ToInt32(cmbventadetavent.SelectedValue);
            Int32 zapatos = Convert.ToInt32(cmbproductodetavent.SelectedValue);
            Int32 empleados = Convert.ToInt32(cmbempleadodetavent.SelectedValue);
            Decimal totalpagar = Convert.ToDecimal(txttotalpagardetavent.Text);
            Int32 cantproducto = Convert.ToInt32(txtcantidadproductodetanvet.Text);


            if (ws.agregarDetavent (ventas ,zapatos ,empleados ,cantproducto ,totalpagar ) == 1)
            {

                MessageBox.Show("Nueva venta agregada", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudo agregar la venta", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgdetavent.ItemsSource = ws.getAllDetavent();
            limpiardetavent();
            nuevodetavent();
        }

        private void btneditardetavent_Click(object sender, RoutedEventArgs e)
        {
            Int32 iddetavent = Convert.ToInt32(txtiddetavent.Text);
            Int32 ventas = Convert.ToInt32(cmbventadetavent .SelectedValue);
            Int32 zapatos = Convert.ToInt32(cmbproductodetavent .SelectedValue);
            Int32 empleados = Convert.ToInt32(cmbempleadodetavent .SelectedValue);
            Decimal totalpagar = Convert.ToDecimal(txttotalpagardetavent .Text);
            Int32 cantproducto = Convert.ToInt32(txtcantidadproductodetanvet.Text);


            if (ws.updateDetavent (iddetavent ,ventas, zapatos, empleados, cantproducto, totalpagar) == 1)
            {

                MessageBox.Show("Datos modificados", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudieron modificar los datos", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgdetavent.ItemsSource = ws.getAllDetavent();
            limpiardetavent();
            nuevodetavent();
        }

        private void btneliminardetavent_Click(object sender, RoutedEventArgs e)
        {
            Int32 iddetavent = Convert.ToInt32(txtiddetavent.Text);


            if (ws.deleteDetavent (iddetavent) == 1)
            {

                MessageBox.Show("Datos eliminados", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudieron eliminar los datos", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dtgdetavent.ItemsSource = ws.getAllDetavent();
            limpiardetavent();
            nuevodetavent();
        }

        private void btncancelardetavent_Click(object sender, RoutedEventArgs e)
        {
            limpiardetavent();
            nuevodetavent();
        }

        private void limpiardetavent ()
        {
            txtiddetavent.Clear();
            cmbventadetavent.SelectedIndex = -1;
            cmbproductodetavent.SelectedIndex = -1;
            cmbempleadodetavent.SelectedIndex = -1;
            txttotalpagardetavent.Clear();
            txtcantidadproductodetanvet.Clear();

        }

        private void nuevodetavent ()
        {
            btneliminardetavent.IsEnabled = false;
            btneditardetavent.IsEnabled = false ;
            btnguardardetavent.IsEnabled = true ;
        }

        private void dtgClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cliente  = (ServicioZapateriaReferenciab.clientes )dtgClientes .SelectedItem;

            if (cliente != null)
            {
                this.txtidcliente .Text = "" + cliente.Id_cliente ;
                this.txtnombrecliente .Text = cliente.NomCliente1;
                this.txtapellidocliente .Text = cliente.ApeCliente1 ;
                this.txttelefonocliente .Text = cliente.TelCliente1 ;
                this.txtdireccióncliente .Text = cliente.DireccionCliente1;


                btneliminarcliente .IsEnabled = true;
                btneditarcliente .IsEnabled = true;
                btnguardarcliente  .IsEnabled = false;
            }
        }

        private void btnguardarcliente_Click(object sender, RoutedEventArgs e)
        {
            String nombre = txtnombrecliente .Text;
            String apellido = txtapellidocliente .Text;
            String telefono = txttelefonocliente .Text;
            String direccion  = txtdireccióncliente .Text;


            if (ws.agregarCliente (nombre, apellido, telefono, direccion) == 1)
            {

                MessageBox.Show("Nuevo cliente agregado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudo agregar el cliente", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        
        }

        private void btneditarcliente_Click(object sender, RoutedEventArgs e)
        {
            Int32 idcliente = Convert.ToInt32(txtidcliente.Text);
            String nombre = txtnombrecliente.Text;
            String apellido = txtapellidocliente.Text;
            String telefono = txttelefonocliente.Text;
            String direccion = txtdireccióncliente.Text;


            if (ws.updateClientes( idcliente ,nombre, apellido, telefono, direccion) == 1)
            {

                MessageBox.Show("Datos actualizados", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudieron actualizar los datos", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btneliminarcliente_Click(object sender, RoutedEventArgs e)
        {
            Int32 idcliente = Convert.ToInt32(txtidcliente.Text);
            


            if (ws.deleteClientes (idcliente) == 1)
            {

                MessageBox.Show("Datos eliminados", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No se pudieron eliminar los datos", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btncancelarcliente_Click(object sender, RoutedEventArgs e)
        {
            limpiarcliente();
            nuevocliente();
        }

        private void limpiarcliente()
        {
            txtidcliente.Clear();
            txtnombrecliente.Clear();
            txtapellidocliente.Clear();
            txttelefonocliente.Clear();
            txtdireccióncliente.Clear();
        }

        private void nuevocliente ()
        {
            btneliminarcliente.IsEnabled = false ;
            btneditarcliente.IsEnabled = false ;
            btnguardarcliente.IsEnabled = true ;
        }

    }
    }

