using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zapateria_clases
{
    public class prestamos
    {
        private Int32 id_prestamo, ventas;
        private Decimal  AbonoDeuda, SaldoPendiente;

        public int Id_prestamo
        {
            get
            {
                return id_prestamo;
            }

            set
            {
                id_prestamo = value;
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

        public Decimal AbonoDeuda1
        {
            get
            {
                return AbonoDeuda;
            }

            set
            {
                AbonoDeuda = value;
            }
        }

        public Decimal SaldoPendiente1
        {
            get
            {
                return SaldoPendiente;
            }

            set
            {
                SaldoPendiente = value;
            }
        }
    }
}
