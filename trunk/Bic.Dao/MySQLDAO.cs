using System;
using System.Collections;
using System.Data;
using Bic.Domain.Catalogo;
using Bic.Domain.Dao;
using MySql.Data.MySqlClient;

namespace Bic.Dao
{
	/// <summary>
	/// Este DAO se encarga de leer la información del catalogo de la BD
	/// </summary>
	public class MySQLDAO : ICatalogoDAO
	{

		private static readonly string GET_CATALOGO_SQL = "SELECT table_name, table_schema FROM `information_schema`.`TABLES` where table_schema = ?database";
		private static readonly string GET_COLUMNAS_SQL = "SELECT column_name, data_type FROM `information_schema`.`COLUMNS` where table_schema = ?database and table_name= ?tablename";

		public MySQLDAO()
		{
		}

		/// <summary>
		/// Implementacion ICatalogoDAO.GetCatalogo
		/// </summary>
		public Catalogo ObtenerCatalogo(Conexion conexion)
		{
			string connStr = String.Format("Server={0};Database={1};Uid={2};Pwd={3}", 
				new object[]{conexion.Server, conexion.Database, conexion.User, conexion.Password});
			MySqlConnection con = new MySqlConnection(connStr);

			using (con)
			{
				con.Open();

				DataSet ds = new DataSet();

				MySqlCommand cmd = new MySqlCommand(GET_CATALOGO_SQL, con);
				cmd.Parameters.Add("?database", conexion.Database);

				MySqlDataAdapter da = new MySqlDataAdapter(cmd);
				da.Fill(ds);

				Catalogo cat = new Catalogo();
				Tabla t = null;

				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					t = new Tabla(dr.ItemArray[0].ToString(), dr.ItemArray[1].ToString());
					cat.AgregarTabla(t);
				}
				con.Close();
				return cat;
			}
		}

		
		/// <summary>
		/// Implementacion ICatalogoDAO.GetColumnas
		/// </summary>
		public IList ObtenerColumnas(Tabla t)
		{
			Conexion c = t.Proyecto.Conexion;
			string connStr = String.Format("Server={0};Database={1};Uid={2};Pwd={3}", 
				new object[]{c.Server, c.Database, c.User, c.Password});
			MySqlConnection con = new MySqlConnection(connStr);

			using (con)
			{
				con.Open();

				DataSet ds = new DataSet();

				MySqlCommand cmd = new MySqlCommand(GET_COLUMNAS_SQL, con);
				cmd.Parameters.Add("?database", c.Database);
				cmd.Parameters.Add("?tablename", t.Nombre);

				MySqlDataAdapter da = new MySqlDataAdapter(cmd);
				da.Fill(ds);

				IList ret = new ArrayList();
				
				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					Columna col = new Columna(dr.ItemArray[0].ToString(), dr.ItemArray[1].ToString());
					ret.Add(col);
				}
				con.Close();
				return ret;
			}
		}

		/// <summary>
		/// Implementacion ICatalogoDAO.ProbarConexion
		/// </summary>
		public string ProbarConexion(Conexion conexion)
		{
			MySqlConnection con = null;
			try
			{
				string connStr = String.Format("Server={0};Database={1};Uid={2};Pwd={3}", 
					new object[]{conexion.Server, conexion.Database, conexion.User, conexion.Password});
				con =  new MySqlConnection(connStr);

				using (con)
				{
					con.Open();
				}
			} 
			catch (Exception ex)
			{
				return ex.Message;
			}
			finally
			{
				con.Close();
			}
			return "Ok";
		}

		public DataSet EjecutarSql(Conexion c, string sql)
		{
			string connStr = String.Format("Server={0};Database={1};Uid={2};Pwd={3}", 
				new object[]{c.Server, c.Database, c.User, c.Password});
			MySqlConnection con = new MySqlConnection(connStr);

			using (con)
			{
				con.Open();

				DataSet ds = new DataSet();
				MySqlCommand cmd = new MySqlCommand(sql, con);
				MySqlDataAdapter da = new MySqlDataAdapter(cmd);
				da.Fill(ds);
				con.Close();
				return ds;
			}
		}
	}
}
