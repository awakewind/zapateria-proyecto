using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de ViajeroServiceImpl
/// </summary>
public class ViajeroServiceImpl : ViajeroService 
{
    conexion conn = null;
    public ViajeroServiceImpl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int add(viajeros viajero)
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
            command.CommandText = "INSERT INTO viajeros(NomViajero,ApeViajero,TelefonoViajero,proveedores,CorreoViajero) VALUES(@NomViajero,@ApeViajero,@TelefonoViajero,@proveedores,@CorreoViajero)";
            command.Parameters.Add("@NomViajero", SqlDbType.VarChar, 50);
            command.Parameters.Add("@ApeViajero", SqlDbType.VarChar ,50);
            command.Parameters.Add("@TelefonoViajero", SqlDbType.VarChar ,50);
            command.Parameters.Add("@proveedores", SqlDbType.Int );
            command.Parameters.Add("@CorreoViajero", SqlDbType.VarChar ,50);
            command.Parameters["@NomViajero"].Value = viajero.NomViajero1 ;
            command.Parameters["@ApeViajero"].Value = viajero .ApeViajero1 ;
            command.Parameters["@TelefonoViajero"].Value = viajero .TelefonoViajero1 ;
            command.Parameters["@proveedores"].Value = viajero .Proveedores ;
            command.Parameters["@CorreoViajero"].Value = viajero .CorreoViajero1 ;
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

    public List<viajeros> findAll()
    {
        List<viajeros > lista = new List<viajeros >(0);
        conn = new conexion();
        SqlCommand command = new SqlCommand("SELECT * FROM viajeros", conn.getConn());
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            viajeros  viajero  = new viajeros ();
            viajero .Id_viajero  = rd.GetInt32(0);
            viajero.NomViajero1  = rd.GetString(1);
            viajero.ApeViajero1  = rd.GetString (2);
            viajero.TelefonoViajero1  = rd.GetString (3);
            viajero.Proveedores  = rd.GetInt32 (4);
            viajero.CorreoViajero1  = rd.GetString(5);
            lista.Add(viajero );
        }
        rd.Close();
        conn.cerrar();
        return lista;
    }

    public viajeros findById(int id_viajero)
    {
        viajeros  viajero  = null;
        String sqlString = "SELECT * FROM viajeros WHERE id_viajero = @id_viajero";
        conn = new conexion();
        SqlCommand command = new SqlCommand(sqlString, conn.getConn());
        command.Parameters.Add("@id_viajero", SqlDbType.Int);
        command.Parameters["@id_viajero"].Value = id_viajero;
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            viajero.Id_viajero = rd.GetInt32(0);
            viajero.NomViajero1 = rd.GetString(1);
            viajero.ApeViajero1 = rd.GetString(2);
            viajero.TelefonoViajero1 = rd.GetString(3);
            viajero.Proveedores = rd.GetInt32(4);
            viajero.CorreoViajero1 = rd.GetString(5);
        }
        rd.Close();
        conn.cerrar();
        return viajero;
    }

    public int remove(viajeros viajero)
    {
        {
            int a = 0;
            String query = "DELETE FROM viajeros WHERE id_viajero = @id_viajero";
            conn = new conexion();
            SqlCommand command = conn.getConn().CreateCommand();
            SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
            try
            {
                command.Connection = conn.getConn();
                command.CommandText = query;
                command.Transaction = trans;
                command.Parameters.Add("@id_viajero", SqlDbType.Int);
                command.Parameters["@id_viajero"].Value = viajero .Id_viajero ;
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

    public int update(viajeros viajero)
    {
        int a = 0;
        String query = "UPDATE viajeros SET NomViajero = @NomViajero, ApeViajero = @ApeViajero, TelefonoViajero = @TelefonoViajero, proveedores = @proveedores, CorreoViajero = @CorreoViajero WHERE id_viajero = @id_viajero";
        conn = new conexion();
        SqlCommand command = conn.getConn().CreateCommand();
        SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conn.getConn();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_viajero", SqlDbType.Int);
            command.Parameters["@id_viajero"].Value = viajero .Id_viajero ;
            command.Parameters.Add("@NomViajero", SqlDbType.VarChar, 50);
            command.Parameters.Add("@ApeViajero", SqlDbType.VarChar,50);
            command.Parameters.Add("@TelefonoViajero", SqlDbType.VarChar,50);
            command.Parameters.Add("@proveedores", SqlDbType.Int);
            command.Parameters.Add("@CorreoViajero", SqlDbType.VarChar,50);
            command.Parameters["@NomViajero"].Value = viajero.NomViajero1;
            command.Parameters["@ApeViajero"].Value = viajero.ApeViajero1;
            command.Parameters["@TelefonoViajero"].Value = viajero.TelefonoViajero1;
            command.Parameters["@proveedores"].Value = viajero.Proveedores;
            command.Parameters["@CorreoViajero"].Value = viajero.CorreoViajero1;
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