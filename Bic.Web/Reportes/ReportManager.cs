using System;
using System.Collections;
using WebChart;
using System.Web.SessionState;
using System.Data;
using Bic.Domain;
using Bic.Application;

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


		public Reporte Reporte
		{
			get
			{
				this.reporte = this.httpSessionState["reporte"] as Reporte;
				return reporte;
			}

			set
			{
				this.reporte = value;
				this.httpSessionState["reporte"] = this.reporte;
			}
		}


		public DataSet ReportSourceCache
		{
			get
			{
				if(this.Reporte!=null)
				{					
					//Aca deberia actualizarse solo si cambio el reporte. Preguntarle a fer si existe alguna propeidad de 
					// hibernate que permita determinar esto.
					this.reportSourceCache = BICContext.Instance.ReporteService.Ejecutar(this.Reporte.Id);					
				}
				else
				{
					throw new Exception("Reporte no seteado");
				}

				return this.reportSourceCache;
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
        
		private Reporte reporte;
		private HttpSessionState httpSessionState;

		private String dataColumn;
		private String descriptionColumn;
		private DataSet reportSourceCache;
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
			DataSet ds = this.ReportSourceCache;

			ArrayList columnNames = new ArrayList();

			foreach(DataColumn column in ds.Tables[0].Columns)
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
