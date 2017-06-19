using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zapateria_clases
{
    public class detalles_de_venta
    {
        private Int32 id_detalleVenta, ventas, zapatos, empleados, CantidadProducto;
        private Decimal  TotalPagar;

        public int CantidadProducto1
        {
            get
            {
                return CantidadProducto;
            }

            set
            {
                CantidadProducto = value;
            }
        }

        public int Empleados
        {
            get
            {
                return empleados;
            }

            set
            {
                empleados = value;
            }
        }

        public int Id_detalleVenta
        {
            get
            {
                return id_detalleVenta;
            }

            set
            {
                id_detalleVenta = value;
            }
        }

        public Decimal TotalPagar1
        {
            get
            {
                return TotalPagar;
            }

            set
            {
                TotalPagar = value;
            }
        }

        public int Ventas
        {
            get
            {
                return ventas;
            }

            set
            {
                ventas = value;
            }
        }

        public int Zapatos
        {
            get
            {
                return zapatos;
            }

            set
            {
                zapatos = value;
            }
        }
    }
}

