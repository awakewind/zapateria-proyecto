using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zapateria_clases
{

    public class cargos
    {
        private Int32 id_cargo;
        private String NomCargo, DescripcionCargo;
        private Decimal Salario;

        public string DescripcionCargo1
        {
            get
            {
                return DescripcionCargo;
            }

            set
            {
                DescripcionCargo = value;
            }
        }

        public int Id_cargo
        {
            get
            {
                return id_cargo;
            }

            set
            {
                id_cargo = value;
            }
        }

        public string NomCargo1
        {
            get
            {
                return NomCargo;
            }

            set
            {
                NomCargo = value;
            }
        }

        public Decimal   Salario1
        {
            get
            {
                return Salario;
            }

            set
            {
                Salario = value;
            }
        }
    }
}
