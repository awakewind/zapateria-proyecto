using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de conexion
/// </summary>
public class conexion
{
    private SqlConnection conn = null;
    public conexion ()
    {
        string stringConnection = "Data Source = localhost\\sqlexpress; Integrated Security = True; Initial Catalog = Administración zapateria";

        
        conn = new SqlConnection(stringConnection);
        try
        {
            conn.Open();
        }
        catch (Exception e)
        {
            throw new Exception("Error " + e);
        }
    }

    public SqlConnection getConn()
    {
        return conn;
    }

    public void cerrar()
    {
        if (conn != null)
        {
            conn.Close();
        }
    }
}