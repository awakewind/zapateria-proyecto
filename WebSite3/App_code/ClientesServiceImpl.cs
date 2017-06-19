using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de ClientesServiceImpl
/// </summary>
public class ClientesServiceImpl : ClientesService
{
    conexion conn = null;
    public ClientesServiceImpl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int add(clientes cliente)
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
            command.CommandText = "INSERT INTO clientes(NomCliente,ApeCliente,TelCliente,DireccionCliente) VALUES(@NomCliente,@ApeCliente,@TelCliente,@DireccionCliente)";
            command.Parameters.Add("@NomCliente", SqlDbType.VarChar, 50);
            command.Parameters.Add("@ApeCliente", SqlDbType.VarChar,50);
            command.Parameters.Add("@TelCliente", SqlDbType.VarChar,50);
            command.Parameters.Add("@DireccionCliente", SqlDbType.VarChar, 50);
            command.Parameters["@NomCliente"].Value = cliente .NomCliente1 ;
            command.Parameters["@ApeCliente"].Value = cliente .ApeCliente1 ;
            command.Parameters["@TelCliente"].Value = cliente .TelCliente1;
            command.Parameters["@DireccionCliente"].Value = cliente.DireccionCliente1;

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

    public List<clientes> findAll()
    {
        List<clientes> lista = new List<clientes>(0);
        conn = new conexion();
        SqlCommand command = new SqlCommand("SELECT * FROM clientes", conn.getConn());
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            clientes cliente  = new clientes();
            cliente.Id_cliente = rd.GetInt32(0);
            cliente.NomCliente1 = rd.GetString(1);
            cliente.ApeCliente1 = rd.GetString(2);
            cliente.TelCliente1 = rd.GetString(3);
            cliente.DireccionCliente1 = rd.GetString(4);
            lista.Add(cliente);
        }
        rd.Close();
        conn.cerrar();
        return lista;
    }

    public List<clientes> findByField(string criteria)
    {
        List<clientes> lista = new List<clientes>(0);
        String sqlString = "SELECT * FROM clientes WHERE NomCliente like @searchParam OR ApeCliente like @searchParam";
        conn = new conexion();
        SqlCommand command = new SqlCommand(sqlString, conn.getConn());
        command.Parameters.Add("@searchParam", SqlDbType.Char);
        command.Parameters["@searchParam"].Value = "%" + criteria.Trim() + "%";
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            clientes cliente = new clientes();
            cliente.Id_cliente = rd.GetInt32(0);
            cliente.NomCliente1 = rd.GetString(1);
            cliente.ApeCliente1 = rd.GetString(2);
            cliente.TelCliente1 = rd.GetString(3);
            cliente.DireccionCliente1 = rd.GetString(4);
            lista.Add(cliente);
        }
        rd.Close();
        conn.cerrar();
        return lista;
    }

    public clientes findById(int id_cliente)
    {
        clientes cliente = null;
        String sqlString = "SELECT * FROM clientes WHERE id_cliente = @id_cliente";
        conn = new conexion();
        SqlCommand command = new SqlCommand(sqlString, conn.getConn());
        command.Parameters.Add("@id_cliente", SqlDbType.Int);
        command.Parameters["@id_cliente"].Value = id_cliente;
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            cliente = new clientes();
            cliente.DireccionCliente1 = rd.GetString(4);
            cliente.TelCliente1 = rd.GetString(3);
            cliente.ApeCliente1 = rd.GetString(2);
            cliente.NomCliente1 = rd.GetString(1);
            cliente.Id_cliente = rd.GetInt32(0);
        }
        rd.Close();
        conn.cerrar();
        return cliente;
    }


    public int remove(clientes cliente)
    {
        int a = 0;
        String query = "DELETE FROM clientes WHERE id_cliente = @id_cliente";
        conn = new conexion();
        SqlCommand command = conn.getConn().CreateCommand();
        SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conn.getConn();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_cliente", SqlDbType.Int);
            command.Parameters["@id_cliente"].Value = cliente.Id_cliente;
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

    public int update(clientes cliente)
    {
        int a = 0;
        String query = "UPDATE clientes SET NomCliente = @NomCliente, ApeCliente = @ApeCliente, TelCliente = @TelCliente, DireccionCliente = @DireccionCliente WHERE id_cliente = @id_cliente";
        conn = new conexion();
        SqlCommand command = conn.getConn().CreateCommand();
        SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conn.getConn();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_cliente", SqlDbType.Int);
            command.Parameters["@id_cliente"].Value = cliente .Id_cliente;
            command.Parameters.Add("@NomCliente", SqlDbType.VarChar, 50);
            command.Parameters.Add("@ApeCliente", SqlDbType.VarChar, 50);
            command.Parameters.Add("@TelCliente", SqlDbType.VarChar, 50);
            command.Parameters.Add("@DireccionCliente", SqlDbType.VarChar, 50);
            command.Parameters["@NomCliente"].Value = cliente.NomCliente1;
            command.Parameters["@ApeCliente"].Value = cliente.ApeCliente1;
            command.Parameters["@TelCliente"].Value = cliente.TelCliente1;
            command.Parameters["@DireccionCliente"].Value = cliente.DireccionCliente1;
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