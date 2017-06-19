using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;

/// <summary>
/// Descripción breve de PedidosService
/// </summary>
public interface PedidosService
{
    int add(pedidos  pedido );
    int update(pedidos  pedido );
    int remove(pedidos  pedido );

    pedidos  findById(Int32 id_pedido );

    List<pedidos > findAll();
}