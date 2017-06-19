using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zapateria_clases
{
   public class clientes
    {
        private Int32 id_cliente;
        private String NomCliente, ApeCliente, TelCliente, DireccionCliente;

        public string ApeCliente1
        {
            get
            {
                return ApeCliente;
            }

            set
            {
                ApeCliente = value;
            }
        }

        public string DireccionCliente1
        {
            get
            {
                return DireccionCliente;
            }

            set
            {
                DireccionCliente = value;
            }
        }

        public int Id_cliente
        {
            get
            {
                return id_cliente;
            }

            set
            {
                id_cliente = value;
            }
        }

        public string NomCliente1
        {
            get
            {
                return NomCliente;
            }

            set
            {
                NomCliente = value;
            }
        }

        public string TelCliente1
        {
            get
            {
                return TelCliente;
            }

            set
            {
                TelCliente = value;
            }
        }
    }
}
