using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;
/// <summary>
/// Descripción breve de ViajeroService
/// </summary>
public interface ViajeroService
{
    int add(viajeros  viajero );
    int update(viajeros viajero);
    int remove(viajeros viajero);

    viajeros findById(Int32 id_viajero );

    List<viajeros > findAll();
}