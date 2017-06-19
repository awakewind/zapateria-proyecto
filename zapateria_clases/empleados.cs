using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zapateria_clases
{
    public class empleados
    {
        private Int32 id_empleado, cargos;
        private String nomempleado, apeempleado, numtellempleado, direcempleado, duiempleado, nitempleado;
        private DateTime fechanacempleado;

        public int Id_empleado
        {
            get
            {
                return id_empleado;
            }

            set
            {
                id_empleado = value;
            }
        }

        public int Cargos
        {
            get
            {
                return cargos;
            }

            set
            {
                cargos = value;
            }
        }

        public string Nomempleado
        {
            get
            {
                return nomempleado;
            }

            set
            {
                nomempleado = value;
            }
        }

        public string Apeempleado
        {
            get
            {
                return apeempleado;
            }

            set
            {
                apeempleado = value;
            }
        }

        public string Numtellempleado
        {
            get
            {
                return numtellempleado;
            }

            set
            {
                numtellempleado = value;
            }
        }

        public string Direcempleado
        {
            get
            {
                return direcempleado;
            }

            set
            {
                direcempleado = value;
            }
        }

        public string Duiempleado
        {
            get
            {
                return duiempleado;
            }

            set
            {
                duiempleado = value;
            }
        }

        public string Nitempleado
        {
            get
            {
                return nitempleado;
            }

            set
            {
                nitempleado = value;
            }
        }

        public DateTime Fechanacempleado
        {
            get
            {
                return fechanacempleado;
            }

            set
            {
                fechanacempleado = value;
            }
        }
    }
}
