using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de ComisionServiceImpl
/// </summary>
public class ComisionServiceImpl : ComisionesService
{
    conexion conn = null;
    public ComisionServiceImpl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int add(comisiones comision)
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
            command.CommandText = "INSERT INTO comisiones(empleados,ValorComision,ventas) VALUES(@empleados,@ValorComision,@ventas)";
            command.Parameters.Add("@empleados", SqlDbType.Int);
            command.Parameters.Add("@ValorComision", SqlDbType.Decimal);
            command.Parameters.Add("@ventas", SqlDbType.Int);
            command.Parameters["@empleados"].Value = comision.Empleados;
            command.Parameters["@ValorComision"].Value = comision.ValorComision1;
            command.Parameters["@ventas"].Value = comision.Ventas;

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

    public List<comisiones> findAll()
    {
        List<comisiones> lista = new List<comisiones>(0);
        conn = new conexion();
        SqlCommand command = new SqlCommand("SELECT * FROM comisiones", conn.getConn());
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            comisiones comision  = new comisiones();
            comision.Id_comision = rd.GetInt32(0);
            comision.Empleados = rd.GetInt32(1);
            comision.ValorComision1 = rd.GetDecimal (2);
            comision.Ventas = rd.GetInt32(3);
            lista.Add(comision);
        }
        rd.Close();
        conn.cerrar();
        return lista;
    }

    public comisiones findById(int id_comision)
    {
        comisiones comision   = null;
        String sqlString = "SELECT * FROM comisiones WHERE id_comision = @id_comision";
        conn = new conexion();
        SqlCommand command = new SqlCommand(sqlString, conn.getConn());
        command.Parameters.Add("@id_comision", SqlDbType.Int);
        command.Parameters["@id_comision"].Value = id_comision;
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            comision = new comisiones();
            comision.Ventas = rd.GetInt32(2);
            comision.ValorComision1 = rd.GetDecimal (1);
            comision.Empleados = rd.GetInt32(0);
        }
        rd.Close();
        conn.cerrar();
        return comision;
    }

    public int remove(comisiones comision)
    {
        int a = 0;
        String query = "DELETE FROM comisiones WHERE id_comision = @id_comision";
        conn = new conexion();
        SqlCommand command = conn.getConn().CreateCommand();
        SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conn.getConn();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_comision", SqlDbType.Int);
            command.Parameters["@id_comision"].Value = comision.Id_comision;
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

    public int update(comisiones comision)
    {
        int a = 0;
        String query = "UPDATE comisiones SET empleados = @empleados, ValorComision = @ValorComision, ventas = @ventas WHERE id_comision = @id_comision";
        conn = new conexion();
        SqlCommand command = conn.getConn().CreateCommand();
        SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conn.getConn();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_comision", SqlDbType.Int);
            command.Parameters["@id_comision"].Value = comision.Id_comision;
            command.Parameters.Add("@empleados", SqlDbType.Int);
            command.Parameters.Add("@ValorComision", SqlDbType.Decimal);
            command.Parameters.Add("@ventas", SqlDbType.Int);
            command.Parameters["@empleados"].Value = comision.Empleados;
            command.Parameters["@ValorComision"].Value = comision.ValorComision1;
            command.Parameters["@ventas"].Value = comision.Ventas;
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