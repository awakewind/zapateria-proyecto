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

namespace Zapateria.interfazb
{
    /// <summary>
    /// Lógica de interacción para VentanaVentas.xaml
    /// </summary>
    public partial class VentanaVentas : Window
    {
        ServicioZapateriaReferenciab.zapateriawsSoapClient ws = new ServicioZapateriaReferenciab.zapateriawsSoapClient();
        MainWindow window = new MainWindow();
        public VentanaVentas()
        {
            InitializeComponent();
        }

        private void btnagregar_Click(object sender, RoutedEventArgs e)
        {
            
            Int32 codeventa = 1;
            Int32 codcliente;
            Int32 codproducto;
            Int32 codempleado;
            Int32 cantproducto;
            Decimal totalpagar;

      


            if (!cmbCliente.Text.Equals(""))
            {
                codcliente = Convert.ToInt32(cmbCliente.SelectedValue);
                if (!cmbProducto.Text.Equals(""))
                {
                    codproducto = Convert.ToInt32(cmbProducto.SelectedValue);
                    if (!cmbEmpleado.Text.Equals(""))
                    {
                        codempleado = Convert.ToInt32(cmbEmpleado.SelectedValue);
                        cantproducto = comprobarint(txtcantproducto.Text);
                        if (cantproducto != 0)
                        {
                            cantproducto = comprobarint(txtcantproducto.Text);
                            totalpagar = comprobardecimal(txttotalpagar.Text);
                            if (totalpagar != 0)
                            {
                                totalpagar = comprobardecimal(txttotalpagar.Text);
                                if (ws.agregarVenta(DateTime.Today, codcliente) == 1)
                                {

                                    if (ws.agregarDetavent(codeventa, codproducto, codempleado, cantproducto, totalpagar) == 1)
                                    {
                                        MessageBox.Show("Nueva venta agregada", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

                                        
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo agregar la venta", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                        }

                        
                       
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese un valor", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese un valor", "Información", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese un valor", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
               
            }


        }

        private void Window_Activated(object sender, EventArgs e)
        {
            lblFecha.Content = DateTime.Today;


            var clientes = ws.getAllClientes();
            cmbCliente.ItemsSource = clientes;
            cmbCliente.DisplayMemberPath = "NomCliente1";
            cmbCliente.SelectedValuePath = "Id_cliente";
            var productos = ws.getAllZapato();
            cmbProducto.ItemsSource = productos;
            cmbProducto.DisplayMemberPath = "NomGaZapato1";
            cmbProducto.SelectedValuePath = "Id_zapatos";
            var empleado = ws.getAllEmpleados();
            cmbEmpleado.ItemsSource = empleado;
            cmbEmpleado.DisplayMemberPath = "Nomempleado";
            cmbEmpleado.SelectedValuePath = "Id_empleado";



        }

        private void btnfinalizar_Click(object sender, RoutedEventArgs e)
        {
            Int32 codeventa = 1;
            Int32 codcliente;
            Int32 codproducto;
            Int32 codempleado;
            Int32 cantproducto;
            Decimal totalpagar;

            if (!cmbCliente.Text.Equals(""))
            {
                codcliente = Convert.ToInt32(cmbCliente.SelectedValue);
                if (!cmbProducto.Text.Equals(""))
                {
                    codproducto = Convert.ToInt32(cmbProducto.SelectedValue);
                    if (!cmbEmpleado.Text.Equals(""))
                    {
                        codempleado = Convert.ToInt32(cmbEmpleado.SelectedValue);
                        cantproducto = comprobarint(txtcantproducto.Text);
                        if (cantproducto != 0)
                        {
                            cantproducto = comprobarint(txtcantproducto.Text);
                            totalpagar = comprobardecimal(txttotalpagar.Text);
                            if (totalpagar != 0)
                            {
                                totalpagar = comprobardecimal(txttotalpagar.Text);
                                if (ws.agregarVenta(DateTime.Today, codcliente) == 1)
                                {

                                    if (ws.agregarDetavent(codeventa, codproducto, codempleado, cantproducto, totalpagar) == 1)
                                    {
                                        MessageBox.Show("Nueva venta agregada", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

                                        window.Show();
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo agregar la venta", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                        }



                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese un valor", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese un valor", "Información", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese un valor", "Información", MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }

        public string comprobarstring(String texto)
        {
            String resultado = "";

            if (!texto.Equals(""))
            {
                resultado = texto;
            }
            else
            {
                MessageBox.Show("Por favor ingrese un valor", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return resultado;
        }
        public Int32 comprobarint(String numero)
        {
            Int32 resultado = 0;
            Int32 variable;
            if (!numero.Equals(""))
            {
                Boolean isNumeric = Int32.TryParse(numero, out variable);
                if (isNumeric == true)
                {

                    if (variable > 0)
                    {
                        resultado = variable;
                        return resultado;
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese un valor valido", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
                        
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese un valor valido", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
                    
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese un valor valido", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }

            return resultado;

        }

        public Decimal comprobardecimal(String numero)
        {
            Decimal resultado = 0;
            Decimal variable;
            if (!numero.Equals(""))
            {
                Boolean isNumeric = Decimal.TryParse(numero, out variable);
                if (isNumeric == true)
                {

                    if (variable > 0)
                    {
                        resultado = variable;
                        return resultado;
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese un valor valido", "Información", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese un valor valido", "Información", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese un valor valido", "Información", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            return resultado;
        }


       
    }
}






