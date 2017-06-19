using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zapateria_clases
{
    public class comisiones
    {
        private Int32 id_comision, empleados, ventas;
        private Decimal  ValorComision;

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

        public int Id_comision
        {
            get
            {
                return id_comision;
            }

            set
            {
                id_comision = value;
            }
        }

        public Decimal  ValorComision1
        {
            get
            {
                return ValorComision;
            }

            set
            {
                ValorComision = value;
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
    }
}
