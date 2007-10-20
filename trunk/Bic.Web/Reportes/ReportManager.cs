using System;
using System.Collections;
using WebChart;
using System.Web.SessionState;
using System.Data;
using Bic.Domain;
using Bic.Application;
using Bic.Application.DTO;

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

		private ArrayList Colors
		{
			get
			{
				this.colors = this.httpSessionState["colors"] as ArrayList;
				
				if(this.colors == null)
				{
					this.InitializeColorsCollection();
				}
				return this.colors ;
			}

			set
			{
				this.colors = value;
				this.httpSessionState["colors"] = this.colors;
			}
		}


		private int ColorCount
		{
			get
			{
				this.colorCount = (int)this.httpSessionState["colorCount"];
				this.colorCount++;
				this.httpSessionState["colorCount"] = this.colorCount;
				
				if(this.colorCount >= this.Colors.Count)
				{
					this.colorCount = 0;
					this.httpSessionState["colorCount"] = 0;
				}

				return this.colorCount;
			}

			set
			{
				this.colorCount = value;
				this.httpSessionState["colorCount"] = this.colorCount;
			}
		}


		public Hashtable DataSources
		{
			get
			{
				if(this.httpSessionState["dataSources"] == null)
				{
					this.httpSessionState["dataSources"] = new Hashtable();
				}

				this.dataSources = this.httpSessionState["dataSources"] as Hashtable;
				return this.dataSources ;
			}

			set
			{
				this.dataSources = value;
				this.httpSessionState["dataSources"] = this.dataSources;
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


		public ReporteDTO Reporte
		{
			get
			{
				this.reporte = this.httpSessionState["reporte"] as ReporteDTO;
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
					//TODO
					//Aca deberia actualizarse solo si cambio el reporte. Preguntarle a fer si existe alguna propeidad de 
					// hibernate que permita determinar esto.
					this.reportSourceCache = BICContext.Instance.ReporteService.Ejecutar(this.Reporte);					
				}
				else
				{
					throw new Exception("Reporte no seteado");
				}

				return this.reportSourceCache;
			}

			set
			{
				this.reportSourceCache = value;
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
        
		private ReporteDTO reporte;
		private HttpSessionState httpSessionState;
		private DataSet reportSourceCache;
		private string  graphFilter;
		private Hashtable dataSources;
		private ChartTypesSelectedManager chartTypesSelectedManager; 

		private ArrayList colors;
		private int colorCount;

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


		public ChartCollection GetPreviewCharts(ChartEngine chartEngine)
		{
			ChartCollection chartCollection = new ChartCollection(chartEngine);

			IEnumerator enumerator = this.chartTypesSelectedManager.GetSelectedCharts().GetEnumerator();

			while(enumerator.MoveNext())
			{
				ChartAbstractFactory factory = enumerator.Current as ChartAbstractFactory;

				foreach(String key in this.DataSources.Keys)
				{
					DataSourceItem dataSourceItem = this.DataSources[key] as DataSourceItem; 
					Chart chart = factory.GetPreviewChart(this,chartEngine,dataSourceItem);
					chartCollection.Add(chart);
				}				
			}
			
			return chartCollection;
		}


		public ChartCollection GetCharts(ChartEngine chartEngine)
		{
			ChartCollection chartCollection = new ChartCollection(chartEngine);

			IEnumerator enumerator = this.chartTypesSelectedManager.GetSelectedCharts().GetEnumerator();

			while(enumerator.MoveNext())
			{
				ChartAbstractFactory factory = enumerator.Current as ChartAbstractFactory;

				foreach(String key in this.DataSources.Keys)
				{
					DataSourceItem dataSourceItem = this.DataSources[key] as DataSourceItem; 
					Chart chart = factory.GetChart(this,chartEngine,dataSourceItem);
					chartCollection.Add(chart);
				}	
			}
			
			return chartCollection;
		}


		public System.Drawing.Color GetChartColor()
		{
			return (System.Drawing.Color) this.Colors[this.ColorCount];
		}


		public void Clear()
		{
			this.ColorCount = -1;
			this.Reporte = null;
			this.DataSources.Clear();
			this.ReportSourceCache = null;
			this.ChartTypesSelectedManager.Clear();
		}	


		#endregion
		
		#region Private methods

		private void InitializeColorsCollection()
		{
			this.ColorCount = -1;

			this.Colors = new ArrayList();
			this.Colors.Add(System.Drawing.Color.Blue);
			this.Colors.Add(System.Drawing.Color.Brown);
			this.Colors.Add(System.Drawing.Color.Red);
			this.Colors.Add(System.Drawing.Color.Orange);
			this.Colors.Add(System.Drawing.Color.Green);
			this.Colors.Add(System.Drawing.Color.Gray);
			this.Colors.Add(System.Drawing.Color.Gold);
			this.Colors.Add(System.Drawing.Color.Pink);
			this.Colors.Add(System.Drawing.Color.Yellow);
			this.Colors.Add(System.Drawing.Color.Violet);
		}

		#endregion		
	}
}
