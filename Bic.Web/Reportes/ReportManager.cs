using System;
using System.Collections;
using WebChart;
using System.Web.SessionState;
using System.Data;

namespace Bic.Web
{
	/// <summary>
	/// Singleton del componente encargado de gestionar el manejo de reportes.
	/// </summary>
	public class ReportManager
	{
		#region Graph type enum

		public enum GraphTypes
		{
			Bars,
			Pie,
			Lines,
			Area
		}


		#endregion

		#region	Constructor

		private ReportManager(HttpSessionState session)
		{
			this.httpSessionState = session; 
		}


		#endregion

		#region Properties

		public DataSet ReportCache
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


		public GraphTypes GraphType
		{
			get
			{
				this.graphType = (ReportManager.GraphTypes)this.httpSessionState["graphType"];
				return this.graphType;
			}

			set
			{
				this.graphType = value;
				this.httpSessionState["graphType"] = this.graphType;
			}
		}


		public String DataColumn
		{
			get
			{
				this.dataColumn = this.httpSessionState["dataColumn"] as String;
				return this.dataColumn;
			}

			set
			{
				this.dataColumn = value;
				this.httpSessionState["dataColumn"] = this.dataColumn;
			}
		}

		public String DescriptionColumn
		{
			get
			{
				this.descriptionColumn = this.httpSessionState["descriptionColumn"] as String;
				return this.descriptionColumn ;
			}

			set
			{
				this.descriptionColumn = value;
				this.httpSessionState["descriptionColumn"] = this.descriptionColumn;
			}
		}


		public ChartHelper ChartHelper
		{
			get
			{
				switch(this.graphType)
				{
					case ReportManager.GraphTypes.Bars :
							return new BarChartHelper();							

					case ReportManager.GraphTypes.Pie :
							return new PieChartHelper();							

					case ReportManager.GraphTypes.Lines :
							return new LinesChartHelper();	

					case ReportManager.GraphTypes.Area :
						return new AreaChartHelper();	
				}
				
				throw new Exception("Tipo de grafico inexistente");				
			}			
		}


		#endregion

		#region Private members

		private static ReportManager reportManager;
		private static object syncRoot = new Object();
        private DataSet reportCache;
		private HttpSessionState httpSessionState;
		private GraphTypes graphType;
		private String dataColumn;
		private String descriptionColumn;

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


		public Chart GetChart()
		{	
			return this.ChartHelper.GetChart(this.DataColumn , this.DescriptionColumn , this.ReportCache );
		}


		#endregion
		
		//TODO ; agregar excepcion en caso de que se quiera utilizar el cache y esta este en nula.
	}
}
