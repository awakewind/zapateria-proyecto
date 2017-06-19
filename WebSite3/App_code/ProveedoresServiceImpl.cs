using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de ProveedoresServiceImpl
/// </summary>
public class ProveedoresServiceImpl : ProveedoresService 
{
    conexion conn = null;
    public ProveedoresServiceImpl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int add(proveedores proveedor)
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
            command.CommandText = "INSERT INTO proveedores(NomEmpresa,TelefonoEmpresa,CorreoEmpresa) VALUES(@NomEmpresa,@TelefonoEmpresa,@CorreoEmpresa)";
            command.Parameters.Add("@NomEmpresa", SqlDbType.VarChar);
            command.Parameters.Add("@TelefonoEmpresa", SqlDbType.VarChar );
            command.Parameters.Add("@CorreoEmpresa", SqlDbType.VarChar );
            command.Parameters["@NomEmpresa"].Value = proveedor .NomEmpresa1 ;
            command.Parameters["@TelefonoEmpresa"].Value = proveedor .TelefonoEmpresa1 ;
            command.Parameters["@CorreoEmpresa"].Value = proveedor .CorreoEmpresa1;
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

    public List<proveedores> findAll()
    {
        List<proveedores > lista = new List<proveedores >(0);
        conn = new conexion();
        SqlCommand command = new SqlCommand("SELECT * FROM proveedores", conn.getConn());
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            proveedores  proveedor  = new proveedores ();
            proveedor .Id_proveedor  = rd.GetInt32(0);
            proveedor .NomEmpresa1  = rd.GetString (1);
            proveedor .TelefonoEmpresa1  = rd.GetString (2);
            proveedor .CorreoEmpresa1  = rd.GetString (3);

            lista.Add(proveedor );
        }
        rd.Close();
        conn.cerrar();
        return lista;
    }

    public proveedores findById(int id_proveedor)
    {
        proveedores  proveedor  = null;
        String sqlString = "SELECT * FROM proveedores WHERE id_proveedor = @id_proveedor";
        conn = new conexion();
        SqlCommand command = new SqlCommand(sqlString, conn.getConn());
        command.Parameters.Add("@id_proveedor", SqlDbType.Int);
        command.Parameters["@id_proveedor"].Value = id_proveedor ;
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            proveedor.Id_proveedor = rd.GetInt32(0);
            proveedor.NomEmpresa1 = rd.GetString(1);
            proveedor.TelefonoEmpresa1 = rd.GetString(2);
            proveedor.CorreoEmpresa1 = rd.GetString(3);
        }
        rd.Close();
        conn.cerrar();
        return proveedor  ;
    }

    public int remove(proveedores proveedor)
    {
        int a = 0;
        String query = "DELETE FROM proveedores WHERE id_proveedor = @id_proveedor";
        conn = new conexion();
        SqlCommand command = conn.getConn().CreateCommand();
        SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conn.getConn();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_proveedor", SqlDbType.Int);
            command.Parameters["@id_proveedor"].Value = proveedor .Id_proveedor ;
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

    public int update(proveedores proveedor)
    {
        int a = 0;
        String query = "UPDATE proveedores SET NomEmpresa = @NomEmpresa, TelefonoEmpresa = @TelefonoEmpresa, CorreoEmpresa = @CorreoEmpresa WHERE id_proveedor = @id_proveedor";
        conn = new conexion();
        SqlCommand command = conn.getConn().CreateCommand();
        SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conn.getConn();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_proveedor", SqlDbType.Int);
            command.Parameters["@id_proveedor"].Value = proveedor .Id_proveedor ;
            command.Parameters.Add("@NomEmpresa", SqlDbType.VarChar);
            command.Parameters.Add("@TelefonoEmpresa", SqlDbType.VarChar);
            command.Parameters.Add("@CorreoEmpresa", SqlDbType.VarChar);
            command.Parameters["@NomEmpresa"].Value = proveedor.NomEmpresa1;
            command.Parameters["@TelefonoEmpresa"].Value = proveedor.TelefonoEmpresa1;
            command.Parameters["@CorreoEmpresa"].Value = proveedor.CorreoEmpresa1;
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