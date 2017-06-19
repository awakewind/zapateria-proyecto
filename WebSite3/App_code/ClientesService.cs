using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;

/// <summary>
/// Descripción breve de ClientesService
/// </summary>
public interface ClientesService
{
    int add(clientes cliente );
    int update(clientes cliente);
    int remove(clientes cliente );

    clientes findById(Int32 id_cliente);

    List<clientes> findByField(string param);
    List<clientes> findAll();
}