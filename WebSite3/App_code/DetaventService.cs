using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;

/// <summary>
/// Descripción breve de DetaventService
/// </summary>
public interface DetaventService
{
    int add(detalles_de_venta detavent );
    int update(detalles_de_venta detavent );
    int remove(detalles_de_venta detavent );

    detalles_de_venta findById(Int32 id_detalleVenta );

    List<detalles_de_venta> findAll();
}