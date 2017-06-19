using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;

/// <summary>
/// Descripción breve de PrestamoService
/// </summary>
public interface PrestamoService
{
    int add( prestamos prestamo);
    int update(prestamos  prestamo );
    int remove(prestamos  prestamo );

    prestamos  findById(Int32 id_prestamo);

    List<prestamos > findAll();
}