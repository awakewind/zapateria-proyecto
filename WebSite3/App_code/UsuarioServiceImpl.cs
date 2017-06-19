using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Descripción breve de UsuarioServiceImpl
/// </summary>
public class UsuarioServiceImpl :Usuarioservice 
{
    conexion conn = null;
    public UsuarioServiceImpl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int add(usuarios usuario)
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
            command.CommandText = "INSERT INTO usuarios(usuario,contraseña) VALUES(@usuario,@contraseña)";
            command.Parameters.Add("@usuario", SqlDbType.VarChar, 50);
            command.Parameters["@usuario"].Value = usuario  .Usuario ;
            command.Parameters.Add("@contraseña", SqlDbType.VarChar, 50);
            command.Parameters["@contraseña"].Value = usuario.Contraseña;
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

    public List<usuarios> findAll()
    {
        throw new NotImplementedException();
    }

    public usuarios findById(int id_usuario)
    {
        throw new NotImplementedException();
    }

    public usuarios login(usuarios usuario)
    {
        conn = new conexion ();
        SqlCommand command = new SqlCommand("SELECT * FROM usuarios WHERE usuario = @usuario AND contraseña = @contraseña", conn.getConn());
        command.Parameters.Add("@contraseña", SqlDbType.VarChar, 50);
        command.Parameters["@contraseña"].Value = usuario.Contraseña;
        command.Parameters.Add("@usuario", SqlDbType.VarChar, 50);
        command.Parameters["@usuario"].Value = usuario.Usuario ;
        SqlDataReader rd = command.ExecuteReader();
        usuarios   login = null;

        while (rd.Read())
        {
            login = new usuarios ();
            login.Id_usuario  = rd.GetInt32(0);
            login.Usuario  = rd.GetString(1);
            login.Contraseña  = rd.GetString(2);


        }
        rd.Close();
        conn.cerrar();
        return login;
    }

    public int remove(usuarios usuario)
    {
        throw new NotImplementedException();
    }

    public int update(usuarios usuario)
    {
        throw new NotImplementedException();
    }
}