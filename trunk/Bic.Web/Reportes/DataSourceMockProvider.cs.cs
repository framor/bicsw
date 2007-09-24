using System;
using System.Data;
using System.Data.Odbc; 

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
			OdbcConnection odbcConnection;
			OdbcCommand odbcCommand;
			OdbcDataAdapter odbcDataAdapter;
			DataSet dataSet;

			odbcConnection = new OdbcConnection(
				@"Provider = Foodmart;
							Driver={MySQL ODBC 3.51 Driver};
							Server=127.0.0.1;
							Database=foodmart;
							UID=foodmart; 
							PWD=foodmart;");
			try
			{
				if (odbcConnection.State == ConnectionState.Closed)
				{
					odbcConnection.Open();
				}

				//TODO : REfactorizar para hacerlo mas flexible y pegarle a otras tablas.
				odbcCommand = new OdbcCommand("Select * from account",odbcConnection);
				odbcCommand.CommandType = CommandType.Text;
			
				odbcDataAdapter = new OdbcDataAdapter(odbcCommand);
 
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
