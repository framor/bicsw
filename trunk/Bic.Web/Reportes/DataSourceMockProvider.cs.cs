using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Bic.Web
{
	public class DataSourceMockProvider
	{
		#region	Constructor

		public DataSourceMockProvider()
		{			
		}


		#endregion

		#region Static methods

		public static DataSet GetDataSource()
		{
			MySqlConnection odbcConnection;
			MySqlCommand odbcCommand;
			MySqlDataAdapter odbcDataAdapter;
			DataSet dataSet;

			string connStr = String.Format("Server={0};Database={1};Uid={2};Pwd={3}", 
				new object[]{"localhost", "foodmart", "foodmart", "foodmart"});
			odbcConnection = new MySqlConnection(connStr);
			try
			{
				if (odbcConnection.State == ConnectionState.Closed)
				{
					odbcConnection.Open();
				}

				//TODO : REfactorizar para hacerlo mas flexible y pegarle a otras tablas.
				odbcCommand = new MySqlCommand("Select * from product",odbcConnection);
				odbcCommand.CommandType = CommandType.Text;
			
				odbcDataAdapter = new MySqlDataAdapter(odbcCommand);
 
				dataSet = new DataSet();
				odbcDataAdapter.Fill(dataSet,"account");
				
				odbcCommand.ExecuteNonQuery();

				return dataSet;
				
			}
			catch (Exception Ex)
			{
				throw new Exception("Falló la conexión a la base de datos. Stack trace exception: /n"+Ex.ToString());
			}
			finally
			{
				odbcConnection.Close();
			}
		}


		#endregion
	}
}
