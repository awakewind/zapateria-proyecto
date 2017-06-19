using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de DetaventServiceImpl
/// </summary>
public class DetaventServiceImpl : DetaventService
{
    conexion conn = null;
    public DetaventServiceImpl()

    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int add(detalles_de_venta detavent)
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
            command.CommandText = "INSERT INTO detalles_de_venta(ventas,zapatos,empleados,TotalPagar,CantidadProducto) VALUES(@ventas,@zapatos,@empleados,@TotalPagar,@CantidadProducto)";
            command.Parameters.Add("@ventas", SqlDbType.Int);
            command.Parameters.Add("@zapatos", SqlDbType.Int);
            command.Parameters.Add("@empleados", SqlDbType.Int);
            command.Parameters.Add("@TotalPagar", SqlDbType.Decimal);
            command.Parameters.Add("@CantidadProducto", SqlDbType.Int);
            command.Parameters["@ventas"].Value = detavent.Ventas;
            command.Parameters["@zapatos"].Value = detavent.Zapatos;
            command.Parameters["@empleados"].Value = detavent.Empleados;
            command.Parameters["@TotalPagar"].Value = detavent.TotalPagar1;
            command.Parameters["@CantidadProducto"].Value = detavent.CantidadProducto1;
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

    public List<detalles_de_venta> findAll()
    {
        List<detalles_de_venta> lista = new List<detalles_de_venta>(0);
        conn = new conexion();
        SqlCommand command = new SqlCommand("SELECT * FROM detalles_de_venta", conn.getConn());
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            detalles_de_venta detavent  = new detalles_de_venta();
            detavent.Id_detalleVenta = rd.GetInt32(0);
            detavent.Ventas = rd.GetInt32(1);
            detavent.Zapatos = rd.GetInt32(2);
            detavent.Empleados = rd.GetInt32(3);
            detavent.TotalPagar1 = rd.GetDecimal(4);
            detavent.CantidadProducto1 = rd.GetInt32(5);
            lista.Add(detavent);
        }
        rd.Close();
        conn.cerrar();
        return lista;
    }

    public detalles_de_venta findById(int id_detalleVenta)
    {
        detalles_de_venta datavent  = null;
        String sqlString = "SELECT * FROM detalles_de_venta WHERE id_detalleVenta = @id_detalleVenta";
        conn = new conexion();
        SqlCommand command = new SqlCommand(sqlString, conn.getConn());
        command.Parameters.Add("@id_detalleVenta", SqlDbType.Int);
        command.Parameters["@id_detalleVenta"].Value = id_detalleVenta;
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            datavent.Id_detalleVenta = rd.GetInt32(0);
            datavent.Ventas = rd.GetInt32(1);
            datavent.Zapatos = rd.GetInt32(2);
            datavent.Empleados = rd.GetInt32(3);
            datavent.TotalPagar1 = rd.GetDecimal(4);
            datavent.CantidadProducto1 = rd.GetInt32(5);
        }
        rd.Close();
        conn.cerrar();
        return datavent;
    }

    public int remove(detalles_de_venta detavent)
    {
        int a = 0;
        String query = "DELETE FROM detalles_de_venta WHERE id_detalleVenta = @id_detalleVenta";
        conn = new conexion();
        SqlCommand command = conn.getConn().CreateCommand();
        SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conn.getConn();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_detalleVenta", SqlDbType.Int);
            command.Parameters["@id_detalleVenta"].Value = detavent.Id_detalleVenta;
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

    public int update(detalles_de_venta detavent)
    {
        int a = 0;
        String query = "UPDATE detalles_de_venta SET ventas = @ventas, zapatos = @zapatos, empleados = @empleados, TotalPagar = @TotalPagar, CantidadProducto = @CantidadProducto WHERE id_detalleVenta = @id_detalleVenta";
        conn = new conexion();
        SqlCommand command = conn.getConn().CreateCommand();
        SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conn.getConn();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_detalleVenta", SqlDbType.Int);
            command.Parameters["@id_detalleVenta"].Value = detavent.Id_detalleVenta;
            command.Parameters.Add("@ventas", SqlDbType.Int);
            command.Parameters.Add("@zapatos", SqlDbType.Int);
            command.Parameters.Add("@empleados", SqlDbType.Int);
            command.Parameters.Add("@TotalPagar", SqlDbType.Decimal);
            command.Parameters.Add("@CantidadProducto", SqlDbType.Int);
            command.Parameters["@ventas"].Value = detavent.Ventas;
            command.Parameters["@zapatos"].Value = detavent.Zapatos;
            command.Parameters["@empleados"].Value = detavent.Empleados;
            command.Parameters["@TotalPagar"].Value = detavent.TotalPagar1;
            command.Parameters["@CantidadProducto"].Value = detavent.CantidadProducto1;
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
    }