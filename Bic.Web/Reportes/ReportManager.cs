using System;
using System.Data;

namespace Bic.Web
{
	/// <summary>
	/// Singleton del componente encargado de gestionar el manejo de reportes.
	/// </summary>
	public class ReportManager
	{
		#region	Constructor

		private ReportManager(DataSet reportCache)
		{
			//TODO : Hacer property que meta en sesion la cache.
			this.reportCache = reportCache; 
		}


		#endregion

		#region Private members

		private static ReportManager reportManager;
		private static object syncRoot = new Object();
        private DataSet reportCache;

		#endregion

		#region Public methods

		public static ReportManager GetInstance(DataSet reportCache)
		{
			if (reportManager == null) 
			{
				lock (syncRoot) 
				{
					if (reportManager == null) 
					{
						reportManager = new ReportManager(reportCache);
					}
				}
			}

			return reportManager;
		}


		#endregion
		
	}
}
