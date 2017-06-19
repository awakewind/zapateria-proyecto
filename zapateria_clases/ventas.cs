using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zapateria_clases
{
    public class ventas
    {
        private Int32 id_venta, clientes;
        private DateTime FechaVenta;

        public int Id_venta
        {
            get
            {
                return id_venta;
            }

            set
            {
                id_venta = value;
            }
        }

        public int Clientes
        {
            get
            {
                return clientes;
            }

            set
            {
                clientes = value;
            }
        }

        public DateTime FechaVenta1
        {
            get
            {
                return FechaVenta;
            }

            set
            {
                FechaVenta = value;
            }
        }
    }
}