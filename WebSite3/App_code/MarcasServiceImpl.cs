using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de MarcasServiceImpl
/// </summary>
public class MarcasServiceImpl : MarcasService
{
    conexion conn = null;
    public MarcasServiceImpl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int add(marcas marca)
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
            command.CommandText = "INSERT INTO marcas(NomMarca) VALUES(@NomMarca)";
            command.Parameters.Add("@NomMarca", SqlDbType.VarChar, 50);
            command.Parameters["@NomMarca"].Value = marca.NomMarca1;
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

    public List<marcas> findAll()
    {
        List<marcas> lista = new List<marcas>(0);
        conn = new conexion();
        SqlCommand command = new SqlCommand("SELECT * FROM marcas", conn.getConn());
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            marcas marca  = new marcas();
            marca.Id_marcas  = rd.GetInt32(0);
            marca.NomMarca1  = rd.GetString(1);
            lista.Add(marca);
        }
        rd.Close();
        conn.cerrar();
        return lista;
    }

    public marcas findById(int id_marcas)
    {
        marcas  marca  = null;
        String sqlString = "SELECT * FROM marcas WHERE id_marcas = @id_marcas";
        conn = new conexion();
        SqlCommand command = new SqlCommand(sqlString, conn.getConn());
        command.Parameters.Add("@id_marcas", SqlDbType.Int);
        command.Parameters["@id_marcas"].Value = id_marcas;
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            marca.Id_marcas = rd.GetInt32(0);
            marca .NomMarca1  = rd.GetString(1);
        }
        rd.Close();
        conn.cerrar();
        return marca ;
    }

    public int remove(marcas marca)
    {
        int a = 0;
        String query = "DELETE FROM marcas WHERE id_marcas = @id_marcas";
        conn = new conexion();
        SqlCommand command = conn.getConn().CreateCommand();
        SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conn.getConn();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_marcas", SqlDbType.Int);
            command.Parameters["@id_marcas"].Value = marca .Id_marcas ;
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

    public int update(marcas marca)
    {
        int a = 0;
        String query = "UPDATE marcas SET NomMarca = @NomMarca WHERE id_marcas = @id_marcas";
        conn = new conexion();
        SqlCommand command = conn.getConn().CreateCommand();
        SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conn.getConn();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_marcas", SqlDbType.Int);
            command.Parameters["@id_marcas"].Value = marca .Id_marcas ;
            command.Parameters.Add("@NomMarca", SqlDbType.VarChar, 50);
            command.Parameters["@NomMarca"].Value = marca .NomMarca1 ;
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