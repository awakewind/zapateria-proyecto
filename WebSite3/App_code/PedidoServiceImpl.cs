using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de PedidoServiceImpl
/// </summary>
public class PedidoServiceImpl : PedidosService 
{
    conexion conn = null;
    public PedidoServiceImpl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int add(pedidos pedido)
    {
        int a = 0;
        conn = new conexion();
        SqlTransaction tran;
        SqlCommand command = conn.getConn().CreateCommand();
        tran = conn.getConn().BeginTransaction("simpleTransicion");
        try
        {
            command.Connection = conn.getConn();
            command.Transaction = tran;
            command.CommandText = "INSERT INTO pedidos(viajeros,zapatos,CantidadPedido,CostoTotal) VALUES(@viajeros,@zapatos,@CantidadPedido,@CostoTotal)";
            command.Parameters.Add("@viajeros", SqlDbType.Int);
            command.Parameters.Add("@zapatos", SqlDbType.Int);
            command.Parameters.Add("@CantidadPedido", SqlDbType.Int);
            command.Parameters.Add("@CostoTotal", SqlDbType.Decimal);
            command.Parameters["@viajeros"].Value = pedido.Viajeros;
            command.Parameters["@zapatos"].Value = pedido .Zapatos;
            command.Parameters["@CantidadPedido"].Value = pedido .CantidadPedido1 ;
            command.Parameters["@CostoTotal"].Value = pedido .CostoTotal1 ;
            command.ExecuteNonQuery();
            tran.Commit();
            a = 1;
        }
        catch (Exception e)
        {
            tran.Rollback();
        }
        finally
        {
            conn.cerrar();
        }
        return a;
    }

    public List<pedidos> findAll()
    {
        List<pedidos > lista = new List<pedidos >(0);
        conn = new conexion();
        SqlCommand command = new SqlCommand("SELECT * FROM pedidos", conn.getConn());
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            pedidos  pedido  = new pedidos ();
            pedido  .Id_pedido  = rd.GetInt32(0);
            pedido .Viajeros  = rd.GetInt32(1);
            pedido .Zapatos = rd.GetInt32(2);
            pedido .CantidadPedido1  = rd.GetInt32(3);
            pedido .CostoTotal1  = rd.GetDouble(4);
           
            lista.Add(pedido );
        }
        rd.Close();
        conn.cerrar();
        return lista;
    }

    public pedidos findById(int id_pedido)
    {
        pedidos  pedido  = null;
        String sqlString = "SELECT * FROM pedidos WHERE id_pedido = @id_pedido";
        conn = new conexion();
        SqlCommand command = new SqlCommand(sqlString, conn.getConn());
        command.Parameters.Add("@id_pedido", SqlDbType.Int);
        command.Parameters["@id_pedido"].Value = id_pedido ;
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            pedido.Id_pedido = rd.GetInt32(0);
            pedido.Viajeros = rd.GetInt32(1);
            pedido.Zapatos = rd.GetInt32(2);
            pedido.CantidadPedido1 = rd.GetInt32(3);
            pedido.CostoTotal1 = rd.GetDouble(4);
        }
        rd.Close();
        conn.cerrar();
        return pedido ;
    }

    public int remove(pedidos pedido)
    {
        int a = 0;
        String query = "DELETE * FROM pedidos WHERE pedidos = @id_pedido";
        conn = new conexion();
        SqlCommand command = conn.getConn().CreateCommand();
        SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conn.getConn();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_pedido", SqlDbType.Int);
            command.Parameters["@id_pedido"].Value = pedido .Id_pedido ;
            command.ExecuteNonQuery();
            trans.Commit();
            a = 1;
        }
        catch (Exception e)
        {
            trans.Rollback();
        }
        finally
        {
            conn.cerrar();
        }
        return a;
    }

    public int update(pedidos pedido)
    {
        int a = 0;
        String query = "UPDATE pedidos SET viajeros = @viajeros, zapatos = @zapatos, CantidadPedido = @CantidadPedido, CostoTotal = @CostoTotal WHERE id_pedido = @id_pedido";
        conn = new conexion();
        SqlCommand command = conn.getConn().CreateCommand();
        SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conn.getConn();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_pedido", SqlDbType.Int);
            command.Parameters["@id_pedido"].Value = pedido .Id_pedido ;
            command.Parameters.Add("@viajeros", SqlDbType.Int);
            command.Parameters.Add("@zapatos", SqlDbType.Int);
            command.Parameters.Add("@CantidadPedido", SqlDbType.Int);
            command.Parameters.Add("@CostoTotal", SqlDbType.Decimal);
            command.Parameters["@viajeros"].Value = pedido.Viajeros;
            command.Parameters["@zapatos"].Value = pedido.Zapatos;
            command.Parameters["@CantidadPedido"].Value = pedido.CantidadPedido1;
            command.Parameters["@CostoTotal"].Value = pedido.CostoTotal1;
            trans.Commit();
            a = 1;
        }
        catch (Exception e)
        {
            trans.Rollback();
        }
        finally
        {
            conn.cerrar();
        }
        return a;
    }
}