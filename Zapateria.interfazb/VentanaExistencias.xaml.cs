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
using zapateria_clases;

namespace Zapateria.interfazb
{
    /// <summary>
    /// Lógica de interacción para VentanaExistencias.xaml
    /// </summary>
    public partial class VentanaExistencias : Window
    {
        ServicioZapateriaReferenciab.zapateriawsSoapClient ws = new ServicioZapateriaReferenciab.zapateriawsSoapClient();
        MainWindow window = new MainWindow();

        public VentanaExistencias()
        {
            InitializeComponent();
        }



        private void Window_Activated(object sender, EventArgs e)
        {
            dtgZapatos.ItemsSource = ws.getAllZapato();
            var productos = ws.getAllZapato();
            cmbProducto.ItemsSource = productos;
            cmbProducto.DisplayMemberPath = "NomGaZapato1";
            cmbProducto.SelectedValuePath = "Id_zapatos";
        }



        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Int32 id = Convert.ToInt32(cmbProducto.SelectedValue);

            List<zapatos> lista = new List<zapatos>(0);

            zapatos zapato = new zapatos() ;
            zapato.Id_zapatos = ws .getZapatoById (id ).Id_zapatos ;
            zapato.NomGaZapato1 = ws.getZapatoById(id).NomGaZapato1 ;
            zapato.Estilos = ws.getZapatoById(id).Estilos ;
            zapato.Marcas = ws.getZapatoById(id).Marcas ;
            zapato.TallasDisponibles1 = ws.getZapatoById(id).TallasDisponibles1 ;
            zapato.CantidadDisponible1 = ws.getZapatoById(id).CantidadDisponible1 ;
            zapato.ColoresGama1 = ws.getZapatoById(id).ColoresGama1 ;
            zapato.Viajeros = ws.getZapatoById(id).Viajeros ;
            lista.Add(zapato);

            dtgZapatos.ItemsSource = lista;


        }
    }
}
