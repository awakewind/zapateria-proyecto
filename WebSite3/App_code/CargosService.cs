using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;

/// <summary>
/// Descripción breve de CargosService
/// </summary>
public interface CargosService
{
    int add(cargos cargo);
    int update(cargos cargos);
    int remove(cargos cargos);

    cargos findById(Int32 id_cargo);

    List<cargos> findAll();

}