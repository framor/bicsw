using System;
using System.Data;
using System.Web.SessionState;

namespace Bic.Web
{
	/// <summary>
	/// Singleton del componente encargado de gestionar el manejo de reportes.
	/// </summary>
	public class ReportManager
	{
		#region	Constructor

		private ReportManager(HttpSessionState session)
		{
			this.httpSessionState = session; 
		}


		#endregion

		#region Properties

		private DataSet ReportCache
		{
			get
			{
				this.reportCache = this.httpSessionState["reportCache"] as DataSet;
				return this.reportCache;
			}

			set
			{
				this.reportCache = value;
				this.httpSessionState["reportCache"] = this.reportCache;
			}
		}


		#endregion

		#region Private members

		private static ReportManager reportManager;
		private static object syncRoot = new Object();
        private DataSet reportCache;
		private HttpSessionState httpSessionState;

		#endregion

		#region Public methods

		public static ReportManager GetInstance(HttpSessionState session)
		{
			if (reportManager == null) 
			{
				lock (syncRoot) 
				{
					if (reportManager == null) 
					{
						reportManager = new ReportManager(session);
					}
				}
			}

			return reportManager;
		}


		#endregion
		
		//TODO ; agregar excepcion en caso de que se quiera utilizar el cache y esta este en nula.
	}
}
