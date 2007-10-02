using System;
using System.Collections;
using WebChart;
using System.Web.SessionState;
using System.Data;
using Bic.Domain;

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
			Columns,
			Pie,
			Lines,
			Area
		}

		#endregion

		#region Graph Filters
		
		public enum GraphFilters
		{
			Top,
			Bottom,
			All
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

		public string GraphFilter
		{
			get
			{
				this.graphFilter  = this.httpSessionState["graphFilter"] as string;
				return this.graphFilter ;
			}

			set
			{
				this.graphFilter = value;
				this.httpSessionState["graphFilter"] = this.graphFilter;
			}
		}


		public ChartTypesSelectedManager ChartTypesSelectedManager
		{
			get
			{
				if(this.chartTypesSelectedManager == null)
				{
					this.chartTypesSelectedManager = new ChartTypesSelectedManager();
				}

				return this.chartTypesSelectedManager;
			}
		}


		#endregion

		#region Private members

		private static ReportManager reportManager;
		private static object syncRoot = new Object();
        
		private DataSet reportCache;
		private HttpSessionState httpSessionState;

		private String dataColumn;
		private String descriptionColumn;
		private string  graphFilter;
		
		private ChartTypesSelectedManager chartTypesSelectedManager; 

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


		public void AddSelectedChart(ReportManager.GraphTypes graphType)
		{
			this.ChartTypesSelectedManager.Add(graphType, ChartAbstractFactory.GetFactory(graphType));
		}

		public ArrayList GetColumnNames()
		{
			ArrayList columnNames = new ArrayList();

			foreach(DataColumn column in this.ReportCache.Tables[0].Columns)
			{
				columnNames.Add(column.ColumnName);
			}

			return columnNames;
		}			


		private Chart GetEmptyPreviewChart(ChartEngine chartEngine)
		{
			return new UtilsChartFactory().GetPreviewChart(this,chartEngine);
		}


		private Chart GetEmptyChart(ChartEngine chartEngine)
		{
			return new UtilsChartFactory().GetChart(this,chartEngine);
		}


		public ChartCollection GetPreviewCharts(ChartEngine chartEngine)
		{
			ChartCollection chartCollection = new ChartCollection(chartEngine);

			if( this.chartTypesSelectedManager.GetSelectedCharts().Count == 0)
			{
				chartCollection.Add(this.GetEmptyPreviewChart(chartEngine));
			}

			IEnumerator enumerator = this.chartTypesSelectedManager.GetSelectedCharts().GetEnumerator();

			while(enumerator.MoveNext())
			{
				ChartAbstractFactory factory = enumerator.Current as ChartAbstractFactory;
				Chart chart = factory.GetPreviewChart(this,chartEngine);
				chartCollection.Add(chart);
			}
			
			return chartCollection;
		}


		public ChartCollection GetCharts(ChartEngine chartEngine)
		{
			ChartCollection chartCollection = new ChartCollection(chartEngine);

			if( this.chartTypesSelectedManager.GetSelectedCharts().Count == 0)
			{
				chartCollection.Add(this.GetEmptyChart(chartEngine));
			}

			IEnumerator enumerator = this.chartTypesSelectedManager.GetSelectedCharts().GetEnumerator();

			while(enumerator.MoveNext())
			{
				ChartAbstractFactory factory = enumerator.Current as ChartAbstractFactory;
				Chart chart = factory.GetChart(this,chartEngine);
				chartCollection.Add(chart);
			}
			
			return chartCollection;
		}


		#endregion
		
		//TODO ; agregar excepcion en caso de que se quiera utilizar el cache y esta este en nula.
	}
}
