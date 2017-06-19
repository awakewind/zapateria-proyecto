using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;
/// <summary>
/// Descripción breve de MarcasService
/// </summary>
public interface MarcasService
{
    int add(marcas  marca);
    int update(marcas marca);
    int remove(marcas  marca );

    marcas  findById(Int32 id_marcas );

    List<marcas> findAll();
}