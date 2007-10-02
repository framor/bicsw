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


		#endregion

		#region Private methods

		private void UpdateChartCompatibility()
		{
			//Este metodo agregara o quitara algun grafico seleccionado
			// en funcion de la compatibilidad entre ellos
			// por ejemplo, lineas y torta a la vez no se puede
		}


		#endregion
	}
}
