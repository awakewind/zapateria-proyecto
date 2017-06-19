using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zapateria_clases
{
    public class proveedores
    {
        private Int32 id_proveedor;
        private String NomEmpresa, TelefonoEmpresa, CorreoEmpresa;

        public string CorreoEmpresa1
        {
            get
            {
                return CorreoEmpresa;
            }

            set
            {
                CorreoEmpresa = value;
            }
        }

        public int Id_proveedor
        {
            get
            {
                return id_proveedor;
            }

            set
            {
                id_proveedor = value;
            }
        }

        public string NomEmpresa1
        {
            get
            {
                return NomEmpresa;
            }

            set
            {
                NomEmpresa = value;
            }
        }

        public string TelefonoEmpresa1
        {
            get
            {
                return TelefonoEmpresa;
            }

            set
            {
                TelefonoEmpresa = value;
            }
        }
    }
}
