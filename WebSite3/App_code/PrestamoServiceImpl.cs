using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de PrestamoServiceImpl
/// </summary>
public class PrestamoServiceImpl : PrestamoService 
{
    conexion conn = null;
    public PrestamoServiceImpl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int add(prestamos prestamo)
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
            command.CommandText = "INSERT INTO prestamos(ventas,AbonoDeuda,SaldoPendiente) VALUES(@ventas,@AbonoDeuda,@SaldoPendiente)";
            command.Parameters.Add("@ventas", SqlDbType.Int);
            command.Parameters.Add("@AbonoDeuda", SqlDbType.Decimal);
            command.Parameters.Add("@SaldoPendiente", SqlDbType.Decimal);
            command.Parameters["@ventas"].Value = prestamo .Ventas ;
            command.Parameters["@AbonoDeuda"].Value = prestamo .AbonoDeuda1 ;
            command.Parameters["@SaldoPendiente"].Value = prestamo .SaldoPendiente1 ;
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

    public List<prestamos> findAll()
    {
        List<prestamos > lista = new List<prestamos >(0);
        conn = new conexion();
        SqlCommand command = new SqlCommand("SELECT * FROM prestamos", conn.getConn());
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            prestamos  prestamo  = new prestamos ();
            prestamo .Id_prestamo  = rd.GetInt32(0);
            prestamo .Ventas  = rd.GetInt32(1);
            prestamo .AbonoDeuda1  = rd.GetDecimal  (2);
            prestamo .SaldoPendiente1  = rd.GetDecimal (3);

            lista.Add(prestamo );
        }
        rd.Close();
        conn.cerrar();
        return lista;
    }

    public prestamos findById(int id_prestamo)
    {
        prestamos  prestamo  = null;
        String sqlString = "SELECT * FROM prestamos WHERE id_prestamo = @id_prestamo";
        conn = new conexion();
        SqlCommand command = new SqlCommand(sqlString, conn.getConn());
        command.Parameters.Add("@id_prestamo", SqlDbType.Int);
        command.Parameters["@id_prestamo"].Value = id_prestamo ;
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            prestamo.Id_prestamo = rd.GetInt32(0);
            prestamo.Ventas = rd.GetInt32(1);
            prestamo.AbonoDeuda1 = rd.GetDecimal(2);
            prestamo.SaldoPendiente1 = rd.GetDecimal(3);
        }
        rd.Close();
        conn.cerrar();
        return prestamo ;
    }

    public int remove(prestamos prestamo)
    {
        int a = 0;
        String query = "DELETE FROM prestamos WHERE id_prestamo = @id_prestamo";
        conn = new conexion();
        SqlCommand command = conn.getConn().CreateCommand();
        SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conn.getConn();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_prestamo", SqlDbType.Int);
            command.Parameters["@id_prestamo"].Value = prestamo .Id_prestamo ;
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

    public int update(prestamos prestamo)
    {
        int a = 0;
        String query = "UPDATE prestamos SET ventas = @ventas, AbonoDeuda = @AbonoDeuda, SaldoPendiente = @SaldoPendiente WHERE id_prestamo = @id_prestamo";
        conn = new conexion();
        SqlCommand command = conn.getConn().CreateCommand();
        SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conn.getConn();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_prestamo", SqlDbType.Int);
            command.Parameters["@id_prestamo"].Value = prestamo .Id_prestamo ;
            command.Parameters.Add("@ventas", SqlDbType.Int);
            command.Parameters.Add("@AbonoDeuda", SqlDbType.Decimal);
            command.Parameters.Add("@SaldoPendiente", SqlDbType.Decimal);
            command.Parameters["@ventas"].Value = prestamo.Ventas;
            command.Parameters["@AbonoDeuda"].Value = prestamo.AbonoDeuda1;
            command.Parameters["@SaldoPendiente"].Value = prestamo.SaldoPendiente1;
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