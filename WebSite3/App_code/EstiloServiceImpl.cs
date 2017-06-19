using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de EstiloServiceImpl
/// </summary>
public class EstiloServiceImpl : EstilosService
{
    conexion conn = null;
    public EstiloServiceImpl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int add(estilos estilo)
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
            command.CommandText = "INSERT INTO estilos(NomEstilo,Descripcíon,GeneroEstilo) VALUES(@NomEstilo,@Descripcíon,@GeneroEstilo)";
            command.Parameters.Add("@NomEstilo", SqlDbType.VarChar, 50);
            command.Parameters.Add("@Descripcíon", SqlDbType.VarChar);
            command.Parameters.Add("@GeneroEstilo", SqlDbType.VarChar, 50);
            command.Parameters["@NomEstilo"].Value = estilo.NomEstilo1;
            command.Parameters["@Descripcíon"].Value = estilo.Descripcíon1;
            command.Parameters["@GeneroEstilo"].Value = estilo .GeneroEstilo1 ;
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

    public List<estilos> findAll()
    {
        List<estilos > lista = new List<estilos >(0);
        conn = new conexion();
        SqlCommand command = new SqlCommand("SELECT * FROM estilos", conn.getConn());
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            estilos estilo  = new estilos ();
            estilo.Id_estilo = rd.GetInt32(0);
            estilo.NomEstilo1 = rd.GetString(1);
            estilo.Descripcíon1 = rd.GetString(2);
            estilo.GeneroEstilo1 = rd.GetString(3);
            lista.Add(estilo);
        }
        rd.Close();
        conn.cerrar();
        return lista;
    }

    public estilos findById(int id_estilo)
    {
        estilos estilo  = null;
        String sqlString = "SELECT * FROM estilos WHERE id_estilo = @id_estilo";
        conn = new conexion();
        SqlCommand command = new SqlCommand(sqlString, conn.getConn());
        command.Parameters.Add("@id_estilo", SqlDbType.Int);
        command.Parameters["@id_estilo"].Value = id_estilo;
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            estilo.Id_estilo = rd.GetInt32(0);
            estilo.NomEstilo1 = rd.GetString(1);
            estilo.Descripcíon1 = rd.GetString(2);
            estilo.GeneroEstilo1 = rd.GetString(3);
        }
        rd.Close();
        conn.cerrar();
        return estilo;
    }


    public int remove(estilos estilo)
    {
        {
            int a = 0;
            String query = "DELETE FROM estilos WHERE id_estilo = @id_estilo";
            conn = new conexion();
            SqlCommand command = conn.getConn().CreateCommand();
            SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
            try
            {
                command.Connection = conn.getConn();
                command.CommandText = query;
                command.Transaction = trans;
                command.Parameters.Add("@id_estilo", SqlDbType.Int);
                command.Parameters["@id_estilo"].Value = estilo.Id_estilo;
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

    public int update(estilos estilo)
    {
        int a = 0;
        String query = "UPDATE estilos SET NomEstilo = @NomEstilo, Descripcíon = @Descripcíon, GeneroEstilo = @GeneroEstilo WHERE id_estilo = @id_estilo";
        conn = new conexion();
        SqlCommand command = conn.getConn().CreateCommand();
        SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conn.getConn();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_estilo", SqlDbType.Int);
            command.Parameters["@id_estilo"].Value = estilo.Id_estilo;
            command.Parameters.Add("@NomEstilo", SqlDbType.VarChar, 50);
            command.Parameters.Add("@Descripcíon", SqlDbType.VarChar);
            command.Parameters.Add("@GeneroEstilo", SqlDbType.VarChar, 50);
            command.Parameters["@NomEstilo"].Value = estilo.NomEstilo1;
            command.Parameters["@Descripcíon"].Value = estilo.Descripcíon1;
            command.Parameters["@GeneroEstilo"].Value = estilo.GeneroEstilo1;
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