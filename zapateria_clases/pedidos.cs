using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zapateria_clases
{
    public class pedidos
    {
        private Int32 id_pedido, viajeros, zapatos, CantidadPedido;
        private Double CostoTotal;

        public int Id_pedido
        {
            get
            {
                return id_pedido;
            }

            set
            {
                id_pedido = value;
            }
        }

        public int Viajeros
        {
            get
            {
                return viajeros;
            }

            set
            {
                viajeros = value;
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

        public int CantidadPedido1
        {
            get
            {
                return CantidadPedido;
            }

            set
            {
                CantidadPedido = value;
            }
        }

        public double CostoTotal1
        {
            get
            {
                return CostoTotal;
            }

            set
            {
                CostoTotal = value;
            }
        }
    }
}