using System;
using System.Text;
using System.Collections;
using WebChart;

namespace Bic.Web
{
	/// <summary>
	/// Clase que tiene la responsabilidad de mantener de manera consistente
	/// el conjunto de graficos seleccionados que se graficaran postariormente,
	/// de acuerdo a su compatibilidad.
	/// </summary>
	public class ChartTypesSelectedManager
	{
		#region Constructor

		public ChartTypesSelectedManager()
		{
			this.selectedCharts = new Hashtable();
		}


		#endregion

		#region Private members

		private Hashtable selectedCharts;

		#endregion

		#region Public methods

		public void Add(ReportManager.GraphTypes graphType, ChartAbstractFactory chartAbstractFactory)
		{
			if(! this.selectedCharts.ContainsKey(graphType.ToString()))
			{
				this.selectedCharts.Add(graphType.ToString(),chartAbstractFactory);
			}
			else
			{
				this.selectedCharts.Remove (graphType.ToString());
			}

			this.UpdateChartCompatibility();
		}


		public ICollection GetSelectedCharts()
		{
			return this.selectedCharts.Values;
		}


		public string GetSelectedChartsStringDescription()
		{
			StringBuilder sb = new StringBuilder();
			
			foreach (Object key in this.selectedCharts.Keys)
			{
				sb.Append (key.ToString() + " - ");
			}

			if(sb.Length != 0)
			{
				sb.Remove(sb.Length-2,1);
			}

			return sb.ToString().Trim();
		}


		public void Clear()
		{
			this.selectedCharts.Clear();
		}

		#endregion

		#region Private methods

		private void UpdateChartCompatibility()
		{
			if(this.selectedCharts[ReportManager.GraphTypes.Pie.ToString()] != null && this.selectedCharts.Keys.Count != 1)
			{
				this.selectedCharts.Remove(ReportManager.GraphTypes.Pie.ToString());
			}

			if(this.selectedCharts[ReportManager.GraphTypes.Bars.ToString()] != null && this.selectedCharts.Keys.Count != 1)
			{
				if(this.selectedCharts[ReportManager.GraphTypes.Columns.ToString()] != null)
				{
					this.selectedCharts.Remove(ReportManager.GraphTypes.Columns.ToString());
				}				

				if(this.selectedCharts[ReportManager.GraphTypes.Pie.ToString()] != null)
				{
					this.selectedCharts.Remove(ReportManager.GraphTypes.Pie.ToString());
				}
			}
		}


		#endregion
	}
}
