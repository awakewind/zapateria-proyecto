using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;
/// <summary>
/// Descripción breve de ZapatoService
/// </summary>
public interface ZapatoService
{
    int add(zapatos zapato );
    int update(zapatos zapato );
    int remove(zapatos zapato );

    zapatos findById(Int32 id_zapatos);

    List<zapatos> findAll();
}