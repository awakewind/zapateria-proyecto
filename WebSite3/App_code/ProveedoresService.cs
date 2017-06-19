using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;

/// <summary>
/// Descripción breve de ProveedoresService
/// </summary>
public interface  ProveedoresService
{
    int add(proveedores  proveedor );
    int update(proveedores  proveedor );
    int remove(proveedores  proveedor );

    proveedores  findById(Int32 id_proveedor );

    List<proveedores > findAll();
}