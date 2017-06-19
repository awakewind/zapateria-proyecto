using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zapateria_clases
{
    public class estilos
    {
        private Int32 id_estilo;
        private String NomEstilo, Descripcíon, GeneroEstilo;

        public string Descripcíon1
        {
            get
            {
                return Descripcíon;
            }

            set
            {
                Descripcíon = value;
            }
        }

        public string GeneroEstilo1
        {
            get
            {
                return GeneroEstilo;
            }

            set
            {
                GeneroEstilo = value;
            }
        }

        public int Id_estilo
        {
            get
            {
                return id_estilo;
            }

            set
            {
                id_estilo = value;
            }
        }

        public string NomEstilo1
        {
            get
            {
                return NomEstilo;
            }

            set
            {
                NomEstilo = value;
            }
        }
    }
}
