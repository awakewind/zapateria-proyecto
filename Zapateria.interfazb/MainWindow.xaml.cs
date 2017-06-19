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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zapateria.interfazb
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void imgVentas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            VentanaVentas ventas = new VentanaVentas() ;
            ventas.Show();
           

        }

        private void imgExistencias_MouseUp(object sender, MouseButtonEventArgs e)
        {
            VentanaExistencias existe = new VentanaExistencias();
            existe.Show();
           
        }

        private void lblAdministrar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            VentanaAdministración administración = new VentanaAdministración();
            administración.Show();
            
        }
    }
}
