using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zapateria_clases
{
    public class marcas
    {
        private Int32 id_marcas;
        private String NomMarca;

        public int Id_marcas
        {
            get
            {
                return id_marcas;
            }

            set
            {
                id_marcas = value;
            }
        }

        public string NomMarca1
        {
            get
            {
                return NomMarca;
            }

            set
            {
                NomMarca = value;
            }
        }
    }
}
