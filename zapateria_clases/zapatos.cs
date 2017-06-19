using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zapateria_clases
{
    public class zapatos
    {
        private Int32 id_zapatos, estilos, marcas, CantidadDisponible, viajeros;
        private String NomGaZapato, TallasDisponibles, ColoresGama;

        public int CantidadDisponible1
        {
            get
            {
                return CantidadDisponible;
            }

            set
            {
                CantidadDisponible = value;
            }
        }

        public string ColoresGama1
        {
            get
            {
                return ColoresGama;
            }

            set
            {
                ColoresGama = value;
            }
        }

        public int Estilos
        {
            get
            {
                return estilos;
            }

            set
            {
                estilos = value;
            }
        }

        public int Id_zapatos
        {
            get
            {
                return id_zapatos;
            }

            set
            {
                id_zapatos = value;
            }
        }

        public int Marcas
        {
            get
            {
                return marcas;
            }

            set
            {
                marcas = value;
            }
        }

        public string NomGaZapato1
        {
            get
            {
                return NomGaZapato;
            }

            set
            {
                NomGaZapato = value;
            }
        }

        public string TallasDisponibles1
        {
            get
            {
                return TallasDisponibles;
            }

            set
            {
                TallasDisponibles = value;
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
    }
}
