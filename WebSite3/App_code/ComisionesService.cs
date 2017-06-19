using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;

/// <summary>
/// Descripción breve de ComisionesService
/// </summary>
public interface ComisionesService
{
    int add(comisiones comision );
    int update(comisiones comision );
    int remove(comisiones  comision );

    comisiones findById(Int32 id_comision);

    List<comisiones> findAll();
}