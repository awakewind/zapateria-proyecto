using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Descripción breve de VentaServiceImpl
/// </summary>
public class VentaServiceImpl : VentasService 
{
    conexion conn = null;
    public VentaServiceImpl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int add(ventas venta)
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
            command.CommandText = "INSERT INTO ventas(FechaVenta,clientes) VALUES(@FechaVenta,@clientes)";
            command.Parameters.Add("@FechaVenta", SqlDbType.Date );
            command.Parameters.Add("@clientes", SqlDbType.Int );
            command.Parameters["@FechaVenta"].Value = venta.FechaVenta1 ;
            command.Parameters["@clientes"].Value = venta .Clientes;
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

    public List<ventas> findAll()
    {
        List<ventas > lista = new List<ventas >(0);
        conn = new conexion();
        SqlCommand command = new SqlCommand("SELECT * FROM ventas", conn.getConn());
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            ventas  venta  = new ventas ();
            venta .Id_venta = rd.GetInt32(0);
            venta .FechaVenta1  = rd.GetDateTime(1);
            venta .Clientes = rd.GetInt32(2);

            lista.Add(venta );
        }
        rd.Close();
        conn.cerrar();
        return lista;
    }

    public ventas findById(int id_venta)
    {
        ventas  venta  = null;
        String sqlString = "SELECT * FROM ventas WHERE id_venta = @id_venta";
        conn = new conexion();
        SqlCommand command = new SqlCommand(sqlString, conn.getConn());
        command.Parameters.Add("@id_venta", SqlDbType.Int);
        command.Parameters["@id_venta"].Value = id_venta ;
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            venta.Id_venta = rd.GetInt32(0);
            venta.FechaVenta1 = rd.GetDateTime(1);
            venta.Clientes = rd.GetInt32(2);
        }
        rd.Close();
        conn.cerrar();
        return venta ;
    }

    public int remove(ventas venta)
    {
        int a = 0;
        String query = "DELETE * FROM ventas WHERE ventas = @id_venta";
        conn = new conexion();
        SqlCommand command = conn.getConn().CreateCommand();
        SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conn.getConn();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_venta", SqlDbType.Int);
            command.Parameters["@id_venta"].Value = venta.Id_venta;
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

    public int update(ventas venta)
    {
        int a = 0;
        String query = "UPDATE ventas SET FechaVenta = @FechaVenta, clientes = @clientes WHERE id_venta = @id_venta";
        conn = new conexion();
        SqlCommand command = conn.getConn().CreateCommand();
        SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conn.getConn();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_venta", SqlDbType.Int);
            command.Parameters["@id_venta"].Value = venta.Id_venta ;
            command.Parameters.Add("@FechaVenta", SqlDbType.Date);
            command.Parameters.Add("@clientes", SqlDbType.Int);
            command.Parameters["@FechaVenta"].Value = venta.FechaVenta1;
            command.Parameters["@clientes"].Value = venta.Clientes;
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