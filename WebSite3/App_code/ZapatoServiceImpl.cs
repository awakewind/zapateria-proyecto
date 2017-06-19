using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de ZapatoServiceImpl
/// </summary>
public class ZapatoServiceImpl : ZapatoService
{
    conexion conn = null;
    public ZapatoServiceImpl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int add(zapatos zapato)
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
            command.CommandText = "INSERT INTO zapatos(NomGaZapato,estilos,marcas,TallasDisponibles,CantidadDisponible,ColoresGama,viajeros) VALUES(@NomGaZapato,@estilos,@marcas,@TallasDisponibles,@CantidadDisponible,@ColoresGama,@viajeros)";
            command.Parameters.Add("@NomGaZapato", SqlDbType.VarChar, 50);
            command.Parameters.Add("@estilos", SqlDbType.Int);
            command.Parameters.Add("@marcas", SqlDbType.Int);
            command.Parameters.Add("@TallasDisponibles", SqlDbType.VarChar, 100);
            command.Parameters.Add("@CantidadDisponible", SqlDbType.Int);
            command.Parameters.Add("@ColoresGama", SqlDbType.VarChar, 100);
            command.Parameters.Add("@viajeros", SqlDbType.Int);
            command.Parameters["@NomGaZapato"].Value = zapato.NomGaZapato1 ;
            command.Parameters["@estilos"].Value = zapato.Estilos;
            command.Parameters["@marcas"].Value = zapato.Marcas;
            command.Parameters["@TallasDisponibles"].Value = zapato.TallasDisponibles1;
            command.Parameters["@CantidadDisponible"].Value = zapato.CantidadDisponible1;
            command.Parameters["@ColoresGama"].Value = zapato.ColoresGama1;
            command.Parameters["@viajeros"].Value = zapato.Viajeros;
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

    public List<zapatos> findAll()
    {
        List<zapatos> lista = new List<zapatos>(0);
        conn = new conexion();
        SqlCommand command = new SqlCommand("SELECT * FROM zapatos", conn.getConn());
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            zapatos zapato  = new zapatos();
            zapato.Id_zapatos = rd.GetInt32(0);
            zapato.NomGaZapato1 = rd.GetString(1);
            zapato.Estilos = rd.GetInt32(2);
            zapato.Marcas  = rd.GetInt32(3);
            zapato.TallasDisponibles1  = rd.GetString(4);
            zapato.CantidadDisponible1  = rd.GetInt32(5);
            zapato.ColoresGama1 = rd.GetString(6);
            zapato.Viajeros  = rd.GetInt32(7);
            lista.Add(zapato);
        }
        rd.Close();
        conn.cerrar();
        return lista;
    }

    public zapatos findById(int id_zapatos)
    {
        zapatos zapato  = new zapatos ();
        String sqlString = "SELECT * FROM zapatos WHERE id_zapatos = @id_zapatos";
        conn = new conexion();
        SqlCommand command = new SqlCommand(sqlString, conn.getConn());
        command.Parameters.Add("@id_zapatos", SqlDbType.Int);
        command.Parameters["@id_zapatos"].Value = id_zapatos;
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            zapato.Id_zapatos = rd.GetInt32(0);
            zapato.NomGaZapato1 = rd.GetString(1);
            zapato.Estilos = rd.GetInt32(2);
            zapato.Marcas = rd.GetInt32(3);
            zapato.TallasDisponibles1 = rd.GetString(4);
            zapato.CantidadDisponible1 = rd.GetInt32(5);
            zapato.ColoresGama1 = rd.GetString(6);
            zapato.Viajeros = rd.GetInt32(7);
        }
        rd.Close();
        conn.cerrar();
        return zapato;
    }

    public int remove(zapatos zapato)
    {
        {
            int a = 0;
            String query = "DELETE FROM zapatos WHERE id_zapatos = @id_zapatos";
            conn = new conexion();
            SqlCommand command = conn.getConn().CreateCommand();
            SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
            try
            {
                command.Connection = conn.getConn();
                command.CommandText = query;
                command.Transaction = trans;
                command.Parameters.Add("@id_zapatos", SqlDbType.Int);
                command.Parameters["@id_zapatos"].Value = zapato.Id_zapatos;
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

    public int update(zapatos zapato)
    {
        int a = 0;
        String query = "UPDATE zapatos SET NomGaZapato = @NomGaZapato, estilos = @estilos, marcas = @marcas, TallasDisponibles = @TallasDisponibles, CantidadDisponible = @CantidadDisponible, ColoresGama = @ColoresGama, viajeros = @viajeros WHERE id_zapatos = @id_zapatos";
        conn = new conexion();
        SqlCommand command = conn.getConn().CreateCommand();
        SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conn.getConn();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_zapatos", SqlDbType.Int);
            command.Parameters["@id_zapatos"].Value = zapato.Id_zapatos;
            command.Parameters.Add("@NomGaZapato", SqlDbType.VarChar, 50);
            command.Parameters.Add("@estilos", SqlDbType.Int);
            command.Parameters.Add("@marcas", SqlDbType.Int);
            command.Parameters.Add("@TallasDisponibles", SqlDbType.VarChar, 100);
            command.Parameters.Add("@CantidadDisponible", SqlDbType.Int);
            command.Parameters.Add("@ColoresGama", SqlDbType.VarChar, 100);
            command.Parameters.Add("@viajeros", SqlDbType.Int);
            command.Parameters["@NomGaZapato"].Value = zapato.NomGaZapato1;
            command.Parameters["@estilos"].Value = zapato.Estilos;
            command.Parameters["@marcas"].Value = zapato.Marcas;
            command.Parameters["@TallasDisponibles"].Value = zapato.TallasDisponibles1;
            command.Parameters["@CantidadDisponible"].Value = zapato.CantidadDisponible1;
            command.Parameters["@ColoresGama"].Value = zapato.ColoresGama1;
            command.Parameters["@viajeros"].Value = zapato.Viajeros;
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