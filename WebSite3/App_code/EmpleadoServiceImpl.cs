using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de EmpleadoServiceImpl
/// </summary>
public class EmpleadoServiceImpl : EmpleadoService
{
    conexion conn = null;
    public EmpleadoServiceImpl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int add(empleados empleado )
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
            command.CommandText = "INSERT INTO empleados(NomEmpleado,ApeEmpleado,NumTellEmpleado,DirecEmpleado,cargos,FechaNacEmpleado,DuiEmpleado,NitEmpleado) VALUES(@NomEmpleado,@ApeEmpleado,@NumTellEmpleado,@DirecEmpleado,@cargos,@FechaNacEmpleado,@DuiEmpleado,@NitEmpleado)";
            command.Parameters.Add("@NomEmpleado", SqlDbType.VarChar,50);
            command.Parameters.Add("@ApeEmpleado", SqlDbType.VarChar, 50);
            command.Parameters.Add("@NumTellEmpleado", SqlDbType.VarChar, 50);
            command.Parameters.Add("@DirecEmpleado", SqlDbType.VarChar, 200);
            command.Parameters.Add("@cargos", SqlDbType.Int);
            command.Parameters.Add("@FechaNacEmpleado", SqlDbType.Date);
            command.Parameters.Add("@DuiEmpleado", SqlDbType.VarChar, 50);
            command.Parameters.Add("@NitEmpleado", SqlDbType.VarChar, 50);
            command.Parameters["@NomEmpleado"].Value = empleado.Nomempleado;
            command.Parameters["@ApeEmpleado"].Value = empleado.Apeempleado;
            command.Parameters["@NumTellEmpleado"].Value = empleado.Numtellempleado;
            command.Parameters["@DirecEmpleado"].Value = empleado.Direcempleado;
            command.Parameters["@cargos"].Value = empleado.Cargos;
            command.Parameters["@FechaNacEmpleado"].Value = empleado.Fechanacempleado;
            command.Parameters["@DuiEmpleado"].Value = empleado.Duiempleado;
            command.Parameters["@NitEmpleado"].Value = empleado.Nitempleado;
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

    public List<empleados> findAll()
    {
        List<empleados> lista = new List<empleados>(0);
        conn = new conexion();
        SqlCommand command = new SqlCommand("SELECT * FROM empleados", conn.getConn());
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            empleados empleado  = new empleados();
            empleado.Id_empleado = rd.GetInt32(0);
            empleado.Nomempleado  = rd.GetString(1);
            empleado.Apeempleado = rd.GetString(2);
            empleado.Numtellempleado = rd.GetString(3);
            empleado.Direcempleado = rd.GetString(4);
            empleado.Cargos = rd.GetInt32(5);
            empleado.Fechanacempleado = rd.GetDateTime(6);
            empleado.Duiempleado = rd.GetString(7);
            empleado.Nitempleado = rd.GetString(8);
            lista.Add(empleado);
        }
        rd.Close();
        conn.cerrar();
        return lista;
    }

    public empleados findById(int id_empleado)
    {
        empleados empleado  = null;
        String sqlString = "SELECT * FROM empleados WHERE id_empleado = @id_empleado";
        conn = new conexion();
        SqlCommand command = new SqlCommand(sqlString, conn.getConn());
        command.Parameters.Add("@id_empleado", SqlDbType.Int);
        command.Parameters["@id_empleado"].Value = id_empleado;
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            empleado.Id_empleado = rd.GetInt32(0);
            empleado.Nomempleado = rd.GetString(1);
            empleado.Apeempleado = rd.GetString(2);
            empleado.Numtellempleado = rd.GetString(3);
            empleado.Direcempleado = rd.GetString(4);
            empleado.Cargos = rd.GetInt32(5);
            empleado.Fechanacempleado = rd.GetDateTime(6);
            empleado.Duiempleado = rd.GetString(7);
            empleado.Nitempleado = rd.GetString(8);
        }
        rd.Close();
        conn.cerrar();
        return empleado;
    }

    public int remove(empleados empleado )
    {
        {
            int a = 0;
            String query = "DELETE FROM empleados WHERE id_empleado = @id_empleado";
            conn = new conexion();
            SqlCommand command = conn.getConn().CreateCommand();
            SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
            try
            {
                command.Connection = conn.getConn();
                command.CommandText = query;
                command.Transaction = trans;
                command.Parameters.Add("@id_empleado", SqlDbType.Int);
                command.Parameters["@id_empleado"].Value = empleado.Id_empleado;
                command.ExecuteNonQuery();
                trans.Commit();
                a = 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                trans.Rollback();
            }
            finally
            {
                conn.cerrar();
            }
            return a;
        }
    }

    public int update(empleados empleado )
    {
        int a = 0;
        String query = "UPDATE empleados SET NomEmpleado = @NomEmpleado, ApeEmpleado = @ApeEmpleado, NumTellEmpleado = @NumTellEmpleado, DirecEmpleado = @DirecEmpleado, cargos = @cargos, FechaNacEmpleado = @FechaNacEmpleado, DuiEmpleado = @DuiEmpleado, NitEmpleado = @NitEmpleado WHERE id_empleado = @id_empleado";
        conn = new conexion();
        SqlCommand command = conn.getConn().CreateCommand();
        SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conn.getConn();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_empleado", SqlDbType.Int);
            command.Parameters["@id_empleado"].Value = empleado.Id_empleado;
            command.Parameters.Add("@NomEmpleado", SqlDbType.VarChar, 50);
            command.Parameters.Add("@ApeEmpleado", SqlDbType.VarChar, 50);
            command.Parameters.Add("@NumTellEmpleado", SqlDbType.VarChar, 50);
            command.Parameters.Add("@DirecEmpleado", SqlDbType.VarChar, 200);
            command.Parameters.Add("@cargos", SqlDbType.Int);
            command.Parameters.Add("@FechaNacEmpleado", SqlDbType.Date);
            command.Parameters.Add("@DuiEmpleado", SqlDbType.VarChar, 50);
            command.Parameters.Add("@NitEmpleado", SqlDbType.VarChar, 50);
            command.Parameters["@NomEmpleado"].Value = empleado.Nomempleado;
            command.Parameters["@ApeEmpleado"].Value = empleado.Apeempleado;
            command.Parameters["@NumTellEmpleado"].Value = empleado.Numtellempleado;
            command.Parameters["@DirecEmpleado"].Value = empleado.Direcempleado;
            command.Parameters["@cargos"].Value = empleado.Cargos;
            command.Parameters["@FechaNacEmpleado"].Value = empleado.Fechanacempleado;
            command.Parameters["@DuiEmpleado"].Value = empleado.Duiempleado;
            command.Parameters["@NitEmpleado"].Value = empleado.Nitempleado;
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