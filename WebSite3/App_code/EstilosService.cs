using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;
/// <summary>
/// Descripción breve de EstilosService
/// </summary>
public interface EstilosService
{
    int add(estilos estilo );
    int update(estilos estilo );
    int remove(estilos estilo );

    estilos findById(Int32 id_estilo );

    List<estilos> findAll();
}