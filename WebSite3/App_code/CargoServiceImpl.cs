using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de CargoServiceImpl
/// </summary>
public class CargoServiceImpl : CargosService

{
    conexion conn = null;
    public CargoServiceImpl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int add(cargos cargo)
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
            command.CommandText = "INSERT INTO cargos(NomCargo,Salario,DescripcionCargo) VALUES(@NomCargo,@Salario,@DescripcionCargo)";
            command.Parameters.Add("@NomCargo", SqlDbType.VarChar, 50);
            command.Parameters.Add("@Salario", SqlDbType.Decimal);
            command.Parameters.Add("@DescripcionCargo", SqlDbType.Text);
            command.Parameters["@NomCargo"].Value = cargo.NomCargo1;
            command.Parameters["@Salario"].Value = cargo.Salario1;
            command.Parameters["@DescripcionCargo"].Value = cargo.DescripcionCargo1;


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

    public List<cargos> findAll()
    {
        List<cargos> lista = new List<cargos>(0);
        conn = new conexion();
        SqlCommand command = new SqlCommand("SELECT * FROM cargos", conn.getConn());
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            cargos cargos  = new cargos();
            cargos.Id_cargo = rd.GetInt32(0);
            cargos.NomCargo1 = rd.GetString(1);
            cargos.Salario1 = rd.GetDecimal  (2);
            cargos.DescripcionCargo1 = rd.GetString(3);
            lista.Add(cargos);
        }
        rd.Close();
        conn.cerrar();
        return lista;
    }

    public cargos findById(int id_cargo)
    {
        cargos cargos  = new cargos() ;
        String sqlString = "SELECT * FROM cargos WHERE id_cargo = @id_cargo";
        conn = new conexion();
        SqlCommand command = new SqlCommand(sqlString, conn.getConn());
        command.Parameters.Add("@id_cargo", SqlDbType.Int);
        command.Parameters["@id_cargo"].Value = id_cargo;
        SqlDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            cargos = new cargos();
            cargos.Salario1 = rd.GetDecimal(3);
            cargos.DescripcionCargo1 = rd.GetString(2);
            cargos.NomCargo1 = rd.GetString(1);
            cargos.Id_cargo = rd.GetInt32(0);
        }
        rd.Close();
        conn.cerrar();
        return cargos;
    }

    public int remove(cargos cargos)
    {
        int a = 0;
        String query = "DELETE FROM cargos WHERE id_cargo = @id_cargo";
        conn = new conexion();
        SqlCommand command = conn.getConn().CreateCommand();
        SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conn.getConn();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_cargo", SqlDbType.Int);
            command.Parameters["@id_cargo"].Value = cargos.Id_cargo;
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

    public int update(cargos cargos)
    {
        int a = 0;
        String query = "UPDATE cargos SET NomCargo = @NomCargo, Salario = @Salario, DescripcionCargo = @DescripcionCargo WHERE id_cargo = @id_cargo";
        conn = new conexion();
        SqlCommand command = conn.getConn().CreateCommand();
        SqlTransaction trans = conn.getConn().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conn.getConn();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_cargo", SqlDbType.Int);
            command.Parameters["@id_cargo"].Value = cargos.Id_cargo;
            command.Parameters.Add("@NomCargo", SqlDbType.VarChar, 50);
            command.Parameters["@NomCargo"].Value = cargos.NomCargo1;
            command.Parameters.Add("@Salario", SqlDbType.Decimal);
            command.Parameters["@Salario"].Value = cargos.Salario1;
            command.Parameters.Add("@DescripcionCargo", SqlDbType.Text);
            command.Parameters["@DescripcionCargo"].Value = cargos.DescripcionCargo1;
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