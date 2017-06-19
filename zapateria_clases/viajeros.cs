using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zapateria_clases
{
    public class viajeros
    {
        private Int32 id_viajero, proveedores;
        private String NomViajero, ApeViajero, TelefonoViajero, CorreoViajero;

        public string ApeViajero1
        {
            get
            {
                return ApeViajero;
            }

            set
            {
                ApeViajero = value;
            }
        }

        public string CorreoViajero1
        {
            get
            {
                return CorreoViajero;
            }

            set
            {
                CorreoViajero = value;
            }
        }

        public int Id_viajero
        {
            get
            {
                return id_viajero;
            }

            set
            {
                id_viajero = value;
            }
        }

        public string NomViajero1
        {
            get
            {
                return NomViajero;
            }

            set
            {
                NomViajero = value;
            }
        }

        public int Proveedores
        {
            get
            {
                return proveedores;
            }

            set
            {
                proveedores = value;
            }
        }

        public string TelefonoViajero1
        {
            get
            {
                return TelefonoViajero;
            }

            set
            {
                TelefonoViajero = value;
            }
        }
    }
}