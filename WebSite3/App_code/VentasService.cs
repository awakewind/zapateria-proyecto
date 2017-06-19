using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;
/// <summary>
/// Descripción breve de VentasService
/// </summary>
public interface  VentasService
{
    int add(ventas  venta );
    int update(ventas  venta );
    int remove(ventas  venta );

    ventas  findById(Int32 id_venta );

    List<ventas > findAll();
}