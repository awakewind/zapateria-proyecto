using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;

/// <summary>
/// Descripción breve de EmpleadoService
/// </summary>
public interface EmpleadoService
{
    int add(empleados empleado );
    int update(empleados empleado );
    int remove(empleados empleado );

    empleados findById(Int32 id_empleado );

    List<empleados> findAll();
}