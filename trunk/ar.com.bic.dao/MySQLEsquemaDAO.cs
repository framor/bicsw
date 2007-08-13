using System;
using System.Data;
using System.Text;
using ar.com.bic.domain.esquema;
using MySql.Data.MySqlClient;

namespace ar.com.bic.dao
{
	/// <summary>
	/// Este DAO se encarga de leer la información del esquema de la BD
	/// </summary>
	public class MySQLEsquemaDAO
	{

		private static readonly string GET_SCHEMA_SQL = "SELECT table_name, column_name, data_type FROM `information_schema`.`COLUMNS` where TABLE_SCHEMA = ?schema";

		public MySQLEsquemaDAO()
		{
		}

		public Esquema GetEsquema(string server, string database, string user, string password)
		{
			string connStr = String.Format("Server=?;Database=?;Uid=?;Pwd=?", 
				new object[]{server, database, user, password});
			MySqlConnection con = new MySqlConnection(connStr);

			DataRow myRow = null;
			using (con)
			{
				con.Open();

				DataSet ds = new DataSet();

				MySqlCommand cmd = new MySqlCommand(GET_SCHEMA_SQL, con);
				cmd.Parameters.Add("?schema", database);

				MySqlDataAdapter da = new MySqlDataAdapter(cmd);
				da.Fill(ds);

				string nombreTablaAnterior = string.Empty;
				Esquema e = new Esquema();
				Tabla t = null;

				if (ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0)
				{	// FER A. cambie el constructor ahora los parametros son Tabla(string alias, string nombreBD, string nombreTabla)
					t = new Tabla(ds.Tables[0].Rows[0].ItemArray[0].ToString(),database,ds.Tables[0].Rows[0].ItemArray[0].ToString());
					nombreTablaAnterior = t.NombreTabla;
				}

				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					t.NombreTabla = dr.ItemArray[0].ToString();
					if (!t.NombreTabla.Equals(nombreTablaAnterior))
					{
						e.AgregarTabla(t);
						t = new Tabla(t.NombreTabla,database,t.NombreTabla);
					}
					Columna col = new Columna(dr.ItemArray[1].ToString(), dr.ItemArray[2].ToString());
					t.AgregarColumna(col);
					nombreTablaAnterior = t.NombreTabla;
				}
				con.Close();
			}
			return null;
		}
	}
}
